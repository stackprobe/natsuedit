using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.Tools;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;

namespace Charlotte
{
	public class EffectBokashi
	{
		private bool _strongMode;

		private int _bokashi_l;
		private int _bokashi_t;
		private int _bokashi_r;
		private int _bokashi_b;

		private int _bokashi_rad;

		private int _startIndex;
		private int _endIndex;
		private int _currIndex;

		public void perform(bool strongMode = false)
		{
			_strongMode = strongMode;

			if (Gnd.i.md == null)
				return;

			if (Gnd.i.md.ed.v.selectRect == null) // ? ! 画面選択完了
				throw new FailedOperation("画面選択を行って下さい。");

			if (Gnd.i.md.ed.a.selectEnd == -1) // ? ! 時間選択完了
				throw new FailedOperation("時間を選択して下さい。");

			{
				Rect rect = Gnd.i.md.ed.v.selectRect;

				_bokashi_l = IntTools.toInt(rect.l);
				_bokashi_t = IntTools.toInt(rect.t);
				_bokashi_r = IntTools.toInt(rect.getR()) - 1; // l + w の直前までなので、-1
				_bokashi_b = IntTools.toInt(rect.getB()) - 1; // t + h の直前までなので、-1
			}

			{
				int video_w = Gnd.i.md.getTargetVideoStream().w;
				int video_h = Gnd.i.md.getTargetVideoStream().h;

				if (_strongMode)
					_bokashi_rad = Math.Max(40, Math.Min(video_w, video_h) / 10);
				else
					_bokashi_rad = Math.Max(10, Math.Min(video_w, video_h) / 40);
			}

			Gnd.i.logger.writeLine("_bokashi_rad: " + _bokashi_rad);

			_startIndex = Gnd.i.md.ed.a.selectBegin; // ここから
			_endIndex = Gnd.i.md.ed.a.selectEnd; // ここまで、ぼかしを入れる。
			_currIndex = _startIndex;

			Thread[] ths = new Thread[getThCount()];

			for (int index = 0; index < ths.Length; index++)
			{
				ths[index] = new Thread((ThreadStart)delegate
				{
					try
					{
						doBokashi();
					}
					catch
					{ }
				});

				ths[index].Start();
			}
			for (int index = 0; index < ths.Length; index++)
			{
				ths[index].Join();
			}
			if (Gnd.i.cancelled)
				throw new Cancelled("処理を中止しました。\n途中まで処理が進んでいるかもしれません。");

			Gnd.i.progressMessage.post(""); // 完了
		}

		private int getThCount()
		{
			return Math.Max(1, Utils.getNumOfProcessor() - 1); // 100%になると重くて他のことが出来なくなりそうなので、1つ分空けておく。
		}

		private object SYNCROOT = new object();
		private bool _mainThStaff = true;

		private void doBokashi()
		{
			for (; ; )
			{
				Bitmap img;
				int img_w;
				int img_h;
				string file;
				Bitmap destImg;
				bool mainThStaff;

				lock (SYNCROOT)
				{
					// ぼかしを入れる範囲は _endIndex を含む！

					if (_endIndex < _currIndex)
						break;

					Gnd.i.progressMessage.post("ぼかしを入れています... " + _currIndex + " (" + _startIndex + "-" + _endIndex + ")");

					img = Gnd.i.md.ed.v.getImage(_currIndex);
					img_w = img.Width;
					img_h = img.Height;
					file = Gnd.i.md.ed.v.getFile(_currIndex);
					destImg = new Bitmap(img_w, img_h, PixelFormat.Format24bppRgb); // 24 bit じゃないと、ffmpeg で動画に変換できない！

					_currIndex++;

					mainThStaff = _mainThStaff;
					_mainThStaff = false;
				}
				doBokashiBitmap(img, img_w, img_h, destImg, mainThStaff);

				lock (SYNCROOT)
				{
					destImg.Save(file, Consts.V_IMG_FORMAT);
					GC.Collect();

					_mainThStaff |= mainThStaff;
					mainThStaff = false;
				}
				if (Gnd.i.cancelled)
					break;
			}
		}

