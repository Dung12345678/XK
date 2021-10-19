namespace BMS
{
    partial class frmChooseRisk
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
			this.btnAdd = new System.Windows.Forms.Button();
			this.txtRisk = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// btnAdd
			// 
			this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnAdd.Location = new System.Drawing.Point(399, 237);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(79, 35);
			this.btnAdd.TabIndex = 1;
			this.btnAdd.Text = "Cất";
			this.btnAdd.UseVisualStyleBackColor = true;
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// txtRisk
			// 
			this.txtRisk.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtRisk.Location = new System.Drawing.Point(3, 2);
			this.txtRisk.Multiline = true;
			this.txtRisk.Name = "txtRisk";
			this.txtRisk.Size = new System.Drawing.Size(475, 229);
			this.txtRisk.TabIndex = 0;
			this.txtRisk.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRisk_KeyDown);
			// 
			// frmChooseRisk
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(480, 275);
			this.ControlBox = false;
			this.Controls.Add(this.txtRisk);
			this.Controls.Add(this.btnAdd);
			this.Name = "frmChooseRisk";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Nhập lý do bỏ qua Order";
			this.Load += new System.EventHandler(this.frmChooseRisk_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtRisk;
    }
}