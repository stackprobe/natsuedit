using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Charlotte.Tools
{
	public class Expand
	{
		private Bmp _src;
		private Bmp _dest;

		public Bmp Main(Bmp src, int new_w, int new_h)
		{
			_src = src;
			_dest = new Bmp(new_w, new_h, Bmp.Dot.getDot(Color.Transparent));

			this.Main2();

			return _dest;
		}

		private List<LineInfo> VLines;
		private List<LineInfo> HLines;

		private class LineInfo
		{
			public List<RangeInfo> RangeList = new List<RangeInfo>();
		}

		private class RangeInfo
		{
			public int DPos;
			public int SPos;
			public int E_Bgn;
			public int E_End;
			public int Count;
		}

		private List<LineInfo> MakeLines(int src_w, int dest_w)
		{
			List<LineInfo> lines = new List<LineInfo>();

			for (int dPos = 0; dPos < dest_w; dPos++)
			{
				int eBgn = dPos * src_w;
				int eEnd = (dPos + 1) * src_w - 1;

				int sBgn = eBgn / dest_w;
				int sEnd = eEnd / dest_w;

				LineInfo li = new LineInfo();

				for (int sPos = sBgn; sPos <= sEnd; sPos++)
				{
					RangeInfo ri = new RangeInfo();

					ri.DPos = dPos;
					ri.SPos = sPos;

					if (sPos == sBgn)
						ri.E_Bgn = eBgn;
					else
						ri.E_Bgn = sPos * dest_w;

					if (sPos == sEnd)
						ri.E_End = eEnd;
					else
						ri.E_End = (sPos + 1) * dest_w - 1;

					ri.Count = ri.E_End + 1 - ri.E_Bgn;

					li.RangeList.Add(ri);
				}
				lines.Add(li);
			}
			return lines;
		}

		private void Main2()
		{
			this.VLines = this.MakeLines(_src.table.w, _dest.table.w);
			this.HLines = this.MakeLines(_src.table.h, _dest.table.h);

			for (int color = 0; color < 4; color++)
			{
				for (int x = 0; x < _dest.table.w; x++)
				{
					for (int y = 0; y < _dest.table.h; y++)
					{
						LineInfo vli = this.VLines[x];
						LineInfo hli = this.HLines[y];

						long numer = 0;
						long denom = 0;

						for (int v = 0; v < vli.RangeList.Count; v++)
						{
							for (int h = 0; h < hli.RangeList.Count; h++)
							{
								RangeInfo vri = vli.RangeList[v];
								RangeInfo hri = hli.RangeList[h];

								long weight = vri.Count * hri.Count;

								if (color != 0)
									weight *= _src.table.get(vri.SPos, hri.SPos).getLevel(0);

								numer += weight * _src.table.get(vri.SPos, hri.SPos).getLevel(color);
								denom += weight;
							}
						}
						int cVal;

						if (denom == 0)
							cVal = 0;
						else
							cVal = (int)((numer + (denom / 2)) / denom);

						_dest.table.get(x, y).setLevel(color, cVal);
					}
				}
			}
		}
	}
}
