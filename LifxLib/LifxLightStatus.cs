using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace LifxLib
{
    public class LifxLightStatus
    {
        LifxColor mColor;
        LifxPowerState mPowerState;
        UInt16 mDimState;
        String mLabel;
        UInt64 mTags;
       
        public LifxLightStatus(LifxColor color, LifxPowerState powerState, UInt16 dimState, String label, UInt64 tags)
        {
            mColor = color;
            mPowerState = powerState;
            mDimState = dimState;
            mDimState = dimState;
            mTags = tags;
        }

        public LifxColor Color
        {
            get { return mColor; }
            set { mColor = value; }
        }
        public LifxPowerState PowerState
        {
            get { return mPowerState; }
            set { mPowerState = value; }
        }
        public UInt16 DimState
        {
            get { return mDimState; }
            set { mDimState = value; }
        }
        public String Label
        {
            get { return mLabel; }
            set { mLabel = value; }
        }
        public UInt64 Tags
        {
            get { return mTags; }
            set { mTags = value; }
        }
    }

   
}




