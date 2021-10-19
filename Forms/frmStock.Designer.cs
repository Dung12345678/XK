namespace BMS
{
	partial class frmStock
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStock));
			this.mnuMenu = new System.Windows.Forms.ToolStrip();
			this.btnSave = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.btnSaveNew = new System.Windows.Forms.ToolStripButton();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtStockName = new System.Windows.Forms.TextBox();
			this.txtStockCode = new System.Windows.Forms.TextBox();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.aToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.KhaiBaoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.cấtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
			this.label1.Location = new System.Drawing.Point(12, 124);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(116, 31);
			this.label1.TabIndex = 2;
			this.label1.Text = "Tên Kho:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(12, 61);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(110, 31);
			this.label2.TabIndex = 3;
			this.label2.Text = "Mã Kho:";
			// 
			// txtStockName
			// 
			this.txtStockName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtStockName.Font = new System.Drawing.Font("Times New Roman", 20.25F);
			this.txtStockName.Location = new System.Drawing.Point(127, 121);
			this.txtStockName.Name = "txtStockName";
			this.txtStockName.Size = new System.Drawing.Size(395, 39);
			this.txtStockName.TabIndex = 7;
			// 
			// txtStockCode
			// 
			this.txtStockCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtStockCode.Font = new System.Drawing.Font("Times New Roman", 20.25F);
			this.txtStockCode.Location = new System.Drawing.Point(127, 58);
			this.txtStockCode.Name = "txtStockCode";
			this.txtStockCode.Size = new System.Drawing.Size(395, 39);
			this.txtStockCode.TabIndex = 6;
			this.txtStockCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtStockCode_KeyDown);
			// 
			// menuStrip1
			// 
			this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
			this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(252, 31);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
			this.menuStrip1.Size = new System.Drawing.Size(31, 24);
			this.menuStrip1.TabIndex = 18;
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
			// frmStock
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(534, 180);
			this.Controls.Add(this.menuStrip1);
			this.Controls.Add(this.txtStockCode);
			this.Controls.Add(this.txtStockName);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.mnuMenu);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "frmStock";
			this.Text = "CHI TIẾT KHO VÀ CÔNG ĐOẠN";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmStock_FormClosed);
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
		private System.Windows.Forms.TextBox txtStockName;
		private System.Windows.Forms.TextBox txtStockCode;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem aToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem KhaiBaoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem cấtToolStripMenuItem;
	}
}