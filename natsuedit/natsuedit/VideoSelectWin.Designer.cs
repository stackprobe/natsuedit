namespace Charlotte
{
	partial class VideoSelectWin
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VideoSelectWin));
			this.label1 = new System.Windows.Forms.Label();
			this.txtL = new System.Windows.Forms.TextBox();
			this.txtT = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtH = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtW = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.imgFrame = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.imgFrame)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(28, 20);
			this.label1.TabIndex = 0;
			this.label1.Text = "左:";
			// 
			// txtL
			// 
			this.txtL.Location = new System.Drawing.Point(46, 12);
			this.txtL.MaxLength = 5;
			this.txtL.Name = "txtL";
			this.txtL.Size = new System.Drawing.Size(60, 27);
			this.txtL.TabIndex = 1;
			this.txtL.Text = "123456";
			this.txtL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtL.TextChanged += new System.EventHandler(this.txtL_TextChanged);
			this.txtL.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtL_KeyPress);
			// 
			// txtT
			// 
			this.txtT.Location = new System.Drawing.Point(146, 12);
			this.txtT.MaxLength = 5;
			this.txtT.Name = "txtT";
			this.txtT.Size = new System.Drawing.Size(60, 27);
			this.txtT.TabIndex = 3;
			this.txtT.Text = "123456";
			this.txtT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtT.TextChanged += new System.EventHandler(this.txtT_TextChanged);
			this.txtT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtT_KeyPress);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(112, 15);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(28, 20);
			this.label2.TabIndex = 2;
			this.label2.Text = "上:";
			// 
			// txtH
			// 
			this.txtH.Location = new System.Drawing.Point(359, 12);
			this.txtH.MaxLength = 5;
			this.txtH.Name = "txtH";
			this.txtH.Size = new System.Drawing.Size(60, 27);
			this.txtH.TabIndex = 7;
			this.txtH.Text = "123456";
			this.txtH.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtH.TextChanged += new System.EventHandler(this.txtH_TextChanged);
			this.txtH.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtH_KeyPress);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(312, 15);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(41, 20);
			this.label3.TabIndex = 6;
			this.label3.Text = "高さ:";
			// 
			// txtW
			// 
			this.txtW.Location = new System.Drawing.Point(246, 12);
			this.txtW.MaxLength = 5;
			this.txtW.Name = "txtW";
			this.txtW.Size = new System.Drawing.Size(60, 27);
			this.txtW.TabIndex = 5;
			this.txtW.Text = "123456";
			this.txtW.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtW.TextChanged += new System.EventHandler(this.txtW_TextChanged);
			this.txtW.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtW_KeyPress);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(212, 15);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(28, 20);
			this.label4.TabIndex = 4;
			this.label4.Text = "幅:";
			// 
			// imgFrame
			// 
			this.imgFrame.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.imgFrame.BackColor = System.Drawing.Color.Silver;
			this.imgFrame.Location = new System.Drawing.Point(12, 45);
			this.imgFrame.Name = "imgFrame";
			this.imgFrame.Size = new System.Drawing.Size(460, 205);
			this.imgFrame.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.imgFrame.TabIndex = 8;
			this.imgFrame.TabStop = false;
			// 
			// VideoSelectWin
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(484, 262);
			this.Controls.Add(this.imgFrame);
			this.Controls.Add(this.txtH);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtW);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txtT);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtL);
			this.Controls.Add(this.label1);
			this.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.Name = "VideoSelectWin";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "画面選択";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SelectVideoWin_FormClosing);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SelectVideoWin_FormClosed);
			this.Load += new System.EventHandler(this.SelectVideoWin_Load);
			this.Shown += new System.EventHandler(this.SelectVideoWin_Shown);
			((System.ComponentModel.ISupportInitialize)(this.imgFrame)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtL;
		private System.Windows.Forms.TextBox txtT;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtH;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtW;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.PictureBox imgFrame;
	}
}
