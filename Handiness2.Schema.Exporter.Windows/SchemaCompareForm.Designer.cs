namespace Handiness2.Schema.Exporter.Windows
{
    partial class SchemaCompareForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this._splitContainerSchemaInfo = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this._tvSourceSchema = new System.Windows.Forms.TreeView();
            this._imageListSrouceSchemaTree = new System.Windows.Forms.ImageList(this.components);
            this._tvTargetSchema = new System.Windows.Forms.TreeView();
            this._imageListTargetSchemaTree = new System.Windows.Forms.ImageList(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this._labelTipInfo = new System.Windows.Forms.Label();
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this._splitContainerSchemaInfo)).BeginInit();
            this._splitContainerSchemaInfo.Panel1.SuspendLayout();
            this._splitContainerSchemaInfo.Panel2.SuspendLayout();
            this._splitContainerSchemaInfo.SuspendLayout();
            this._tabSchemaShow.SuspendLayout();
            this._pageColumnSchema.SuspendLayout();
            this._pnlColumnSchema.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvColumnSchema)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._dgvIndexColumnSchema)).BeginInit();
            this._pageDefine.SuspendLayout();
            this._pnlSchemaDefine.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // _splitContainerSchemaInfo
            // 
            this._splitContainerSchemaInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._splitContainerSchemaInfo.BackColor = System.Drawing.Color.Gainsboro;
            this._splitContainerSchemaInfo.Location = new System.Drawing.Point(0, 0);
            this._splitContainerSchemaInfo.Name = "_splitContainerSchemaInfo";
            // 
            // _splitContainerSchemaInfo.Panel1
            // 
            this._splitContainerSchemaInfo.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this._splitContainerSchemaInfo.Panel1.Controls.Add(this._tabSchemaShow);
            this._splitContainerSchemaInfo.Panel1.Controls.Add(this.label1);
            this._splitContainerSchemaInfo.Panel1.Controls.Add(this._tvSourceSchema);
            // 
            // _splitContainerSchemaInfo.Panel2
            // 
            this._splitContainerSchemaInfo.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this._splitContainerSchemaInfo.Panel2.Controls.Add(this.tabControl1);
            this._splitContainerSchemaInfo.Panel2.Controls.Add(this._tvTargetSchema);
            this._splitContainerSchemaInfo.Panel2.Controls.Add(this.label2);
            this._splitContainerSchemaInfo.Size = new System.Drawing.Size(984, 641);
            this._splitContainerSchemaInfo.SplitterDistance = 478;
            this._splitContainerSchemaInfo.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label1.Location = new System.Drawing.Point(11, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "源结构信息";
            // 
            // _tvSourceSchema
            // 
            this._tvSourceSchema.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._tvSourceSchema.BackColor = System.Drawing.Color.White;
            this._tvSourceSchema.ImageIndex = 0;
            this._tvSourceSchema.ImageList = this._imageListSrouceSchemaTree;
            this._tvSourceSchema.ItemHeight = 23;
            this._tvSourceSchema.Location = new System.Drawing.Point(10, 45);
            this._tvSourceSchema.Name = "_tvSourceSchema";
            this._tvSourceSchema.SelectedImageIndex = 0;
            this._tvSourceSchema.ShowNodeToolTips = true;
            this._tvSourceSchema.Size = new System.Drawing.Size(457, 234);
            this._tvSourceSchema.TabIndex = 0;
            // 
            // _imageListSrouceSchemaTree
            // 
            this._imageListSrouceSchemaTree.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this._imageListSrouceSchemaTree.ImageSize = new System.Drawing.Size(16, 16);
            this._imageListSrouceSchemaTree.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // _tvTargetSchema
            // 
            this._tvTargetSchema.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._tvTargetSchema.BackColor = System.Drawing.Color.White;
            this._tvTargetSchema.ImageIndex = 0;
            this._tvTargetSchema.ImageList = this._imageListTargetSchemaTree;
            this._tvTargetSchema.ItemHeight = 23;
            this._tvTargetSchema.Location = new System.Drawing.Point(11, 45);
            this._tvTargetSchema.Name = "_tvTargetSchema";
            this._tvTargetSchema.SelectedImageIndex = 0;
            this._tvTargetSchema.Size = new System.Drawing.Size(480, 234);
            this._tvTargetSchema.TabIndex = 6;
            this._tvTargetSchema.DrawNode += new System.Windows.Forms.DrawTreeNodeEventHandler(this._tvTargetSchema_DrawNode);
            // 
            // _imageListTargetSchemaTree
            // 
            this._imageListTargetSchemaTree.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this._imageListTargetSchemaTree.ImageSize = new System.Drawing.Size(16, 16);
            this._imageListTargetSchemaTree.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label2.Location = new System.Drawing.Point(12, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "目标结构信息";
            // 
            // _labelTipInfo
            // 
            this._labelTipInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._labelTipInfo.AutoEllipsis = true;
            this._labelTipInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this._labelTipInfo.ForeColor = System.Drawing.Color.White;
            this._labelTipInfo.Location = new System.Drawing.Point(0, 644);
            this._labelTipInfo.Name = "_labelTipInfo";
            this._labelTipInfo.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this._labelTipInfo.Size = new System.Drawing.Size(984, 17);
            this._labelTipInfo.TabIndex = 23;
            this._labelTipInfo.Text = "..";
            // 
            // _tabSchemaShow
            // 
            this._tabSchemaShow.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._tabSchemaShow.Controls.Add(this._pageColumnSchema);
            this._tabSchemaShow.Controls.Add(this._pageDefine);
            this._tabSchemaShow.Location = new System.Drawing.Point(12, 285);
            this._tabSchemaShow.Name = "_tabSchemaShow";
            this._tabSchemaShow.SelectedIndex = 0;
            this._tabSchemaShow.Size = new System.Drawing.Size(455, 349);
            this._tabSchemaShow.TabIndex = 31;
            // 
            // _pageColumnSchema
            // 
            this._pageColumnSchema.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this._pageColumnSchema.Controls.Add(this._pnlColumnSchema);
            this._pageColumnSchema.Location = new System.Drawing.Point(4, 26);
            this._pageColumnSchema.Name = "_pageColumnSchema";
            this._pageColumnSchema.Size = new System.Drawing.Size(447, 319);
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
            this._pnlColumnSchema.Size = new System.Drawing.Size(447, 319);
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
            this._dgvColumnSchema.Size = new System.Drawing.Size(441, 192);
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
            this._dgvIndexColumnSchema.Location = new System.Drawing.Point(3, 206);
            this._dgvIndexColumnSchema.Name = "_dgvIndexColumnSchema";
            this._dgvIndexColumnSchema.RowHeadersVisible = false;
            this._dgvIndexColumnSchema.RowTemplate.Height = 23;
            this._dgvIndexColumnSchema.Size = new System.Drawing.Size(441, 110);
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
            this._pageDefine.Size = new System.Drawing.Size(447, 323);
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
            this._pnlSchemaDefine.Size = new System.Drawing.Size(441, 317);
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
            this._richTbSchemaDefine.Size = new System.Drawing.Size(441, 317);
            this._richTbSchemaDefine.TabIndex = 0;
            this._richTbSchemaDefine.Text = "";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(11, 285);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(479, 349);
            this.tabControl1.TabIndex = 32;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(471, 319);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "列信息";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.dataGridView2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(471, 319);
            this.panel1.TabIndex = 2;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewCheckBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewCheckBoxColumn2,
            this.dataGridViewTextBoxColumn4});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(166)))), ((int)(((byte)(228)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView1.Location = new System.Drawing.Point(3, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(465, 192);
            this.dataGridView1.TabIndex = 7;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "列名";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.HeaderText = "主键";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewCheckBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "类型";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "长度";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewCheckBoxColumn2
            // 
            this.dataGridViewCheckBoxColumn2.HeaderText = "可空";
            this.dataGridViewCheckBoxColumn2.Name = "dataGridViewCheckBoxColumn2";
            this.dataGridViewCheckBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewCheckBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "说明";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridView2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(166)))), ((int)(((byte)(228)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView2.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridView2.Location = new System.Drawing.Point(3, 206);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.Size = new System.Drawing.Size(465, 110);
            this.dataGridView2.TabIndex = 28;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "名称";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "关联列";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "说明";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(471, 315);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "定义";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.richTextBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(465, 309);
            this.panel2.TabIndex = 1;
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.White;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.richTextBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.richTextBox1.Location = new System.Drawing.Point(0, 0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(465, 309);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // SchemaCompareForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 661);
            this.Controls.Add(this._labelTipInfo);
            this.Controls.Add(this._splitContainerSchemaInfo);
            this.Name = "SchemaCompareForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "结构差异比较";
            this._splitContainerSchemaInfo.Panel1.ResumeLayout(false);
            this._splitContainerSchemaInfo.Panel1.PerformLayout();
            this._splitContainerSchemaInfo.Panel2.ResumeLayout(false);
            this._splitContainerSchemaInfo.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._splitContainerSchemaInfo)).EndInit();
            this._splitContainerSchemaInfo.ResumeLayout(false);
            this._tabSchemaShow.ResumeLayout(false);
            this._pageColumnSchema.ResumeLayout(false);
            this._pnlColumnSchema.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dgvColumnSchema)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._dgvIndexColumnSchema)).EndInit();
            this._pageDefine.ResumeLayout(false);
            this._pnlSchemaDefine.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer _splitContainerSchemaInfo;
        private System.Windows.Forms.TreeView _tvSourceSchema;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TreeView _tvTargetSchema;
        private System.Windows.Forms.Label _labelTipInfo;
        private System.Windows.Forms.ImageList _imageListSrouceSchemaTree;
        private System.Windows.Forms.ImageList _imageListTargetSchemaTree;
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
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}