using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LifxLib.Messages
{
    public class LifxGetPowerStateCommand : LifxCommand
    {
        private const UInt16 PACKET_TYPE = 0x14;

        public LifxGetPowerStateCommand()
            : base(PACKET_TYPE, new LifxPowerStateMessage())
        {

        }

      
    }
}
