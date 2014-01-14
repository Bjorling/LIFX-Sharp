using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LifxLib.Messages
{
    public class LifxPowerStateMessage : LifxReceivedMessage
    {
        private const UInt16 PACKET_TYPE = 0x16;

        public LifxPowerStateMessage()
            : base(PACKET_TYPE)
        {

        }

        public LifxPowerState PowerState
        {
            get 
            {
                if (BitConverter.ToUInt16(ReceivedData.Payload, 0) == 0)
                    return LifxPowerState.Off;
                if (BitConverter.ToUInt16(ReceivedData.Payload, 0) == UInt16.MaxValue)
                    return LifxPowerState.On;
                else
                    return LifxPowerState.Unknown;
            }
        }
    }
}
