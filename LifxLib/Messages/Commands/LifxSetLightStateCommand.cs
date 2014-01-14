using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LifxLib.Messages
{
    public class LifxSetLightStateCommand : LifxCommand
    {
        private UInt16 mHue = 0;
        private UInt16 mSaturation = 0;
        private UInt16 mBrightness = 0;
        private UInt16 mKelvin = 0;
        private UInt32 mFadeTimeMilliseconds = 0;

        private const UInt16 PACKET_TYPE = 0x66;

        public LifxSetLightStateCommand(UInt16 hue, UInt16 saturation, UInt16 brightness, UInt16 kelvin, UInt32 fadeTimeMilliseconds)
            : base(PACKET_TYPE, null)
        {
            mHue = hue;
            mSaturation = saturation;
            mBrightness = brightness;
            mKelvin = kelvin;
            mFadeTimeMilliseconds = fadeTimeMilliseconds;
        }

        #region ILifxMessage Members

        public override byte[] GetRawMessage()
        {
            byte[] bytesToReturn = new byte[13];

            Array.Copy(BitConverter.GetBytes(mHue), 0, bytesToReturn, 1, 2);
            Array.Copy(BitConverter.GetBytes(mSaturation), 0, bytesToReturn, 3, 2);
            Array.Copy(BitConverter.GetBytes(mBrightness), 0, bytesToReturn, 5, 2);
            Array.Copy(BitConverter.GetBytes(mKelvin), 0, bytesToReturn, 7, 2);
            Array.Copy(BitConverter.GetBytes(mFadeTimeMilliseconds), 0, bytesToReturn, 9, 4);

            return bytesToReturn;
        }

        #endregion
    }
}
