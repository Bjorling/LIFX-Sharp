using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LifxLib.Messages
{
    public class LifxGetLabelCommand : LifxCommand
    {
        private const UInt16 PACKET_TYPE = 0x17;

        public LifxGetLabelCommand()
            : base(PACKET_TYPE, new LifxLabelMessage())
        {
            
        }

    }
}
