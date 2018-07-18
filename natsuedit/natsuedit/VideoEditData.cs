using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.Tools;
using System.IO;
using System.Drawing;

namespace Charlotte
{
	public class VideoEditData
	{
		private EditData _ed;
		private string _dir;

		public VideoEditData(EditData ed)
		{
			_ed = ed;
			_dir = _ed.md.getImageDir();
		}

		public int getCount()
		{
			int l = 0;
			int r = IntTools.IMAX;

			while (l + 1 < r)
			{
				int m = (l + r) / 2;

				if (File.Exists(getFile(m)))
				{
					l = m;
				}
				else
				{
					r = m;
				}
			}
			return r;
		}

		// 123 -> "0000000124.png"

		public string getFile(int index)
		{
			return _dir + "\\" + StringTools.zPad(index + 1, 10) + Consts.V_IMG_EXT;
		}

		public Bitmap getImage(int index)
		{
			return new Bitmap(new MemoryStream(File.ReadAllBytes(getFile(index))));
		}

		public void setImage(int index, Bitmap img)
		{
			img.Save(getFile(index), Consts.V_IMG_FORMAT);
		}

		public XYPoint selectOrig; // null == not_範囲選択中
		public XYPoint selectDest; // null == not_範囲選択中
		public Rect selectRect; // null == 未選択

		public void clearSelection()
		{
			selectOrig = null;
			selectDest = null;
			selectRect = null;
		}

		public bool isSelecting()
		{
			return selectOrig != null && selectDest != null;
		}

		public Rect getSelectingRect()
		{
			Rect rect = Rect.ltrb(
				Math.Min(selectOrig.x, selectDest.x),
				Math.Min(selectOrig.y, selectDest.y),
				Math.Max(selectOrig.x, selectDest.x),
				Math.Max(selectOrig.y, selectDest.y)
				);

			if (rect.w < Consts.VIDEO_SELECT_W_MIN || rect.h < Consts.VIDEO_SELECT_H_MIN) // ? 選択範囲が狭すぎて、選択しているとは言えない。
				return null;

			return rect;
		}
	}
}
