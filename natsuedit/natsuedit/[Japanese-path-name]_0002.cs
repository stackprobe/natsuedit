using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.Tools;
using System.Drawing;
using System.Drawing.Imaging;

namespace Charlotte
{
	public class Effect枠外切り捨て
	{
		private int _l;
		private int _t;
		private int _w;
		private int _h;

		public void perform()
		{
			if (Gnd.i.md == null)
				return;

			if (Gnd.i.md.ed.v.selectRect == null) // ? ! 画面選択完了
				throw new FailedOperation("画面選択を行って下さい。");

			{
				Rect rect = Gnd.i.md.ed.v.selectRect;

				_l = IntTools.toInt(rect.l);
				_t = IntTools.toInt(rect.t);
				_w = IntTools.toInt(rect.w);
				_h = IntTools.toInt(rect.h);
			}

			if (_w < Consts.VIDEO_W_MIN)
				throw new FailedOperation("選択範囲の幅が短すぎます。\n" + Consts.VIDEO_W_MIN + "px以上必要");

			if (_h < Consts.VIDEO_H_MIN)
				throw new FailedOperation("選択範囲の高さが短すぎます。\n" + Consts.VIDEO_H_MIN + "px以上必要");

			int count = Gnd.i.md.ed.v.getCount();

			for (int index = 0; index < count; index++)
			{
				Gnd.i.progressMessage.post("枠外切り捨て... " + index + " / " + count);

				Bitmap img = Gnd.i.md.ed.v.getImage(index);
				Bitmap destImg = new Bitmap(_w, _h, PixelFormat.Format24bppRgb); // 24 bit じゃないと、ffmpeg で動画に変換できない！

#if true
				using (Graphics g = Graphics.FromImage(destImg))
				{
					Rectangle srcRect = new Rectangle(_l, _t, _w, _h);
					Rectangle destRect = new Rectangle(0, 0, _w, _h);

					g.DrawImage(
						img,
						destRect,
						srcRect,
						GraphicsUnit.Pixel
						);
				}
#else // same 遅い
				for (int x = 0; x < _w; x++)
				{
					for (int y = 0; y < _h; y++)
					{
						destImg.SetPixel(x, y, img.GetPixel(_l + x, _t + y));
					}
				}
#endif

				string file = Gnd.i.md.ed.v.getFile(index);

				destImg.Save(file, Consts.V_IMG_FORMAT);
				GC.Collect();
			}

			// 動画の情報変更
			{
				Gnd.i.md.getTargetVideoStream().w = _w;
				Gnd.i.md.getTargetVideoStream().h = _h;
			}
		}
	}
}
