﻿namespace Handiness2.Schema.Exporter.Windows
{
    partial class SchemaExportForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SchemaExportForm));
            this._cbSchemaProvider = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this._tbConnectionString = new System.Windows.Forms.TextBox();
            this._btnEditorConnectionString = new System.Windows.Forms.Button();
            this._tvSchema = new System.Windows.Forms.TreeView();
            this._iListSchemaTree = new System.Windows.Forms.ImageList(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this._dgvColumnSchema = new System.Windows.Forms.DataGridView();
            this._colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._colPrimary = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this._colType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._colLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._colNullable = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this._colExplain = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._btnOpen = new System.Windows.Forms.Button();
            this._waitSchemProvider = new Concision.Controls.WaitIndicator();
            this._labelProviderExplain = new System.Windows.Forms.Label();
            this.line1 = new Concision.Controls.Line();
            this.line2 = new Concision.Controls.Line();
            this._waitConnect = new Concision.Controls.WaitIndicator();
            this._waitColumnSchemaLoad = new Concision.Controls.WaitIndicator();
            this.line3 = new Concision.Controls.Line();
            this.label4 = new System.Windows.Forms.Label();
            this._pbarExportProcess = new System.Windows.Forms.ProgressBar();
            this._btnExport = new System.Windows.Forms.Button();
            this._tabExportConfig = new System.Windows.Forms.TabControl();
            this._pageExcel = new System.Windows.Forms.TabPage();
            this._pageCode = new System.Windows.Forms.TabPage();
            this._labelExprtProcess = new System.Windows.Forms.Label();
            this._labelTipInfo = new System.Windows.Forms.Label();
            this.excelExportConfigControl1 = new Handiness2.Schema.Exporter.Windows.ExcelExportConfigControl();
            ((System.ComponentModel.ISupportInitialize)(this._dgvColumnSchema)).BeginInit();
            this._tabExportConfig.SuspendLayout();
            this._pageExcel.SuspendLayout();
            this.SuspendLayout();
            // 
            // _cbSchemaProvider
            // 
            this._cbSchemaProvider.BackColor = System.Drawing.Color.White;
            this._cbSchemaProvider.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cbSchemaProvider.FormattingEnabled = true;
            this._cbSchemaProvider.Location = new System.Drawing.Point(98, 59);
            this._cbSchemaProvider.Name = "_cbSchemaProvider";
            this._cbSchemaProvider.Size = new System.Drawing.Size(349, 25);
            this._cbSchemaProvider.TabIndex = 0;
            this._cbSchemaProvider.SelectedValueChanged += new System.EventHandler(this._cbSchemaProvider_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "结构提供源";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "连接字符串";
            // 
            // _tbConnectionString
            // 
            this._tbConnectionString.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._tbConnectionString.BackColor = System.Drawing.Color.White;
            this._tbConnectionString.Location = new System.Drawing.Point(98, 22);
            this._tbConnectionString.Name = "_tbConnectionString";
            this._tbConnectionString.Size = new System.Drawing.Size(761, 23);
            this._tbConnectionString.TabIndex = 3;
            this._tbConnectionString.Text = "Data Source=117.48.197.78;Initial Catalog=biobank_report;User ID=sa;Password=9324" +
    "44208wlj+";
            // 
            // _btnEditorConnectionString
            // 
            this._btnEditorConnectionString.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnEditorConnectionString.Location = new System.Drawing.Point(875, 20);
            this._btnEditorConnectionString.Name = "_btnEditorConnectionString";
            this._btnEditorConnectionString.Size = new System.Drawing.Size(63, 26);
            this._btnEditorConnectionString.TabIndex = 4;
            this._btnEditorConnectionString.Text = "编辑...";
            this._btnEditorConnectionString.UseVisualStyleBackColor = true;
            this._btnEditorConnectionString.Click += new System.EventHandler(this._btnEditorConnectionString_Click);
            // 
            // _tvSchema
            // 
            this._tvSchema.BackColor = System.Drawing.Color.White;
            this._tvSchema.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._tvSchema.CheckBoxes = true;
            this._tvSchema.ImageIndex = 0;
            this._tvSchema.ImageList = this._iListSchemaTree;
            this._tvSchema.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this._tvSchema.Location = new System.Drawing.Point(30, 139);
            this._tvSchema.Name = "_tvSchema";
            this._tvSchema.SelectedImageIndex = 0;
            this._tvSchema.ShowNodeToolTips = true;
            this._tvSchema.Size = new System.Drawing.Size(274, 352);
            this._tvSchema.TabIndex = 5;
            this._tvSchema.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this._tvSchema_AfterCheck);
            this._tvSchema.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this._tvSchema_NodeMouseClick);
            // 
            // _iListSchemaTree
            // 
            this._iListSchemaTree.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this._iListSchemaTree.ImageSize = new System.Drawing.Size(16, 16);
            this._iListSchemaTree.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "表/视图";
            // 
            // _dgvColumnSchema
            // 
            this._dgvColumnSchema.AllowUserToAddRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this._dgvColumnSchema.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this._dgvColumnSchema.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
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
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(166)))), ((int)(((byte)(228)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._dgvColumnSchema.DefaultCellStyle = dataGridViewCellStyle4;
            this._dgvColumnSchema.Location = new System.Drawing.Point(313, 139);
            this._dgvColumnSchema.Name = "_dgvColumnSchema";
            this._dgvColumnSchema.RowHeadersVisible = false;
            this._dgvColumnSchema.RowTemplate.Height = 23;
            this._dgvColumnSchema.Size = new System.Drawing.Size(625, 352);
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
            // _btnOpen
            // 
            this._btnOpen.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnOpen.FlatAppearance.BorderSize = 0;
            this._btnOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnOpen.Image = ((System.Drawing.Image)(resources.GetObject("_btnOpen.Image")));
            this._btnOpen.Location = new System.Drawing.Point(275, 111);
            this._btnOpen.Name = "_btnOpen";
            this._btnOpen.Size = new System.Drawing.Size(29, 26);
            this._btnOpen.TabIndex = 8;
            this._btnOpen.UseVisualStyleBackColor = true;
            this._btnOpen.Click += new System.EventHandler(this._btnOpen_Click);
            // 
            // _waitSchemProvider
            // 
            this._waitSchemProvider.CurrentAngle = 180F;
            this._waitSchemProvider.EachRollingAngle = 15F;
            this._waitSchemProvider.EnabledMousePierce = false;
            this._waitSchemProvider.HatchBrushStyle = System.Drawing.Drawing2D.HatchStyle.DarkHorizontal;
            this._waitSchemProvider.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this._waitSchemProvider.IsFollowParentBackColor = true;
            this._waitSchemProvider.Location = new System.Drawing.Point(457, 62);
            this._waitSchemProvider.Margin = new System.Windows.Forms.Padding(0);
            this._waitSchemProvider.Name = "_waitSchemProvider";
            this._waitSchemProvider.RollingSpeed = 60D;
            this._waitSchemProvider.RollPartBrushType = Concision.Controls.RollPartBrushType.Solid;
            this._waitSchemProvider.RollPartLengthPercent = 40F;
            this._waitSchemProvider.RollPartWidthPercent = 20F;
            this._waitSchemProvider.Size = new System.Drawing.Size(20, 20);
            this._waitSchemProvider.TabIndex = 10;
            this._waitSchemProvider.Text = "waitIndicator1";
            this._waitSchemProvider.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._waitSchemProvider.Visible = false;
            this._waitSchemProvider.WaitIndicatorColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            // 
            // _labelProviderExplain
            // 
            this._labelProviderExplain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._labelProviderExplain.AutoEllipsis = true;
            this._labelProviderExplain.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this._labelProviderExplain.Location = new System.Drawing.Point(488, 64);
            this._labelProviderExplain.Name = "_labelProviderExplain";
            this._labelProviderExplain.Size = new System.Drawing.Size(450, 17);
            this._labelProviderExplain.TabIndex = 11;
            this._labelProviderExplain.Text = ".";
            // 
            // line1
            // 
            this.line1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.line1.CustomBursh = null;
            this.line1.EnabledMousePierce = false;
            this.line1.IsVertical = false;
            this.line1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this.line1.LineLength = 980;
            this.line1.LineWidth = 1;
            this.line1.Location = new System.Drawing.Point(0, 96);
            this.line1.Margin = new System.Windows.Forms.Padding(0);
            this.line1.Name = "line1";
            this.line1.Size = new System.Drawing.Size(980, 1);
            this.line1.TabIndex = 12;
            this.line1.Text = "line1";
            this.line1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // line2
            // 
            this.line2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.line2.CustomBursh = null;
            this.line2.EnabledMousePierce = false;
            this.line2.IsVertical = false;
            this.line2.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this.line2.LineLength = 980;
            this.line2.LineWidth = 1;
            this.line2.Location = new System.Drawing.Point(-8, 511);
            this.line2.Margin = new System.Windows.Forms.Padding(0);
            this.line2.Name = "line2";
            this.line2.Size = new System.Drawing.Size(980, 1);
            this.line2.TabIndex = 13;
            this.line2.Text = "line2";
            this.line2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _waitConnect
            // 
            this._waitConnect.CurrentAngle = 180F;
            this._waitConnect.EachRollingAngle = 15F;
            this._waitConnect.EnabledMousePierce = false;
            this._waitConnect.HatchBrushStyle = System.Drawing.Drawing2D.HatchStyle.DarkHorizontal;
            this._waitConnect.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this._waitConnect.IsFollowParentBackColor = true;
            this._waitConnect.Location = new System.Drawing.Point(251, 116);
            this._waitConnect.Margin = new System.Windows.Forms.Padding(0);
            this._waitConnect.Name = "_waitConnect";
            this._waitConnect.RollingSpeed = 60D;
            this._waitConnect.RollPartBrushType = Concision.Controls.RollPartBrushType.Solid;
            this._waitConnect.RollPartLengthPercent = 60F;
            this._waitConnect.RollPartWidthPercent = 30F;
            this._waitConnect.Size = new System.Drawing.Size(15, 15);
            this._waitConnect.TabIndex = 14;
            this._waitConnect.Text = "waitIndicator1";
            this._waitConnect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._waitConnect.Visible = false;
            this._waitConnect.WaitIndicatorColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            // 
            // _waitColumnSchemaLoad
            // 
            this._waitColumnSchemaLoad.CurrentAngle = 180F;
            this._waitColumnSchemaLoad.EachRollingAngle = 15F;
            this._waitColumnSchemaLoad.EnabledMousePierce = false;
            this._waitColumnSchemaLoad.HatchBrushStyle = System.Drawing.Drawing2D.HatchStyle.DarkHorizontal;
            this._waitColumnSchemaLoad.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this._waitColumnSchemaLoad.IsFollowParentBackColor = true;
            this._waitColumnSchemaLoad.Location = new System.Drawing.Point(313, 116);
            this._waitColumnSchemaLoad.Margin = new System.Windows.Forms.Padding(0);
            this._waitColumnSchemaLoad.Name = "_waitColumnSchemaLoad";
            this._waitColumnSchemaLoad.RollingSpeed = 60D;
            this._waitColumnSchemaLoad.RollPartBrushType = Concision.Controls.RollPartBrushType.Solid;
            this._waitColumnSchemaLoad.RollPartLengthPercent = 60F;
            this._waitColumnSchemaLoad.RollPartWidthPercent = 30F;
            this._waitColumnSchemaLoad.Size = new System.Drawing.Size(15, 15);
            this._waitColumnSchemaLoad.TabIndex = 15;
            this._waitColumnSchemaLoad.Text = "waitIndicator1";
            this._waitColumnSchemaLoad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._waitColumnSchemaLoad.Visible = false;
            this._waitColumnSchemaLoad.WaitIndicatorColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            // 
            // line3
            // 
            this.line3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.line3.CustomBursh = null;
            this.line3.EnabledMousePierce = false;
            this.line3.IsVertical = false;
            this.line3.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this.line3.LineLength = 980;
            this.line3.LineWidth = 1;
            this.line3.Location = new System.Drawing.Point(-8, 662);
            this.line3.Margin = new System.Windows.Forms.Padding(0);
            this.line3.Name = "line3";
            this.line3.Size = new System.Drawing.Size(980, 1);
            this.line3.TabIndex = 16;
            this.line3.Text = "line3";
            this.line3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 677);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 17);
            this.label4.TabIndex = 17;
            this.label4.Text = "导出进度";
            // 
            // _pbarExportProcess
            // 
            this._pbarExportProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._pbarExportProcess.Location = new System.Drawing.Point(87, 677);
            this._pbarExportProcess.Name = "_pbarExportProcess";
            this._pbarExportProcess.Size = new System.Drawing.Size(409, 17);
            this._pbarExportProcess.TabIndex = 18;
            this._pbarExportProcess.Value = 20;
            // 
            // _btnExport
            // 
            this._btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnExport.Location = new System.Drawing.Point(875, 674);
            this._btnExport.Name = "_btnExport";
            this._btnExport.Size = new System.Drawing.Size(63, 26);
            this._btnExport.TabIndex = 19;
            this._btnExport.Text = "导出";
            this._btnExport.UseVisualStyleBackColor = true;
            // 
            // _tabExportConfig
            // 
            this._tabExportConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._tabExportConfig.Controls.Add(this._pageExcel);
            this._tabExportConfig.Controls.Add(this._pageCode);
            this._tabExportConfig.Location = new System.Drawing.Point(30, 521);
            this._tabExportConfig.Name = "_tabExportConfig";
            this._tabExportConfig.SelectedIndex = 0;
            this._tabExportConfig.Size = new System.Drawing.Size(908, 133);
            this._tabExportConfig.TabIndex = 20;
            // 
            // _pageExcel
            // 
            this._pageExcel.Controls.Add(this.excelExportConfigControl1);
            this._pageExcel.Location = new System.Drawing.Point(4, 26);
            this._pageExcel.Name = "_pageExcel";
            this._pageExcel.Size = new System.Drawing.Size(900, 103);
            this._pageExcel.TabIndex = 0;
            this._pageExcel.Text = "Excel(.xlsx)";
            this._pageExcel.UseVisualStyleBackColor = true;
            // 
            // _pageCode
            // 
            this._pageCode.Location = new System.Drawing.Point(4, 26);
            this._pageCode.Name = "_pageCode";
            this._pageCode.Size = new System.Drawing.Size(900, 103);
            this._pageCode.TabIndex = 1;
            this._pageCode.Text = "代码";
            this._pageCode.UseVisualStyleBackColor = true;
            // 
            // _labelExprtProcess
            // 
            this._labelExprtProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._labelExprtProcess.AutoSize = true;
            this._labelExprtProcess.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this._labelExprtProcess.Location = new System.Drawing.Point(504, 677);
            this._labelExprtProcess.Name = "_labelExprtProcess";
            this._labelExprtProcess.Size = new System.Drawing.Size(56, 17);
            this._labelExprtProcess.TabIndex = 21;
            this._labelExprtProcess.Text = "(18/100)";
            // 
            // _labelTipInfo
            // 
            this._labelTipInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._labelTipInfo.AutoSize = true;
            this._labelTipInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this._labelTipInfo.Location = new System.Drawing.Point(24, 700);
            this._labelTipInfo.Name = "_labelTipInfo";
            this._labelTipInfo.Size = new System.Drawing.Size(56, 17);
            this._labelTipInfo.TabIndex = 22;
            this._labelTipInfo.Text = "提示信息";
            // 
            // excelExportConfigControl1
            // 
            this.excelExportConfigControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.excelExportConfigControl1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.excelExportConfigControl1.Location = new System.Drawing.Point(0, 0);
            this.excelExportConfigControl1.Margin = new System.Windows.Forms.Padding(0);
            this.excelExportConfigControl1.Name = "excelExportConfigControl1";
            this.excelExportConfigControl1.Size = new System.Drawing.Size(900, 103);
            this.excelExportConfigControl1.TabIndex = 0;
            // 
            // SchemaExportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(964, 721);
            this.Controls.Add(this._labelTipInfo);
            this.Controls.Add(this._labelExprtProcess);
            this.Controls.Add(this._tabExportConfig);
            this.Controls.Add(this._btnExport);
            this.Controls.Add(this._pbarExportProcess);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.line3);
            this.Controls.Add(this._waitColumnSchemaLoad);
            this.Controls.Add(this._waitConnect);
            this.Controls.Add(this.line2);
            this.Controls.Add(this.line1);
            this.Controls.Add(this._labelProviderExplain);
            this.Controls.Add(this._waitSchemProvider);
            this.Controls.Add(this._btnOpen);
            this.Controls.Add(this._dgvColumnSchema);
            this.Controls.Add(this.label3);
            this.Controls.Add(this._tvSchema);
            this.Controls.Add(this._btnEditorConnectionString);
            this.Controls.Add(this._tbConnectionString);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._cbSchemaProvider);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(980, 760);
            this.Name = "SchemaExportForm";
            this.Text = "[HANDINESS] 结构导出工具";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.SchemaExportForm_HelpButtonClicked);
            this.Load += new System.EventHandler(this.SchemaExportForm_Load);
            this.Shown += new System.EventHandler(this.SchemaExportForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this._dgvColumnSchema)).EndInit();
            this._tabExportConfig.ResumeLayout(false);
            this._pageExcel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox _cbSchemaProvider;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox _tbConnectionString;
        private System.Windows.Forms.Button _btnEditorConnectionString;
        private System.Windows.Forms.TreeView _tvSchema;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView _dgvColumnSchema;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn _colPrimary;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colType;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colLength;
        private System.Windows.Forms.DataGridViewCheckBoxColumn _colNullable;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colExplain;
        private System.Windows.Forms.Button _btnOpen;
        private Concision.Controls.WaitIndicator _waitSchemProvider;
        private System.Windows.Forms.Label _labelProviderExplain;
        private Concision.Controls.Line line1;
        private Concision.Controls.Line line2;
        private Concision.Controls.WaitIndicator _waitConnect;
        private System.Windows.Forms.ImageList _iListSchemaTree;
        private Concision.Controls.WaitIndicator _waitColumnSchemaLoad;
        private Concision.Controls.Line line3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ProgressBar _pbarExportProcess;
        private System.Windows.Forms.Button _btnExport;
        private System.Windows.Forms.TabControl _tabExportConfig;
        private System.Windows.Forms.TabPage _pageExcel;
        private System.Windows.Forms.TabPage _pageCode;
        private System.Windows.Forms.Label _labelExprtProcess;
        private System.Windows.Forms.Label _labelTipInfo;
        private ExcelExportConfigControl excelExportConfigControl1;
    }
}

