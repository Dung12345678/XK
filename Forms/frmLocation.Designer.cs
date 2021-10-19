namespace BMS
{
    partial class frmLocation
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLocation));
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.panel2 = new System.Windows.Forms.Panel();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.btnDeleteStep = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
			this.btnEditStep = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.btnAddStep = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.btnRestartCD = new System.Windows.Forms.ToolStripButton();
			this.grdData = new DevExpress.XtraGrid.GridControl();
			this.grvData = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colCDCode = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colCDDName = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colStock = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colStockID = new DevExpress.XtraGrid.Columns.GridColumn();
			this.panel4 = new System.Windows.Forms.Panel();
			this.mnuMenu = new System.Windows.Forms.ToolStrip();
			this.btnDelete = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.btnEdit = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.btnNew = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.btnRestart = new System.Windows.Forms.ToolStripButton();
			this.label1 = new System.Windows.Forms.Label();
			this.panel3 = new System.Windows.Forms.Panel();
			this.grdDetail = new DevExpress.XtraGrid.GridControl();
			this.grvDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.colLocationID = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colCDID = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colLocationCode = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colLocationName = new DevExpress.XtraGrid.Columns.GridColumn();
			this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
			this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
			this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
			this.miniToolStrip = new System.Windows.Forms.ToolStrip();
			this.colCDName = new DevExpress.XtraGrid.Columns.GridColumn();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grvData)).BeginInit();
			this.panel4.SuspendLayout();
			this.mnuMenu.SuspendLayout();
			this.panel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdDetail)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grvDetail)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
			this.SuspendLayout();
			// 
			// splitContainer1
			// 
			this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.panel2);
			this.splitContainer1.Panel1.Controls.Add(this.grdData);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.panel4);
			this.splitContainer1.Panel2.Controls.Add(this.panel3);
			this.splitContainer1.Size = new System.Drawing.Size(1199, 841);
			this.splitContainer1.SplitterDistance = 449;
			this.splitContainer1.SplitterWidth = 5;
			this.splitContainer1.TabIndex = 29;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.toolStrip1);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(447, 71);
			this.panel2.TabIndex = 31;
			// 
			// toolStrip1
			// 
			this.toolStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.toolStrip1.AutoSize = false;
			this.toolStrip1.BackColor = System.Drawing.Color.WhiteSmoke;
			this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
			this.toolStrip1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnDeleteStep,
            this.toolStripSeparator6,
            this.btnEditStep,
            this.toolStripSeparator5,
            this.btnAddStep,
            this.toolStripSeparator2,
            this.btnRestartCD});
			this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
			this.toolStrip1.Location = new System.Drawing.Point(149, 12);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
			this.toolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.toolStrip1.Size = new System.Drawing.Size(297, 57);
			this.toolStrip1.TabIndex = 30;
			this.toolStrip1.Text = "toolStrip2";
			// 
			// btnDeleteStep
			// 
			this.btnDeleteStep.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnDeleteStep.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteStep.Image")));
			this.btnDeleteStep.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnDeleteStep.Name = "btnDeleteStep";
			this.btnDeleteStep.Size = new System.Drawing.Size(39, 41);
			this.btnDeleteStep.Tag = "frmProductWorkingH_DeleteCD";
			this.btnDeleteStep.Text = "Xóa";
			this.btnDeleteStep.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnDeleteStep.Click += new System.EventHandler(this.btnDeleteStep_Click);
			// 
			// toolStripSeparator6
			// 
			this.toolStripSeparator6.Name = "toolStripSeparator6";
			this.toolStripSeparator6.Size = new System.Drawing.Size(6, 23);
			// 
			// btnEditStep
			// 
			this.btnEditStep.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnEditStep.Image = ((System.Drawing.Image)(resources.GetObject("btnEditStep.Image")));
			this.btnEditStep.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnEditStep.Name = "btnEditStep";
			this.btnEditStep.Size = new System.Drawing.Size(39, 41);
			this.btnEditStep.Tag = "frmProductWorkingH_EditCD";
			this.btnEditStep.Text = "Sửa";
			this.btnEditStep.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnEditStep.Click += new System.EventHandler(this.btnEditStep_Click);
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(6, 23);
			// 
			// btnAddStep
			// 
			this.btnAddStep.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnAddStep.Image = ((System.Drawing.Image)(resources.GetObject("btnAddStep.Image")));
			this.btnAddStep.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnAddStep.Name = "btnAddStep";
			this.btnAddStep.Size = new System.Drawing.Size(51, 41);
			this.btnAddStep.Tag = "frmProductWorkingH_AddCD";
			this.btnAddStep.Text = "Thêm";
			this.btnAddStep.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnAddStep.Click += new System.EventHandler(this.btnAddStep_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 23);
			// 
			// btnRestartCD
			// 
			this.btnRestartCD.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnRestartCD.Image = ((System.Drawing.Image)(resources.GetObject("btnRestartCD.Image")));
			this.btnRestartCD.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnRestartCD.Name = "btnRestartCD";
			this.btnRestartCD.Size = new System.Drawing.Size(70, 41);
			this.btnRestartCD.Tag = "";
			this.btnRestartCD.Text = "Làm mới";
			this.btnRestartCD.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnRestartCD.Click += new System.EventHandler(this.btnRestartCD_Click);
			// 
			// grdData
			// 
			this.grdData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.grdData.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.grdData.Location = new System.Drawing.Point(-1, 73);
			this.grdData.MainView = this.grvData;
			this.grdData.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.grdData.Name = "grdData";
			this.grdData.Size = new System.Drawing.Size(448, 762);
			this.grdData.TabIndex = 25;
			this.grdData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvData});
			// 
			// grvData
			// 
			this.grvData.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			this.grvData.Appearance.FocusedRow.Options.UseBackColor = true;
			this.grvData.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			this.grvData.Appearance.HideSelectionRow.Options.UseBackColor = true;
			this.grvData.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			this.grvData.Appearance.SelectedRow.Options.UseBackColor = true;
			this.grvData.ColumnPanelRowHeight = 40;
			this.grvData.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colCDCode,
            this.colCDDName,
            this.colStock,
            this.colStockID});
			this.grvData.GridControl = this.grdData;
			this.grvData.GroupCount = 1;
			this.grvData.Name = "grvData";
			this.grvData.OptionsBehavior.Editable = false;
			this.grvData.OptionsView.ShowGroupPanel = false;
			this.grvData.RowHeight = 30;
			this.grvData.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colStock, DevExpress.Data.ColumnSortOrder.Ascending)});
			this.grvData.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.grvData_FocusedRowChanged);
			this.grvData.DoubleClick += new System.EventHandler(this.grvData_DoubleClick);
			// 
			// colID
			// 
			this.colID.Caption = "ID";
			this.colID.FieldName = "ID";
			this.colID.Name = "colID";
			this.colID.OptionsColumn.AllowEdit = false;
			// 
			// colCDCode
			// 
			this.colCDCode.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.colCDCode.AppearanceCell.Options.UseFont = true;
			this.colCDCode.AppearanceCell.Options.UseTextOptions = true;
			this.colCDCode.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colCDCode.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.colCDCode.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.colCDCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.colCDCode.AppearanceHeader.Options.UseFont = true;
			this.colCDCode.AppearanceHeader.Options.UseTextOptions = true;
			this.colCDCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colCDCode.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.colCDCode.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.colCDCode.Caption = "Công đoạn";
			this.colCDCode.FieldName = "CDCode";
			this.colCDCode.Name = "colCDCode";
			this.colCDCode.OptionsColumn.AllowEdit = false;
			this.colCDCode.OptionsColumn.AllowFocus = false;
			this.colCDCode.Visible = true;
			this.colCDCode.VisibleIndex = 0;
			this.colCDCode.Width = 117;
			// 
			// colCDDName
			// 
			this.colCDDName.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.colCDDName.AppearanceCell.Options.UseFont = true;
			this.colCDDName.AppearanceCell.Options.UseTextOptions = true;
			this.colCDDName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colCDDName.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.colCDDName.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.colCDDName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.colCDDName.AppearanceHeader.Options.UseFont = true;
			this.colCDDName.AppearanceHeader.Options.UseTextOptions = true;
			this.colCDDName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colCDDName.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.colCDDName.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.colCDDName.Caption = "Tên công đoạn";
			this.colCDDName.FieldName = "CDName";
			this.colCDDName.Name = "colCDDName";
			this.colCDDName.OptionsColumn.AllowEdit = false;
			this.colCDDName.OptionsColumn.AllowFocus = false;
			this.colCDDName.Visible = true;
			this.colCDDName.VisibleIndex = 1;
			this.colCDDName.Width = 201;
			// 
			// colStock
			// 
			this.colStock.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.colStock.AppearanceCell.Options.UseFont = true;
			this.colStock.AppearanceCell.Options.UseTextOptions = true;
			this.colStock.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colStock.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.colStock.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.colStock.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.colStock.AppearanceHeader.Options.UseFont = true;
			this.colStock.AppearanceHeader.Options.UseTextOptions = true;
			this.colStock.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colStock.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.colStock.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.colStock.Caption = "Kho";
			this.colStock.FieldName = "StockName";
			this.colStock.Name = "colStock";
			this.colStock.Visible = true;
			this.colStock.VisibleIndex = 2;
			// 
			// colStockID
			// 
			this.colStockID.Caption = "StockID";
			this.colStockID.FieldName = "StockID";
			this.colStockID.Name = "colStockID";
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.mnuMenu);
			this.panel4.Controls.Add(this.label1);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel4.Location = new System.Drawing.Point(0, 0);
			this.panel4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(743, 69);
			this.panel4.TabIndex = 33;
			// 
			// mnuMenu
			// 
			this.mnuMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.mnuMenu.AutoSize = false;
			this.mnuMenu.BackColor = System.Drawing.Color.WhiteSmoke;
			this.mnuMenu.Dock = System.Windows.Forms.DockStyle.None;
			this.mnuMenu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.mnuMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.mnuMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.mnuMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnDelete,
            this.toolStripSeparator4,
            this.btnEdit,
            this.toolStripSeparator3,
            this.btnNew,
            this.toolStripSeparator1,
            this.btnRestart});
			this.mnuMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
			this.mnuMenu.Location = new System.Drawing.Point(397, 12);
			this.mnuMenu.Name = "mnuMenu";
			this.mnuMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
			this.mnuMenu.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.mnuMenu.Size = new System.Drawing.Size(344, 46);
			this.mnuMenu.TabIndex = 29;
			this.mnuMenu.Text = "toolStrip2";
			// 
			// btnDelete
			// 
			this.btnDelete.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
			this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(39, 41);
			this.btnDelete.Tag = "frmProductWorkingH_DeleteDS";
			this.btnDelete.Text = "Xóa";
			this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(6, 23);
			// 
			// btnEdit
			// 
			this.btnEdit.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
			this.btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnEdit.Name = "btnEdit";
			this.btnEdit.Size = new System.Drawing.Size(39, 41);
			this.btnEdit.Tag = "frmProductWorkingH_EditDS";
			this.btnEdit.Text = "Sửa";
			this.btnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 23);
			// 
			// btnNew
			// 
			this.btnNew.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnNew.Image = ((System.Drawing.Image)(resources.GetObject("btnNew.Image")));
			this.btnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnNew.Name = "btnNew";
			this.btnNew.Size = new System.Drawing.Size(51, 41);
			this.btnNew.Tag = "frmProductWorkingH_AddDS";
			this.btnNew.Text = "Thêm";
			this.btnNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 23);
			// 
			// btnRestart
			// 
			this.btnRestart.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnRestart.Image = ((System.Drawing.Image)(resources.GetObject("btnRestart.Image")));
			this.btnRestart.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnRestart.Name = "btnRestart";
			this.btnRestart.Size = new System.Drawing.Size(70, 41);
			this.btnRestart.Tag = "";
			this.btnRestart.Text = "Làm mới";
			this.btnRestart.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(9, 41);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(277, 17);
			this.label1.TabIndex = 28;
			this.label1.Text = "Danh sách vị trí theo từng công đoạn";
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.grdDetail);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new System.Drawing.Point(0, 0);
			this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(743, 839);
			this.panel3.TabIndex = 32;
			// 
			// grdDetail
			// 
			this.grdDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.grdDetail.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.grdDetail.Location = new System.Drawing.Point(0, 73);
			this.grdDetail.MainView = this.grvDetail;
			this.grdDetail.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.grdDetail.Name = "grdDetail";
			this.grdDetail.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoEdit1,
            this.repositoryItemTextEdit1,
            this.repositoryItemCheckEdit1});
			this.grdDetail.Size = new System.Drawing.Size(745, 767);
			this.grdDetail.TabIndex = 25;
			this.grdDetail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvDetail});
			// 
			// grvDetail
			// 
			this.grvDetail.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			this.grvDetail.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			this.grvDetail.Appearance.FocusedRow.Options.UseBackColor = true;
			this.grvDetail.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			this.grvDetail.Appearance.HideSelectionRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			this.grvDetail.Appearance.HideSelectionRow.Options.UseBackColor = true;
			this.grvDetail.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			this.grvDetail.Appearance.SelectedRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			this.grvDetail.Appearance.SelectedRow.Options.UseBackColor = true;
			this.grvDetail.ColumnPanelRowHeight = 40;
			this.grvDetail.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colLocationID,
            this.colCDID,
            this.colLocationCode,
            this.colLocationName});
			this.grvDetail.GridControl = this.grdDetail;
			this.grvDetail.Name = "grvDetail";
			this.grvDetail.OptionsBehavior.Editable = false;
			this.grvDetail.OptionsView.RowAutoHeight = true;
			this.grvDetail.OptionsView.ShowGroupPanel = false;
			this.grvDetail.RowHeight = 30;
			this.grvDetail.DoubleClick += new System.EventHandler(this.grdDetail_DoubleClick);
			// 
			// colLocationID
			// 
			this.colLocationID.Caption = "ID";
			this.colLocationID.FieldName = "ID";
			this.colLocationID.Name = "colLocationID";
			// 
			// colCDID
			// 
			this.colCDID.Caption = "CDID";
			this.colCDID.FieldName = "CDID";
			this.colCDID.Name = "colCDID";
			// 
			// colLocationCode
			// 
			this.colLocationCode.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.colLocationCode.AppearanceCell.Options.UseFont = true;
			this.colLocationCode.AppearanceCell.Options.UseTextOptions = true;
			this.colLocationCode.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colLocationCode.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.colLocationCode.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.colLocationCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.colLocationCode.AppearanceHeader.Options.UseFont = true;
			this.colLocationCode.AppearanceHeader.Options.UseTextOptions = true;
			this.colLocationCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colLocationCode.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.colLocationCode.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.colLocationCode.Caption = "Mã Vị Trí";
			this.colLocationCode.FieldName = "LocationCode";
			this.colLocationCode.Name = "colLocationCode";
			this.colLocationCode.OptionsColumn.AllowEdit = false;
			this.colLocationCode.Visible = true;
			this.colLocationCode.VisibleIndex = 0;
			this.colLocationCode.Width = 262;
			// 
			// colLocationName
			// 
			this.colLocationName.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.colLocationName.AppearanceCell.Options.UseFont = true;
			this.colLocationName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.colLocationName.AppearanceHeader.Options.UseFont = true;
			this.colLocationName.Caption = "Tên vị trí";
			this.colLocationName.FieldName = "LocationName";
			this.colLocationName.Name = "colLocationName";
			this.colLocationName.OptionsColumn.AllowEdit = false;
			this.colLocationName.Visible = true;
			this.colLocationName.VisibleIndex = 1;
			this.colLocationName.Width = 215;
			// 
			// repositoryItemMemoEdit1
			// 
			this.repositoryItemMemoEdit1.Appearance.Options.UseTextOptions = true;
			this.repositoryItemMemoEdit1.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
			// 
			// repositoryItemTextEdit1
			// 
			this.repositoryItemTextEdit1.AutoHeight = false;
			this.repositoryItemTextEdit1.DisplayFormat.FormatString = "n3";
			this.repositoryItemTextEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.repositoryItemTextEdit1.EditFormat.FormatString = "n3";
			this.repositoryItemTextEdit1.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.repositoryItemTextEdit1.Mask.EditMask = "n3";
			this.repositoryItemTextEdit1.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
			this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
			// 
			// repositoryItemCheckEdit1
			// 
			this.repositoryItemCheckEdit1.AutoHeight = false;
			this.repositoryItemCheckEdit1.Caption = "Check";
			this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
			// 
			// miniToolStrip
			// 
			this.miniToolStrip.AccessibleName = "New item selection";
			this.miniToolStrip.AccessibleRole = System.Windows.Forms.AccessibleRole.ButtonDropDown;
			this.miniToolStrip.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.miniToolStrip.AutoSize = false;
			this.miniToolStrip.BackColor = System.Drawing.Color.WhiteSmoke;
			this.miniToolStrip.CanOverflow = false;
			this.miniToolStrip.Dock = System.Windows.Forms.DockStyle.None;
			this.miniToolStrip.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.miniToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.miniToolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.miniToolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
			this.miniToolStrip.Location = new System.Drawing.Point(0, 0);
			this.miniToolStrip.Name = "miniToolStrip";
			this.miniToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
			this.miniToolStrip.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.miniToolStrip.Size = new System.Drawing.Size(258, 37);
			this.miniToolStrip.TabIndex = 29;
			// 
			// colCDName
			// 
			this.colCDName.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.colCDName.AppearanceCell.Options.UseFont = true;
			this.colCDName.AppearanceCell.Options.UseTextOptions = true;
			this.colCDName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colCDName.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.colCDName.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.colCDName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.colCDName.AppearanceHeader.Options.UseFont = true;
			this.colCDName.AppearanceHeader.Options.UseTextOptions = true;
			this.colCDName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colCDName.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.colCDName.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.colCDName.Caption = "Tên Công Đoạn";
			this.colCDName.FieldName = "CDName";
			this.colCDName.Name = "colCDName";
			this.colCDName.OptionsColumn.AllowEdit = false;
			// 
			// frmLocation
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1199, 841);
			this.Controls.Add(this.splitContainer1);
			this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
			this.Name = "frmLocation";
			this.Text = "DANH SÁCH THEO CÔNG ĐOẠN";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmProductWorking_Load);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grvData)).EndInit();
			this.panel4.ResumeLayout(false);
			this.panel4.PerformLayout();
			this.mnuMenu.ResumeLayout(false);
			this.mnuMenu.PerformLayout();
			this.panel3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.grdDetail)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grvDetail)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
			this.ResumeLayout(false);

        }

		#endregion

		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton btnDeleteStep;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
		private System.Windows.Forms.ToolStripButton btnEditStep;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
		private System.Windows.Forms.ToolStripButton btnAddStep;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton btnRestartCD;
		private DevExpress.XtraGrid.GridControl grdData;
		private DevExpress.XtraGrid.Views.Grid.GridView grvData;
		private DevExpress.XtraGrid.Columns.GridColumn colID;
		private DevExpress.XtraGrid.Columns.GridColumn colCDCode;
		private DevExpress.XtraGrid.Columns.GridColumn colCDDName;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.ToolStrip mnuMenu;
		private System.Windows.Forms.ToolStripButton btnDelete;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripButton btnEdit;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripButton btnNew;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton btnRestart;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel3;
		private DevExpress.XtraGrid.GridControl grdDetail;
		private DevExpress.XtraGrid.Views.Grid.GridView grvDetail;
		private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
		private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
		private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
		private System.Windows.Forms.ToolStrip miniToolStrip;
		private DevExpress.XtraGrid.Columns.GridColumn colLocationID;
		private DevExpress.XtraGrid.Columns.GridColumn colCDID;
		private DevExpress.XtraGrid.Columns.GridColumn colLocationCode;
		private DevExpress.XtraGrid.Columns.GridColumn colLocationName;
		private DevExpress.XtraGrid.Columns.GridColumn colStock;
		private DevExpress.XtraGrid.Columns.GridColumn colCDName;
		private DevExpress.XtraGrid.Columns.GridColumn colStockID;
	}
}