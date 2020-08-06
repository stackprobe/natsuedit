namespace Charlotte
{
	partial class Input字幕Dlg
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Input字幕Dlg));
			this.Line1 = new System.Windows.Forms.TextBox();
			this.btnOk = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.LblLine1 = new System.Windows.Forms.Label();
			this.Line2 = new System.Windows.Forms.TextBox();
			this.LblLine2 = new System.Windows.Forms.Label();
			this.CB複数行 = new System.Windows.Forms.CheckBox();
			this.Align1 = new System.Windows.Forms.ComboBox();
			this.Align2 = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// Line1
			// 
			this.Line1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.Line1.Location = new System.Drawing.Point(66, 12);
			this.Line1.MaxLength = 40;
			this.Line1.Name = "Line1";
			this.Line1.Size = new System.Drawing.Size(371, 27);
			this.Line1.TabIndex = 1;
			// 
			// btnOk
			// 
			this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOk.Location = new System.Drawing.Point(303, 106);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(111, 43);
			this.btnOk.TabIndex = 7;
			this.btnOk.Text = "OK";
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.Location = new System.Drawing.Point(420, 106);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(111, 43);
			this.btnCancel.TabIndex = 8;
			this.btnCancel.Text = "キャンセル";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// LblLine1
			// 
			this.LblLine1.AutoSize = true;
			this.LblLine1.Location = new System.Drawing.Point(12, 15);
			this.LblLine1.Name = "LblLine1";
			this.LblLine1.Size = new System.Drawing.Size(48, 20);
			this.LblLine1.TabIndex = 0;
			this.LblLine1.Text = "１行目";
			// 
			// Line2
			// 
			this.Line2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.Line2.Location = new System.Drawing.Point(66, 45);
			this.Line2.MaxLength = 40;
			this.Line2.Name = "Line2";
			this.Line2.Size = new System.Drawing.Size(371, 27);
			this.Line2.TabIndex = 4;
			// 
			// LblLine2
			// 
			this.LblLine2.AutoSize = true;
			this.LblLine2.Location = new System.Drawing.Point(12, 48);
			this.LblLine2.Name = "LblLine2";
			this.LblLine2.Size = new System.Drawing.Size(48, 20);
			this.LblLine2.TabIndex = 3;
			this.LblLine2.Text = "２行目";
			// 
			// CB複数行
			// 
			this.CB複数行.AutoSize = true;
			this.CB複数行.Location = new System.Drawing.Point(66, 78);
			this.CB複数行.Name = "CB複数行";
			this.CB複数行.Size = new System.Drawing.Size(119, 24);
			this.CB複数行.TabIndex = 6;
			this.CB複数行.Text = "２行入力する。";
			this.CB複数行.UseVisualStyleBackColor = true;
			this.CB複数行.CheckedChanged += new System.EventHandler(this.CB複数行_CheckedChanged);
			// 
			// Align1
			// 
			this.Align1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.Align1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.Align1.FormattingEnabled = true;
			this.Align1.Items.AddRange(new object[] {
            "左寄せ",
            "中央",
            "右寄せ"});
			this.Align1.Location = new System.Drawing.Point(443, 12);
			this.Align1.Name = "Align1";
			this.Align1.Size = new System.Drawing.Size(88, 28);
			this.Align1.TabIndex = 2;
			// 
			// Align2
			// 
			this.Align2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.Align2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.Align2.FormattingEnabled = true;
			this.Align2.Items.AddRange(new object[] {
            "左寄せ",
            "中央",
            "右寄せ"});
			this.Align2.Location = new System.Drawing.Point(443, 45);
			this.Align2.Name = "Align2";
			this.Align2.Size = new System.Drawing.Size(88, 28);
			this.Align2.TabIndex = 5;
			// 
			// Input字幕Dlg
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(543, 161);
			this.Controls.Add(this.Align2);
			this.Controls.Add(this.Align1);
			this.Controls.Add(this.CB複数行);
			this.Controls.Add(this.LblLine2);
			this.Controls.Add(this.Line2);
			this.Controls.Add(this.LblLine1);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.Line1);
			this.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Input字幕Dlg";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "字幕入力";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Input字幕Dlg_FormClosing);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Input字幕Dlg_FormClosed);
			this.Load += new System.EventHandler(this.Input字幕Dlg_Load);
			this.Shown += new System.EventHandler(this.Input字幕Dlg_Shown);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox Line1;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Label LblLine1;
		private System.Windows.Forms.TextBox Line2;
		private System.Windows.Forms.Label LblLine2;
		private System.Windows.Forms.CheckBox CB複数行;
		private System.Windows.Forms.ComboBox Align1;
		private System.Windows.Forms.ComboBox Align2;
	}
}
