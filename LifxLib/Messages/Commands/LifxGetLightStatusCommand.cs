using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LifxLib.Messages
{
    public class LifxGetLightStatusCommand : LifxCommand
    {
        private const UInt16 PACKET_TYPE = 0x65;

        public LifxGetLightStatusCommand()
            : base(PACKET_TYPE, new LifxLightStatusMessage())
        {

        }

      
    }
}
