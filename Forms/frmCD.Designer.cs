namespace BMS
{
	partial class frmCD
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCD));
			this.mnuMenu = new System.Windows.Forms.ToolStrip();
			this.btnSave = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.btnSaveNew = new System.Windows.Forms.ToolStripButton();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtCDCode = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtCDName = new System.Windows.Forms.TextBox();
			this.cboStockName = new System.Windows.Forms.ComboBox();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.aToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.KhaiBaoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.cấtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.txtTaktTime = new System.Windows.Forms.DateTimePicker();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.txtLocation = new System.Windows.Forms.TextBox();
			this.mnuMenu.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// mnuMenu
			// 
			this.mnuMenu.AutoSize = false;
			this.mnuMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
			this.mnuMenu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.mnuMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.mnuMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.mnuMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSave,
            this.toolStripSeparator2,
            this.btnSaveNew});
			this.mnuMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
			this.mnuMenu.Location = new System.Drawing.Point(0, 0);
			this.mnuMenu.Name = "mnuMenu";
			this.mnuMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
			this.mnuMenu.Size = new System.Drawing.Size(534, 42);
			this.mnuMenu.TabIndex = 1;
			this.mnuMenu.Text = "toolStrip2";
			// 
			// btnSave
			// 
			this.btnSave.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
			this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(75, 37);
			this.btnSave.Tag = "frmConfigShipToH_Add";
			this.btnSave.Text = "Cất && Đóng";
			this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.AutoSize = false;
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 40);
			// 
			// btnSaveNew
			// 
			this.btnSaveNew.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnSaveNew.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveNew.Image")));
			this.btnSaveNew.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnSaveNew.Name = "btnSaveNew";
			this.btnSaveNew.Size = new System.Drawing.Size(101, 37);
			this.btnSaveNew.Tag = "frmConfigShipToH_Add";
			this.btnSaveNew.Text = "Cất && Thêm mới";
			this.btnSaveNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnSaveNew.Click += new System.EventHandler(this.btnSaveNew_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(12, 57);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(116, 31);
			this.label1.TabIndex = 2;
			this.label1.Text = "Tên Kho:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(12, 119);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(188, 31);
			this.label2.TabIndex = 3;
			this.label2.Text = "Mã Công Đoạn:";
			// 
			// txtCDCode
			// 
			this.txtCDCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtCDCode.Font = new System.Drawing.Font("Times New Roman", 20.25F);
			this.txtCDCode.Location = new System.Drawing.Point(201, 116);
			this.txtCDCode.Name = "txtCDCode";
			this.txtCDCode.Size = new System.Drawing.Size(321, 39);
			this.txtCDCode.TabIndex = 6;
			this.txtCDCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCDCode_KeyDown);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(12, 186);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(194, 31);
			this.label3.TabIndex = 3;
			this.label3.Text = "Tên Công Đoạn:";
			// 
			// txtCDName
			// 
			this.txtCDName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtCDName.Font = new System.Drawing.Font("Times New Roman", 20.25F);
			this.txtCDName.Location = new System.Drawing.Point(201, 183);
			this.txtCDName.Name = "txtCDName";
			this.txtCDName.Size = new System.Drawing.Size(321, 39);
			this.txtCDName.TabIndex = 7;
			// 
			// cboStockName
			// 
			this.cboStockName.Enabled = false;
			this.cboStockName.Font = new System.Drawing.Font("Times New Roman", 20.25F);
			this.cboStockName.FormattingEnabled = true;
			this.cboStockName.Location = new System.Drawing.Point(201, 57);
			this.cboStockName.Name = "cboStockName";
			this.cboStockName.Size = new System.Drawing.Size(321, 39);
			this.cboStockName.TabIndex = 5;
			// 
			// menuStrip1
			// 
			this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
			this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(252, 112);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
			this.menuStrip1.Size = new System.Drawing.Size(31, 24);
			this.menuStrip1.TabIndex = 19;
			this.menuStrip1.Text = "menuStrip1";
			this.menuStrip1.Visible = false;
			// 
			// aToolStripMenuItem
			// 
			this.aToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.KhaiBaoToolStripMenuItem,
            this.cấtToolStripMenuItem});
			this.aToolStripMenuItem.Name = "aToolStripMenuItem";
			this.aToolStripMenuItem.Size = new System.Drawing.Size(25, 22);
			this.aToolStripMenuItem.Text = "a";
			// 
			// KhaiBaoToolStripMenuItem
			// 
			this.KhaiBaoToolStripMenuItem.Name = "KhaiBaoToolStripMenuItem";
			this.KhaiBaoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
			this.KhaiBaoToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
			this.KhaiBaoToolStripMenuItem.Text = "Cất&&Đóng";
			this.KhaiBaoToolStripMenuItem.Click += new System.EventHandler(this.KhaiBaoToolStripMenuItem_Click);
			// 
			// cấtToolStripMenuItem
			// 
			this.cấtToolStripMenuItem.Name = "cấtToolStripMenuItem";
			this.cấtToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
			this.cấtToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
			this.cấtToolStripMenuItem.Text = "Cất&&Thêm mới";
			this.cấtToolStripMenuItem.Click += new System.EventHandler(this.cấtToolStripMenuItem_Click);
			// 
			// txtTaktTime
			// 
			this.txtTaktTime.CustomFormat = "mm:ss";
			this.txtTaktTime.Font = new System.Drawing.Font("Times New Roman", 20.25F);
			this.txtTaktTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.txtTaktTime.Location = new System.Drawing.Point(201, 249);
			this.txtTaktTime.Name = "txtTaktTime";
			this.txtTaktTime.ShowUpDown = true;
			this.txtTaktTime.Size = new System.Drawing.Size(131, 39);
			this.txtTaktTime.TabIndex = 54;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Times New Roman", 20.25F);
			this.label4.Location = new System.Drawing.Point(12, 253);
			this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(163, 31);
			this.label4.TabIndex = 53;
			this.label4.Text = "Takt time (s): ";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Times New Roman", 20.25F);
			this.label5.Location = new System.Drawing.Point(13, 313);
			this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(77, 31);
			this.label5.TabIndex = 56;
			this.label5.Text = "Vị trí:";
			this.label5.Click += new System.EventHandler(this.label5_Click);
			// 
			// txtLocation
			// 
			this.txtLocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtLocation.Font = new System.Drawing.Font("Times New Roman", 20.25F);
			this.txtLocation.Location = new System.Drawing.Point(201, 310);
			this.txtLocation.Name = "txtLocation";
			this.txtLocation.Size = new System.Drawing.Size(321, 39);
			this.txtLocation.TabIndex = 55;
			// 
			// frmCD
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(534, 359);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.txtLocation);
			this.Controls.Add(this.txtTaktTime);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.menuStrip1);
			this.Controls.Add(this.cboStockName);
			this.Controls.Add(this.txtCDName);
			this.Controls.Add(this.txtCDCode);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.mnuMenu);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "frmCD";
			this.Text = "CHI TIẾT CÔNG ĐOẠN";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmCD_FormClosed);
			this.Load += new System.EventHandler(this.frmStockStepDetail_Load);
			this.mnuMenu.ResumeLayout(false);
			this.mnuMenu.PerformLayout();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip mnuMenu;
		private System.Windows.Forms.ToolStripButton btnSave;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton btnSaveNew;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtCDCode;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtCDName;
		private System.Windows.Forms.ComboBox cboStockName;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem aToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem KhaiBaoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem cấtToolStripMenuItem;
		private System.Windows.Forms.DateTimePicker txtTaktTime;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtLocation;
	}
}