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
	public partial class Input字幕Dlg : Form
	{
		public bool OkPressed = false;
		public string Ret_Line1;
		public Consts.LineAlign_e Ret_Align1;
		public string Ret_Line2;
		public Consts.LineAlign_e Ret_Align2;

		public Input字幕Dlg()
		{
			InitializeComponent();

			this.MinimumSize = this.Size;
		}

		private void Input字幕Dlg_Load(object sender, EventArgs e)
		{
			// TODO
		}

		private void Input字幕Dlg_Shown(object sender, EventArgs e)
		{
			// TODO
		}

		private void Input字幕Dlg_FormClosing(object sender, FormClosingEventArgs e)
		{
			// TODO
		}

		private void Input字幕Dlg_FormClosed(object sender, FormClosedEventArgs e)
		{
			// TODO
		}
	}
}
