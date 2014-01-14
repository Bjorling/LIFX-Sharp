using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LifxLib.Messages
{
    public class LifxLabelMessage : LifxReceivedMessage
    {
        private const UInt16 PACKET_TYPE = 0x19;

        public LifxLabelMessage()
            : base(PACKET_TYPE)
        {

        }

        public String BulbLabel
        {
            get 
            {
                return Encoding.ASCII.GetString(base.ReceivedData.Payload);
            }
        }
    }
}
