﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Charlotte.Tools
{
	public class JString
	{
		public static bool isJString(string str, bool okJpn, bool okRet, bool okTab, bool okSpc)
		{
			return toJString(str, okJpn, okRet, okTab, okSpc) == str;
		}

		public static string toJString(string str, bool okJpn, bool okRet, bool okTab, bool okSpc)
		{
			if (str == null)
				str = "";

			byte[] src = StringTools.ENCODING_SJIS.GetBytes(str);

			return toJString(src, okJpn, okRet, okTab, okSpc);
		}

		public static string toJString(byte[] src, bool okJpn, bool okRet, bool okTab, bool okSpc)
		{
			if (src == null)
				src = new byte[0];

			List<byte> dest = new List<byte>();

			for (int index = 0; index < src.Length; index++)
			{
				byte chr = src[index];

				if (chr == 0x09) // ? '\t'
				{
					if (okTab == false)
						continue;
				}
				else if (chr == 0x0a) // ? '\n'
				{
					if (okRet == false)
						continue;
				}
				else if (chr < 0x20) // ? other control code
				{
					continue;
				}
				else if (chr == 0x20) // ? ' '
				{
					if (okSpc == false)
						continue;
				}
				else if (chr <= 0x7e) // ? ascii
				{
					// noop
				}
				else if (0xa1 <= chr && chr <= 0xdf) // ? kana
				{
					if (okJpn == false)
						continue;
				}
				else // ? 全角文字の前半 || 破損
				{
					if (okJpn == false)
						continue;

					index++;

					if (src.Length <= index) // ? 後半欠損
						break;

					if (JChar.i.contains(chr, src[index]) == false) // ? 破損
						continue;

					dest.Add(chr);
					chr = src[index];
				}
				dest.Add(chr);
			}
			return StringTools.ENCODING_SJIS.GetString(dest.ToArray());
		}

		public class JChar
		{
			private static JChar _i = null;

			public static JChar i
			{
				get
				{
					if (_i == null)
						_i = new JChar();

					return _i;
				}
			}

			private HashSet<UInt16> _chrs = new HashSet<ushort>();

			private JChar()
			{
				this.add();
			}

			public bool contains(byte lead, byte trail)
			{
				UInt16 chr = lead;

				chr <<= 8;
				chr |= trail;

				return contains(chr);
			}

			public bool contains(UInt16 chr)
			{
				return _chrs.Contains(chr);
			}

			private void add(UInt16 chr)
			{
				_chrs.Add(chr);
			}

			private void add(UInt16 bgn, UInt16 end)
			{
				for (UInt16 chr = bgn; chr <= end; chr++)
				{
					this.add(chr);
				}
			}

			/// <summary>
			/// generated by C:\Factory\Labo\GenData\IsJChar.c
			/// </summary>
			private void add()
			{
				this.add(0x8140, 0x817e);
				this.add(0x8180, 0x81ac);
				this.add(0x81b8, 0x81bf);
				this.add(0x81c8, 0x81ce);
				this.add(0x81da, 0x81e8);
				this.add(0x81f0, 0x81f7);
				this.add(0x81fc, 0x81fc);
				this.add(0x824f, 0x8258);
				this.add(0x8260, 0x8279);
				this.add(0x8281, 0x829a);
				this.add(0x829f, 0x82f1);
				this.add(0x8340, 0x837e);
				this.add(0x8380, 0x8396);
				this.add(0x839f, 0x83b6);
				this.add(0x83bf, 0x83d6);
				this.add(0x8440, 0x8460);
				this.add(0x8470, 0x847e);
				this.add(0x8480, 0x8491);
				this.add(0x849f, 0x84be);
				this.add(0x8740, 0x875d);
				this.add(0x875f, 0x8775);
				this.add(0x877e, 0x877e);
				this.add(0x8780, 0x879c);
				this.add(0x889f, 0x88fc);
				this.add(0x8940, 0x897e);
				this.add(0x8980, 0x89fc);
				this.add(0x8a40, 0x8a7e);
				this.add(0x8a80, 0x8afc);
				this.add(0x8b40, 0x8b7e);
				this.add(0x8b80, 0x8bfc);
				this.add(0x8c40, 0x8c7e);
				this.add(0x8c80, 0x8cfc);
				this.add(0x8d40, 0x8d7e);
				this.add(0x8d80, 0x8dfc);
				this.add(0x8e40, 0x8e7e);
				this.add(0x8e80, 0x8efc);
				this.add(0x8f40, 0x8f7e);
				this.add(0x8f80, 0x8ffc);
				this.add(0x9040, 0x907e);
				this.add(0x9080, 0x90fc);
				this.add(0x9140, 0x917e);
				this.add(0x9180, 0x91fc);
				this.add(0x9240, 0x927e);
				this.add(0x9280, 0x92fc);
				this.add(0x9340, 0x937e);
				this.add(0x9380, 0x93fc);
				this.add(0x9440, 0x947e);
				this.add(0x9480, 0x94fc);
				this.add(0x9540, 0x957e);
				this.add(0x9580, 0x95fc);
				this.add(0x9640, 0x967e);
				this.add(0x9680, 0x96fc);
				this.add(0x9740, 0x977e);
				this.add(0x9780, 0x97fc);
				this.add(0x9840, 0x9872);
				this.add(0x989f, 0x98fc);
				this.add(0x9940, 0x997e);
				this.add(0x9980, 0x99fc);
				this.add(0x9a40, 0x9a7e);
				this.add(0x9a80, 0x9afc);
				this.add(0x9b40, 0x9b7e);
				this.add(0x9b80, 0x9bfc);
				this.add(0x9c40, 0x9c7e);
				this.add(0x9c80, 0x9cfc);
				this.add(0x9d40, 0x9d7e);
				this.add(0x9d80, 0x9dfc);
				this.add(0x9e40, 0x9e7e);
				this.add(0x9e80, 0x9efc);
				this.add(0x9f40, 0x9f7e);
				this.add(0x9f80, 0x9ffc);
				this.add(0xe040, 0xe07e);
				this.add(0xe080, 0xe0fc);
				this.add(0xe140, 0xe17e);
				this.add(0xe180, 0xe1fc);
				this.add(0xe240, 0xe27e);
				this.add(0xe280, 0xe2fc);
				this.add(0xe340, 0xe37e);
				this.add(0xe380, 0xe3fc);
				this.add(0xe440, 0xe47e);
				this.add(0xe480, 0xe4fc);
				this.add(0xe540, 0xe57e);
				this.add(0xe580, 0xe5fc);
				this.add(0xe640, 0xe67e);
				this.add(0xe680, 0xe6fc);
				this.add(0xe740, 0xe77e);
				this.add(0xe780, 0xe7fc);
				this.add(0xe840, 0xe87e);
				this.add(0xe880, 0xe8fc);
				this.add(0xe940, 0xe97e);
				this.add(0xe980, 0xe9fc);
				this.add(0xea40, 0xea7e);
				this.add(0xea80, 0xeaa4);
				this.add(0xed40, 0xed7e);
				this.add(0xed80, 0xedfc);
				this.add(0xee40, 0xee7e);
				this.add(0xee80, 0xeeec);
				this.add(0xeeef, 0xeefc);
				this.add(0xfa40, 0xfa7e);
				this.add(0xfa80, 0xfafc);
				this.add(0xfb40, 0xfb7e);
				this.add(0xfb80, 0xfbfc);
				this.add(0xfc40, 0xfc4b);
			}
		}
	}
}
