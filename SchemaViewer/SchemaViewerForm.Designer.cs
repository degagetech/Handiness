namespace SchemaViewer
{
    partial class SchemaViewerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SchemaViewerForm));
            this._spcMain = new System.Windows.Forms.SplitContainer();
            this._btnConfirm = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this._txtConnectionString = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this._cmbDataBaseType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this._spcRight = new System.Windows.Forms.SplitContainer();
            this._btnQuery = new System.Windows.Forms.Button();
            this._txtRestriction = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this._dgvDataShow = new SchemaViewer.DataGridViewEx();
            this.label6 = new System.Windows.Forms.Label();
            this._cmbCollectionName = new System.Windows.Forms.ComboBox();
            this._cbNewForm = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this._spcMain)).BeginInit();
            this._spcMain.Panel1.SuspendLayout();
            this._spcMain.Panel2.SuspendLayout();
            this._spcMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._spcRight)).BeginInit();
            this._spcRight.Panel1.SuspendLayout();
            this._spcRight.Panel2.SuspendLayout();
            this._spcRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvDataShow)).BeginInit();
            this.SuspendLayout();
            // 
            // _spcMain
            // 
            this._spcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this._spcMain.Location = new System.Drawing.Point(0, 0);
            this._spcMain.Name = "_spcMain";
            // 
            // _spcMain.Panel1
            // 
            this._spcMain.Panel1.AutoScroll = true;
            this._spcMain.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this._spcMain.Panel1.Controls.Add(this._btnConfirm);
            this._spcMain.Panel1.Controls.Add(this.textBox2);
            this._spcMain.Panel1.Controls.Add(this.label3);
            this._spcMain.Panel1.Controls.Add(this._txtConnectionString);
            this._spcMain.Panel1.Controls.Add(this.label2);
            this._spcMain.Panel1.Controls.Add(this._cmbDataBaseType);
            this._spcMain.Panel1.Controls.Add(this.label1);
            // 
            // _spcMain.Panel2
            // 
            this._spcMain.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this._spcMain.Panel2.Controls.Add(this._spcRight);
            this._spcMain.Size = new System.Drawing.Size(1350, 729);
            this._spcMain.SplitterDistance = 449;
            this._spcMain.SplitterWidth = 2;
            this._spcMain.TabIndex = 0;
            // 
            // _btnConfirm
            // 
            this._btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this._btnConfirm.FlatAppearance.BorderSize = 0;
            this._btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnConfirm.ForeColor = System.Drawing.Color.White;
            this._btnConfirm.Location = new System.Drawing.Point(341, 652);
            this._btnConfirm.Name = "_btnConfirm";
            this._btnConfirm.Size = new System.Drawing.Size(80, 31);
            this._btnConfirm.TabIndex = 6;
            this._btnConfirm.Text = "确定";
            this._btnConfirm.UseVisualStyleBackColor = false;
            this._btnConfirm.Click += new System.EventHandler(this._btnConfrim_Click);
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Location = new System.Drawing.Point(35, 249);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(386, 379);
            this.textBox2.TabIndex = 5;
            this.textBox2.Text = resources.GetString("textBox2.Text");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.label3.Location = new System.Drawing.Point(28, 210);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "连接字符串示例";
            // 
            // _txtConnectionString
            // 
            this._txtConnectionString.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtConnectionString.BackColor = System.Drawing.Color.WhiteSmoke;
            this._txtConnectionString.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._txtConnectionString.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this._txtConnectionString.Location = new System.Drawing.Point(35, 164);
            this._txtConnectionString.Name = "_txtConnectionString";
            this._txtConnectionString.Size = new System.Drawing.Size(390, 19);
            this._txtConnectionString.TabIndex = 3;
            this._txtConnectionString.Text = "server=192.168.1.102;Port=3306;Uid=root;Pwd=932444208;DataBase=school;Pooling=tru" +
    "e;charset=utf8;";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.label2.Location = new System.Drawing.Point(28, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "连接字符串";
            // 
            // _cmbDataBaseType
            // 
            this._cmbDataBaseType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this._cmbDataBaseType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbDataBaseType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._cmbDataBaseType.FormattingEnabled = true;
            this._cmbDataBaseType.Location = new System.Drawing.Point(31, 76);
            this._cmbDataBaseType.Name = "_cmbDataBaseType";
            this._cmbDataBaseType.Size = new System.Drawing.Size(305, 25);
            this._cmbDataBaseType.TabIndex = 1;
            this._cmbDataBaseType.SelectedIndexChanged += new System.EventHandler(this._cmbDataBaseType_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.label1.Location = new System.Drawing.Point(24, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "数据库类型";
            // 
            // _spcRight
            // 
            this._spcRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this._spcRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this._spcRight.Location = new System.Drawing.Point(0, 0);
            this._spcRight.Name = "_spcRight";
            this._spcRight.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // _spcRight.Panel1
            // 
            this._spcRight.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this._spcRight.Panel1.Controls.Add(this.label5);
            this._spcRight.Panel1.Controls.Add(this._cbNewForm);
            this._spcRight.Panel1.Controls.Add(this._cmbCollectionName);
            this._spcRight.Panel1.Controls.Add(this.label6);
            this._spcRight.Panel1.Controls.Add(this._btnQuery);
            this._spcRight.Panel1.Controls.Add(this._txtRestriction);
            this._spcRight.Panel1.Controls.Add(this.label4);
            // 
            // _spcRight.Panel2
            // 
            this._spcRight.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this._spcRight.Panel2.Controls.Add(this._dgvDataShow);
            this._spcRight.Size = new System.Drawing.Size(899, 729);
            this._spcRight.SplitterDistance = 175;
            this._spcRight.SplitterWidth = 1;
            this._spcRight.TabIndex = 0;
            // 
            // _btnQuery
            // 
            this._btnQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnQuery.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this._btnQuery.FlatAppearance.BorderSize = 0;
            this._btnQuery.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnQuery.ForeColor = System.Drawing.Color.White;
            this._btnQuery.Location = new System.Drawing.Point(784, 129);
            this._btnQuery.Name = "_btnQuery";
            this._btnQuery.Size = new System.Drawing.Size(80, 31);
            this._btnQuery.TabIndex = 7;
            this._btnQuery.Text = "查询";
            this._btnQuery.UseVisualStyleBackColor = false;
            this._btnQuery.Click += new System.EventHandler(this._btnQuery_Click);
            // 
            // _txtRestriction
            // 
            this._txtRestriction.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtRestriction.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this._txtRestriction.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._txtRestriction.Location = new System.Drawing.Point(121, 79);
            this._txtRestriction.Multiline = true;
            this._txtRestriction.Name = "_txtRestriction";
            this._txtRestriction.Size = new System.Drawing.Size(628, 81);
            this._txtRestriction.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.label4.Location = new System.Drawing.Point(50, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "查询限制";
            // 
            // _dgvDataShow
            // 
            this._dgvDataShow.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._dgvDataShow.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this._dgvDataShow.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._dgvDataShow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dgvDataShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this._dgvDataShow.Location = new System.Drawing.Point(0, 0);
            this._dgvDataShow.MultiSelect = false;
            this._dgvDataShow.Name = "_dgvDataShow";
            this._dgvDataShow.ReadOnly = true;
            this._dgvDataShow.RowHeadersVisible = false;
            this._dgvDataShow.RowTemplate.Height = 23;
            this._dgvDataShow.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dgvDataShow.Size = new System.Drawing.Size(899, 553);
            this._dgvDataShow.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.label6.Location = new System.Drawing.Point(26, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 17);
            this.label6.TabIndex = 8;
            this.label6.Text = "查询集合名称";
            // 
            // _cmbCollectionName
            // 
            this._cmbCollectionName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this._cmbCollectionName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._cmbCollectionName.FormattingEnabled = true;
            this._cmbCollectionName.Location = new System.Drawing.Point(121, 19);
            this._cmbCollectionName.Name = "_cmbCollectionName";
            this._cmbCollectionName.Size = new System.Drawing.Size(373, 25);
            this._cmbCollectionName.TabIndex = 9;
            // 
            // _cbNewForm
            // 
            this._cbNewForm.AutoSize = true;
            this._cbNewForm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this._cbNewForm.Location = new System.Drawing.Point(516, 23);
            this._cbNewForm.Name = "_cbNewForm";
            this._cbNewForm.Size = new System.Drawing.Size(99, 21);
            this._cbNewForm.TabIndex = 10;
            this._cbNewForm.Text = "显示到新窗体";
            this._cbNewForm.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.label5.Location = new System.Drawing.Point(757, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "请以 ; 号分割";
            // 
            // SchemaViewerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this._spcMain);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SchemaViewerForm";
            this.Text = "SchemaViewer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SchemaViewerForm_FormClosing);
            this._spcMain.Panel1.ResumeLayout(false);
            this._spcMain.Panel1.PerformLayout();
            this._spcMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._spcMain)).EndInit();
            this._spcMain.ResumeLayout(false);
            this._spcRight.Panel1.ResumeLayout(false);
            this._spcRight.Panel1.PerformLayout();
            this._spcRight.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._spcRight)).EndInit();
            this._spcRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dgvDataShow)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer _spcMain;
        private System.Windows.Forms.TextBox _txtConnectionString;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox _cmbDataBaseType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button _btnConfirm;
        private System.Windows.Forms.SplitContainer _spcRight;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox _txtRestriction;
        private System.Windows.Forms.Button _btnQuery;
        private DataGridViewEx _dgvDataShow;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox _cmbCollectionName;
        private System.Windows.Forms.CheckBox _cbNewForm;
        private System.Windows.Forms.Label label5;
    }
}

