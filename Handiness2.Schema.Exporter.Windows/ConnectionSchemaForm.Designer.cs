namespace Handiness2.Schema.Exporter.Windows
{
    partial class ConnectionSchemaForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConnectionSchemaForm));
            this._labelProviderExplain = new System.Windows.Forms.Label();
            this._waitSchemProvider = new Concision.Controls.WaitIndicator();
            this._btnEditorConnectionString = new System.Windows.Forms.Button();
            this._tbConnectionString = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this._cbSchemaProvider = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this._labelTipInfo = new System.Windows.Forms.Label();
            this._tvSchema = new System.Windows.Forms.TreeView();
            this._iListSchemaTree = new System.Windows.Forms.ImageList(this.components);
            this._tabSchemaShow = new System.Windows.Forms.TabControl();
            this._pageColumnSchema = new System.Windows.Forms.TabPage();
            this._pnlColumnSchema = new System.Windows.Forms.Panel();
            this._dgvColumnSchema = new System.Windows.Forms.DataGridView();
            this._colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._colPrimary = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this._colType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._colLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._colNullable = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this._colExplain = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._dgvIndexColumnSchema = new System.Windows.Forms.DataGridView();
            this._colIndexName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._colIndexColumnNames = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._colIndexDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._pageDefine = new System.Windows.Forms.TabPage();
            this._pnlSchemaDefine = new System.Windows.Forms.Panel();
            this._richTbSchemaDefine = new System.Windows.Forms.RichTextBox();
            this._lblLoadTypeSymbol = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this._btnOpen = new System.Windows.Forms.Button();
            this._waitConnect = new Concision.Controls.WaitIndicator();
            this._waitColumnSchemaLoad = new Concision.Controls.WaitIndicator();
            this._btnCompare = new System.Windows.Forms.Button();
            this._btnCannel = new System.Windows.Forms.Button();
            this._toolTip = new System.Windows.Forms.ToolTip(this.components);
            this._tabSchemaShow.SuspendLayout();
            this._pageColumnSchema.SuspendLayout();
            this._pnlColumnSchema.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvColumnSchema)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._dgvIndexColumnSchema)).BeginInit();
            this._pageDefine.SuspendLayout();
            this._pnlSchemaDefine.SuspendLayout();
            this.SuspendLayout();
            // 
            // _labelProviderExplain
            // 
            this._labelProviderExplain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._labelProviderExplain.AutoEllipsis = true;
            this._labelProviderExplain.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this._labelProviderExplain.Location = new System.Drawing.Point(478, 69);
            this._labelProviderExplain.Name = "_labelProviderExplain";
            this._labelProviderExplain.Size = new System.Drawing.Size(395, 17);
            this._labelProviderExplain.TabIndex = 18;
            this._labelProviderExplain.Text = ".";
            // 
            // _waitSchemProvider
            // 
            this._waitSchemProvider.CurrentAngle = 180F;
            this._waitSchemProvider.EachRollingAngle = 15F;
            this._waitSchemProvider.EnabledMousePierce = false;
            this._waitSchemProvider.HatchBrushStyle = System.Drawing.Drawing2D.HatchStyle.DarkHorizontal;
            this._waitSchemProvider.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this._waitSchemProvider.IsFollowParentBackColor = true;
            this._waitSchemProvider.Location = new System.Drawing.Point(447, 67);
            this._waitSchemProvider.Margin = new System.Windows.Forms.Padding(0);
            this._waitSchemProvider.Name = "_waitSchemProvider";
            this._waitSchemProvider.RollingSpeed = 60D;
            this._waitSchemProvider.RollPartBrushType = Concision.Controls.RollPartBrushType.Solid;
            this._waitSchemProvider.RollPartLengthPercent = 40F;
            this._waitSchemProvider.RollPartWidthPercent = 20F;
            this._waitSchemProvider.Size = new System.Drawing.Size(20, 20);
            this._waitSchemProvider.TabIndex = 17;
            this._waitSchemProvider.Text = "waitIndicator1";
            this._waitSchemProvider.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._waitSchemProvider.Visible = false;
            this._waitSchemProvider.WaitIndicatorColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            // 
            // _btnEditorConnectionString
            // 
            this._btnEditorConnectionString.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnEditorConnectionString.Location = new System.Drawing.Point(810, 25);
            this._btnEditorConnectionString.Name = "_btnEditorConnectionString";
            this._btnEditorConnectionString.Size = new System.Drawing.Size(63, 26);
            this._btnEditorConnectionString.TabIndex = 16;
            this._btnEditorConnectionString.Text = "编辑...";
            this._btnEditorConnectionString.UseVisualStyleBackColor = true;
            this._btnEditorConnectionString.Click += new System.EventHandler(this._btnEditorConnectionString_Click);
            // 
            // _tbConnectionString
            // 
            this._tbConnectionString.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._tbConnectionString.BackColor = System.Drawing.Color.White;
            this._tbConnectionString.Location = new System.Drawing.Point(88, 27);
            this._tbConnectionString.Name = "_tbConnectionString";
            this._tbConnectionString.Size = new System.Drawing.Size(716, 23);
            this._tbConnectionString.TabIndex = 15;
            this._tbConnectionString.Text = "Data Source=192.168.1.120;Initial Catalog=biobank;User ID=sa;Password=932444208wl" +
    "j+";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 14;
            this.label2.Text = "连接字符串";
            // 
            // _cbSchemaProvider
            // 
            this._cbSchemaProvider.BackColor = System.Drawing.Color.White;
            this._cbSchemaProvider.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cbSchemaProvider.FormattingEnabled = true;
            this._cbSchemaProvider.Location = new System.Drawing.Point(88, 64);
            this._cbSchemaProvider.Name = "_cbSchemaProvider";
            this._cbSchemaProvider.Size = new System.Drawing.Size(349, 25);
            this._cbSchemaProvider.TabIndex = 12;
            this._cbSchemaProvider.SelectedValueChanged += new System.EventHandler(this._cbSchemaProvider_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 13;
            this.label1.Text = "结构提供源";
            // 
            // _labelTipInfo
            // 
            this._labelTipInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._labelTipInfo.AutoEllipsis = true;
            this._labelTipInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this._labelTipInfo.ForeColor = System.Drawing.Color.White;
            this._labelTipInfo.Location = new System.Drawing.Point(-1, 450);
            this._labelTipInfo.Name = "_labelTipInfo";
            this._labelTipInfo.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this._labelTipInfo.Size = new System.Drawing.Size(885, 17);
            this._labelTipInfo.TabIndex = 23;
            this._labelTipInfo.Text = "..";
            // 
            // _tvSchema
            // 
            this._tvSchema.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this._tvSchema.BackColor = System.Drawing.Color.White;
            this._tvSchema.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._tvSchema.CheckBoxes = true;
            this._tvSchema.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this._tvSchema.ImageIndex = 0;
            this._tvSchema.ImageList = this._iListSchemaTree;
            this._tvSchema.ItemHeight = 23;
            this._tvSchema.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this._tvSchema.Location = new System.Drawing.Point(17, 137);
            this._tvSchema.Name = "_tvSchema";
            this._tvSchema.SelectedImageIndex = 0;
            this._tvSchema.ShowNodeToolTips = true;
            this._tvSchema.Size = new System.Drawing.Size(274, 266);
            this._tvSchema.TabIndex = 24;
            this._tvSchema.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this._tvSchema_NodeMouseClick);
            // 
            // _iListSchemaTree
            // 
            this._iListSchemaTree.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this._iListSchemaTree.ImageSize = new System.Drawing.Size(16, 16);
            this._iListSchemaTree.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // _tabSchemaShow
            // 
            this._tabSchemaShow.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._tabSchemaShow.Controls.Add(this._pageColumnSchema);
            this._tabSchemaShow.Controls.Add(this._pageDefine);
            this._tabSchemaShow.Location = new System.Drawing.Point(297, 107);
            this._tabSchemaShow.Name = "_tabSchemaShow";
            this._tabSchemaShow.SelectedIndex = 0;
            this._tabSchemaShow.Size = new System.Drawing.Size(576, 296);
            this._tabSchemaShow.TabIndex = 31;
            // 
            // _pageColumnSchema
            // 
            this._pageColumnSchema.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this._pageColumnSchema.Controls.Add(this._pnlColumnSchema);
            this._pageColumnSchema.Location = new System.Drawing.Point(4, 26);
            this._pageColumnSchema.Name = "_pageColumnSchema";
            this._pageColumnSchema.Size = new System.Drawing.Size(568, 266);
            this._pageColumnSchema.TabIndex = 0;
            this._pageColumnSchema.Text = "列信息";
            // 
            // _pnlColumnSchema
            // 
            this._pnlColumnSchema.Controls.Add(this._dgvColumnSchema);
            this._pnlColumnSchema.Controls.Add(this._dgvIndexColumnSchema);
            this._pnlColumnSchema.Dock = System.Windows.Forms.DockStyle.Fill;
            this._pnlColumnSchema.Location = new System.Drawing.Point(0, 0);
            this._pnlColumnSchema.Margin = new System.Windows.Forms.Padding(0);
            this._pnlColumnSchema.Name = "_pnlColumnSchema";
            this._pnlColumnSchema.Size = new System.Drawing.Size(568, 266);
            this._pnlColumnSchema.TabIndex = 2;
            // 
            // _dgvColumnSchema
            // 
            this._dgvColumnSchema.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this._dgvColumnSchema.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this._dgvColumnSchema.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dgvColumnSchema.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._dgvColumnSchema.BackgroundColor = System.Drawing.Color.White;
            this._dgvColumnSchema.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._dgvColumnSchema.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._colName,
            this._colPrimary,
            this._colType,
            this._colLength,
            this._colNullable,
            this._colExplain});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(166)))), ((int)(((byte)(228)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._dgvColumnSchema.DefaultCellStyle = dataGridViewCellStyle2;
            this._dgvColumnSchema.Location = new System.Drawing.Point(3, 4);
            this._dgvColumnSchema.Name = "_dgvColumnSchema";
            this._dgvColumnSchema.RowHeadersVisible = false;
            this._dgvColumnSchema.RowTemplate.Height = 23;
            this._dgvColumnSchema.Size = new System.Drawing.Size(562, 139);
            this._dgvColumnSchema.TabIndex = 7;
            // 
            // _colName
            // 
            this._colName.HeaderText = "列名";
            this._colName.Name = "_colName";
            // 
            // _colPrimary
            // 
            this._colPrimary.HeaderText = "主键";
            this._colPrimary.Name = "_colPrimary";
            this._colPrimary.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this._colPrimary.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // _colType
            // 
            this._colType.HeaderText = "类型";
            this._colType.Name = "_colType";
            // 
            // _colLength
            // 
            this._colLength.HeaderText = "长度";
            this._colLength.Name = "_colLength";
            // 
            // _colNullable
            // 
            this._colNullable.HeaderText = "可空";
            this._colNullable.Name = "_colNullable";
            this._colNullable.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this._colNullable.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // _colExplain
            // 
            this._colExplain.HeaderText = "说明";
            this._colExplain.Name = "_colExplain";
            // 
            // _dgvIndexColumnSchema
            // 
            this._dgvIndexColumnSchema.AllowUserToAddRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this._dgvIndexColumnSchema.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this._dgvIndexColumnSchema.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dgvIndexColumnSchema.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._dgvIndexColumnSchema.BackgroundColor = System.Drawing.Color.White;
            this._dgvIndexColumnSchema.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._dgvIndexColumnSchema.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._colIndexName,
            this._colIndexColumnNames,
            this._colIndexDesc});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(166)))), ((int)(((byte)(228)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._dgvIndexColumnSchema.DefaultCellStyle = dataGridViewCellStyle4;
            this._dgvIndexColumnSchema.Location = new System.Drawing.Point(3, 153);
            this._dgvIndexColumnSchema.Name = "_dgvIndexColumnSchema";
            this._dgvIndexColumnSchema.RowHeadersVisible = false;
            this._dgvIndexColumnSchema.RowTemplate.Height = 23;
            this._dgvIndexColumnSchema.Size = new System.Drawing.Size(562, 110);
            this._dgvIndexColumnSchema.TabIndex = 28;
            // 
            // _colIndexName
            // 
            this._colIndexName.HeaderText = "名称";
            this._colIndexName.Name = "_colIndexName";
            // 
            // _colIndexColumnNames
            // 
            this._colIndexColumnNames.HeaderText = "关联列";
            this._colIndexColumnNames.Name = "_colIndexColumnNames";
            this._colIndexColumnNames.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // _colIndexDesc
            // 
            this._colIndexDesc.HeaderText = "说明";
            this._colIndexDesc.Name = "_colIndexDesc";
            // 
            // _pageDefine
            // 
            this._pageDefine.Controls.Add(this._pnlSchemaDefine);
            this._pageDefine.Location = new System.Drawing.Point(4, 26);
            this._pageDefine.Name = "_pageDefine";
            this._pageDefine.Padding = new System.Windows.Forms.Padding(3);
            this._pageDefine.Size = new System.Drawing.Size(568, 266);
            this._pageDefine.TabIndex = 1;
            this._pageDefine.Text = "定义";
            this._pageDefine.UseVisualStyleBackColor = true;
            // 
            // _pnlSchemaDefine
            // 
            this._pnlSchemaDefine.Controls.Add(this._richTbSchemaDefine);
            this._pnlSchemaDefine.Dock = System.Windows.Forms.DockStyle.Fill;
            this._pnlSchemaDefine.Location = new System.Drawing.Point(3, 3);
            this._pnlSchemaDefine.Margin = new System.Windows.Forms.Padding(0);
            this._pnlSchemaDefine.Name = "_pnlSchemaDefine";
            this._pnlSchemaDefine.Size = new System.Drawing.Size(562, 260);
            this._pnlSchemaDefine.TabIndex = 1;
            // 
            // _richTbSchemaDefine
            // 
            this._richTbSchemaDefine.BackColor = System.Drawing.Color.White;
            this._richTbSchemaDefine.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._richTbSchemaDefine.Dock = System.Windows.Forms.DockStyle.Fill;
            this._richTbSchemaDefine.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this._richTbSchemaDefine.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this._richTbSchemaDefine.Location = new System.Drawing.Point(0, 0);
            this._richTbSchemaDefine.Name = "_richTbSchemaDefine";
            this._richTbSchemaDefine.Size = new System.Drawing.Size(562, 260);
            this._richTbSchemaDefine.TabIndex = 0;
            this._richTbSchemaDefine.Text = "";
            // 
            // _lblLoadTypeSymbol
            // 
            this._lblLoadTypeSymbol.AutoSize = true;
            this._lblLoadTypeSymbol.Image = global::Handiness2.Schema.Exporter.Windows.Properties.Resources.schema_load_database;
            this._lblLoadTypeSymbol.Location = new System.Drawing.Point(50, 109);
            this._lblLoadTypeSymbol.Name = "_lblLoadTypeSymbol";
            this._lblLoadTypeSymbol.Size = new System.Drawing.Size(20, 17);
            this._lblLoadTypeSymbol.TabIndex = 36;
            this._lblLoadTypeSymbol.Text = "   ";
            this._lblLoadTypeSymbol.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 17);
            this.label3.TabIndex = 32;
            this.label3.Text = "目录";
            // 
            // _btnOpen
            // 
            this._btnOpen.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnOpen.FlatAppearance.BorderSize = 0;
            this._btnOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnOpen.Image = ((System.Drawing.Image)(resources.GetObject("_btnOpen.Image")));
            this._btnOpen.Location = new System.Drawing.Point(263, 107);
            this._btnOpen.Name = "_btnOpen";
            this._btnOpen.Size = new System.Drawing.Size(29, 26);
            this._btnOpen.TabIndex = 33;
            this._btnOpen.UseVisualStyleBackColor = true;
            this._btnOpen.Click += new System.EventHandler(this._btnOpen_Click);
            // 
            // _waitConnect
            // 
            this._waitConnect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this._waitConnect.CurrentAngle = 180F;
            this._waitConnect.EachRollingAngle = 15F;
            this._waitConnect.EnabledMousePierce = false;
            this._waitConnect.HatchBrushStyle = System.Drawing.Drawing2D.HatchStyle.DarkHorizontal;
            this._waitConnect.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this._waitConnect.IsFollowParentBackColor = true;
            this._waitConnect.Location = new System.Drawing.Point(239, 112);
            this._waitConnect.Margin = new System.Windows.Forms.Padding(0);
            this._waitConnect.Name = "_waitConnect";
            this._waitConnect.RollingSpeed = 60D;
            this._waitConnect.RollPartBrushType = Concision.Controls.RollPartBrushType.Solid;
            this._waitConnect.RollPartLengthPercent = 60F;
            this._waitConnect.RollPartWidthPercent = 30F;
            this._waitConnect.Size = new System.Drawing.Size(15, 15);
            this._waitConnect.TabIndex = 34;
            this._waitConnect.Text = "waitIndicator1";
            this._waitConnect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._waitConnect.Visible = false;
            this._waitConnect.WaitIndicatorColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            // 
            // _waitColumnSchemaLoad
            // 
            this._waitColumnSchemaLoad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this._waitColumnSchemaLoad.CurrentAngle = 180F;
            this._waitColumnSchemaLoad.EachRollingAngle = 15F;
            this._waitColumnSchemaLoad.EnabledMousePierce = false;
            this._waitColumnSchemaLoad.HatchBrushStyle = System.Drawing.Drawing2D.HatchStyle.DarkHorizontal;
            this._waitColumnSchemaLoad.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this._waitColumnSchemaLoad.IsFollowParentBackColor = true;
            this._waitColumnSchemaLoad.Location = new System.Drawing.Point(84, 112);
            this._waitColumnSchemaLoad.Margin = new System.Windows.Forms.Padding(0);
            this._waitColumnSchemaLoad.Name = "_waitColumnSchemaLoad";
            this._waitColumnSchemaLoad.RollingSpeed = 60D;
            this._waitColumnSchemaLoad.RollPartBrushType = Concision.Controls.RollPartBrushType.Solid;
            this._waitColumnSchemaLoad.RollPartLengthPercent = 60F;
            this._waitColumnSchemaLoad.RollPartWidthPercent = 30F;
            this._waitColumnSchemaLoad.Size = new System.Drawing.Size(15, 15);
            this._waitColumnSchemaLoad.TabIndex = 35;
            this._waitColumnSchemaLoad.Text = "waitIndicator1";
            this._waitColumnSchemaLoad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._waitColumnSchemaLoad.Visible = false;
            this._waitColumnSchemaLoad.WaitIndicatorColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            // 
            // _btnCompare
            // 
            this._btnCompare.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnCompare.Location = new System.Drawing.Point(715, 412);
            this._btnCompare.Name = "_btnCompare";
            this._btnCompare.Size = new System.Drawing.Size(63, 26);
            this._btnCompare.TabIndex = 37;
            this._btnCompare.Text = "比较";
            this._btnCompare.UseVisualStyleBackColor = true;
            this._btnCompare.Click += new System.EventHandler(this._btnCompare_Click);
            // 
            // _btnCannel
            // 
            this._btnCannel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnCannel.Location = new System.Drawing.Point(804, 412);
            this._btnCannel.Name = "_btnCannel";
            this._btnCannel.Size = new System.Drawing.Size(63, 26);
            this._btnCannel.TabIndex = 38;
            this._btnCannel.Text = "取消";
            this._btnCannel.UseVisualStyleBackColor = true;
            // 
            // ConnectionSchemaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 467);
            this.Controls.Add(this._btnCannel);
            this.Controls.Add(this._btnCompare);
            this.Controls.Add(this._lblLoadTypeSymbol);
            this.Controls.Add(this.label3);
            this.Controls.Add(this._btnOpen);
            this.Controls.Add(this._waitConnect);
            this.Controls.Add(this._waitColumnSchemaLoad);
            this.Controls.Add(this._tabSchemaShow);
            this.Controls.Add(this._tvSchema);
            this.Controls.Add(this._labelTipInfo);
            this.Controls.Add(this._labelProviderExplain);
            this.Controls.Add(this._waitSchemProvider);
            this.Controls.Add(this._btnEditorConnectionString);
            this.Controls.Add(this._tbConnectionString);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._cbSchemaProvider);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.MaximizeBox = false;
            this.Name = "ConnectionSchemaForm";
            this.Text = "通过数据连接获取目标结构";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConnectionSchemaForm_FormClosing);
            this.Load += new System.EventHandler(this.ConnectionSchemaForm_Load);
            this.Shown += new System.EventHandler(this.ConnectionSchemaForm_Shown);
            this._tabSchemaShow.ResumeLayout(false);
            this._pageColumnSchema.ResumeLayout(false);
            this._pnlColumnSchema.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dgvColumnSchema)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._dgvIndexColumnSchema)).EndInit();
            this._pageDefine.ResumeLayout(false);
            this._pnlSchemaDefine.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _labelProviderExplain;
        private Concision.Controls.WaitIndicator _waitSchemProvider;
        private System.Windows.Forms.Button _btnEditorConnectionString;
        private System.Windows.Forms.TextBox _tbConnectionString;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox _cbSchemaProvider;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label _labelTipInfo;
        private System.Windows.Forms.TreeView _tvSchema;
        private System.Windows.Forms.TabControl _tabSchemaShow;
        private System.Windows.Forms.TabPage _pageColumnSchema;
        private System.Windows.Forms.Panel _pnlColumnSchema;
        private System.Windows.Forms.DataGridView _dgvColumnSchema;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn _colPrimary;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colType;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colLength;
        private System.Windows.Forms.DataGridViewCheckBoxColumn _colNullable;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colExplain;
        private System.Windows.Forms.DataGridView _dgvIndexColumnSchema;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colIndexName;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colIndexColumnNames;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colIndexDesc;
        private System.Windows.Forms.TabPage _pageDefine;
        private System.Windows.Forms.Panel _pnlSchemaDefine;
        private System.Windows.Forms.RichTextBox _richTbSchemaDefine;
        private System.Windows.Forms.Label _lblLoadTypeSymbol;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button _btnOpen;
        private Concision.Controls.WaitIndicator _waitConnect;
        private Concision.Controls.WaitIndicator _waitColumnSchemaLoad;
        private System.Windows.Forms.Button _btnCompare;
        private System.Windows.Forms.Button _btnCannel;
        private System.Windows.Forms.ImageList _iListSchemaTree;
        private System.Windows.Forms.ToolTip _toolTip;
    }
}