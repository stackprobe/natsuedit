using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Charlotte
{
	public partial class SettingDlg : Form
	{
		private Color _selectingColor;
		private Color _selectColor;

		public SettingDlg()
		{
			InitializeComponent();

			// load
			{
				_selectingColor = Gnd.i.selectingColor;
				_selectColor = Gnd.i.selectColor;

				this.cbファイルを閉じるとき保存するか確認しない.Checked = Gnd.i._ファイルを閉じるとき保存するか確認しない;
				this.cb映像をJPEGで保存する.Checked = Gnd.i._映像をJPEGで保存する;

				this.JPEGの画質.Text = "" + Gnd.i._映像をJPEGで保存する時の画質;
			}
		}

		private void SettingDlg_Load(object sender, EventArgs e)
		{
			// noop
		}

		private void SettingDlg_Shown(object sender, EventArgs e)
		{
			refreshUI();
		}

		private void SettingDlg_FormClosing(object sender, FormClosingEventArgs e)
		{
			// noop
		}

		private void SettingDlg_FormClosed(object sender, FormClosedEventArgs e)
		{
			// noop
		}

		private void refreshUI()
		{
			this.lblSelectingColor.Text = "選択中の色 : " + Utils.toUIString(_selectingColor);
			this.lblSelectColor.Text = "選択された矩形の色 : " + Utils.toUIString(_selectColor);

			{
				bool f = this.cb映像をJPEGで保存する.Checked;

				this.lblJPEGの画質.Enabled = f;
				this.JPEGの画質.Enabled = f;
			}
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			// save
			{
				Gnd.i.selectingColor = _selectingColor;
				Gnd.i.selectColor = _selectColor;

				Gnd.i._ファイルを閉じるとき保存するか確認しない = this.cbファイルを閉じるとき保存するか確認しない.Checked;
				Gnd.i._映像をJPEGで保存する = this.cb映像をJPEGで保存する.Checked;

				try
				{
					int value = (int)this.JPEGの画質.Value;

					if (value < 0 || 100 < value)
						throw null;

					Gnd.i._映像をJPEGで保存する時の画質 = value;
				}
				catch
				{ }
			}

			this.Close();
		}

		private void btnSelectingColor_Click(object sender, EventArgs e)
		{
			_selectingColor = changeColor(_selectingColor);
			refreshUI();
		}

		private void btnSelectColor_Click(object sender, EventArgs e)
		{
			_selectColor = changeColor(_selectColor);
			refreshUI();
		}

		private Color changeColor(Color color)
		{
			using (ColorSettingDlg f = new ColorSettingDlg(color))
			{
				f.ShowDialog();

				if (f.okPressed)
					color = f.retColor;
			}
			return color;
		}

		private void cb映像をJPEGで保存する_CheckedChanged(object sender, EventArgs e)
		{
			refreshUI();
		}
	}
}
