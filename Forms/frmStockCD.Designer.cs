namespace BMS
{
    partial class frmStockCD
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStockCD));
			this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
			this.grvData = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colStocID = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colCDName = new DevExpress.XtraGrid.Columns.GridColumn();
			this.repositoryItemMemoEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
			this.colCDCode = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colTaktTime = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colNameLocation = new DevExpress.XtraGrid.Columns.GridColumn();
			this.grdData = new DevExpress.XtraGrid.GridControl();
			this.btnDel = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.btnEdit = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
			this.btnAdd = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.btnDeleteGroup = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
			this.btnEditGroup = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
			this.btnNewGroup = new System.Windows.Forms.ToolStripButton();
			this.mnuMenu = new System.Windows.Forms.ToolStrip();
			this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.treeData = new DevExpress.XtraTreeList.TreeList();
			this.colIDTree = new DevExpress.XtraTreeList.Columns.TreeListColumn();
			this.colNameTree = new DevExpress.XtraTreeList.Columns.TreeListColumn();
			this.repositoryItemMemoEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
			this.colCodeTree = new DevExpress.XtraTreeList.Columns.TreeListColumn();
			this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
			this.btnFindAll = new DevExpress.XtraEditors.SimpleButton();
			this.txtName = new System.Windows.Forms.TextBox();
			this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
			this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grvData)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
			this.mnuMenu.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.treeData)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit2)).BeginInit();
			this.SuspendLayout();
			// 
			// repositoryItemMemoEdit1
			// 
			this.repositoryItemMemoEdit1.Appearance.Options.UseTextOptions = true;
			this.repositoryItemMemoEdit1.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
			// 
			// grvData
			// 
			this.grvData.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			this.grvData.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			this.grvData.Appearance.FocusedRow.Options.UseBackColor = true;
			this.grvData.Appearance.HeaderPanel.Options.UseTextOptions = true;
			this.grvData.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.grvData.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			this.grvData.Appearance.HideSelectionRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			this.grvData.Appearance.HideSelectionRow.Options.UseBackColor = true;
			this.grvData.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			this.grvData.Appearance.SelectedRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			this.grvData.Appearance.SelectedRow.Options.UseBackColor = true;
			this.grvData.ColumnPanelRowHeight = 40;
			this.grvData.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colStocID,
            this.colCDName,
            this.colCDCode,
            this.colTaktTime,
            this.colNameLocation});
			this.grvData.GridControl = this.grdData;
			this.grvData.HorzScrollStep = 5;
			this.grvData.Name = "grvData";
			this.grvData.OptionsBehavior.AutoExpandAllGroups = true;
			this.grvData.OptionsBehavior.Editable = false;
			this.grvData.OptionsCustomization.AllowRowSizing = true;
			this.grvData.OptionsFind.AllowFindPanel = false;
			this.grvData.OptionsFind.ShowCloseButton = false;
			this.grvData.OptionsView.RowAutoHeight = true;
			this.grvData.OptionsView.ShowFooter = true;
			this.grvData.OptionsView.ShowGroupPanel = false;
			this.grvData.RowHeight = 30;
			this.grvData.DoubleClick += new System.EventHandler(this.grvData_DoubleClick);
			// 
			// colID
			// 
			this.colID.Caption = "ID";
			this.colID.FieldName = "ID";
			this.colID.Name = "colID";
			// 
			// colStocID
			// 
			this.colStocID.Caption = "StockID";
			this.colStocID.FieldName = "StockID";
			this.colStocID.Name = "colStocID";
			// 
			// colCDName
			// 
			this.colCDName.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.colCDName.AppearanceCell.Options.UseFont = true;
			this.colCDName.AppearanceCell.Options.UseTextOptions = true;
			this.colCDName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colCDName.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.colCDName.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.colCDName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.colCDName.AppearanceHeader.Options.UseFont = true;
			this.colCDName.AppearanceHeader.Options.UseTextOptions = true;
			this.colCDName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colCDName.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.colCDName.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.colCDName.Caption = "Tên Công Đoạn";
			this.colCDName.ColumnEdit = this.repositoryItemMemoEdit3;
			this.colCDName.FieldName = "CDName";
			this.colCDName.Name = "colCDName";
			this.colCDName.OptionsColumn.AllowEdit = false;
			this.colCDName.Visible = true;
			this.colCDName.VisibleIndex = 1;
			this.colCDName.Width = 216;
			// 
			// repositoryItemMemoEdit3
			// 
			this.repositoryItemMemoEdit3.Name = "repositoryItemMemoEdit3";
			// 
			// colCDCode
			// 
			this.colCDCode.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.colCDCode.AppearanceCell.Options.UseFont = true;
			this.colCDCode.AppearanceCell.Options.UseTextOptions = true;
			this.colCDCode.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colCDCode.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.colCDCode.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.colCDCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.colCDCode.AppearanceHeader.Options.UseFont = true;
			this.colCDCode.AppearanceHeader.Options.UseTextOptions = true;
			this.colCDCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colCDCode.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.colCDCode.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.colCDCode.Caption = "Mã Công Đoạn";
			this.colCDCode.ColumnEdit = this.repositoryItemMemoEdit3;
			this.colCDCode.FieldName = "CDCode";
			this.colCDCode.Name = "colCDCode";
			this.colCDCode.OptionsColumn.AllowEdit = false;
			this.colCDCode.Visible = true;
			this.colCDCode.VisibleIndex = 0;
			this.colCDCode.Width = 192;
			// 
			// colTaktTime
			// 
			this.colTaktTime.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 13.8F);
			this.colTaktTime.AppearanceCell.Options.UseFont = true;
			this.colTaktTime.AppearanceCell.Options.UseTextOptions = true;
			this.colTaktTime.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colTaktTime.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.colTaktTime.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.colTaktTime.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold);
			this.colTaktTime.AppearanceHeader.Options.UseFont = true;
			this.colTaktTime.AppearanceHeader.Options.UseTextOptions = true;
			this.colTaktTime.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colTaktTime.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.colTaktTime.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.colTaktTime.Caption = "Takt Time";
			this.colTaktTime.DisplayFormat.FormatString = "mm:ss";
			this.colTaktTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.colTaktTime.FieldName = "TaktTime";
			this.colTaktTime.Name = "colTaktTime";
			this.colTaktTime.Visible = true;
			this.colTaktTime.VisibleIndex = 2;
			this.colTaktTime.Width = 117;
			// 
			// colNameLocation
			// 
			this.colNameLocation.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 13.8F);
			this.colNameLocation.AppearanceCell.Options.UseFont = true;
			this.colNameLocation.AppearanceCell.Options.UseTextOptions = true;
			this.colNameLocation.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colNameLocation.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.colNameLocation.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.colNameLocation.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold);
			this.colNameLocation.AppearanceHeader.Options.UseFont = true;
			this.colNameLocation.AppearanceHeader.Options.UseTextOptions = true;
			this.colNameLocation.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colNameLocation.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.colNameLocation.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.colNameLocation.Caption = "Vị trí";
			this.colNameLocation.FieldName = "NameLocation";
			this.colNameLocation.Name = "colNameLocation";
			this.colNameLocation.Visible = true;
			this.colNameLocation.VisibleIndex = 3;
			// 
			// grdData
			// 
			this.grdData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.grdData.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.grdData.Location = new System.Drawing.Point(7, 34);
			this.grdData.MainView = this.grvData;
			this.grdData.Name = "grdData";
			this.grdData.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoEdit3});
			this.grdData.Size = new System.Drawing.Size(685, 433);
			this.grdData.TabIndex = 16;
			this.grdData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvData});
			this.grdData.Click += new System.EventHandler(this.grdData_Click);
			// 
			// btnDel
			// 
			this.btnDel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnDel.Image = ((System.Drawing.Image)(resources.GetObject("btnDel.Image")));
			this.btnDel.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnDel.Name = "btnDel";
			this.btnDel.Size = new System.Drawing.Size(50, 37);
			this.btnDel.Tag = "frmProduct_DeleteProductH";
			this.btnDel.Text = "Xóa CD";
			this.btnDel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
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
			this.btnEdit.Size = new System.Drawing.Size(51, 37);
			this.btnEdit.Tag = "frmProduct_EditProductH";
			this.btnEdit.Text = "Sửa CD";
			this.btnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			// 
			// toolStripSeparator6
			// 
			this.toolStripSeparator6.Name = "toolStripSeparator6";
			this.toolStripSeparator6.Size = new System.Drawing.Size(6, 23);
			// 
			// btnAdd
			// 
			this.btnAdd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
			this.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(50, 37);
			this.btnAdd.Tag = "frmProduct_AddProductH";
			this.btnAdd.Text = "Tạo CD";
			this.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.AutoSize = false;
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 40);
			// 
			// btnDeleteGroup
			// 
			this.btnDeleteGroup.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnDeleteGroup.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteGroup.Image")));
			this.btnDeleteGroup.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnDeleteGroup.Name = "btnDeleteGroup";
			this.btnDeleteGroup.Size = new System.Drawing.Size(56, 37);
			this.btnDeleteGroup.Tag = "frmProduct_DeleteGroupH";
			this.btnDeleteGroup.Text = "Xóa Kho";
			this.btnDeleteGroup.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnDeleteGroup.Click += new System.EventHandler(this.btnDeleteGroup_Click);
			// 
			// toolStripSeparator8
			// 
			this.toolStripSeparator8.Name = "toolStripSeparator8";
			this.toolStripSeparator8.Size = new System.Drawing.Size(6, 23);
			// 
			// btnEditGroup
			// 
			this.btnEditGroup.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnEditGroup.Image = ((System.Drawing.Image)(resources.GetObject("btnEditGroup.Image")));
			this.btnEditGroup.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnEditGroup.Name = "btnEditGroup";
			this.btnEditGroup.Size = new System.Drawing.Size(57, 37);
			this.btnEditGroup.Tag = "frmProduct_EditGroupH";
			this.btnEditGroup.Text = "Sửa Kho";
			this.btnEditGroup.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnEditGroup.Click += new System.EventHandler(this.btnEditGroup_Click);
			// 
			// toolStripSeparator9
			// 
			this.toolStripSeparator9.Name = "toolStripSeparator9";
			this.toolStripSeparator9.Size = new System.Drawing.Size(6, 23);
			// 
			// btnNewGroup
			// 
			this.btnNewGroup.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnNewGroup.Image = ((System.Drawing.Image)(resources.GetObject("btnNewGroup.Image")));
			this.btnNewGroup.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnNewGroup.Name = "btnNewGroup";
			this.btnNewGroup.Size = new System.Drawing.Size(56, 37);
			this.btnNewGroup.Tag = "frmProduct_AddGroupH";
			this.btnNewGroup.Text = "&Tạo Kho";
			this.btnNewGroup.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnNewGroup.Click += new System.EventHandler(this.btnNewGroup_Click);
			// 
			// mnuMenu
			// 
			this.mnuMenu.AutoSize = false;
			this.mnuMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
			this.mnuMenu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.mnuMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.mnuMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.mnuMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNewGroup,
            this.toolStripSeparator9,
            this.btnEditGroup,
            this.toolStripSeparator8,
            this.btnDeleteGroup,
            this.toolStripSeparator1,
            this.btnAdd,
            this.toolStripSeparator6,
            this.btnEdit,
            this.toolStripSeparator4,
            this.btnDel,
            this.toolStripSeparator10});
			this.mnuMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
			this.mnuMenu.Location = new System.Drawing.Point(0, 0);
			this.mnuMenu.Name = "mnuMenu";
			this.mnuMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
			this.mnuMenu.Size = new System.Drawing.Size(1038, 42);
			this.mnuMenu.TabIndex = 20;
			this.mnuMenu.Text = "toolStrip2";
			// 
			// toolStripSeparator10
			// 
			this.toolStripSeparator10.AutoSize = false;
			this.toolStripSeparator10.Name = "toolStripSeparator10";
			this.toolStripSeparator10.Size = new System.Drawing.Size(6, 40);
			// 
			// splitContainer1
			// 
			this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.splitContainer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
			this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.splitContainer1.Location = new System.Drawing.Point(0, 45);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.treeData);
			this.splitContainer1.Panel1.Controls.Add(this.labelControl1);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.btnFindAll);
			this.splitContainer1.Panel2.Controls.Add(this.txtName);
			this.splitContainer1.Panel2.Controls.Add(this.labelControl2);
			this.splitContainer1.Panel2.Controls.Add(this.grdData);
			this.splitContainer1.Size = new System.Drawing.Size(1038, 474);
			this.splitContainer1.SplitterDistance = 336;
			this.splitContainer1.TabIndex = 21;
			// 
			// treeData
			// 
			this.treeData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.treeData.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
			this.treeData.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
			this.treeData.Appearance.FocusedRow.Options.UseBackColor = true;
			this.treeData.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
			this.treeData.Appearance.HideSelectionRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
			this.treeData.Appearance.HideSelectionRow.Options.UseBackColor = true;
			this.treeData.ColumnPanelRowHeight = 40;
			this.treeData.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colIDTree,
            this.colNameTree,
            this.colCodeTree});
			this.treeData.Location = new System.Drawing.Point(-1, 34);
			this.treeData.Name = "treeData";
			this.treeData.OptionsBehavior.AllowExpandOnDblClick = false;
			this.treeData.OptionsBehavior.DragNodes = true;
			this.treeData.OptionsBehavior.Editable = false;
			this.treeData.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoEdit2});
			this.treeData.Size = new System.Drawing.Size(332, 439);
			this.treeData.TabIndex = 19;
			this.treeData.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.treeData_FocusedNodeChanged);
			// 
			// colIDTree
			// 
			this.colIDTree.Caption = "Mã nhóm";
			this.colIDTree.FieldName = "ID";
			this.colIDTree.Name = "colIDTree";
			// 
			// colNameTree
			// 
			this.colNameTree.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.colNameTree.AppearanceCell.Options.UseFont = true;
			this.colNameTree.AppearanceCell.Options.UseTextOptions = true;
			this.colNameTree.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colNameTree.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.colNameTree.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.colNameTree.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.colNameTree.AppearanceHeader.Options.UseFont = true;
			this.colNameTree.AppearanceHeader.Options.UseTextOptions = true;
			this.colNameTree.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colNameTree.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.colNameTree.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.colNameTree.Caption = "Tên Kho";
			this.colNameTree.ColumnEdit = this.repositoryItemMemoEdit2;
			this.colNameTree.FieldName = "Name";
			this.colNameTree.Name = "colNameTree";
			this.colNameTree.OptionsColumn.AllowEdit = false;
			this.colNameTree.OptionsColumn.AllowFocus = false;
			this.colNameTree.Visible = true;
			this.colNameTree.VisibleIndex = 1;
			this.colNameTree.Width = 156;
			// 
			// repositoryItemMemoEdit2
			// 
			this.repositoryItemMemoEdit2.Name = "repositoryItemMemoEdit2";
			// 
			// colCodeTree
			// 
			this.colCodeTree.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.colCodeTree.AppearanceCell.Options.UseFont = true;
			this.colCodeTree.AppearanceCell.Options.UseTextOptions = true;
			this.colCodeTree.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colCodeTree.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.colCodeTree.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.colCodeTree.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.colCodeTree.AppearanceHeader.Options.UseFont = true;
			this.colCodeTree.AppearanceHeader.Options.UseTextOptions = true;
			this.colCodeTree.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colCodeTree.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.colCodeTree.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.colCodeTree.Caption = "Mã Kho";
			this.colCodeTree.ColumnEdit = this.repositoryItemMemoEdit2;
			this.colCodeTree.FieldName = "Code";
			this.colCodeTree.Name = "colCodeTree";
			this.colCodeTree.OptionsColumn.AllowEdit = false;
			this.colCodeTree.OptionsColumn.AllowFocus = false;
			this.colCodeTree.Visible = true;
			this.colCodeTree.VisibleIndex = 0;
			this.colCodeTree.Width = 91;
			// 
			// labelControl1
			// 
			this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelControl1.Location = new System.Drawing.Point(6, 9);
			this.labelControl1.Name = "labelControl1";
			this.labelControl1.Size = new System.Drawing.Size(101, 17);
			this.labelControl1.TabIndex = 18;
			this.labelControl1.Text = "Danh sách kho";
			this.labelControl1.Click += new System.EventHandler(this.labelControl1_Click);
			// 
			// btnFindAll
			// 
			this.btnFindAll.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnFindAll.Appearance.Options.UseFont = true;
			this.btnFindAll.Location = new System.Drawing.Point(384, 6);
			this.btnFindAll.Name = "btnFindAll";
			this.btnFindAll.Size = new System.Drawing.Size(75, 23);
			this.btnFindAll.TabIndex = 21;
			this.btnFindAll.Text = "Tìm kiếm";
			this.btnFindAll.Click += new System.EventHandler(this.btnFindAll_Click);
			// 
			// txtName
			// 
			this.txtName.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtName.Location = new System.Drawing.Point(161, 6);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(217, 24);
			this.txtName.TabIndex = 20;
			this.txtName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtName_KeyDown);
			// 
			// labelControl2
			// 
			this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelControl2.Location = new System.Drawing.Point(7, 9);
			this.labelControl2.Name = "labelControl2";
			this.labelControl2.Size = new System.Drawing.Size(148, 17);
			this.labelControl2.TabIndex = 18;
			this.labelControl2.Text = "Danh sách công đoạn";
			// 
			// frmStockCD
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1038, 522);
			this.Controls.Add(this.mnuMenu);
			this.Controls.Add(this.splitContainer1);
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "frmStockCD";
			this.Text = "DANH SÁCH SẢN PHẨM HYPONIC";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmProduct_Load);
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grvData)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
			this.mnuMenu.ResumeLayout(false);
			this.mnuMenu.PerformLayout();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.PerformLayout();
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.treeData)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit2)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraGrid.Views.Grid.GridView grvData;
        private DevExpress.XtraGrid.GridControl grdData;
        private System.Windows.Forms.ToolStripButton btnDel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnDeleteGroup;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripButton btnEditGroup;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripButton btnNewGroup;
        private System.Windows.Forms.ToolStrip mnuMenu;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnFindAll;
        private System.Windows.Forms.TextBox txtName;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
		private System.ComponentModel.BackgroundWorker backgroundWorker1;
		private DevExpress.XtraGrid.Columns.GridColumn colID;
		private DevExpress.XtraGrid.Columns.GridColumn colStocID;
		private DevExpress.XtraGrid.Columns.GridColumn colCDName;
		private DevExpress.XtraGrid.Columns.GridColumn colCDCode;
		private DevExpress.XtraTreeList.TreeList treeData;
		private DevExpress.XtraTreeList.Columns.TreeListColumn colIDTree;
		private DevExpress.XtraTreeList.Columns.TreeListColumn colNameTree;
		private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit2;
		private DevExpress.XtraTreeList.Columns.TreeListColumn colCodeTree;
		private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit3;
		private DevExpress.XtraGrid.Columns.GridColumn colTaktTime;
		private DevExpress.XtraGrid.Columns.GridColumn colNameLocation;
	}
}