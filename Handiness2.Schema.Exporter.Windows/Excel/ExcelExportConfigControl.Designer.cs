namespace Handiness2.Schema.Exporter.Windows
{
    partial class ExcelExportConfigControl
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExcelExportConfigControl));
            this._cbExcelExportTemplate = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this._btnEditorConnectionString = new System.Windows.Forms.Button();
            this._checkMerge = new System.Windows.Forms.CheckBox();
            this._btnEditGroup = new System.Windows.Forms.Button();
            this._lvGroup = new System.Windows.Forms.ListView();
            this._iListItem = new System.Windows.Forms.ImageList(this.components);
            this._checkCustomGroup = new System.Windows.Forms.CheckBox();
            this._pannelGroup = new System.Windows.Forms.Panel();
            this._checkExclude = new System.Windows.Forms.CheckBox();
            this._toolTip = new System.Windows.Forms.ToolTip(this.components);
            this._pannelGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // _cbExcelExportTemplate
            // 
            this._cbExcelExportTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._cbExcelExportTemplate.BackColor = System.Drawing.Color.White;
            this._cbExcelExportTemplate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cbExcelExportTemplate.FormattingEnabled = true;
            this._cbExcelExportTemplate.Location = new System.Drawing.Point(104, 109);
            this._cbExcelExportTemplate.Name = "_cbExcelExportTemplate";
            this._cbExcelExportTemplate.Size = new System.Drawing.Size(349, 25);
            this._cbExcelExportTemplate.TabIndex = 2;
            this._cbExcelExportTemplate.SelectedIndexChanged += new System.EventHandler(this._cbExcelExportTemplate_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "样式模板";
            // 
            // _btnEditorConnectionString
            // 
            this._btnEditorConnectionString.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnEditorConnectionString.Location = new System.Drawing.Point(466, 109);
            this._btnEditorConnectionString.Name = "_btnEditorConnectionString";
            this._btnEditorConnectionString.Size = new System.Drawing.Size(63, 26);
            this._btnEditorConnectionString.TabIndex = 5;
            this._btnEditorConnectionString.Text = "编辑...";
            this._btnEditorConnectionString.UseVisualStyleBackColor = true;
            this._btnEditorConnectionString.Click += new System.EventHandler(this._btnEditorConnectionString_Click);
            // 
            // _checkMerge
            // 
            this._checkMerge.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._checkMerge.AutoSize = true;
            this._checkMerge.Location = new System.Drawing.Point(563, 111);
            this._checkMerge.Name = "_checkMerge";
            this._checkMerge.Size = new System.Drawing.Size(207, 21);
            this._checkMerge.TabIndex = 7;
            this._checkMerge.Text = "导出相同分组的信息至同一工作表";
            this._checkMerge.UseVisualStyleBackColor = true;
            this._checkMerge.CheckedChanged += new System.EventHandler(this._checkMerge_CheckedChanged);
            // 
            // _btnEditGroup
            // 
            this._btnEditGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnEditGroup.Location = new System.Drawing.Point(715, 3);
            this._btnEditGroup.Name = "_btnEditGroup";
            this._btnEditGroup.Size = new System.Drawing.Size(63, 26);
            this._btnEditGroup.TabIndex = 9;
            this._btnEditGroup.Text = "编辑...";
            this._btnEditGroup.UseVisualStyleBackColor = true;
            this._btnEditGroup.Click += new System.EventHandler(this._btnEditGroup_Click);
            // 
            // _lvGroup
            // 
            this._lvGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._lvGroup.BackColor = System.Drawing.Color.White;
            this._lvGroup.LargeImageList = this._iListItem;
            this._lvGroup.Location = new System.Drawing.Point(3, 3);
            this._lvGroup.Name = "_lvGroup";
            this._lvGroup.Size = new System.Drawing.Size(706, 87);
            this._lvGroup.TabIndex = 12;
            this._lvGroup.UseCompatibleStateImageBehavior = false;
            // 
            // _iListItem
            // 
            this._iListItem.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("_iListItem.ImageStream")));
            this._iListItem.TransparentColor = System.Drawing.Color.Transparent;
            this._iListItem.Images.SetKeyName(0, "table.png");
            // 
            // _checkCustomGroup
            // 
            this._checkCustomGroup.AutoSize = true;
            this._checkCustomGroup.Location = new System.Drawing.Point(7, 11);
            this._checkCustomGroup.Name = "_checkCustomGroup";
            this._checkCustomGroup.Size = new System.Drawing.Size(87, 21);
            this._checkCustomGroup.TabIndex = 13;
            this._checkCustomGroup.Text = "自定义分组";
            this._checkCustomGroup.UseVisualStyleBackColor = true;
            this._checkCustomGroup.CheckedChanged += new System.EventHandler(this._checkCustomGroup_CheckedChanged);
            // 
            // _pannelGroup
            // 
            this._pannelGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._pannelGroup.Controls.Add(this._checkExclude);
            this._pannelGroup.Controls.Add(this._lvGroup);
            this._pannelGroup.Controls.Add(this._btnEditGroup);
            this._pannelGroup.Enabled = false;
            this._pannelGroup.Location = new System.Drawing.Point(102, 10);
            this._pannelGroup.Name = "_pannelGroup";
            this._pannelGroup.Size = new System.Drawing.Size(791, 93);
            this._pannelGroup.TabIndex = 14;
            // 
            // _checkExclude
            // 
            this._checkExclude.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._checkExclude.AutoSize = true;
            this._checkExclude.Enabled = false;
            this._checkExclude.Location = new System.Drawing.Point(718, 37);
            this._checkExclude.Name = "_checkExclude";
            this._checkExclude.Size = new System.Drawing.Size(63, 21);
            this._checkExclude.TabIndex = 15;
            this._checkExclude.Text = "只包含";
            this._toolTip.SetToolTip(this._checkExclude, "当使用自定义分组时，导出的元信息中是否只包含分组内的");
            this._checkExclude.UseVisualStyleBackColor = true;
            this._checkExclude.CheckedChanged += new System.EventHandler(this._checkExclude_CheckedChanged);
            // 
            // _toolTip
            // 
            this._toolTip.BackColor = System.Drawing.Color.White;
            this._toolTip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            // 
            // ExcelExportConfigControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._pannelGroup);
            this.Controls.Add(this._checkCustomGroup);
            this.Controls.Add(this._checkMerge);
            this.Controls.Add(this._btnEditorConnectionString);
            this.Controls.Add(this._cbExcelExportTemplate);
            this.Controls.Add(this.label1);
            this.Name = "ExcelExportConfigControl";
            this.Size = new System.Drawing.Size(900, 143);
            this._pannelGroup.ResumeLayout(false);
            this._pannelGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox _cbExcelExportTemplate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button _btnEditorConnectionString;
        private System.Windows.Forms.CheckBox _checkMerge;
        private System.Windows.Forms.Button _btnEditGroup;
        private System.Windows.Forms.ListView _lvGroup;
        private System.Windows.Forms.CheckBox _checkCustomGroup;
        private System.Windows.Forms.Panel _pannelGroup;
        private System.Windows.Forms.ImageList _iListItem;
        private System.Windows.Forms.CheckBox _checkExclude;
        private System.Windows.Forms.ToolTip _toolTip;
    }
}
