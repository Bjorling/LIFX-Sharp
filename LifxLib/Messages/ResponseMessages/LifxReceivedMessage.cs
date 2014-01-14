using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LifxLib.Messages
{
    public abstract class LifxReceivedMessage
    {
        private LifxDataPacket mData;
        private UInt16 mPacketType = 0;
        

        public LifxReceivedMessage(LifxDataPacket data, UInt16 packetType)
        {
            mData = data;
            mPacketType = packetType;
        }

        public LifxReceivedMessage(UInt16 packetType)
        {
            mPacketType = packetType;
        }

        public LifxDataPacket ReceivedData
        {
            get { return mData; }
            set { mData = value; }
        }

        public UInt16 PacketType
        {
            get { return mPacketType; }
        }

    }
}
