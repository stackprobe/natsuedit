using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Permissions;
using Charlotte.Tools;

namespace Charlotte
{
	public partial class PseudoMainWin : Form
	{
		#region ALT_F4 抑止

		[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
		protected override void WndProc(ref Message m)
		{
			const int WM_SYSCOMMAND = 0x112;
			const long SC_CLOSE = 0xF060L;

			if (m.Msg == WM_SYSCOMMAND && (m.WParam.ToInt64() & 0xFFF0L) == SC_CLOSE)
				return;

			base.WndProc(ref m);
		}

		#endregion

		public PseudoMainWin()
		{
			InitializeComponent();
		}

		private void PseudoMainWin_Load(object sender, EventArgs e)
		{
			// noop
		}

		private void PseudoMainWin_Shown(object sender, EventArgs e)
		{
			this.Visible = false;
			this.mtEnabled = true;
		}

		private void PseudoMainWin_FormClosing(object sender, FormClosingEventArgs e)
		{
			// noop
		}

		private void PseudoMainWin_FormClosed(object sender, FormClosedEventArgs e)
		{
			this.mtEnabled = false; // 2bs
		}

		private bool mtEnabled = false;

		private void mainTimer_Tick(object sender, EventArgs e)
		{
			if (this.mtEnabled == false)
				return;

			this.mtEnabled = false;

			try
			{
				perform();
			}
			catch (Exception ex)
			{
				FailedOperation.caught(ex);
			}
			this.Close();
		}

		private void perform()
		{
			if (FFmpeg.isFFmpegDir(Gnd.i.ffmpegDir) == false)
			{
				using (FFmpegDirDlg f = new FFmpegDirDlg())
				{
					f.ShowDialog();
				}
				if (Gnd.i.ffmpegDir == "")
				{
					throw new Cancelled("ffmpeg のパスが指定されていないため、続行出来ません。");
				}
				if (FFmpeg.isFFmpegDir(Gnd.i.ffmpegDir) == false)
				{
					throw new Cancelled("ffmpeg のパスが見つからないため、続行出来ません。");
				}
			}

			try
			{
				BusyDlg.perform(delegate
				{
					FFmpegBin.i = new FFmpegBin(FFmpeg.getBinDir());

					try
					{
						FFmpegBinTester.doTest();
					}
					catch (Exception e)
					{
						Gnd.i.ffmpegDir = ""; // 次回起動時に再設定出来るように..
						throw new ExceptionCarrier(e);
					}

					if (Gnd.i.bootOpenFile != null)
						Gnd.i.md = new MediaData(Gnd.i.bootOpenFile);
				});

				using (MainWin f = new MainWin())
				{
					f.ShowDialog();
				}
			}
			finally
			{
				BusyDlg.perform(delegate
				{
					if (Gnd.i.md != null)
					{
						Gnd.i.md.Dispose();
						Gnd.i.md = null;
					}
					if (Gnd.i.qsd != null)
					{
						Gnd.i.qsd.Dispose();
						Gnd.i.qsd = null;
					}
					if (FFmpegBin.i != null)
					{
						FFmpegBin.i.Dispose();
						FFmpegBin.i = null;
					}
				});
			}
		}
	}
}
