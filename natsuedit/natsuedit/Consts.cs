using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Imaging;

namespace Charlotte
{
	public class Consts
	{
		public const int _起動や初期化が確実に終わったと言えるであろうmtCount = 2;

		public const int VIDEO_W_MIN = 10;
		public const int VIDEO_W_MAX = 100000;
		public const int VIDEO_H_MIN = 10;
		public const int VIDEO_H_MAX = 100000;

		public const int VIDEO_SELECT_W_MIN = 3;
		public const int VIDEO_SELECT_H_MIN = 3;

		public const int AUDIO_HZ_MIN = 100;
		public const int AUDIO_HZ_MAX = 1000000;

#if true
		public const string V_IMG_EXT = ".png";
		public const string V_IMG_VCODEC = "png";
		public static readonly ImageFormat V_IMG_FORMAT = ImageFormat.Png;
#else
		public const string V_IMG_EXT = ".bmp";
		public const string V_IMG_VCODEC = "bmp";
		public static readonly ImageFormat V_IMG_FORMAT = ImageFormat.Bmp;
#endif
	}
}
