using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LifxLib.Messages
{
    public class LifxSetLabelCommand : LifxCommand
    {
        private const UInt16 PACKET_TYPE = 0x18;
        private string mLabelName = "";

       
        public LifxSetLabelCommand(string newLabelName)
            : base(PACKET_TYPE, new LifxLabelMessage())
        {
            mLabelName = newLabelName;    
        }

        public override byte[] GetRawMessage()
        {
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(mLabelName);

            byte[] payload = new byte[32];

            

            Array.Copy(bytes, payload, Math.Min(payload.Length,bytes.Length));

            return payload;
        }


        public string LabelName
        {
            get { return mLabelName; }
            set { mLabelName = value; }
        }
    }
}
