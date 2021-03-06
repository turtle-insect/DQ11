﻿using System;
using System.Collections.Generic;

namespace DQ11
{
	class Util
	{
		public static readonly uint CharCount = 31;
		public static readonly uint CharDateSize = 0x200;
		public static readonly uint PartyStartAddress = 0x3E04;
		public static readonly uint YochiStartAddress = 0x9DE4;
		public static readonly uint MonsterStartAddress = 0x78E4;
		public static readonly uint YochiDateSize = 0x8C;
		public static readonly uint YochiCount = 50;
		public static readonly uint YochiHatCount = 118;
		public static readonly uint HatStartAddress = 0xC66C;
		public static readonly uint HatObtainStartAddress = 0x6754;
		public static readonly uint TitleObtainStartAddress = 0x6764;
		public static readonly uint BagToolStartAddress = 0x3E34;
		public static readonly uint BagToolCount = 168;
		public static readonly uint BagEquipmentStartAddress = 0x40EC;
		public static readonly uint BagEquipmentCount = 2340;

		public static List<String> GetPartyNames()
		{
			List<String> result = new List<string>();
			SaveData data = SaveData.Instance();
			for (uint i = 0; i < CharCount; i++)
			{
				String name = data.ReadUnicode(i * CharDateSize + 2, 12);
				result.Add(name);
			}
			return result;
		}

		public static List<String> GetYochiNames()
		{
			List<String> result = new List<string>();
			SaveData data = SaveData.Instance();
			for (uint i = 0; i < YochiCount; i++)
			{
				String name = data.ReadUnicode(i * YochiDateSize + YochiStartAddress, 12);
				if (String.IsNullOrEmpty(name)) break;
				result.Add(name);
			}
			return result;
		}

		public static void WriteNumber(uint address, uint size, uint value, uint min, uint max)
		{
			if (value < min) value = min;
			if (value > max) value = max;
			SaveData.Instance().WriteNumber(address, size, value);
		}
	}
}
