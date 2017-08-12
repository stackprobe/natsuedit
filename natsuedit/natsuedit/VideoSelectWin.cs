using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Charlotte.Tools;

namespace Charlotte
{
	public partial class VideoSelectWin : Form
	{
		private Bitmap _frameImage;
		private Rect _ownerRect;

		public Rect retRect;

		public VideoSelectWin(Bitmap frameImage, Rect ownerRect)
		{
			_frameImage = frameImage;
			_ownerRect = ownerRect;

			InitializeComponent();

			this.MinimumSize = this.Size;
			this.imgFrame.Image = _frameImage;

			{
				Rect rect = getInitSelectRect();

				txtL.Text = "" + IntTools.toInt(rect.l);
				txtT.Text = "" + IntTools.toInt(rect.t);
				txtW.Text = "" + IntTools.toInt(rect.w);
				txtH.Text = "" + IntTools.toInt(rect.h);
			}
		}

		private Rect getInitSelectRect()
		{
			if (Gnd.i.md.ed.v.selectRect != null)
				return Gnd.i.md.ed.v.selectRect;

			if (Gnd.i.md.ed.v.isSelecting())
				return Gnd.i.md.ed.v.getSelectingRect();

			if (_frameImage.Width < 200 || _frameImage.Height < 200)
				return new Rect(0, 0, _frameImage.Width, _frameImage.Height);

			return new Rect(
				_frameImage.Width / 4,
				_frameImage.Height / 4,
				_frameImage.Width / 2,
				_frameImage.Height / 2
				);
		}

		private void SelectVideoWin_Load(object sender, EventArgs e)
		{
			// noop
		}

		private void SelectVideoWin_Shown(object sender, EventArgs e)
		{
			if (_ownerRect == null)
			{
				this.WindowState = FormWindowState.Maximized;
			}
			else
			{
				this.Left = (int)_ownerRect.l;
				this.Top = (int)_ownerRect.t;
				this.Width = (int)_ownerRect.w;
				this.Height = (int)_ownerRect.h;
			}
			refreshFrame();
		}

		private void SelectVideoWin_FormClosing(object sender, FormClosingEventArgs e)
		{
			retRect = getInputRect();
		}

		private Rect getInputRect()
		{
			try
			{
				Rect rect = new Rect(
					IntTools.toInt(this.txtL.Text),
					IntTools.toInt(this.txtT.Text),
					IntTools.toInt(this.txtW.Text),
					IntTools.toInt(this.txtH.Text)
					);

				rect.l = IntTools.toRange((int)rect.l, 0, _frameImage.Width - Consts.VIDEO_SELECT_W_MIN);
				rect.t = IntTools.toRange((int)rect.t, 0, _frameImage.Height - Consts.VIDEO_SELECT_H_MIN);
				rect.w = IntTools.toRange((int)rect.w, Consts.VIDEO_SELECT_W_MIN, _frameImage.Width - (int)rect.l);
				rect.h = IntTools.toRange((int)rect.h, Consts.VIDEO_SELECT_H_MIN, _frameImage.Height - (int)rect.t);

				return rect;
			}
			catch
			{ }

			return null;
		}

		private void SelectVideoWin_FormClosed(object sender, FormClosedEventArgs e)
		{
			// noop
		}

		private void refreshFrame()
		{
			Image imgNew;

			try
			{
				Rect rect = getInputRect();

				imgNew = (Image)_frameImage.Clone();

				using (Graphics g = Graphics.FromImage(imgNew))
				{
					Utils.fillRectangle(g, rect, Gnd.i.selectingColor);
				}
			}
			catch
			{
				imgNew = _frameImage;
			}
			if (this.imgFrame.Image != imgNew)
				this.imgFrame.Image = imgNew;
		}

		private void txtL_TextChanged(object sender, EventArgs e)
		{
			ltwhCnahged();
		}

		private void txtT_TextChanged(object sender, EventArgs e)
		{
			ltwhCnahged();
		}

		private void txtW_TextChanged(object sender, EventArgs e)
		{
			ltwhCnahged();
		}

		private void txtH_TextChanged(object sender, EventArgs e)
		{
			ltwhCnahged();
		}

		private void ltwhCnahged()
		{
			refreshFrame();
		}

		private void txtL_KeyPress(object sender, KeyPressEventArgs e)
		{
			keyPressTxtLTWH(e, 0);
		}

		private void txtT_KeyPress(object sender, KeyPressEventArgs e)
		{
			keyPressTxtLTWH(e, 1);
		}

		private void txtW_KeyPress(object sender, KeyPressEventArgs e)
		{
			keyPressTxtLTWH(e, 2);
		}

		private void txtH_KeyPress(object sender, KeyPressEventArgs e)
		{
			keyPressTxtLTWH(e, 3);
		}

		private void keyPressTxtLTWH(KeyPressEventArgs e, int index)
		{
			if (e.KeyChar == (char)13) // enter
			{
				TextBox tb = new TextBox[] { txtT, txtW, txtH, null }[index];

				if (tb == null)
					this.Close();
				else
					tb.Focus();

				e.Handled = true;
			}
		}
	}
}