		private void doBokashiBitmap(Bitmap img, int img_w, int img_h, Bitmap destImg, bool mainThStaff)
		{
			for (int x = 0; x < img_w; x++)
			{
				for (int y = 0; y < img_h; y++)
				{
					destImg.SetPixel(x, y, img.GetPixel(x, y));
				}
			}

			// pbn == per bonnou

			int pbnSpan = Math.Max(1, ((_bokashi_r - _bokashi_l + 1) * (_bokashi_b - _bokashi_t + 1)) / 108);
			int pbn = 0;
			int count = 0;

			if (_strongMode)
			{
				BokashiDotColor bdcX = new BokashiDotColor(img, _bokashi_l, _bokashi_t, _bokashi_rad);

				for (int x = _bokashi_l; x <= _bokashi_r; x++)
				{
					if (_bokashi_l < x)
						bdcX._右へ();

					BokashiDotColor bdcY = bdcX.getClone();

					for (int y = _bokashi_t; y <= _bokashi_b; y++)
					{
						if (_bokashi_t < y)
							bdcY._下へ();

						if (
							IntTools.isRange(x, 0, img_w - 1) &&
							IntTools.isRange(y, 0, img_h - 1)
							)
							destImg.SetPixel(x, y, bdcY.getColor());

						if (mainThStaff)
						{
							if (count % pbnSpan == 0)
							{
								Gnd.i.progressOptionalMessage.post(pbn + " pbn");
								pbn++;
							}
							count++;
						}
					}
				}
			}
			else
			{
				for (int x = _bokashi_l; x <= _bokashi_r; x++)
				{
					for (int y = _bokashi_t; y <= _bokashi_b; y++)
					{
						if (
							IntTools.isRange(x, 0, img_w - 1) &&
							IntTools.isRange(y, 0, img_h - 1)
							)
							destImg.SetPixel(x, y, getBokashiDotColor(img, x, y));

						if (mainThStaff)
						{
							if (count % pbnSpan == 0)
							{
								Gnd.i.progressOptionalMessage.post(pbn + " pbn");
								pbn++;
							}
							count++;
						}
					}
				}
			}
		}

		private class BokashiDotColor
		{
			private Bitmap _img;
			private int _x;
			private int _y;
			private int _rad;
			private long _r;
			private long _g;
			private long _b;
			private long _count;

			public BokashiDotColor(Bitmap img, int x, int y, int rad)
			{
				_img = img;
				_x = x;
				_y = y;
				_rad = rad;

				for (int sx = -_rad; sx <= _rad; sx++)
				{
					for (int sy = -_rad; sy <= _rad; sy++)
					{
						add(_x + sx, _y + sy, 1);
					}
				}
			}

			private BokashiDotColor()
			{ }

			public BokashiDotColor getClone()
			{
				return new BokashiDotColor()
				{
					_img = this._img,
					_x = this._x,
					_y = this._y,
					_rad = this._rad,
					_r = this._r,
					_g = this._g,
					_b = this._b,
					_count = this._count,
				};
			}

			private void add(int x, int y, long scale)
			{
				if (
					IntTools.isRange(x, 0, _img.Width - 1) &&
					IntTools.isRange(y, 0, _img.Height - 1)
					)
				{
					Color color = _img.GetPixel(x, y);

					_r += (long)color.R * scale;
					_g += (long)color.G * scale;
					_b += (long)color.B * scale;
					_count += scale;
				}
			}

			public void _右へ()
			{
				for (int sy = -_rad; sy <= _rad; sy++)
				{
					add(_x - _rad, _y + sy, -1);
					add(_x + _rad, _y + sy, 1);
				}
				_x++;
			}

			public void _下へ()
			{
				for (int sx = -_rad; sx <= _rad; sx++)
				{
					add(_x + sx, _y - _rad, -1);
					add(_x + sx, _y + _rad, 1);
				}
				_y++;
			}

			public Color getColor()
			{
				return Color.FromArgb(
					IntTools.toInt((double)_r / _count),
					IntTools.toInt((double)_g / _count),
					IntTools.toInt((double)_b / _count)
					);
			}
		}

		private Color getBokashiDotColor(Bitmap img, int trgX, int trgY)
		{
			int r = 0;
			int g = 0;
			int b = 0;
			int count = 0;

			for (int sx = -_bokashi_rad; sx <= _bokashi_rad; sx++)
			{
				for (int sy = -_bokashi_rad; sy <= _bokashi_rad; sy++)
				{
					if (sx * sx + sy * sy <= _bokashi_rad * _bokashi_rad)
					{
						int x = trgX + sx;
						int y = trgY + sy;

						if (
							IntTools.isRange(x, 0, img.Width - 1) &&
							IntTools.isRange(y, 0, img.Height - 1)
							)
						{
							Color color = img.GetPixel(x, y);

							r += color.R;
							g += color.G;
							b += color.B;
							count++;
						}
					}
				}
			}
			r = IntTools.toInt((double)r / count);
			g = IntTools.toInt((double)g / count);
			b = IntTools.toInt((double)b / count);

			return Color.FromArgb(r, g, b);
		}
	}
}
