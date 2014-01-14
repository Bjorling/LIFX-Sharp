using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LifxLib.Messages
{
    public class LifxSetTagsCommand : LifxCommand
    {
        private const UInt16 PACKET_TYPE = 0x1E;
        private UInt64 mTagsValue = 0;


        public LifxSetTagsCommand(UInt64 tagsValue)
            : base(PACKET_TYPE, new LifxTagsMessage())
        {
            mTagsValue = tagsValue;
        }

        public override byte[] GetRawMessage()
        {
            return BitConverter.GetBytes(mTagsValue);
        }


        public UInt64 TagsValue
        {
            get { return mTagsValue; }
            set { mTagsValue = value; }
        }
    }
}
