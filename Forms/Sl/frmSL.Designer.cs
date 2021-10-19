namespace BMS
{
    partial class frmSL
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.lblMaHang = new System.Windows.Forms.Label();
			this.txtNumer = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// lblMaHang
			// 
			this.lblMaHang.AutoSize = true;
			this.lblMaHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblMaHang.Location = new System.Drawing.Point(59, 77);
			this.lblMaHang.Name = "lblMaHang";
			this.lblMaHang.Size = new System.Drawing.Size(109, 29);
			this.lblMaHang.TabIndex = 0;
			this.lblMaHang.Text = "Mã Hàng";
			// 
			// txtNumer
			// 
			this.txtNumer.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtNumer.Location = new System.Drawing.Point(265, 74);
			this.txtNumer.Name = "txtNumer";
			this.txtNumer.ReadOnly = true;
			this.txtNumer.Size = new System.Drawing.Size(228, 35);
			this.txtNumer.TabIndex = 2;
			// 
			// button1
			// 
			this.button1.Dock = System.Windows.Forms.DockStyle.Top;
			this.button1.Enabled = false;
			this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button1.Location = new System.Drawing.Point(0, 0);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(579, 42);
			this.button1.TabIndex = 3;
			this.button1.Text = "XÁC NHẬN SỐ LƯỢNG LINH KIỆN";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// btnCancel
			// 
			this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnCancel.Location = new System.Drawing.Point(64, 158);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(104, 45);
			this.btnCancel.TabIndex = 1;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnOK
			// 
			this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnOK.Location = new System.Drawing.Point(389, 158);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(104, 45);
			this.btnOK.TabIndex = 0;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// frmSL
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(579, 215);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.txtNumer);
			this.Controls.Add(this.lblMaHang);
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "frmSL";
			this.Text = "XÁC NHẬN";
			this.Load += new System.EventHandler(this.frmSL_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

		#endregion

		private System.Windows.Forms.Label lblMaHang;
		private System.Windows.Forms.TextBox txtNumer;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOK;
	}
}