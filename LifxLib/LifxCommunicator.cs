using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using LifxLib.Messages;



namespace LifxLib
{
    public class LifxCommunicator : IDisposable
    {
        private class UdpState
        {
            public UdpClient udpClient;
            public IPEndPoint endPoint;
        }
        private class IncomingMessage
        { 
            public LifxDataPacket Data;
            public IPEndPoint BulbAddress;

            public IncomingMessage(LifxDataPacket data, IPEndPoint address)
            {
                Data = data;
                BulbAddress = address;
            }
        }

        private Queue<IncomingMessage> mIncomingQueue = new Queue<IncomingMessage>(10);
        private const Int32 LIFX_PORT = 56700;
        private int mTimeoutMilliseconds = 700;
        private UdpClient mSendCommandClient;
        private UdpClient mListnerClient;
        private bool mIsInitialized = false;
        private bool mIsDisposed = false;
        private static LifxCommunicator mInstance  = new LifxCommunicator();

        public static LifxCommunicator Instance
        {
            get
            {
                return mInstance;
            }
        }
        public int TimeoutMilliseconds
        {
            get { return mTimeoutMilliseconds; }
            set { mTimeoutMilliseconds = value; }
        }

        private LifxCommunicator()
        {

            
        }

        /// <summary>
        /// Initializes the listner for bulb messages
        /// </summary>
        public void Initialize()
        {
            IPEndPoint end = new IPEndPoint(IPAddress.Any, 56700);
            mListnerClient = new UdpClient(end);
            mListnerClient.Client.Blocking = false;
            UdpState udpState = new UdpState();
            udpState.endPoint = end;
            udpState.udpClient = mListnerClient;
            mListnerClient.Client.SetSocketOption(
                SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);

            mListnerClient.BeginReceive(new AsyncCallback(ReceiveCallback), udpState);
            mIsInitialized = true;
        }

        private void ReceiveCallback(IAsyncResult ar)
        {
            if (mIsDisposed)
                return;

            UdpClient client = (UdpClient)((UdpState)(ar.AsyncState)).udpClient;
            IPEndPoint endPoint = (IPEndPoint)((UdpState)(ar.AsyncState)).endPoint;            

            Byte[] receiveBytes = client.EndReceive(ar, ref endPoint);
            string receiveString = LifxHelper.ByteArrayToString(receiveBytes);

            LifxDataPacket package = new LifxDataPacket(receiveBytes);

            mIncomingQueue.Enqueue(new IncomingMessage(package, endPoint));

            client.BeginReceive(new AsyncCallback(ReceiveCallback), (UdpState)(ar.AsyncState));
            
        }

        /// <summary>
        /// Discovers the bulbs currently available. NOTE: WILL ONLY FIND ONE BULB IN THIS IMPLEMENTATION.
        /// </summary>
        /// <returns>List of bulbs</returns>
        public List<LifxBulb> DiscoverBulbs()
        {
            LifxGetPANGatewayCommand getPANCommand = new LifxGetPANGatewayCommand();

           LifxBulb bulb = LifxBulb.UninitializedBulb;


           try
           {
               SendCommand(getPANCommand, bulb);

               List<LifxBulb> foundBulbs = new List<LifxBulb>();
               foundBulbs.Add(bulb);
               return foundBulbs;
           }
           catch (TimeoutException)
           {
               //Could not find any bulb, just return empty array...
               return new List<LifxBulb>();

           }
           catch (Exception e)
           {
               //In case of any other exception, re-throw
               throw e;
           }
            
            
        }


        /// <summary>
        /// Sends command to a bulb
        /// </summary>
        /// <param name="command"></param>
        /// <param name="bulb">The bulb to send the command to.</param>
        /// <returns>Returns the response message. If the command does not trigger a response it will reurn null. </returns>
        public LifxReceivedMessage SendCommand(LifxCommand command, LifxBulb bulb)
        {
            if (!IsInitialized)
                throw new InvalidOperationException("The communicator needs to be initialized before sening a command.");


            UdpClient client = GetConnectedClient(command, bulb);


            LifxDataPacket packet = new LifxDataPacket(command);
            packet.TargetMac = LifxHelper.StringToByteArray(bulb.MacAddress);
            packet.PanControllerMac = LifxHelper.StringToByteArray(bulb.PanHandler);

            client.Send(packet.PacketData, packet.PacketData.Length);

            DateTime commandSentTime = DateTime.Now;

            if (command.ReturnMessage == null)
                return null;

            while ((DateTime.Now - commandSentTime).TotalMilliseconds < mTimeoutMilliseconds)
            {
                if (mIncomingQueue.Count != 0)
                {
                    IncomingMessage mess = mIncomingQueue.Dequeue();
                    LifxDataPacket recievedPacket = mess.Data;


                    if (recievedPacket.PacketType == command.ReturnMessage.PacketType)
                    {
                        bulb.IpEndpoint = mess.BulbAddress;
                        bulb.MacAddress = LifxHelper.ByteArrayToString(recievedPacket.TargetMac);
                        bulb.PanHandler = LifxHelper.ByteArrayToString(recievedPacket.PanControllerMac);

                        command.ReturnMessage.ReceivedData = recievedPacket;
                        mIncomingQueue.Clear();
                        return command.ReturnMessage;
                    }
                }
                Thread.Sleep(10);
            }

            if (command.RetryCount > 0)
            {
                command.RetryCount -= 1;

                //Recurssion
                return SendCommand(command, bulb);
            }
            else
                throw new TimeoutException("Did not get a reply from bulb in a timely fashion");

        }


 
        private UdpClient GetConnectedClient(LifxCommand command, LifxBulb bulb)
        {
            if (mSendCommandClient == null)
            {
                return CreateClient(command, bulb);
            }
            else
            { 
                if (command.IsBroadcastCommand)
                {
                    if (mSendCommandClient.Client.EnableBroadcast)
                    {
                        return mSendCommandClient;
                    }
                    else
                    {
                        mSendCommandClient.Close();
                        return CreateClient(command,bulb);
                    }
                }
                else
                {
                    if (mSendCommandClient.Client.EnableBroadcast)
                    {
                        mSendCommandClient.Close();
                        return CreateClient(command, bulb); 
                        
                    }
                    else
                    {
                        return mSendCommandClient;
                    }
                }
            }
        }
        private UdpClient CreateClient(LifxCommand command, LifxBulb bulb)
        {
            if (command.IsBroadcastCommand)
            {
                mSendCommandClient = new UdpClient();

                mSendCommandClient.EnableBroadcast = true;
                mSendCommandClient.Client.SetSocketOption(
                SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);

                mSendCommandClient.Connect(new IPEndPoint(IPAddress.Broadcast, LIFX_PORT));
                return mSendCommandClient;
            }
            else
            {
                mSendCommandClient = new UdpClient();

                mSendCommandClient.Client.SetSocketOption(
                SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);

                mSendCommandClient.Connect(new IPEndPoint(bulb.IpEndpoint.Address, LIFX_PORT));
                return mSendCommandClient;

            }
        }

        public bool IsInitialized
        {
            get { return mIsInitialized; }
            set { mIsInitialized = value; }
        }

        public void CloseConnections()
        {
            mListnerClient.Close();
            mSendCommandClient.Close();
        }

        #region IDisposable Members

        public void Dispose()
        {
            mIsDisposed = true;
            CloseConnections();
        }

        #endregion
    }
}
