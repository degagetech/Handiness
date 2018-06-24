namespace Handiness2.Schema.Exporter.Windows
{
    partial class ExcelExportGroupForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExcelExportGroupForm));
            this._cbGroup = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this._checkItemContainer = new System.Windows.Forms.CheckedListBox();
            this.line1 = new Concision.Controls.Line();
            this._btnAddGroup = new System.Windows.Forms.Button();
            this._btnDeleteGroup = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _cbGroup
            // 
            this._cbGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._cbGroup.BackColor = System.Drawing.Color.White;
            this._cbGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cbGroup.FormattingEnabled = true;
            this._cbGroup.Location = new System.Drawing.Point(89, 30);
            this._cbGroup.Name = "_cbGroup";
            this._cbGroup.Size = new System.Drawing.Size(318, 25);
            this._cbGroup.TabIndex = 10;
            this._cbGroup.SelectedIndexChanged += new System.EventHandler(this._cbGroup_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "已有分组";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "account.png");
            this.imageList1.Images.SetKeyName(1, "adapter_16x16.png");
            // 
            // _checkItemContainer
            // 
            this._checkItemContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._checkItemContainer.BackColor = System.Drawing.Color.White;
            this._checkItemContainer.CheckOnClick = true;
            this._checkItemContainer.ColumnWidth = 175;
            this._checkItemContainer.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this._checkItemContainer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this._checkItemContainer.FormattingEnabled = true;
            this._checkItemContainer.HorizontalScrollbar = true;
            this._checkItemContainer.Location = new System.Drawing.Point(26, 113);
            this._checkItemContainer.MultiColumn = true;
            this._checkItemContainer.Name = "_checkItemContainer";
            this._checkItemContainer.Size = new System.Drawing.Size(535, 277);
            this._checkItemContainer.TabIndex = 11;
            this._checkItemContainer.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this._checkItemContainer_ItemCheck);
            // 
            // line1
            // 
            this.line1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.line1.CustomBursh = null;
            this.line1.EnabledMousePierce = false;
            this.line1.IsVertical = false;
            this.line1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this.line1.LineLength = 600;
            this.line1.LineWidth = 1;
            this.line1.Location = new System.Drawing.Point(0, 76);
            this.line1.Margin = new System.Windows.Forms.Padding(0);
            this.line1.Name = "line1";
            this.line1.Size = new System.Drawing.Size(600, 1);
            this.line1.TabIndex = 13;
            this.line1.Text = "line1";
            this.line1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _btnAddGroup
            // 
            this._btnAddGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnAddGroup.Location = new System.Drawing.Point(425, 29);
            this._btnAddGroup.Name = "_btnAddGroup";
            this._btnAddGroup.Size = new System.Drawing.Size(63, 26);
            this._btnAddGroup.TabIndex = 14;
            this._btnAddGroup.Text = "新增...";
            this._btnAddGroup.UseVisualStyleBackColor = true;
            this._btnAddGroup.Click += new System.EventHandler(this._btnAddGroup_Click);
            // 
            // _btnDeleteGroup
            // 
            this._btnDeleteGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnDeleteGroup.Location = new System.Drawing.Point(496, 29);
            this._btnDeleteGroup.Name = "_btnDeleteGroup";
            this._btnDeleteGroup.Size = new System.Drawing.Size(63, 26);
            this._btnDeleteGroup.TabIndex = 15;
            this._btnDeleteGroup.Text = "删除";
            this._btnDeleteGroup.UseVisualStyleBackColor = true;
            this._btnDeleteGroup.Click += new System.EventHandler(this._btnDeleteGroup_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 17);
            this.label1.TabIndex = 16;
            this.label1.Text = "分组项";
            // 
            // ExcelExportGroupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 411);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._btnDeleteGroup);
            this.Controls.Add(this._btnAddGroup);
            this.Controls.Add(this.line1);
            this.Controls.Add(this._checkItemContainer);
            this.Controls.Add(this._cbGroup);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(600, 450);
            this.Name = "ExcelExportGroupForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "分组编辑";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox _cbGroup;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.CheckedListBox _checkItemContainer;
        private Concision.Controls.Line line1;
        private System.Windows.Forms.Button _btnAddGroup;
        private System.Windows.Forms.Button _btnDeleteGroup;
        private System.Windows.Forms.Label label1;
    }
}