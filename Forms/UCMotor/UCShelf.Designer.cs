namespace BMS
{
	partial class UCShelf
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.lblGia = new System.Windows.Forms.Label();
			this.lblSLTT = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// lblGia
			// 
			this.lblGia.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblGia.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold);
			this.lblGia.Location = new System.Drawing.Point(6, 3);
			this.lblGia.Margin = new System.Windows.Forms.Padding(1);
			this.lblGia.Name = "lblGia";
			this.lblGia.Size = new System.Drawing.Size(126, 21);
			this.lblGia.TabIndex = 0;
			this.lblGia.Text = "label1";
			this.lblGia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblSLTT
			// 
			this.lblSLTT.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold);
			this.lblSLTT.Location = new System.Drawing.Point(6, 26);
			this.lblSLTT.Margin = new System.Windows.Forms.Padding(1);
			this.lblSLTT.Name = "lblSLTT";
			this.lblSLTT.Size = new System.Drawing.Size(126, 19);
			this.lblSLTT.TabIndex = 1;
			this.lblSLTT.Text = "label2";
			this.lblSLTT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// UCShelf
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Gray;
			this.Controls.Add(this.lblSLTT);
			this.Controls.Add(this.lblGia);
			this.DoubleBuffered = true;
			this.Font = new System.Drawing.Font("Symbol", 8.25F);
			this.Margin = new System.Windows.Forms.Padding(1);
			this.Name = "UCShelf";
			this.Size = new System.Drawing.Size(137, 48);
			this.Load += new System.EventHandler(this.UCShelf_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label lblGia;
		private System.Windows.Forms.Label lblSLTT;
	}
}
