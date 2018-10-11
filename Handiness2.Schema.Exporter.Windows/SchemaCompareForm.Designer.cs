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
            this._splitContainerSchemaInfo = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this._splitContainerSchemaInfo)).BeginInit();
            this._splitContainerSchemaInfo.Panel1.SuspendLayout();
            this._splitContainerSchemaInfo.Panel2.SuspendLayout();
            this._splitContainerSchemaInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // _splitContainerSchemaInfo
            // 
            this._splitContainerSchemaInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this._splitContainerSchemaInfo.Location = new System.Drawing.Point(0, 0);
            this._splitContainerSchemaInfo.Name = "_splitContainerSchemaInfo";
            // 
            // _splitContainerSchemaInfo.Panel1
            // 
            this._splitContainerSchemaInfo.Panel1.Controls.Add(this.label1);
            this._splitContainerSchemaInfo.Panel1.Controls.Add(this.treeView1);
            // 
            // _splitContainerSchemaInfo.Panel2
            // 
            this._splitContainerSchemaInfo.Panel2.Controls.Add(this.label2);
            this._splitContainerSchemaInfo.Size = new System.Drawing.Size(984, 661);
            this._splitContainerSchemaInfo.SplitterDistance = 494;
            this._splitContainerSchemaInfo.TabIndex = 1;
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(8, 45);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(477, 234);
            this.treeView1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(11, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "源结构信息";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.label2.Location = new System.Drawing.Point(16, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "目标结构信息";
            // 
            // SchemaCompareForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 661);
            this.Controls.Add(this._splitContainerSchemaInfo);
            this.Name = "SchemaCompareForm";
            this.Text = "结构差异比较";
            this._splitContainerSchemaInfo.Panel1.ResumeLayout(false);
            this._splitContainerSchemaInfo.Panel1.PerformLayout();
            this._splitContainerSchemaInfo.Panel2.ResumeLayout(false);
            this._splitContainerSchemaInfo.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._splitContainerSchemaInfo)).EndInit();
            this._splitContainerSchemaInfo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer _splitContainerSchemaInfo;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}