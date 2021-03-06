﻿using System;

namespace DQ11
{
	class CharStatus
    {
		private readonly uint mAddress;
		private readonly uint mBit;
		public CharStatus(uint address, uint bit)
		{
			mAddress = address;
			mBit = bit;
		}
		public String Name { get; set; }

		public bool Value
		{
			get
			{
				return SaveData.Instance().ReadBit(mAddress, mBit);
			}

			set
			{
				SaveData.Instance().WriteBit(mAddress, mBit, value);
			}
		}
    }
}
