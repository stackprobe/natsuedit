namespace Charlotte
{
	partial class FFmpegDirDlg
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FFmpegDirDlg));
			this.label1 = new System.Windows.Forms.Label();
			this.txtFFmpegDir = new System.Windows.Forms.TextBox();
			this.btnFFmpegDir = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOk = new System.Windows.Forms.Button();
			this.lblExample = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 40);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(132, 20);
			this.label1.TabIndex = 0;
			this.label1.Text = "ffmpegのフォルダ：";
			// 
			// txtFFmpegDir
			// 
			this.txtFFmpegDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtFFmpegDir.Location = new System.Drawing.Point(150, 37);
			this.txtFFmpegDir.Name = "txtFFmpegDir";
			this.txtFFmpegDir.ReadOnly = true;
			this.txtFFmpegDir.Size = new System.Drawing.Size(325, 27);
			this.txtFFmpegDir.TabIndex = 1;
			this.txtFFmpegDir.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFFmpegDir_KeyPress);
			// 
			// btnFFmpegDir
			// 
			this.btnFFmpegDir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnFFmpegDir.Location = new System.Drawing.Point(475, 37);
			this.btnFFmpegDir.Name = "btnFFmpegDir";
			this.btnFFmpegDir.Size = new System.Drawing.Size(37, 27);
			this.btnFFmpegDir.TabIndex = 2;
			this.btnFFmpegDir.Text = "...";
			this.btnFFmpegDir.UseVisualStyleBackColor = true;
			this.btnFFmpegDir.Click += new System.EventHandler(this.btnFFmpegDir_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.Location = new System.Drawing.Point(401, 107);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(111, 43);
			this.btnCancel.TabIndex = 4;
			this.btnCancel.Text = "キャンセル";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnOk
			// 
			this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOk.Location = new System.Drawing.Point(284, 107);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(111, 43);
			this.btnOk.TabIndex = 3;
			this.btnOk.Text = "OK";
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// lblExample
			// 
			this.lblExample.AutoSize = true;
			this.lblExample.Location = new System.Drawing.Point(146, 67);
			this.lblExample.Name = "lblExample";
			this.lblExample.Size = new System.Drawing.Size(265, 20);
			this.lblExample.TabIndex = 5;
			this.lblExample.Text = "例) C:\\app\\ffmpeg-3.2.4-win64-shared";
			// 
			// FFmpegDirDlg
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(524, 162);
			this.Controls.Add(this.lblExample);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnFFmpegDir);
			this.Controls.Add(this.txtFFmpegDir);
			this.Controls.Add(this.label1);
			this.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FFmpegDirDlg";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "夏Edit";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FFmpegDirDlg_FormClosing);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FFmpegDirDlg_FormClosed);
			this.Load += new System.EventHandler(this.FFmpegDirDlg_Load);
			this.Shown += new System.EventHandler(this.FFmpegDirDlg_Shown);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtFFmpegDir;
		private System.Windows.Forms.Button btnFFmpegDir;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Label lblExample;
	}
}
