using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LifxLib.Messages
{
    public class LifxSetDimAbsoluteCommand : LifxCommand
    {
        private UInt16 mDimLevel;
        private UInt32 mDurationMilliseconds;
        private const UInt16 PACKET_TYPE = 0x68;

        public LifxSetDimAbsoluteCommand(UInt16 dimLevel, UInt32 durationMilliseconds)
            : base(PACKET_TYPE, null)
        {
            mDimLevel = dimLevel;
            mDurationMilliseconds = durationMilliseconds;
        }

        #region ILifxMessage Members

        public override byte[] GetRawMessage()
        {
            byte[] bytes = new byte[6];

            Array.Copy(BitConverter.GetBytes(mDimLevel), bytes, 2);
            Array.Copy(BitConverter.GetBytes(mDurationMilliseconds), 0, bytes, 2, 4);

            return bytes;
        }

        #endregion
    }
}
