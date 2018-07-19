using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Charlotte.Tools;
using System.IO;

namespace Charlotte
{
	public partial class FFmpegDirDlg : Form
	{
		public FFmpegDirDlg()
		{
			InitializeComponent();

			this.MinimumSize = this.Size;

			this.txtFFmpegDir.ForeColor = new TextBox().ForeColor;
			this.txtFFmpegDir.BackColor = new TextBox().BackColor;

			if (Environment.Is64BitOperatingSystem == false) // ? OS == 32-bit
			{
				lblExample.Text = lblExample.Text.Replace("64", "32");
			}

			// load
			{
				this.txtFFmpegDir.Text = Gnd.i.ffmpegDir;
			}
		}

		private void FFmpegDirDlg_Load(object sender, EventArgs e)
		{
			// noop
		}

		private void FFmpegDirDlg_Shown(object sender, EventArgs e)
		{
			this.btnFFmpegDir.Focus();
		}

		private void FFmpegDirDlg_FormClosing(object sender, FormClosingEventArgs e)
		{
			// noop
		}

		private void FFmpegDirDlg_FormClosed(object sender, FormClosedEventArgs e)
		{
			// noop
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			string dir = this.txtFFmpegDir.Text;

			// save
			{
				Gnd.i.ffmpegDir = dir;
			}
			this.Close();
		}

		private void txtFFmpegDir_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)1) // ctrl_a
			{
				txtFFmpegDir.SelectAll();
				e.Handled = true;
				return;
			}
			if (e.KeyChar == (char)13 || e.KeyChar == (char)32) // enter || space
			{
				btnFFmpegDir_Click(null, null);
				e.Handled = true;
				return;
			}
		}

		private void btnFFmpegDir_Click(object sender, EventArgs e)
		{
			//FolderBrowserDialogクラスのインスタンスを作成
			using (FolderBrowserDialog fbd = new FolderBrowserDialog())
			{
				//上部に表示する説明テキストを指定する
				fbd.Description = "ffmpegのフォルダを指定して下さい。";
				//ルートフォルダを指定する
				//デフォルトでDesktop
				fbd.RootFolder = Environment.SpecialFolder.MyComputer;
				//最初に選択するフォルダを指定する
				//RootFolder以下にあるフォルダである必要がある
				fbd.SelectedPath = txtFFmpegDir.Text;
				//ユーザーが新しいフォルダを作成できるようにする
				//デフォルトでTrue
				fbd.ShowNewFolderButton = false;

				//ダイアログを表示する
				if (fbd.ShowDialog(this) == DialogResult.OK)
				{
					//選択されたフォルダを表示する
					//Console.WriteLine(fbd.SelectedPath);

					try
					{
						string dir = fbd.SelectedPath;

						dir = FileTools.toFullPath(dir);

						{
							string sysRootDir = Environment.SystemDirectory[0] + ":\\";

							if (StringTools.equalsIgnoreCase(dir, sysRootDir))
								throw new FailedOperation("システムドライブのルートフォルダは指定出来ません。");
						}

						if (FFmpeg.isFFmpegDir(dir) == false)
							throw new FailedOperation("ffmpeg のパスではありません。");

						txtFFmpegDir.Text = dir;
					}
					catch (Exception ex)
					{
						FailedOperation.caught(ex);
					}
				}
			}
		}
	}
}
