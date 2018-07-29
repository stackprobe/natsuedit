namespace Charlotte
{
	partial class MainWin
	{
		/// <summary>
		/// 必要なデザイナー変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows フォーム デザイナーで生成されたコード

		/// <summary>
		/// デザイナー サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディターで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWin));
			this.seekBar = new System.Windows.Forms.TrackBar();
			this.audioContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.ここからここまでSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.先頭からここまでLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ここから終端までRToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
			this.cm時間選択クリアCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.videoContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.cm画面選択クリアCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.imgVideo = new System.Windows.Forms.PictureBox();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
			this.lbl画面選択 = new System.Windows.Forms.ToolStripStatusLabel();
			this.lbl時間選択 = new System.Windows.Forms.ToolStripStatusLabel();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.アプリAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ファイルを開くOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.上書き保存SToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.名前を付けて保存AToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
			this.ファイルを閉じるCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.終了XToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.画面選択SToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.画面選択クリアCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.画面選択全選択AToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
			this.画面選択数値入力IToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.時間選択TToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.時間選択クリアCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.時間選択全選択AToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.エフェクトEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.切り捨てるCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ぼかしを入れるBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ぼかし2KToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.枠外切り捨てToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.字幕を入れるToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ツールLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.設定SToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ffmpegのパスを変更するFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.クイックセーブVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.quickSaveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
			this.quickLoadMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.btnPrev = new System.Windows.Forms.Button();
			this.btnNext = new System.Windows.Forms.Button();
			this.mainTimer = new System.Windows.Forms.Timer(this.components);
			((System.ComponentModel.ISupportInitialize)(this.seekBar)).BeginInit();
			this.audioContextMenu.SuspendLayout();
			this.videoContextMenu.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.imgVideo)).BeginInit();
			this.statusStrip1.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// seekBar
			// 
			this.seekBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.seekBar.ContextMenuStrip = this.audioContextMenu;
			this.seekBar.Location = new System.Drawing.Point(114, 192);
			this.seekBar.Name = "seekBar";
			this.seekBar.Size = new System.Drawing.Size(458, 45);
			this.seekBar.TabIndex = 3;
			this.seekBar.ValueChanged += new System.EventHandler(this.seekBar_ValueChanged);
			// 
			// audioContextMenu
			// 
			this.audioContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ここからここまでSToolStripMenuItem,
            this.先頭からここまでLToolStripMenuItem,
            this.ここから終端までRToolStripMenuItem,
            this.toolStripMenuItem3,
            this.cm時間選択クリアCToolStripMenuItem});
			this.audioContextMenu.Name = "audioContextMenu";
			this.audioContextMenu.Size = new System.Drawing.Size(168, 98);
			// 
			// ここからここまでSToolStripMenuItem
			// 
			this.ここからここまでSToolStripMenuItem.Name = "ここからここまでSToolStripMenuItem";
			this.ここからここまでSToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
			this.ここからここまでSToolStripMenuItem.Text = "ここから・ここまで(&S)";
			this.ここからここまでSToolStripMenuItem.Click += new System.EventHandler(this.ここからここまでSToolStripMenuItem_Click);
			// 
			// 先頭からここまでLToolStripMenuItem
			// 
			this.先頭からここまでLToolStripMenuItem.Name = "先頭からここまでLToolStripMenuItem";
			this.先頭からここまでLToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
			this.先頭からここまでLToolStripMenuItem.Text = "先頭からここまで(&L)";
			this.先頭からここまでLToolStripMenuItem.Click += new System.EventHandler(this.先頭からここまでLToolStripMenuItem_Click);
			// 
			// ここから終端までRToolStripMenuItem
			// 
			this.ここから終端までRToolStripMenuItem.Name = "ここから終端までRToolStripMenuItem";
			this.ここから終端までRToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
			this.ここから終端までRToolStripMenuItem.Text = "ここから終端まで(&R)";
			this.ここから終端までRToolStripMenuItem.Click += new System.EventHandler(this.ここから終端までRToolStripMenuItem_Click);
			// 
			// toolStripMenuItem3
			// 
			this.toolStripMenuItem3.Name = "toolStripMenuItem3";
			this.toolStripMenuItem3.Size = new System.Drawing.Size(164, 6);
			// 
			// cm時間選択クリアCToolStripMenuItem
			// 
			this.cm時間選択クリアCToolStripMenuItem.Name = "cm時間選択クリアCToolStripMenuItem";
			this.cm時間選択クリアCToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
			this.cm時間選択クリアCToolStripMenuItem.Text = "選択クリア(&C)";
			this.cm時間選択クリアCToolStripMenuItem.Click += new System.EventHandler(this.cm時間選択クリアCToolStripMenuItem_Click);
			// 
			// videoContextMenu
			// 
			this.videoContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cm画面選択クリアCToolStripMenuItem});
			this.videoContextMenu.Name = "contextMenu";
			this.videoContextMenu.Size = new System.Drawing.Size(140, 26);
			// 
			// cm画面選択クリアCToolStripMenuItem
			// 
			this.cm画面選択クリアCToolStripMenuItem.Name = "cm画面選択クリアCToolStripMenuItem";
			this.cm画面選択クリアCToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
			this.cm画面選択クリアCToolStripMenuItem.Text = "選択クリア(&C)";
			this.cm画面選択クリアCToolStripMenuItem.Click += new System.EventHandler(this.cm画面選択クリアCToolStripMenuItem_Click);
			// 
			// imgVideo
			// 
			this.imgVideo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.imgVideo.BackColor = System.Drawing.Color.Silver;
			this.imgVideo.ContextMenuStrip = this.videoContextMenu;
			this.imgVideo.Location = new System.Drawing.Point(12, 29);
			this.imgVideo.Name = "imgVideo";
			this.imgVideo.Size = new System.Drawing.Size(560, 157);
			this.imgVideo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.imgVideo.TabIndex = 1;
			this.imgVideo.TabStop = false;
			this.imgVideo.Click += new System.EventHandler(this.imgVideo_Click);
			this.imgVideo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.imgVideo_MouseDown);
			this.imgVideo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.imgVideo_MouseMove);
			this.imgVideo.MouseUp += new System.Windows.Forms.MouseEventHandler(this.imgVideo_MouseUp);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus,
            this.lbl画面選択,
            this.lbl時間選択});
			this.statusStrip1.Location = new System.Drawing.Point(0, 240);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(584, 22);
			this.statusStrip1.TabIndex = 4;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// lblStatus
			// 
			this.lblStatus.Name = "lblStatus";
			this.lblStatus.Size = new System.Drawing.Size(507, 17);
			this.lblStatus.Spring = true;
			this.lblStatus.Text = "準備しています...";
			this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbl画面選択
			// 
			this.lbl画面選択.Name = "lbl画面選択";
			this.lbl画面選択.Size = new System.Drawing.Size(31, 17);
			this.lbl画面選択.Text = "画面";
			// 
			// lbl時間選択
			// 
			this.lbl時間選択.Name = "lbl時間選択";
			this.lbl時間選択.Size = new System.Drawing.Size(31, 17);
			this.lbl時間選択.Text = "時間";
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.アプリAToolStripMenuItem,
            this.画面選択SToolStripMenuItem,
            this.時間選択TToolStripMenuItem,
            this.エフェクトEToolStripMenuItem,
            this.クイックセーブVToolStripMenuItem,
            this.ツールLToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(584, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// アプリAToolStripMenuItem
			// 
			this.アプリAToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ファイルを開くOToolStripMenuItem,
            this.toolStripMenuItem1,
            this.上書き保存SToolStripMenuItem,
            this.名前を付けて保存AToolStripMenuItem,
            this.toolStripMenuItem2,
            this.ファイルを閉じるCToolStripMenuItem,
            this.終了XToolStripMenuItem});
			this.アプリAToolStripMenuItem.Name = "アプリAToolStripMenuItem";
			this.アプリAToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
			this.アプリAToolStripMenuItem.Text = "アプリ(&A)";
			// 
			// ファイルを開くOToolStripMenuItem
			// 
			this.ファイルを開くOToolStripMenuItem.Name = "ファイルを開くOToolStripMenuItem";
			this.ファイルを開くOToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
			this.ファイルを開くOToolStripMenuItem.Text = "ファイルを開く(&O)";
			this.ファイルを開くOToolStripMenuItem.Click += new System.EventHandler(this.ファイルを開くOToolStripMenuItem_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(174, 6);
			// 
			// 上書き保存SToolStripMenuItem
			// 
			this.上書き保存SToolStripMenuItem.Name = "上書き保存SToolStripMenuItem";
			this.上書き保存SToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
			this.上書き保存SToolStripMenuItem.Text = "上書き保存(&S)";
			this.上書き保存SToolStripMenuItem.Click += new System.EventHandler(this.上書き保存SToolStripMenuItem_Click);
			// 
			// 名前を付けて保存AToolStripMenuItem
			// 
			this.名前を付けて保存AToolStripMenuItem.Name = "名前を付けて保存AToolStripMenuItem";
			this.名前を付けて保存AToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
			this.名前を付けて保存AToolStripMenuItem.Text = "名前を付けて保存(&A)";
			this.名前を付けて保存AToolStripMenuItem.Click += new System.EventHandler(this.名前を付けて保存AToolStripMenuItem_Click);
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(174, 6);
			// 
			// ファイルを閉じるCToolStripMenuItem
			// 
			this.ファイルを閉じるCToolStripMenuItem.Name = "ファイルを閉じるCToolStripMenuItem";
			this.ファイルを閉じるCToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
			this.ファイルを閉じるCToolStripMenuItem.Text = "ファイルを閉じる(&C)";
			this.ファイルを閉じるCToolStripMenuItem.Click += new System.EventHandler(this.ファイルを閉じるCToolStripMenuItem_Click);
			// 
			// 終了XToolStripMenuItem
			// 
			this.終了XToolStripMenuItem.Name = "終了XToolStripMenuItem";
			this.終了XToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
			this.終了XToolStripMenuItem.Text = "終了(&X)";
			this.終了XToolStripMenuItem.Click += new System.EventHandler(this.終了XToolStripMenuItem_Click);
			// 
			// 画面選択SToolStripMenuItem
			// 
			this.画面選択SToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.画面選択クリアCToolStripMenuItem,
            this.画面選択全選択AToolStripMenuItem,
            this.toolStripMenuItem4,
            this.画面選択数値入力IToolStripMenuItem});
			this.画面選択SToolStripMenuItem.Name = "画面選択SToolStripMenuItem";
			this.画面選択SToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
			this.画面選択SToolStripMenuItem.Text = "画面選択(&S)";
			// 
			// 画面選択クリアCToolStripMenuItem
			// 
			this.画面選択クリアCToolStripMenuItem.Name = "画面選択クリアCToolStripMenuItem";
			this.画面選択クリアCToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.画面選択クリアCToolStripMenuItem.Text = "選択クリア(&C)";
			this.画面選択クリアCToolStripMenuItem.Click += new System.EventHandler(this.画面選択クリアCToolStripMenuItem_Click);
			// 
			// 画面選択全選択AToolStripMenuItem
			// 
			this.画面選択全選択AToolStripMenuItem.Name = "画面選択全選択AToolStripMenuItem";
			this.画面選択全選択AToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.画面選択全選択AToolStripMenuItem.Text = "全選択(&A)";
			this.画面選択全選択AToolStripMenuItem.Click += new System.EventHandler(this.画面選択全選択AToolStripMenuItem_Click);
			// 
			// toolStripMenuItem4
			// 
			this.toolStripMenuItem4.Name = "toolStripMenuItem4";
			this.toolStripMenuItem4.Size = new System.Drawing.Size(149, 6);
			// 
			// 画面選択数値入力IToolStripMenuItem
			// 
			this.画面選択数値入力IToolStripMenuItem.Name = "画面選択数値入力IToolStripMenuItem";
			this.画面選択数値入力IToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.画面選択数値入力IToolStripMenuItem.Text = "数値入力(&I)";
			this.画面選択数値入力IToolStripMenuItem.Click += new System.EventHandler(this.画面選択数値入力IToolStripMenuItem_Click);
			// 
			// 時間選択TToolStripMenuItem
			// 
			this.時間選択TToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.時間選択クリアCToolStripMenuItem,
            this.時間選択全選択AToolStripMenuItem});
			this.時間選択TToolStripMenuItem.Name = "時間選択TToolStripMenuItem";
			this.時間選択TToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
			this.時間選択TToolStripMenuItem.Text = "時間選択(&T)";
			// 
			// 時間選択クリアCToolStripMenuItem
			// 
			this.時間選択クリアCToolStripMenuItem.Name = "時間選択クリアCToolStripMenuItem";
			this.時間選択クリアCToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.時間選択クリアCToolStripMenuItem.Text = "選択クリア(&C)";
			this.時間選択クリアCToolStripMenuItem.Click += new System.EventHandler(this.時間選択クリアCToolStripMenuItem_Click);
			// 
			// 時間選択全選択AToolStripMenuItem
			// 
			this.時間選択全選択AToolStripMenuItem.Name = "時間選択全選択AToolStripMenuItem";
			this.時間選択全選択AToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.時間選択全選択AToolStripMenuItem.Text = "全選択(&A)";
			this.時間選択全選択AToolStripMenuItem.Click += new System.EventHandler(this.時間選択全選択AToolStripMenuItem_Click);
			// 
			// エフェクトEToolStripMenuItem
			// 
			this.エフェクトEToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.切り捨てるCToolStripMenuItem,
            this.ぼかしを入れるBToolStripMenuItem,
            this.ぼかし2KToolStripMenuItem,
            this.枠外切り捨てToolStripMenuItem,
            this.字幕を入れるToolStripMenuItem});
			this.エフェクトEToolStripMenuItem.Name = "エフェクトEToolStripMenuItem";
			this.エフェクトEToolStripMenuItem.Size = new System.Drawing.Size(74, 20);
			this.エフェクトEToolStripMenuItem.Text = "エフェクト(&E)";
			// 
			// 切り捨てるCToolStripMenuItem
			// 
			this.切り捨てるCToolStripMenuItem.Name = "切り捨てるCToolStripMenuItem";
			this.切り捨てるCToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
			this.切り捨てるCToolStripMenuItem.Text = "切り捨てる　【時間選択】";
			this.切り捨てるCToolStripMenuItem.Click += new System.EventHandler(this.切り捨てるCToolStripMenuItem_Click);
			// 
			// ぼかしを入れるBToolStripMenuItem
			// 
			this.ぼかしを入れるBToolStripMenuItem.Name = "ぼかしを入れるBToolStripMenuItem";
			this.ぼかしを入れるBToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
			this.ぼかしを入れるBToolStripMenuItem.Text = "ぼかし１　【画面+時間選択】";
			this.ぼかしを入れるBToolStripMenuItem.Click += new System.EventHandler(this.ぼかしを入れるBToolStripMenuItem_Click);
			// 
			// ぼかし2KToolStripMenuItem
			// 
			this.ぼかし2KToolStripMenuItem.Name = "ぼかし2KToolStripMenuItem";
			this.ぼかし2KToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
			this.ぼかし2KToolStripMenuItem.Text = "ぼかし２　【画面+時間選択】";
			this.ぼかし2KToolStripMenuItem.Click += new System.EventHandler(this.ぼかし2KToolStripMenuItem_Click);
			// 
			// 枠外切り捨てToolStripMenuItem
			// 
			this.枠外切り捨てToolStripMenuItem.Name = "枠外切り捨てToolStripMenuItem";
			this.枠外切り捨てToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
			this.枠外切り捨てToolStripMenuItem.Text = "枠外切り捨て　【画面選択】";
			this.枠外切り捨てToolStripMenuItem.Click += new System.EventHandler(this.枠外切り捨てToolStripMenuItem_Click);
			// 
			// 字幕を入れるToolStripMenuItem
			// 
			this.字幕を入れるToolStripMenuItem.Name = "字幕を入れるToolStripMenuItem";
			this.字幕を入れるToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
			this.字幕を入れるToolStripMenuItem.Text = "字幕を入れる　【時間選択】";
			this.字幕を入れるToolStripMenuItem.Click += new System.EventHandler(this.字幕を入れるToolStripMenuItem_Click);
			// 
			// ツールLToolStripMenuItem
			// 
			this.ツールLToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.設定SToolStripMenuItem,
            this.ffmpegのパスを変更するFToolStripMenuItem});
			this.ツールLToolStripMenuItem.Name = "ツールLToolStripMenuItem";
			this.ツールLToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
			this.ツールLToolStripMenuItem.Text = "ツール(&L)";
			// 
			// 設定SToolStripMenuItem
			// 
			this.設定SToolStripMenuItem.Name = "設定SToolStripMenuItem";
			this.設定SToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
			this.設定SToolStripMenuItem.Text = "設定(&S)";
			this.設定SToolStripMenuItem.Click += new System.EventHandler(this.設定SToolStripMenuItem_Click);
			// 
			// ffmpegのパスを変更するFToolStripMenuItem
			// 
			this.ffmpegのパスを変更するFToolStripMenuItem.Name = "ffmpegのパスを変更するFToolStripMenuItem";
			this.ffmpegのパスを変更するFToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
			this.ffmpegのパスを変更するFToolStripMenuItem.Text = "ffmpegのパスを変更する(&F)";
			this.ffmpegのパスを変更するFToolStripMenuItem.Click += new System.EventHandler(this.ffmpegのパスを変更するFToolStripMenuItem_Click);
			// 
			// クイックセーブVToolStripMenuItem
			// 
			this.クイックセーブVToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quickSaveMenuItem,
            this.toolStripMenuItem5,
            this.quickLoadMenuItem});
			this.クイックセーブVToolStripMenuItem.Name = "クイックセーブVToolStripMenuItem";
			this.クイックセーブVToolStripMenuItem.Size = new System.Drawing.Size(96, 20);
			this.クイックセーブVToolStripMenuItem.Text = "クイックセーブ(&V)";
			// 
			// quickSaveMenuItem
			// 
			this.quickSaveMenuItem.Name = "quickSaveMenuItem";
			this.quickSaveMenuItem.Size = new System.Drawing.Size(153, 22);
			this.quickSaveMenuItem.Text = "クイックセーブ(&V)";
			this.quickSaveMenuItem.Click += new System.EventHandler(this.quickSaveMenuItem_Click);
			// 
			// toolStripMenuItem5
			// 
			this.toolStripMenuItem5.Name = "toolStripMenuItem5";
			this.toolStripMenuItem5.Size = new System.Drawing.Size(150, 6);
			// 
			// quickLoadMenuItem
			// 
			this.quickLoadMenuItem.Name = "quickLoadMenuItem";
			this.quickLoadMenuItem.Size = new System.Drawing.Size(153, 22);
			this.quickLoadMenuItem.Text = "クイックロード(&W)";
			this.quickLoadMenuItem.Click += new System.EventHandler(this.quickLoadMenuItem_Click);
			// 
			// btnPrev
			// 
			this.btnPrev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnPrev.Location = new System.Drawing.Point(12, 192);
			this.btnPrev.Name = "btnPrev";
			this.btnPrev.Size = new System.Drawing.Size(45, 45);
			this.btnPrev.TabIndex = 1;
			this.btnPrev.Text = "<";
			this.btnPrev.UseVisualStyleBackColor = true;
			this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
			// 
			// btnNext
			// 
			this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnNext.Location = new System.Drawing.Point(63, 192);
			this.btnNext.Name = "btnNext";
			this.btnNext.Size = new System.Drawing.Size(45, 45);
			this.btnNext.TabIndex = 2;
			this.btnNext.Text = ">";
			this.btnNext.UseVisualStyleBackColor = true;
			this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
			// 
			// mainTimer
			// 
			this.mainTimer.Enabled = true;
			this.mainTimer.Tick += new System.EventHandler(this.mainTimer_Tick);
			// 
			// MainWin
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(584, 262);
			this.Controls.Add(this.btnNext);
			this.Controls.Add(this.btnPrev);
			this.Controls.Add(this.imgVideo);
			this.Controls.Add(this.seekBar);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.menuStrip1);
			this.DoubleBuffered = true;
			this.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.Name = "MainWin";
			this.Text = "夏Edit";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWin_FormClosing);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainWin_FormClosed);
			this.Load += new System.EventHandler(this.MainWin_Load);
			this.Shown += new System.EventHandler(this.MainWin_Shown);
			this.ResizeEnd += new System.EventHandler(this.MainWin_ResizeEnd);
			this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainWin_DragDrop);
			this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainWin_DragEnter);
			this.Move += new System.EventHandler(this.MainWin_Move);
			((System.ComponentModel.ISupportInitialize)(this.seekBar)).EndInit();
			this.audioContextMenu.ResumeLayout(false);
			this.videoContextMenu.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.imgVideo)).EndInit();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TrackBar seekBar;
		private System.Windows.Forms.PictureBox imgVideo;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem アプリAToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 終了XToolStripMenuItem;
		private System.Windows.Forms.Button btnPrev;
		private System.Windows.Forms.Button btnNext;
		private System.Windows.Forms.Timer mainTimer;
		private System.Windows.Forms.ToolStripStatusLabel lblStatus;
		private System.Windows.Forms.ToolStripMenuItem ファイルを開くOToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem 上書き保存SToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 名前を付けて保存AToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem ファイルを閉じるCToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 画面選択SToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 時間選択TToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ツールLToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 設定SToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 画面選択クリアCToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 時間選択クリアCToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 画面選択数値入力IToolStripMenuItem;
		private System.Windows.Forms.ContextMenuStrip videoContextMenu;
		private System.Windows.Forms.ToolStripMenuItem 画面選択全選択AToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 時間選択全選択AToolStripMenuItem;
		private System.Windows.Forms.ContextMenuStrip audioContextMenu;
		private System.Windows.Forms.ToolStripMenuItem ここからここまでSToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem cm時間選択クリアCToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem cm画面選択クリアCToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem エフェクトEToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ぼかしを入れるBToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 切り捨てるCToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 先頭からここまでLToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ここから終端までRToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
		private System.Windows.Forms.ToolStripMenuItem ffmpegのパスを変更するFToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ぼかし2KToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 枠外切り捨てToolStripMenuItem;
		private System.Windows.Forms.ToolStripStatusLabel lbl画面選択;
		private System.Windows.Forms.ToolStripStatusLabel lbl時間選択;
		private System.Windows.Forms.ToolStripMenuItem 字幕を入れるToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem クイックセーブVToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem quickSaveMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
		private System.Windows.Forms.ToolStripMenuItem quickLoadMenuItem;
	}
}

