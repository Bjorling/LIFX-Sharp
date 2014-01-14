using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LifxLib.Messages;

namespace LifxLib
{
    public class LifxDataPacket
    {
        private byte[] mPacketData;
        private const UInt16 STANDARD_PROTOCOL = 13312;

        public LifxDataPacket(byte[] packetData)
        {
            mPacketData = packetData;
        }

        public LifxDataPacket(LifxCommand messageToPackage)
        {
            mPacketData = new byte[messageToPackage.GetRawMessage().Length + 36];
            Size = (ushort)(messageToPackage.GetRawMessage().Length + 36);
            Protocol = STANDARD_PROTOCOL;

            PacketType = messageToPackage.PacketType;
            Payload = messageToPackage.GetRawMessage();
        }

        public byte[] PacketData
        {
            get { return mPacketData; }
        }

        public UInt16 Size
        {
            get
            { 
                return BitConverter.ToUInt16(mPacketData, 0); 
            }
            set
            {
                byte[] bytes = BitConverter.GetBytes(value);

                Array.Copy(bytes, 0, mPacketData, 0, bytes.Length);
            }
        }

        public UInt16 Protocol
        {
            get
            {
                return BitConverter.ToUInt16(mPacketData, 2);
            }
            set
            {
                byte[] bytes = BitConverter.GetBytes(value);

                Array.Copy(bytes, 0, mPacketData, 2, bytes.Length);
            }
        }

        public UInt32 Reserved1
        {
            get
            {
                return BitConverter.ToUInt32(mPacketData, 4);
            }
            set
            {
                byte[] bytes = BitConverter.GetBytes(value);

                Array.Copy(bytes, 0, mPacketData, 4, bytes.Length);
            }
        }

        public byte[] TargetMac
        {
            get
            {
                byte[] bytes = new byte[6];

                Array.Copy(mPacketData, 8, bytes, 0, 6);

                return bytes;
            }
            set
            {
                Array.Copy(value, 0, mPacketData, 8, value.Length);
            }
        }

        public UInt16 Reserved2
        {
            get
            {
                return BitConverter.ToUInt16(mPacketData, 14);
            }
            set
            {
                byte[] bytes = BitConverter.GetBytes(value);

                Array.Copy(bytes, 0, mPacketData, 14, bytes.Length);
            }
        }

        public byte[] PanControllerMac
        {
            get
            {
                byte[] bytes = new byte[6];

                Array.Copy(mPacketData, 16, bytes, 0, 6);

                return bytes;
            }
            set
            {
                Array.Copy(value, 0, mPacketData, 16, value.Length);
            }
        }

        public UInt16 Reserved3
        {
            get
            {
                return BitConverter.ToUInt16(mPacketData, 22);
            }
            set
            {
                byte[] bytes = BitConverter.GetBytes(value);

                Array.Copy(bytes, 0, mPacketData, 22, bytes.Length);
            }
        }

        public UInt64 TimestampRaw
        {
            get
            {
                return BitConverter.ToUInt64(mPacketData, 24);
            }
            set
            {
                byte[] bytes = BitConverter.GetBytes(value);

                Array.Copy(bytes, 0, mPacketData, 24, bytes.Length);
            }
        }

        public DateTime PacketTimestamp
        {
            get
            {
                return new DateTime(1970,01,01).AddMilliseconds(TimestampRaw/1000);
            }
            set
            {
                TimestampRaw = (UInt64) (value - new DateTime(1970, 01, 01)).TotalMilliseconds * 10;
            }
        }

        public UInt16 PacketType
        {
            get
            {
                return BitConverter.ToUInt16(mPacketData, 32);
            }
            set
            {
                byte[] bytes = BitConverter.GetBytes(value);

                Array.Copy(bytes, 0, mPacketData, 32, bytes.Length);
            }
        }

        public UInt16 Reserved4
        {
            get
            {
                return BitConverter.ToUInt16(mPacketData, 34);
            }
            set
            {
                byte[] bytes = BitConverter.GetBytes(value);

                Array.Copy(bytes, 0, mPacketData, 34, bytes.Length);
            }
        }

        public byte[] Payload
        {
            get
            {
                byte[] bytes = new byte[mPacketData.Length - 36];

                Array.Copy(mPacketData, 36, bytes, 0, mPacketData.Length - 36);

                return bytes;
            }
            set
            {
                if (value.Length != mPacketData.Length - 36)
                    throw new ArgumentException("Length of byte array (" + value.Length + ") must match lenght of sized message (" + (mPacketData.Length - 36) + ")");

                Array.Copy(value, 0, mPacketData, 36, value.Length);
            }
        }

    }
}
