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

        private List<LifxPanController> mFoundPanHandlers = new List<LifxPanController>();

        private const Int32 LIFX_PORT = 56700;
        private int mTimeoutMilliseconds = 1000;
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
        /// Discovers the PanControllers (including their bulbs)
        /// </summary>
        /// <returns>List of bulbs</returns>
        public List<LifxPanController> Discover()
        {
            LifxGetPANGatewayCommand getPANCommand = new LifxGetPANGatewayCommand();

           mFoundPanHandlers.Clear();
           mTimeoutMilliseconds = 1500;
           int savedTimeout = mTimeoutMilliseconds;

           try
           {

               SendCommand(getPANCommand, LifxPanController.UninitializedPanController);

               foreach (LifxPanController controller in mFoundPanHandlers)
               {
                   LifxGetLightStatusCommand getBulbs = new LifxGetLightStatusCommand();
                   getBulbs.IsDiscoveryCommand = true;

                   SendCommand(getBulbs, controller);
               
               }

               return mFoundPanHandlers;
           }
           catch (Exception e)
           {
               //In case of any other exception, re-throw
               throw e;
           }
           finally 
           {
               mTimeoutMilliseconds = savedTimeout;
           }
            
            
        }
        public LifxReceivedMessage SendCommand(LifxCommand command, LifxBulb bulb)
        {
            return SendCommand(command, bulb.MacAddress, bulb.PanHandler, bulb.IpEndpoint);
        }

        public LifxReceivedMessage SendCommand(LifxCommand command, LifxPanController panController)
        {
            return SendCommand(command, "", panController.MacAddress, panController.IpEndpoint);
        }

        /// <summary>
        /// Sends command to a bulb
        /// </summary>
        /// <param name="command"></param>
        /// <param name="bulb">The bulb to send the command to.</param>
        /// <returns>Returns the response message. If the command does not trigger a response it will reurn null. </returns>
        public LifxReceivedMessage SendCommand(LifxCommand command, string macAddress, string panController, IPEndPoint endPoint)
        {
            if (!IsInitialized)
                throw new InvalidOperationException("The communicator needs to be initialized before sending a command.");


            UdpClient client = GetConnectedClient(command, endPoint);


            LifxDataPacket packet = new LifxDataPacket(command);
            packet.TargetMac = LifxHelper.StringToByteArray(macAddress);
            packet.PanControllerMac = LifxHelper.StringToByteArray(panController);

            client.Send(packet.PacketData, packet.PacketData.Length);

            DateTime commandSentTime = DateTime.Now;

            if (command.ReturnMessage == null)
                return null;

            while ((DateTime.Now - commandSentTime).TotalMilliseconds < mTimeoutMilliseconds)
            {
                if (mIncomingQueue.Count != 0)
                {
                    IncomingMessage mess = mIncomingQueue.Dequeue();
                    LifxDataPacket receivedPacket = mess.Data;


                    if (receivedPacket.PacketType == LifxPANGatewayStateMessage.PACKET_TYPE) 
                    { 
                        //Panhandler identified
                        LifxPANGatewayStateMessage panGateway = new LifxPANGatewayStateMessage();
                        panGateway.ReceivedData = receivedPacket;

                        AddDiscoveredPanHandler(new LifxPanController(
                               LifxHelper.ByteArrayToString(receivedPacket.TargetMac),
                               mess.BulbAddress));

                    }
                    else if (receivedPacket.PacketType == LifxLightStatusMessage.PACKET_TYPE && command.IsDiscoveryCommand)
                    {
                        //Panhandler identified
                        LifxLightStatusMessage panGateway = new LifxLightStatusMessage();
                        panGateway.ReceivedData = receivedPacket;

                        AddDiscoveredBulb(
                            LifxHelper.ByteArrayToString(receivedPacket.TargetMac),   
                            LifxHelper.ByteArrayToString(receivedPacket.PanControllerMac));
                    }
                    else if (receivedPacket.PacketType == command.ReturnMessage.PacketType)
                    {
                       
                        command.ReturnMessage.ReceivedData = receivedPacket;
                        mIncomingQueue.Clear();
                        return command.ReturnMessage;
                    }
                }
                Thread.Sleep(30);
            }

            if (command.IsDiscoveryCommand)
                return null;

            if (command.RetryCount > 0)
            {
                command.RetryCount -= 1;

                //Recurssion
                return SendCommand(command, macAddress, panController, endPoint);
            }
            else
                throw new TimeoutException("Did not get a reply from bulb in a timely fashion");

        }


        private void AddDiscoveredPanHandler(LifxPanController foundPanHandler)
        {
            foreach (LifxPanController handler in mFoundPanHandlers)
            {
                if (handler.MacAddress == foundPanHandler.MacAddress)
                    return;//already added
            }

            mFoundPanHandlers.Add(foundPanHandler);
        }

        private void AddDiscoveredBulb(string macAddress, string panController)
        {
            foreach (LifxPanController controller in mFoundPanHandlers)
            {
                if (controller.MacAddress == panController)
                {
                    foreach (LifxBulb bulb in controller.Bulbs)
                    {
                        if (bulb.MacAddress == macAddress)
                            return;
                    }

                    controller.Bulbs.Add(new LifxBulb(controller, macAddress));
                    return;
                }
            }

            throw new InvalidOperationException("Should not end up here basically.");
        }


        private UdpClient GetConnectedClient(LifxCommand command, IPEndPoint endPoint)
        {
            if (mSendCommandClient == null)
            {
                return CreateClient(command, endPoint);
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
                        return CreateClient(command, endPoint);
                    }
                }
                else
                {
                    if (mSendCommandClient.Client.EnableBroadcast)
                    {
                        mSendCommandClient.Close();
                        return CreateClient(command, endPoint); 
                        
                    }
                    else
                    {
                        return mSendCommandClient;
                    }
                }
            }
        }
        private UdpClient CreateClient(LifxCommand command, IPEndPoint endPoint)
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

                mSendCommandClient.Connect(endPoint);
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
