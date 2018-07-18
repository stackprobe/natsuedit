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
	public partial class Input字幕Dlg : Form
	{
		public bool OkPressed = false;
		public string Ret_Line1;
		public string Ret_Line2;
		public Consts.LineAlign_e Ret_Align1;
		public Consts.LineAlign_e Ret_Align2;

		public Input字幕Dlg()
		{
			InitializeComponent();

			this.MinimumSize = this.Size;

			this.UILoad();
			this.UIRefresh();
		}

		private void UILoad()
		{
			this.Align1.SelectedIndex = 1; // 中央
			this.Align2.SelectedIndex = 1; // 中央
		}

		private void Input字幕Dlg_Load(object sender, EventArgs e)
		{
			// noop
		}

		private void Input字幕Dlg_Shown(object sender, EventArgs e)
		{
			// noop
		}

		private void Input字幕Dlg_FormClosing(object sender, FormClosingEventArgs e)
		{
			// noop
		}

		private void Input字幕Dlg_FormClosed(object sender, FormClosedEventArgs e)
		{
			// noop
		}

		private void CB複数行_CheckedChanged(object sender, EventArgs e)
		{
			this.UIRefresh();
		}

		private void UIRefresh()
		{
			{
				bool flag = this.CB複数行.Checked;

				this.LblLine2.Enabled = flag;
				this.Line2.Enabled = flag;
				this.Align2.Enabled = flag;

				if (flag == false)
					this.Line2.Text = "";
			}
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			this.Ret_Line1 = this.Line1.Text;
			this.Ret_Line2 = this.Line2.Text;
			this.Ret_Align1 = (Consts.LineAlign_e)this.Align1.SelectedIndex;
			this.Ret_Align2 = (Consts.LineAlign_e)this.Align2.SelectedIndex;

			if (this.Check_Ret())
			{
				this.OkPressed = true;
				this.Close();
			}
		}

		private bool Check_Ret()
		{
			try
			{
				if (this.Ret_Line1 == "")
				{
					throw new Exception("１行目に文字列を入力して下さい。");
				}
				if (JString.isJString(this.Ret_Line1, true, false, false, false) == false)
				{
					throw new Exception("１行目にShift_JISに変換出来ない文字が含まれています。(半角スペースは使用出来ません)");
				}
				if (JString.isJString(this.Ret_Line2, true, false, false, false) == false)
				{
					throw new Exception("２行目にShift_JISに変換出来ない文字が含まれています。(半角スペースは使用出来ません)");
				}
				return true;
			}
			catch (Exception e)
			{
				MessageBox.Show("" + e, e.Message, MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
			return false;
		}
	}
}
