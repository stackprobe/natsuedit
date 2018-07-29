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
	public partial class MainWin : Form
	{
		public static MainWin self;

		public MainWin()
		{
			self = this;

			InitializeComponent();

			this.MinimumSize = this.Size;
			this.lblStatus.Text = "";

			refreshTitle();
			//refreshVideo(); // moved -> _Shown
		}

		private void MainWin_Load(object sender, EventArgs e)
		{
			// noop
		}

		private void MainWin_Shown(object sender, EventArgs e)
		{
			if (Gnd.i.mainWin_W == -1)
			{
				Screen ps = Screen.PrimaryScreen;
				Rectangle psb = ps.Bounds;

				this.Left = psb.Left + 50;
				this.Top = psb.Top + 50;
				this.Width = psb.Width - 100;
				this.Height = psb.Height - 100;
			}
			else
			{
				this.Left = Gnd.i.mainWin_L;
				this.Top = Gnd.i.mainWin_T;
				this.Width = Gnd.i.mainWin_W;
				this.Height = Gnd.i.mainWin_H;
			}
			if (Gnd.i.mainWinMaximized)
				this.WindowState = FormWindowState.Maximized;

			this.refreshVideo();
			this.refreshEnable();
			this.mtEnabled = true;

			Gnd.i.logger.writeLine("MainWinを開きました。");
		}

		private void MainWin_FormClosing(object sender, FormClosingEventArgs e)
		{
			Gnd.i.mainWinMaximized = this.WindowState == FormWindowState.Maximized;
			//confirmSaveFile(false, true, false); // ログオフのとき保存すると、ffmpeg とか呼び出すから上手くいかないだろう。
		}

		private void MainWin_FormClosed(object sender, FormClosedEventArgs e)
		{
			this.mtEnabled = false;

			confirmSaveFile(false, true, false);

			Gnd.i.logger.writeLine("MainWinを閉じます。");

			self = null;
		}

		private void 終了XToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.mtEnabled = false;
			this.Close();
		}

		private bool mtEnabled;
		private bool mtBusy;
		private long mtCount;

		private Queue<BusyDlg.operation_d> mtInvokers = new Queue<BusyDlg.operation_d>();

		private void mainTimer_Tick(object sender, EventArgs e)
		{
			if (BusyDlg.performing)
				return;

			if (FailedOperation.caughting)
				return;

			if (this.mtEnabled == false || this.mtBusy)
				return;

			this.mtBusy = true;

			try
			{
				if (1 <= mtInvokers.Count)
				{
					mtInvokers.Dequeue()();
					return; // 2bs
				}
				if (_needRefreshVideoFrame)
				{
					refreshVideoFrame();
					_needRefreshVideoFrame = false;
					_needRefreshVideoFrameNoSeek = false;
				}
				if (_needRefreshVideoFrameNoSeek)
				{
					refreshVideoFrameNoSeek();
					_needRefreshVideoFrameNoSeek = false;
				}
				if (_needRefreshEnable)
				{
					refreshEnable();
					_needRefreshEnable = false;
				}
				refreshStatus();
			}
			finally
			{
				this.mtBusy = false;
				this.mtCount++;
			}
		}

		private void refreshStatus()
		{
			try
			{
				List<string> tokens = new List<string>();

				if (_currFrame != null)
				{
					tokens.Add(_currFrame.Width + "x" + _currFrame.Height);
				}
				if (Gnd.i.md != null)
				{
					int fps = Gnd.i.md.getTargetVideoStream().fps;

					tokens.Add(
						Utils.millisToTimeStamp(IntTools.toInt(this.seekBar.Value * 1000.0 / fps)) +
						" / " +
						Utils.millisToTimeStamp(IntTools.toInt(this.seekBar.Maximum * 1000.0 / fps)) +
						" (" +
						this.seekBar.Value +
						" / " +
						this.seekBar.Maximum +
						")"
						);
					tokens.Add(fps + " fps");
					tokens.Add(Gnd.i.md.getWavHz() + " hz");

					if (Gnd.i.md.ed.v.selectRect != null)
					{
						Rect rect = Gnd.i.md.ed.v.selectRect;

						tokens.Add(
							"画面選択=(" +
							IntTools.toInt(rect.l) +
							", " +
							IntTools.toInt(rect.t) +
							", " +
							(IntTools.toInt(rect.getR()) - 1) +
							", " +
							(IntTools.toInt(rect.getB()) - 1) +
							")"
							);
					}
					if (Gnd.i.md.ed.v.isSelecting())
					{
						Rect rect = Gnd.i.md.ed.v.getSelectingRect();

						if (rect == null)
							tokens.Add("画面選択中...");
						else
							tokens.Add(
								"画面選択中=(" +
								IntTools.toInt(rect.l) +
								", " +
								IntTools.toInt(rect.t) +
								", " +
								(IntTools.toInt(rect.getR()) - 1) +
								", " +
								(IntTools.toInt(rect.getB()) - 1) +
								")"
								);
					}
					if (Gnd.i.md.ed.a.selectEnd != -1)
					{
						tokens.Add(
							"時間選択=" +
							Utils.millisToTimeStamp(IntTools.toInt(Gnd.i.md.ed.a.selectBegin * 1000.0 / fps)) +
							" (" +
							Gnd.i.md.ed.a.selectBegin +
							") ～ " +
							Utils.millisToTimeStamp(IntTools.toInt(Gnd.i.md.ed.a.selectEnd * 1000.0 / fps)) +
							" (" +
							Gnd.i.md.ed.a.selectEnd +
							")"
							);
					}
					else if (Gnd.i.md.ed.a.selectBegin != -1)
					{
						tokens.Add(
							"時間選択中=" +
							Utils.millisToTimeStamp(IntTools.toInt(Gnd.i.md.ed.a.selectBegin * 1000.0 / fps)) +
							" (" +
							Gnd.i.md.ed.a.selectBegin +
							")..."
							);
					}
				}

				{
					string state = string.Join(", ", tokens);

					if (this.lblStatus.Text != state)
						this.lblStatus.Text = state;
				}
			}
			catch (Exception e)
			{
				this.lblStatus.Text = e.Message;
			}

			refreshTimeSelection();
		}

		private void refreshTimeSelection()
		{
			Color back_color;

			switch (isTimeSelection())
			{
				case 0: back_color = Color.DarkGray; break;
				case 1: back_color = Gnd.i.selectingColor; break;
				case 2: back_color = Gnd.i.selectColor; break;

				default:
					throw null;
			}
			if (this.imgVideo.BackColor != back_color)
				this.imgVideo.BackColor = back_color;
		}

		private int isTimeSelection() // ret: 0-2 == 選択していない, 選択中, 選択範囲内
		{
			int ret = 0; // 選択していない

			if (Gnd.i.md == null)
			{
				// noop
			}
			else
			{
				if (Gnd.i.md.ed.a.selectEnd != -1) // ? 時間選択_済み
				{
					int index = this.seekBar.Value;

					if (IntTools.isRange(index, Gnd.i.md.ed.a.selectBegin, Gnd.i.md.ed.a.selectEnd)) // ? 時間選択_範囲内
					{
						ret = 2; // 選択範囲内
					}
				}
				else if (Gnd.i.md.ed.a.selectBegin != -1) // ? 時間選択_中
				{
					ret = 1; // 選択中
				}
			}
			return ret;
		}

		private void refreshTitle()
		{
			if (Gnd.i.md == null)
			{
				this.Text = "夏Edit";
			}
			else
			{
				this.Text = "夏Edit / " + Gnd.i.md.ed.getLastSavedFile();
				//this.Text = "夏Edit / " + Gnd.i.md.getOriginalFile(); // old
			}
		}

		private void refreshVideo()
		{
			if (Gnd.i.md == null)
			{
				this.seekBar.Maximum = 0;
			}
			else
			{
				int count = Gnd.i.md.ed.v.getCount();

				this.seekBar.Maximum = count - 1;
			}
			this.refreshVideoFrame();
		}

		private void refreshVideoFrame()
		{
			if (Gnd.i.md == null)
			{
				_currFrame = null;
			}
			else
			{
				int index = this.seekBar.Value;

				_currFrame = Gnd.i.md.ed.v.getImage(index);
			}
			refreshVideoFrameNoSeek();
		}

		private Bitmap _currFrame;

		private void refreshVideoFrameNoSeek()
		{
			Bitmap frame = _currFrame;

			if (_currFrame != null)
			{
				Color color;
				Rect rect = getFrameSelectRectColor(out color);

				if (rect != null)
				{
					frame = (Bitmap)frame.Clone();

					using (Graphics g = Graphics.FromImage(frame))
					{
						Utils.fillRectangle(g, rect, color);
					}
				}
			}
			this.imgVideo.Image = frame;
			GC.Collect();
		}

		private Rect getFrameSelectRectColor(out Color color)
		{
			color = Color.Black; // dummy

			if (Gnd.i.md == null)
				return null;

			if (Gnd.i.md.ed.v.selectRect != null)
			{
				color = Gnd.i.selectColor;
				return Gnd.i.md.ed.v.selectRect;
			}
			if (Gnd.i.md.ed.v.isSelecting())
			{
				color = Gnd.i.selectingColor;
				return Gnd.i.md.ed.v.getSelectingRect();
			}
			return null;
		}

		private bool _needRefreshVideoFrame = false;

		private void seekBar_ValueChanged(object sender, EventArgs e)
		{
			_needRefreshVideoFrame = true;
			//refreshVideoFrame(); // old
		}

		private void btnPrev_Click(object sender, EventArgs e)
		{
			int index = this.seekBar.Value;

			if (1 <= index)
				index--;

			this.seekBar.Value = index;
		}

		private void btnNext_Click(object sender, EventArgs e)
		{
			int index = this.seekBar.Value;

			if (index < this.seekBar.Maximum - 1)
				index++;

			this.seekBar.Value = index;
		}

		private void ファイルを開くOToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.mtEnabled = false;

			try
			{
				confirmSaveFile(false, true, false);

				string presetFile = Gnd.i.lastOpenedFile;
				string selectedFile = null;

				//OpenFileDialogクラスのインスタンスを作成
				using (OpenFileDialog ofd = new OpenFileDialog())
				{
					//はじめのファイル名を指定する
					//はじめに「ファイル名」で表示される文字列を指定する
					ofd.FileName = Path.GetFileName(presetFile);
					//はじめに表示されるフォルダを指定する
					//指定しない（空の文字列）の時は、現在のディレクトリが表示される
					ofd.InitialDirectory = Path.GetDirectoryName(presetFile);
					//[ファイルの種類]に表示される選択肢を指定する
					//指定しないとすべてのファイルが表示される
					//ofd.Filter = "HTMLファイル(*.html;*.htm)|*.html;*.htm|すべてのファイル(*.*)|*.*";
					ofd.Filter = Gnd.i.movieExtensions.getFilter();
					//[ファイルの種類]ではじめに選択されるものを指定する
					//2番目の「すべてのファイル」が選択されているようにする
					//ofd.FilterIndex = 2;
					ofd.FilterIndex = Gnd.i.movieExtensions.indexOf(".mp4") + 1;
					//タイトルを設定する
					ofd.Title = "動画ファイルを選択してください";
					//ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
					ofd.RestoreDirectory = true;
					//存在しないファイルの名前が指定されたとき警告を表示する
					//デフォルトでTrueなので指定する必要はない
					ofd.CheckFileExists = true;
					//存在しないパスが指定されたとき警告を表示する
					//デフォルトでTrueなので指定する必要はない
					ofd.CheckPathExists = true;

					//ダイアログを表示する
					if (ofd.ShowDialog() == DialogResult.OK)
					{
						//OKボタンがクリックされたとき、選択されたファイル名を表示する
						//Console.WriteLine(ofd.FileName);

						selectedFile = ofd.FileName;
					}
				}

				if (selectedFile != null)
				{
					BusyDlg.perform(delegate
					{
						if (Gnd.i.md != null)
						{
							Gnd.i.md.Dispose();
							Gnd.i.md = null;
						}
						Gnd.i.md = new MediaData(selectedFile);
					});
				}
			}
			catch (Exception ex)
			{
				FailedOperation.caught(ex);
			}

			refreshTitle();
			refreshVideo();
			refreshEnable();

			this.mtEnabled = true;
		}

		// 要 MainWin.AllowDrop = true;

		private void MainWin_DragEnter(object sender, DragEventArgs e)
		{
			try
			{
				if (e.Data.GetDataPresent(DataFormats.FileDrop))
					e.Effect = DragDropEffects.Copy;
			}
			catch
			{ }
		}

		private void MainWin_DragDrop(object sender, DragEventArgs e)
		{
			try
			{
				string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);

				if (files.Length < 1)
					return;

				string file = files[0];
				file = FileTools.toFullPath(file); // 2bs

				mtInvokers.Enqueue(delegate
				{
					try
					{
						confirmSaveFile(true, true, false);

						BusyDlg.perform(delegate
						{
							if (Gnd.i.md != null)
							{
								Gnd.i.md.Dispose();
								Gnd.i.md = null;
							}
							Gnd.i.md = new MediaData(file);
						},
						this
						);
					}
					catch (Exception ex)
					{
						FailedOperation.caught(ex);
					}

					refreshTitle();
					refreshVideo();
					refreshEnable();
				});
			}
			catch
			{ }
		}

		private void 上書き保存SToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.mtEnabled = false;

			try
			{
				confirmSaveFile(false, false, true);
				//saveFileOverwrite(); // 確認が無いのはマズいかなと..
			}
			catch (Exception ex)
			{
				FailedOperation.caught(ex);
			}
			this.mtEnabled = true;
		}

		private void ファイルを閉じるCToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.mtEnabled = false;

			try
			{
				confirmSaveFile(true, true, false);

				if (Gnd.i.md != null)
				{
					BusyDlg.perform(delegate
					{
						Gnd.i.md.Dispose();
						Gnd.i.md = null;
					});
				}
			}
			catch (Exception ex)
			{
				FailedOperation.caught(ex);
			}

			refreshTitle();
			refreshVideo();
			refreshEnable();

			this.mtEnabled = true;
		}

		private void confirmSaveFile(bool showCancelBtn, bool beforeClosingFile, bool overwriteMode)
		{
			if (Gnd.i.md == null)
				return;

			if (beforeClosingFile && Gnd.i._ファイルを閉じるとき保存するか確認しない)
				return;

			string savingFile = Gnd.i.md.ed.getLastSavedFile();
			//string savingFile = Gnd.i.md.getOriginalFile(); // old

			switch (MessageBox.Show(
				"今開いている \"" + Path.GetFileName(savingFile) + "\" を" + (overwriteMode ? "上書き" : "") + "保存しますか？",
				"確認",
				showCancelBtn ? MessageBoxButtons.YesNoCancel : MessageBoxButtons.YesNo,
				MessageBoxIcon.Information
				))
			{
				case DialogResult.Yes:
					saveFile(overwriteMode);
					break;

				case DialogResult.No:
					// noop
					break;

				case DialogResult.Cancel:
					throw new Ended();
			}
		}

		private void saveFile(bool overwriteMode)
		{
			if (Gnd.i.md == null)
				return;

			if (overwriteMode)
			{
				Gnd.i.md.ed.saveFile(Gnd.i.md.ed.getLastSavedFile());
				//Gnd.i.md.ed.saveFile(Gnd.i.md.getOriginalFile()); // old
			}
			else
			{
				名前を付けて保存AToolStripMenuItem_Click(null, null);
			}
		}

		private void 名前を付けて保存AToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.mtEnabled = false;

			try
			{
				if (Gnd.i.md == null)
					return;

				string presetFile = Gnd.i.md.ed.getLastSavedFile();
				//string presetFile = Gnd.i.md.getOriginalFile(); // old
				string selectedFile = null;

				//SaveFileDialogクラスのインスタンスを作成
				using (SaveFileDialog sfd = new SaveFileDialog())
				{
					//はじめのファイル名を指定する
					//はじめに「ファイル名」で表示される文字列を指定する
					sfd.FileName = Path.GetFileName(presetFile);
					//はじめに表示されるフォルダを指定する
					sfd.InitialDirectory = Path.GetDirectoryName(presetFile);
					//[ファイルの種類]に表示される選択肢を指定する
					//指定しない（空の文字列）の時は、現在のディレクトリが表示される
					sfd.Filter = Gnd.i.movieExtensions.getFilter();
					//[ファイルの種類]ではじめに選択されるものを指定する
					//2番目の「すべてのファイル」が選択されているようにする
					//sfd.FilterIndex = 2;
					sfd.FilterIndex = Gnd.i.movieExtensions.indexOf(".mp4") + 1;
					//タイトルを設定する
					sfd.Title = "保存先のファイルを選択してください";
					//ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
					sfd.RestoreDirectory = true;
					//既に存在するファイル名を指定したとき警告する
					//デフォルトでTrueなので指定する必要はない
					sfd.OverwritePrompt = true;
					//存在しないパスが指定されたとき警告を表示する
					//デフォルトでTrueなので指定する必要はない
					sfd.CheckPathExists = true;

					//ダイアログを表示する
					if (sfd.ShowDialog() == DialogResult.OK)
					{
						//OKボタンがクリックされたとき、選択されたファイル名を表示する
						//Console.WriteLine(sfd.FileName);

						selectedFile = sfd.FileName;
					}
				}

				if (selectedFile != null)
				{
					BusyDlg.perform(delegate
					{
						Gnd.i.md.ed.saveFile(selectedFile);
					});
				}
			}
			catch (Exception ex)
			{
				FailedOperation.caught(ex);
			}

			refreshTitle();

			this.mtEnabled = true;
		}

		private void 設定SToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.mtEnabled = false;

			using (SettingDlg f = new SettingDlg())
			{
				f.ShowDialog();
			}
			this.mtEnabled = true;
		}

		private void MainWin_Move(object sender, EventArgs e)
		{
			this.MainWin_ResizeEnd(null, null);
		}

		private void MainWin_ResizeEnd(object sender, EventArgs e)
		{
			if (mtCount < Consts._起動や初期化が確実に終わったと言えるであろうmtCount)
				return;

			if (this.WindowState != FormWindowState.Normal)
				return;

			Gnd.i.mainWin_L = this.Left;
			Gnd.i.mainWin_T = this.Top;
			Gnd.i.mainWin_W = this.Width;
			Gnd.i.mainWin_H = this.Height;
		}

		private bool _needRefreshVideoFrameNoSeek = false;
		private bool _needRefreshEnable = false;

		private void imgVideo_Click(object sender, EventArgs e)
		{
			// noop
		}

		private void imgVideo_MouseDown(object sender, MouseEventArgs e)
		{
			if (Gnd.i.md == null)
				return;

			if (_currFrame == null)
				return;

			if (e.Button != MouseButtons.Left)
				return;

			XYPoint p = Utils.getPictureBoxPointToImagePoint(this.imgVideo, new XYPoint(e.Location));

			if (p == null)
				return;

			p.toInt();

			Gnd.i.md.ed.v.selectOrig = p;
			Gnd.i.md.ed.v.selectDest = p;
			Gnd.i.md.ed.v.selectRect = null;

			_needRefreshVideoFrameNoSeek = true;
		}

		private void imgVideo_MouseMove(object sender, MouseEventArgs e)
		{
			if (Gnd.i.md == null)
				return;

			if (_currFrame == null)
				return;

			if (Gnd.i.md.ed.v.isSelecting() == false)
				return;

			XYPoint p = Utils.getPictureBoxPointToImagePoint(this.imgVideo, new XYPoint(e.Location), true);

			if (p == null)
				return;

			p.toInt();

			Gnd.i.md.ed.v.selectDest = p;

			_needRefreshVideoFrameNoSeek = true;
		}

		private void imgVideo_MouseUp(object sender, MouseEventArgs e)
		{
			if (Gnd.i.md == null)
				return;

			if (_currFrame == null)
				return;

			if (e.Button != MouseButtons.Left)
				return;

			if (Gnd.i.md.ed.v.isSelecting() == false)
				return;

			Gnd.i.md.ed.v.selectRect = Gnd.i.md.ed.v.getSelectingRect();
			Gnd.i.md.ed.v.selectOrig = null;
			Gnd.i.md.ed.v.selectDest = null;

			_needRefreshVideoFrameNoSeek = true;
			_needRefreshEnable = true;
		}

		private void 画面選択クリアCToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (Gnd.i.md == null)
				return;

			Gnd.i.md.ed.v.clearSelection();

			refreshVideoFrameNoSeek();
			refreshEnable();
		}

		private void 画面選択全選択AToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (Gnd.i.md == null)
				return;

			Gnd.i.md.ed.v.clearSelection();

			if (_currFrame == null)
				return;

			Gnd.i.md.ed.v.selectRect = new Rect(0.0, 0.0, _currFrame.Width, _currFrame.Height);

			refreshVideoFrameNoSeek();
			refreshEnable();
		}

		private void 画面選択数値入力IToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (Gnd.i.md == null)
				return;

			if (_currFrame == null)
				return;

			this.mtEnabled = false;
			this.Visible = false;

			using (VideoSelectWin f = new VideoSelectWin(_currFrame, this.WindowState == FormWindowState.Normal ? getWindowRect() : null))
			{
				f.ShowDialog();

				if (f.retRect != null)
				{
					Gnd.i.md.ed.v.clearSelection();
					Gnd.i.md.ed.v.selectRect = f.retRect;
				}
			}
			this.mtEnabled = true;
			this.Visible = true;

			refreshVideoFrameNoSeek();
			refreshEnable();
		}

		private Rect getWindowRect()
		{
			return new Rect(
				this.Left,
				this.Top,
				this.Width,
				this.Height
				);
		}

		private void 時間選択クリアCToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (Gnd.i.md == null)
				return;

			Gnd.i.md.ed.a.clearSelection();

			refreshEnable();
		}

		private void 時間選択全選択AToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (Gnd.i.md == null)
				return;

			Gnd.i.md.ed.a.selectBegin = 0;
			Gnd.i.md.ed.a.selectEnd = this.seekBar.Maximum;

			refreshEnable();
		}

		private void cm画面選択クリアCToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.画面選択クリアCToolStripMenuItem_Click(null, null);
		}

		private void cm時間選択クリアCToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.時間選択クリアCToolStripMenuItem_Click(null, null);
		}

		private void ここからここまでSToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (Gnd.i.md == null)
				return;

			if (Gnd.i.md.ed.a.selectEnd != -1)
				Gnd.i.md.ed.a.clearSelection();

			if (Gnd.i.md.ed.a.selectBegin == -1)
			{
				Gnd.i.md.ed.a.selectBegin = this.seekBar.Value;
			}
			else
			{
				int value_1 = Gnd.i.md.ed.a.selectBegin;
				int value_2 = this.seekBar.Value;

#if true
				Gnd.i.md.ed.a.selectBegin = Math.Min(value_1, value_2);
				Gnd.i.md.ed.a.selectEnd = Math.Max(value_1, value_2);
#else // old
				if (value_2 < value_1)
				{
					int tmp = value_1;
					value_1 = value_2;
					value_2 = tmp;
				}
				Gnd.i.md.ed.a.selectBegin = value_1;
				Gnd.i.md.ed.a.selectEnd = value_2;
#endif
			}

			refreshEnable();
		}

		private void 先頭からここまでLToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (Gnd.i.md == null)
				return;

			Gnd.i.md.ed.a.selectBegin = 0;
			Gnd.i.md.ed.a.selectEnd = this.seekBar.Value;

			refreshStatus();
			refreshEnable();
		}

		private void ここから終端までRToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (Gnd.i.md == null)
				return;

			Gnd.i.md.ed.a.selectBegin = this.seekBar.Value;
			Gnd.i.md.ed.a.selectEnd = this.seekBar.Maximum;

			refreshStatus();
			refreshEnable();
		}

		private void ffmpegのパスを変更するFToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.mtEnabled = false;

			string oldFFmpegDir = Gnd.i.ffmpegDir;

			using (FFmpegDirDlg f = new FFmpegDirDlg())
			{
				f.ShowDialog();
			}
			if (StringTools.equalsIgnoreCase(oldFFmpegDir, Gnd.i.ffmpegDir) == false)
				MessageBox.Show(
					"変更を反映するには、プログラムを再起動して下さい。",
					"情報",
					MessageBoxButtons.OK,
					MessageBoxIcon.Information
					);

			this.mtEnabled = true;
		}

		private Color _commonLabelBackColor = new Label().BackColor;

		private void refreshEnable()
		{
			bool movieLoaded = Gnd.i.md != null;
			bool videoSelected = movieLoaded && Gnd.i.md.ed.v.selectRect != null;
			bool timeSelecting = movieLoaded && Gnd.i.md.ed.a.isSelecting();
			bool timeSelected = movieLoaded && Gnd.i.md.ed.a.isSelected();
			bool quickSaved = Gnd.i.qsd != null;

			//this.アプリAToolStripMenuItem.Enabled = true;
			//this.ファイルを開くOToolStripMenuItem.Enabled = true;
			this.上書き保存SToolStripMenuItem.Enabled = movieLoaded;
			this.名前を付けて保存AToolStripMenuItem.Enabled = movieLoaded;
			this.ファイルを閉じるCToolStripMenuItem.Enabled = movieLoaded;
			//this.終了XToolStripMenuItem.Enabled = true;

			this.画面選択SToolStripMenuItem.Enabled = movieLoaded;
			this.画面選択クリアCToolStripMenuItem.Enabled = videoSelected;
			this.画面選択全選択AToolStripMenuItem.Enabled = movieLoaded;
			this.画面選択数値入力IToolStripMenuItem.Enabled = movieLoaded;

			this.時間選択TToolStripMenuItem.Enabled = movieLoaded;
			this.時間選択クリアCToolStripMenuItem.Enabled = timeSelected || timeSelecting;
			this.時間選択全選択AToolStripMenuItem.Enabled = movieLoaded;

			this.エフェクトEToolStripMenuItem.Enabled = movieLoaded;
			this.切り捨てるCToolStripMenuItem.Enabled = timeSelected;
			this.ぼかしを入れるBToolStripMenuItem.Enabled = videoSelected && timeSelected;
			this.ぼかし2KToolStripMenuItem.Enabled = videoSelected && timeSelected;
			this.枠外切り捨てToolStripMenuItem.Enabled = videoSelected;
			this.字幕を入れるToolStripMenuItem.Enabled = timeSelected;

			//this.ツールLToolStripMenuItem.Enabled = true;
			//this.設定SToolStripMenuItem.Enabled = true;
			//this.ffmpegのパスを変更するFToolStripMenuItem.Enabled = true;

			// context menu 画面
			this.cm画面選択クリアCToolStripMenuItem.Enabled = videoSelected;

			// context menu シークバー
			this.ここからここまでSToolStripMenuItem.Enabled = movieLoaded;
			this.先頭からここまでLToolStripMenuItem.Enabled = movieLoaded;
			this.ここから終端までRToolStripMenuItem.Enabled = movieLoaded;
			this.cm時間選択クリアCToolStripMenuItem.Enabled = timeSelected || timeSelecting;

			this.btnPrev.Enabled = movieLoaded;
			this.btnNext.Enabled = movieLoaded;

			if (videoSelected)
				this.lbl画面選択.BackColor = Gnd.i.selectColor;
			else
				this.lbl画面選択.BackColor = _commonLabelBackColor;

			if (timeSelecting)
				this.lbl時間選択.BackColor = Gnd.i.selectingColor;
			else if (timeSelected)
				this.lbl時間選択.BackColor = Gnd.i.selectColor;
			else
				this.lbl時間選択.BackColor = _commonLabelBackColor;

			this.クイックセーブVToolStripMenuItem.Enabled = movieLoaded;
			this.quickSaveMenuItem.Enabled = movieLoaded;
			this.quickLoadMenuItem.Enabled = movieLoaded && quickSaved;
		}

		private void 切り捨てるCToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (Gnd.i.md == null)
				return;

			this.mtEnabled = false;

			try
			{
				if (MessageBox.Show(
					"時間選択された範囲をカットします。",
					"エフェクト：切り捨てる",
					MessageBoxButtons.OKCancel,
					MessageBoxIcon.Information
					) != DialogResult.OK
					)
					throw new Ended();

				BusyDlg.perform(delegate
				{
					new EffectCut().perform();
				});

				// 切り取った範囲が、動画の長さの範囲外になる場合があるため。
				{
					this.seekBar.Value = Gnd.i.md.ed.a.selectBegin;
					Gnd.i.md.ed.a.clearSelection();
				}

				throw new Completed();
			}
			catch (Exception ex)
			{
				FailedOperation.caught(ex);
			}

			refreshVideo();
			refreshStatus();
			refreshEnable(); // 時間選択解除されるので！

			this.mtEnabled = true;
		}

		private void ぼかしを入れるBToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (Gnd.i.md == null)
				return;

			this.mtEnabled = false;

			try
			{
				if (MessageBox.Show(
					"画面選択・時間選択された範囲にぼかしを入れます。\nこの処理には時間が掛かります。",
					"ぼかし１",
					MessageBoxButtons.OKCancel,
					MessageBoxIcon.Information
					) != DialogResult.OK
					)
					throw new Ended();

				Gnd.i.cancelled = false;

				BusyDlg.perform(delegate
				{
					new EffectBokashi().perform();
				},
				this,
				true
				);

				throw new Completed();
			}
			catch (Exception ex)
			{
				FailedOperation.caught(ex);
			}

			refreshVideoFrame();
			refreshStatus();

			this.mtEnabled = true;
		}

		private void ぼかし2KToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (Gnd.i.md == null)
				return;

			this.mtEnabled = false;

			try
			{
				if (MessageBox.Show(
					"画面選択・時間選択された範囲にぼかしを「強めに」入れます。\nこの処理には時間が掛かります。",
					"ぼかし２",
					MessageBoxButtons.OKCancel,
					MessageBoxIcon.Information
					) != DialogResult.OK
					)
					throw new Ended();

				Gnd.i.cancelled = false;

				BusyDlg.perform(delegate
				{
					new EffectBokashi().perform(true);
				},
				this,
				true
				);

				throw new Completed();
			}
			catch (Exception ex)
			{
				FailedOperation.caught(ex);
			}

			refreshVideoFrame();
			refreshStatus();

			this.mtEnabled = true;
		}

		private void 枠外切り捨てToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (Gnd.i.md == null)
				return;

			this.mtEnabled = false;

			try
			{
				if (MessageBox.Show(
					"画面選択された範囲外を切り捨てます。",
					"枠外切り捨て",
					MessageBoxButtons.OKCancel,
					MessageBoxIcon.Information
					) != DialogResult.OK
					)
					throw new Ended();

				BusyDlg.perform(delegate
				{
					new Effect枠外切り捨て().perform();
				});

				throw new Completed();
			}
			catch (Exception ex)
			{
				FailedOperation.caught(ex);
			}

			refreshVideoFrame();
			refreshStatus();

			this.mtEnabled = true;
		}

		private void 字幕を入れるToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (Gnd.i.md == null)
				return;

			this.mtEnabled = false;

			try
			{
				using (Input字幕Dlg f = new Input字幕Dlg())
				{
					f.ShowDialog();

					if (f.OkPressed)
					{
						BusyDlg.perform(delegate
						{
							new Effect字幕入力().perform(f.Ret_Line1, f.Ret_Align1, f.Ret_Line2, f.Ret_Align2);
						});

						throw new Completed();
					}
				}
			}
			catch (Exception ex)
			{
				FailedOperation.caught(ex);
			}

			refreshVideoFrame();
			refreshStatus();

			this.mtEnabled = true;
		}

		private void quickSaveMenuItem_Click(object sender, EventArgs e)
		{
			this.mtEnabled = false;

			try
			{
				if (Gnd.i.md == null)
					throw new FailedOperation("ファイルを開いていないのでクイックセーブ出来ません。");

				BusyDlg.perform(() =>
				{
					if (Gnd.i.qsd != null)
						Gnd.i.qsd.Dispose();

					Gnd.i.qsd = Gnd.i.md.quickSave();
				});

				throw new Completed();
			}
			catch (Exception ex)
			{
				FailedOperation.caught(ex);
			}

			refreshEnable();

			this.mtEnabled = true;
		}

		private void quickLoadMenuItem_Click(object sender, EventArgs e)
		{
			this.mtEnabled = false;

			try
			{
				if (Gnd.i.qsd == null)
					throw new FailedOperation("クイックセーブしていません。");

				if (Gnd.i.md == null)
					throw new FailedOperation("ファイルを開いていないのでクイックロード出来ません。");

				BusyDlg.perform(() =>
				{
					Gnd.i.md.quickLoad(Gnd.i.qsd);
				});

				throw new Completed();
			}
			catch (Exception ex)
			{
				FailedOperation.caught(ex);
			}

			// 全部リフレッシュする。
			{
				refreshVideo();
				refreshStatus();
				refreshEnable();
			}

			this.mtEnabled = true;
		}
	}
}
