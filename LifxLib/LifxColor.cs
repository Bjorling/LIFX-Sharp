using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace LifxLib
{
    public class LifxColor
    {
        private UInt16 mHue = 0;
        private UInt16 mSaturation = 0;
        private UInt16 mLumnosity = 0;
        private UInt16 mKelvin = 0;


        public LifxColor(UInt16 hue, UInt16 saturation, UInt16 lumnosity, UInt16 kelvin)
        {
            mHue = hue;
            mSaturation = saturation;
            mLumnosity = lumnosity;
            mKelvin = kelvin;
        }

        public LifxColor(Color color, UInt16 kelvinValue)
        {
            DotNetColor = color;
            mKelvin = kelvinValue;
        }

        public HSLColor HSLColor
        {
            get
            {
                return new HSLColor((double)(mHue * 240 / 65535), (double)(mSaturation * 240 / 65535), (double)(mLumnosity * 240 / 65535));
            }
            set
            {
                mHue = (ushort)(value.Hue * 65535 / 240);
                mSaturation = (ushort)(value.Saturation * 65535 / 240);
                mLumnosity = (ushort)(value.Luminosity * 65535 / 240);
            }
        }

        public Color DotNetColor
        {
            get 
            {
                return (Color)HSLColor;
            }
            set
            {
                HSLColor = (HSLColor)value;
            }
        
        }

        public UInt16 Hue
        {
            get { return mHue; }
            set { mHue = value; }
        }
        public UInt16 Saturation
        {
            get { return mSaturation; }
            set { mSaturation = value; }
        }
        public UInt16 Lumnosity
        {
            get { return mLumnosity; }
            set { mLumnosity = value; }
        }
        public UInt16 Kelvin
        {
            get { return mKelvin; }
            set { mKelvin = value; }
        }

    }

   
}




