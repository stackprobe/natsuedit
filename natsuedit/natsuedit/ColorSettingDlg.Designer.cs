namespace Charlotte
{
	partial class ColorSettingDlg
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ColorSettingDlg));
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.pbSample = new System.Windows.Forms.PictureBox();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOk = new System.Windows.Forms.Button();
			this.tbAlpha = new System.Windows.Forms.TrackBar();
			this.label1 = new System.Windows.Forms.Label();
			this.btnRGB = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbSample)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tbAlpha)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.groupBox1.Controls.Add(this.pbSample);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(337, 288);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "サンプル";
			// 
			// pbSample
			// 
			this.pbSample.Location = new System.Drawing.Point(6, 26);
			this.pbSample.Name = "pbSample";
			this.pbSample.Size = new System.Drawing.Size(320, 250);
			this.pbSample.TabIndex = 0;
			this.pbSample.TabStop = false;
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.Location = new System.Drawing.Point(537, 254);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(111, 46);
			this.btnCancel.TabIndex = 5;
			this.btnCancel.Text = "キャンセル";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnOk
			// 
			this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOk.Location = new System.Drawing.Point(420, 254);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(111, 46);
			this.btnOk.TabIndex = 4;
			this.btnOk.Text = "OK";
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// tbAlpha
			// 
			this.tbAlpha.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbAlpha.Location = new System.Drawing.Point(355, 203);
			this.tbAlpha.Maximum = 15;
			this.tbAlpha.Name = "tbAlpha";
			this.tbAlpha.Size = new System.Drawing.Size(293, 45);
			this.tbAlpha.TabIndex = 3;
			this.tbAlpha.Value = 1;
			this.tbAlpha.ValueChanged += new System.EventHandler(this.tbAlpha_ValueChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(358, 180);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(87, 20);
			this.label1.TabIndex = 2;
			this.label1.Text = "アルファ値：";
			// 
			// btnRGB
			// 
			this.btnRGB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnRGB.Location = new System.Drawing.Point(355, 38);
			this.btnRGB.Name = "btnRGB";
			this.btnRGB.Size = new System.Drawing.Size(293, 130);
			this.btnRGB.TabIndex = 1;
			this.btnRGB.Text = "RGB選択";
			this.btnRGB.UseVisualStyleBackColor = true;
			this.btnRGB.Click += new System.EventHandler(this.btnRGB_Click);
			// 
			// ColorSettingDlg
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(660, 312);
			this.Controls.Add(this.btnRGB);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.tbAlpha);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.groupBox1);
			this.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ColorSettingDlg";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "色を設定して下さい";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ColorSettingDlg_FormClosing);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ColorSettingDlg_FormClosed);
			this.Load += new System.EventHandler(this.ColorSettingDlg_Load);
			this.Shown += new System.EventHandler(this.ColorSettingDlg_Shown);
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pbSample)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tbAlpha)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.PictureBox pbSample;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.TrackBar tbAlpha;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnRGB;
	}
}
