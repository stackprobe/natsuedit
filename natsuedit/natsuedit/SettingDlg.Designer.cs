namespace Charlotte
{
	partial class SettingDlg
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingDlg));
			this.lblSelectingColor = new System.Windows.Forms.Label();
			this.lblSelectColor = new System.Windows.Forms.Label();
			this.btnSelectColor = new System.Windows.Forms.Button();
			this.btnSelectingColor = new System.Windows.Forms.Button();
			this.cbファイルを閉じるとき保存するか確認しない = new System.Windows.Forms.CheckBox();
			this.btnOk = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// lblSelectingColor
			// 
			this.lblSelectingColor.AutoSize = true;
			this.lblSelectingColor.Location = new System.Drawing.Point(27, 37);
			this.lblSelectingColor.Name = "lblSelectingColor";
			this.lblSelectingColor.Size = new System.Drawing.Size(223, 20);
			this.lblSelectingColor.TabIndex = 0;
			this.lblSelectingColor.Text = "選択中の色 : (255, 255, 255, 255)";
			// 
			// lblSelectColor
			// 
			this.lblSelectColor.AutoSize = true;
			this.lblSelectColor.Location = new System.Drawing.Point(27, 81);
			this.lblSelectColor.Name = "lblSelectColor";
			this.lblSelectColor.Size = new System.Drawing.Size(283, 20);
			this.lblSelectColor.TabIndex = 2;
			this.lblSelectColor.Text = "選択された矩形の色 : (255, 255, 255, 255)_";
			// 
			// btnSelectColor
			// 
			this.btnSelectColor.Location = new System.Drawing.Point(316, 72);
			this.btnSelectColor.Name = "btnSelectColor";
			this.btnSelectColor.Size = new System.Drawing.Size(74, 38);
			this.btnSelectColor.TabIndex = 3;
			this.btnSelectColor.Text = "変更";
			this.btnSelectColor.UseVisualStyleBackColor = true;
			this.btnSelectColor.Click += new System.EventHandler(this.btnSelectColor_Click);
			// 
			// btnSelectingColor
			// 
			this.btnSelectingColor.Location = new System.Drawing.Point(316, 28);
			this.btnSelectingColor.Name = "btnSelectingColor";
			this.btnSelectingColor.Size = new System.Drawing.Size(74, 38);
			this.btnSelectingColor.TabIndex = 1;
			this.btnSelectingColor.Text = "変更";
			this.btnSelectingColor.UseVisualStyleBackColor = true;
			this.btnSelectingColor.Click += new System.EventHandler(this.btnSelectingColor_Click);
			// 
			// cbファイルを閉じるとき保存するか確認しない
			// 
			this.cbファイルを閉じるとき保存するか確認しない.AutoSize = true;
			this.cbファイルを閉じるとき保存するか確認しない.Location = new System.Drawing.Point(31, 131);
			this.cbファイルを閉じるとき保存するか確認しない.Name = "cbファイルを閉じるとき保存するか確認しない";
			this.cbファイルを閉じるとき保存するか確認しない.Size = new System.Drawing.Size(301, 24);
			this.cbファイルを閉じるとき保存するか確認しない.TabIndex = 4;
			this.cbファイルを閉じるとき保存するか確認しない.Text = "ファイルを閉じるとき保存するか確認しない。";
			this.cbファイルを閉じるとき保存するか確認しない.UseVisualStyleBackColor = true;
			// 
			// btnOk
			// 
			this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOk.Location = new System.Drawing.Point(175, 185);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(111, 46);
			this.btnOk.TabIndex = 5;
			this.btnOk.Text = "OK";
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.Location = new System.Drawing.Point(292, 185);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(111, 46);
			this.btnCancel.TabIndex = 6;
			this.btnCancel.Text = "キャンセル";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// SettingDlg
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(415, 243);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.cbファイルを閉じるとき保存するか確認しない);
			this.Controls.Add(this.btnSelectingColor);
			this.Controls.Add(this.btnSelectColor);
			this.Controls.Add(this.lblSelectColor);
			this.Controls.Add(this.lblSelectingColor);
			this.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SettingDlg";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "設定";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingDlg_FormClosing);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SettingDlg_FormClosed);
			this.Load += new System.EventHandler(this.SettingDlg_Load);
			this.Shown += new System.EventHandler(this.SettingDlg_Shown);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblSelectingColor;
		private System.Windows.Forms.Label lblSelectColor;
		private System.Windows.Forms.Button btnSelectColor;
		private System.Windows.Forms.Button btnSelectingColor;
		private System.Windows.Forms.CheckBox cbファイルを閉じるとき保存するか確認しない;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Button btnCancel;
	}
}
