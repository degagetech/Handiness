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
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("测试组", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("的撒", "account.png");
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("的撒", "account.png");
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("的撒旦", "adapter_16x16.png");
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("的撒", "adapter_16x16.png");
            this._cbExcelExportTemplate = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this._btnEditorConnectionString = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this._checkMerge = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // _cbExcelExportTemplate
            // 
            this._cbExcelExportTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._cbExcelExportTemplate.BackColor = System.Drawing.Color.White;
            this._cbExcelExportTemplate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cbExcelExportTemplate.FormattingEnabled = true;
            this._cbExcelExportTemplate.Location = new System.Drawing.Point(95, 69);
            this._cbExcelExportTemplate.Name = "_cbExcelExportTemplate";
            this._cbExcelExportTemplate.Size = new System.Drawing.Size(349, 25);
            this._cbExcelExportTemplate.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "导出模板";
            // 
            // _btnEditorConnectionString
            // 
            this._btnEditorConnectionString.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnEditorConnectionString.Location = new System.Drawing.Point(457, 69);
            this._btnEditorConnectionString.Name = "_btnEditorConnectionString";
            this._btnEditorConnectionString.Size = new System.Drawing.Size(63, 26);
            this._btnEditorConnectionString.TabIndex = 5;
            this._btnEditorConnectionString.Text = "编辑...";
            this._btnEditorConnectionString.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "自定义分组";
            // 
            // _checkMerge
            // 
            this._checkMerge.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._checkMerge.AutoSize = true;
            this._checkMerge.Location = new System.Drawing.Point(678, 20);
            this._checkMerge.Name = "_checkMerge";
            this._checkMerge.Size = new System.Drawing.Size(207, 21);
            this._checkMerge.TabIndex = 7;
            this._checkMerge.Text = "导出相同分组的信息至同一工作表";
            this._checkMerge.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(597, 17);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(63, 26);
            this.button1.TabIndex = 9;
            this.button1.Text = "编辑...";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            listViewGroup1.Header = "测试组";
            listViewGroup1.Name = "_groupFirst";
            this.listView1.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1});
            this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4});
            this.listView1.Location = new System.Drawing.Point(95, 16);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(490, 39);
            this.listView1.TabIndex = 12;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // ExcelExportConfigControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this._checkMerge);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._btnEditorConnectionString);
            this.Controls.Add(this._cbExcelExportTemplate);
            this.Controls.Add(this.label1);
            this.Name = "ExcelExportConfigControl";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox _cbExcelExportTemplate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button _btnEditorConnectionString;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox _checkMerge;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView listView1;
    }
}
