using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LifxLib.Messages
{
    public class LifxTagLabelMessage : LifxReceivedMessage
    {
        private const UInt16 PACKET_TYPE = 0x1F;

        public LifxTagLabelMessage()
            : base(PACKET_TYPE)
        {

        }

        public UInt64 Tag
        {
            get
            {
                return BitConverter.ToUInt64(base.ReceivedData.Payload, 0);
            }
        }

        public String TagLabel
        {
            get 
            {
                return Encoding.ASCII.GetString(base.ReceivedData.Payload, 8, 32);
            }
        }
    }
}
