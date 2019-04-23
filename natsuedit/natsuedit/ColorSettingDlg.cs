using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Charlotte.Tools;

namespace Charlotte
{
	public partial class ColorSettingDlg : Form
	{
		private Color _color;

		public ColorSettingDlg(Color color)
		{
			_color = color;

			InitializeComponent();

			this.tbAlpha.Value = (_color.A - 1) / 16;
		}

		public bool okPressed;

		public Color retColor
		{
			get
			{
				return _color;
			}
		}

		private void ColorSettingDlg_Load(object sender, EventArgs e)
		{
			// noop
		}

		private void ColorSettingDlg_Shown(object sender, EventArgs e)
		{
			refreshUI();
		}

		private void ColorSettingDlg_FormClosing(object sender, FormClosingEventArgs e)
		{
			// noop
		}

		private void ColorSettingDlg_FormClosed(object sender, FormClosedEventArgs e)
		{
			// noop
		}

		private static Image _imgSample = null;

		private void refreshUI()
		{
			if (_imgSample == null)
				_imgSample = Bitmap.FromFile(imgSampleFile);

			Image img = (Image)_imgSample.Clone();

			using (Graphics g = Graphics.FromImage(img))
			{
				g.FillRectangle(new SolidBrush(_color), 40, 50, 240, 150);
			}
			pbSample.Image = img;

			GC.Collect();
		}

		private string imgSampleFile
		{
			get
			{
				string file = "ColorSettingSample.dat";

				if (File.Exists(file) == false)
					file = @"..\..\..\..\doc\ColorSettingSample.dat"; // devenv

				file = FileTools.makeFullPath(file);
				return file;
			}
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			this.okPressed = true;
			this.Close();
		}

		private void btnRGB_Click(object sender, EventArgs e)
		{
			int[] customColors = new int[]
			{
				0x33, 0x66, 0x99, 0xCC, 0x3300, 0x3333,
				0x3366, 0x3399, 0x33CC, 0x6600, 0x6633,
				0x6666, 0x6699, 0x66CC, 0x9900, 0x9933,
			};

			Color color = _color;

			if (SaveLoadDialogs.SelectColor(ref color, customColors))
			{
				_color = Color.FromArgb(
					_color.A,
					color.R,
					color.G,
					color.B
					);
			}
			refreshUI();
		}

		private void tbAlpha_ValueChanged(object sender, EventArgs e)
		{
			_color = Color.FromArgb(
				Math.Min((this.tbAlpha.Value + 1) * 16, 255),
				_color.R,
				_color.G,
				_color.B
				);

			refreshUI();
		}
	}
}
