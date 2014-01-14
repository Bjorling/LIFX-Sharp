using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LifxLib.Messages
{
    public class LifxSetPowerStateCommand : LifxCommand
    {
        private LifxPowerState mStateToSet = LifxPowerState.Unknown;
        private const UInt16 PACKET_TYPE = 0x15;

        public LifxSetPowerStateCommand(LifxPowerState stateToSet)
            : base(PACKET_TYPE, new LifxPowerStateMessage())
        {
            mStateToSet = stateToSet;
        }

        #region ILifxMessage Members

        public override byte[] GetRawMessage()
        {
            if (mStateToSet == LifxPowerState.Unknown)
            {
                throw new ArgumentException("Invalid Powerstate: " + mStateToSet.ToString());
            }
            byte[] bytes = BitConverter.GetBytes((UInt16)mStateToSet);
            return bytes;
        }

        #endregion
    }
}
