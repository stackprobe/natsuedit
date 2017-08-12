using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Charlotte
{
	public class AudioEditData
	{
		private EditData _ed;

		public AudioEditData(EditData ed)
		{
			_ed = ed;
		}

		public int getCount()
		{
			FileInfo fi = new FileInfo(_ed.md.getWavCsvFile());
			long size = fi.Length;

			if (size % 12L != 0)
				throw new Exception("wav-csv size error");

			return (int)(size / 12L);
		}

		// 時間選択 ...

		/// <summary>
		/// -1 == 未選択
		/// -1 != 選択済み || 選択中
		/// </summary>
		public int selectBegin = -1;

		/// <summary>
		/// -1 == 未選択
		/// -1 != 選択済み
		/// </summary>
		public int selectEnd = -1;

		public void clearSelection()
		{
			selectBegin = -1;
			selectEnd = -1;
		}

		public bool isSelecting()
		{
			return selectBegin != -1 && selectEnd == -1;
		}

		public bool isSelected()
		{
			return selectEnd != -1;
		}
	}
}
