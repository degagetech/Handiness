namespace Handiness2.Schema.Exporter.Windows
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SchemaExportForm));
            this._cbSchemaProvider = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this._tbConnectionString = new System.Windows.Forms.TextBox();
            this._btnEditorConnectionString = new System.Windows.Forms.Button();
            this._tvSchema = new System.Windows.Forms.TreeView();
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
            ((System.ComponentModel.ISupportInitialize)(this._dgvColumnSchema)).BeginInit();
            this.SuspendLayout();
            // 
            // _cbSchemaProvider
            // 
            this._cbSchemaProvider.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this._tvSchema.Location = new System.Drawing.Point(30, 139);
            this._tvSchema.Name = "_tvSchema";
            this._tvSchema.Size = new System.Drawing.Size(274, 352);
            this._tvSchema.TabIndex = 5;
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
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(166)))), ((int)(((byte)(228)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._dgvColumnSchema.DefaultCellStyle = dataGridViewCellStyle2;
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
            this._waitSchemProvider.Location = new System.Drawing.Point(457, 61);
            this._waitSchemProvider.Margin = new System.Windows.Forms.Padding(0);
            this._waitSchemProvider.Name = "_waitSchemProvider";
            this._waitSchemProvider.RollingSpeed = 60D;
            this._waitSchemProvider.RollPartBrushType = Concision.Controls.RollPartBrushType.Solid;
            this._waitSchemProvider.RollPartLengthPercent = 40F;
            this._waitSchemProvider.RollPartWidthPercent = 20F;
            this._waitSchemProvider.Size = new System.Drawing.Size(23, 23);
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
            this._waitConnect.Location = new System.Drawing.Point(246, 113);
            this._waitConnect.Margin = new System.Windows.Forms.Padding(0);
            this._waitConnect.Name = "_waitConnect";
            this._waitConnect.RollingSpeed = 60D;
            this._waitConnect.RollPartBrushType = Concision.Controls.RollPartBrushType.Solid;
            this._waitConnect.RollPartLengthPercent = 40F;
            this._waitConnect.RollPartWidthPercent = 20F;
            this._waitConnect.Size = new System.Drawing.Size(23, 23);
            this._waitConnect.TabIndex = 14;
            this._waitConnect.Text = "waitIndicator1";
            this._waitConnect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._waitConnect.Visible = false;
            this._waitConnect.WaitIndicatorColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            // 
            // SchemaExportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(964, 721);
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
            this.Name = "SchemaExportForm";
            this.Text = "[HANDINESS] 结构导出工具";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.SchemaExportForm_HelpButtonClicked);
            this.Load += new System.EventHandler(this.SchemaExportForm_Load);
            this.Shown += new System.EventHandler(this.SchemaExportForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this._dgvColumnSchema)).EndInit();
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
    }
}

