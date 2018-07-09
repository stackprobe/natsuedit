using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.Tools;

namespace Charlotte
{
	public class Effect字幕入力
	{
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

			throw null; // TODO
		}
	}
}
