using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.Tools;
using System.Drawing;

namespace Charlotte
{
	public class Effect字幕入力
	{
		private int StartIndex;
		private int EndIndex;

		private Bitmap Img;
		private int Img_W;
		private int Img_H;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="line1">""禁止</param>
		/// <param name="align1"></param>
		/// <param name="line2">""==2行目無し</param>
		/// <param name="align2"></param>
		public void perform(string line1, Consts.LineAlign_e align1, string line2, Consts.LineAlign_e align2)
		{
			if (Gnd.i.md == null)
				return;

			if (Gnd.i.md.ed.a.selectEnd == -1) // ? ! 時間選択完了
				throw new FailedOperation("時間を選択して下さい。");

			StartIndex = Gnd.i.md.ed.a.selectBegin; // ここから
			EndIndex = Gnd.i.md.ed.a.selectEnd; // ここまで(これを含む！)

			Img = Gnd.i.md.ed.v.getImage(StartIndex);
			Img_W = Img.Width;
			Img_H = Img.Height;

			Img.Dispose();
			Img = null;

			GC.Collect();

			Bitmap j1;
			Bitmap j2;

			if (line2 == "")
			{
				j1 = null;
				j2 = Make字幕(line1);
			}
			else
			{
				j1 = Make字幕(line1);
				j2 = Make字幕(line2);
			}

			for (int index = StartIndex; index < EndIndex; index++)
			{
				Img = Gnd.i.md.ed.v.getImage(index);

				Put字幕(j1, align1, j2, align2);

				Gnd.i.md.ed.v.setImage(index, Img);

				Img.Dispose();
				Img = null;

				GC.Collect();
			}
		}

		private Bitmap Make字幕(string line)
		{
			Bmp.Dot dotBack = new Bmp.Dot(0, 0, 0, 0);
			Bmp.Dot dotExte = new Bmp.Dot(255, 0, 0, 0);
			Bmp.Dot dotInte = new Bmp.Dot(255, 255, 255, 255);

			Bmp bmp;

			using (Bitmap b = new Bitmap(10000, 400))
			{
				using (Graphics g = Graphics.FromImage(b))
				{
					g.FillRectangle(Brushes.Black, 0f, 0f, (float)b.Width, (float)b.Height);
					g.DrawString(line, new Font("メイリオ", 300f, FontStyle.Regular), Brushes.White, 50f, 50f);
				}
				bmp = Bmp.create(b);
			}

			bmp.select(dot => dot.r < 128 ? dotBack : dotInte);

			{
				Rect rect = bmp.getRect(dot => dot.IsSame(dotInte));

				Gnd.i.logger.writeLine("rect.l: " + rect.l);
				Gnd.i.logger.writeLine("rect.t: " + rect.t);
				Gnd.i.logger.writeLine("rect.r: " + rect.r);
				Gnd.i.logger.writeLine("rect.b: " + rect.b);

				bmp = bmp.getRectBmp(
					IntTools.toInt(rect.l),
					IntTools.toInt(rect.t),
					IntTools.toInt(rect.w),
					IntTools.toInt(rect.h)
					);
			}

			Bmp bmpExte;
			bmpExte = bmp.copy();
			bmpExte.select(dot => dot.IsSame(dotInte) ? dotExte : dotBack);

			using (Bitmap b = new Bitmap(bmp.table.w + 60, bmp.table.h + 60))
			{
				using (Graphics g = Graphics.FromImage(b))
				{
					g.Clear(Color.Transparent);

					{
						Bitmap be = bmpExte.getBitmap();

						g.DrawImage(be, 10f, 10f);
						g.DrawImage(be, 30f, 10f);
						g.DrawImage(be, 50f, 10f);
						g.DrawImage(be, 50f, 30f);
						g.DrawImage(be, 50f, 50f);
						g.DrawImage(be, 30f, 50f);
						g.DrawImage(be, 10f, 50f);
						g.DrawImage(be, 10f, 30f);
					}

					g.DrawImage(bmp.getBitmap(), 30f, 30f);
				}
				bmp = Bmp.create(b);
			}

			{
				Rect rect = bmp.getRect(dot => dot.IsSame(dotBack) == false);

				bmp = bmp.getRectBmp(
					IntTools.toInt(rect.l),
					IntTools.toInt(rect.t),
					IntTools.toInt(rect.w),
					IntTools.toInt(rect.h)
					);
			}

			bmp = bmp.addMargin(10, 10, 10, 10, dotBack);
			bmp = bmp.expand(
				IntTools.toInt(bmp.table.w / 3.0),
				IntTools.toInt(bmp.table.h / 3.0)
				);

			{
				Rect rect = bmp.getRect(dot => dot.IsSame(dotBack) == false);

				bmp = bmp.getRectBmp(
					IntTools.toInt(rect.l),
					IntTools.toInt(rect.t),
					IntTools.toInt(rect.w),
					IntTools.toInt(rect.h)
					);
			}

			{
				int w;
				int h;

				h = IntTools.toInt(Img_H * 0.1);
				w = IntTools.toInt(h * bmp.table.w * 1.0 / bmp.table.h);

				w = Math.Min(w, Img_W);

				bmp = bmp.expand(w, h);
			}

			return bmp.getBitmap();
		}

		private void Put字幕(Bitmap j1, Consts.LineAlign_e align1, Bitmap j2, Consts.LineAlign_e align2)
		{
			using (Graphics g = Graphics.FromImage(Img))
			{
				if (j1 != null)
				{
					int x = Img_W - j1.Width;
					int y = Img_H - (j1.Height + j2.Height);

					switch (align1)
					{
						case Consts.LineAlign_e.左寄せ:
							x = 0;
							break;

						case Consts.LineAlign_e.中央:
							x /= 2;
							break;

						case Consts.LineAlign_e.右寄せ:
							break;

						default:
							throw null;
					}
					g.DrawImage(j1, x, y);
				}

				{
					int x = Img_W - j2.Width;
					int y = Img_H - j2.Height;

					switch (align1)
					{
						case Consts.LineAlign_e.左寄せ:
							x = 0;
							break;

						case Consts.LineAlign_e.中央:
							x /= 2;
							break;

						case Consts.LineAlign_e.右寄せ:
							break;

						default:
							throw null;
					}
					g.DrawImage(j2, x, y);
				}
			}
		}
	}
}
