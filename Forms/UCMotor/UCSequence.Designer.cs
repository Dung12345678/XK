namespace BMS
{
	partial class UCSequence
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
			this.lblCaption = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// lblCaption
			// 
			this.lblCaption.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
			this.lblCaption.ForeColor = System.Drawing.Color.White;
			this.lblCaption.Location = new System.Drawing.Point(0, 0);
			this.lblCaption.Name = "lblCaption";
			this.lblCaption.Size = new System.Drawing.Size(101, 27);
			this.lblCaption.TabIndex = 0;
			this.lblCaption.Text = "label1";
			this.lblCaption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// UCSequence
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Blue;
			this.Controls.Add(this.lblCaption);
			this.Margin = new System.Windows.Forms.Padding(1);
			this.Name = "UCSequence";
			this.Size = new System.Drawing.Size(101, 27);
			this.Load += new System.EventHandler(this.UCSequence_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label lblCaption;
	}
}
