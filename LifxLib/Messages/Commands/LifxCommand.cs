using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LifxLib.Messages;

namespace LifxLib.Messages
{
    /// <summary>
    /// Message sent to/from bulb, this is abstract class, inherited by the message implmentations
    /// </summary>
    public abstract class LifxCommand
    {
        private UInt16 mPacketType = 0;
        private LifxReceivedMessage mReturnMessage;
        private Int32 mTimeoutMs = 0;
        private DateTime mTimestamp = DateTime.MinValue;
        private Boolean mIsBroadcastCommand = false;
        private UInt16 mRetryCount = 3;
        private Boolean mIsDiscoveryCommand = false;
        
        


        public LifxCommand(UInt16 packetType)
        {
            mPacketType = packetType;
        }

        public LifxCommand(UInt16 packetType, LifxReceivedMessage awaitedReturnMessage)
        {
            mPacketType = packetType;
            mReturnMessage = awaitedReturnMessage;
        }

        public virtual byte[] GetRawMessage()
        { 
            return new byte[0];
        }

        public ushort PacketType
        {
            get {  return mPacketType; }
        }

        public LifxReceivedMessage ReturnMessage
        {
            get{ return mReturnMessage;}
        }

        public Int32 Timeout
        {
            get{ return mTimeoutMs;}
            set{ mTimeoutMs = value;}
        }

        public DateTime TimeStamp
        {
            get { return mTimestamp; }
            set { mTimestamp = value; }
        }

        public Boolean IsBroadcastCommand
        {
            get { return mIsBroadcastCommand; }
            set { mIsBroadcastCommand = value; }
        }

        public UInt16 RetryCount
        {
            get { return mRetryCount; }
            set { mRetryCount = value; }
        }

        public Boolean IsDiscoveryCommand
        {
            get { return mIsDiscoveryCommand; }
            set { mIsDiscoveryCommand = value; }
        }

    }
}
