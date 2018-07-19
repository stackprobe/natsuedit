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
			throw null; // TODO
		}

		private void Put字幕(Bitmap j1, Consts.LineAlign_e align1, Bitmap j2, Consts.LineAlign_e align2)
		{
			throw null; // TODO
		}
	}
}
