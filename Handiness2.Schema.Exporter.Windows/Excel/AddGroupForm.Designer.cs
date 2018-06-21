namespace Handiness2.Schema.Exporter.Windows
{
    partial class AddGroupForm
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
            this._btnConfirm = new System.Windows.Forms.Button();
            this._btnCancel = new System.Windows.Forms.Button();
            this._tbGroupName = new System.Windows.Forms.TextBox();
            this._labelGroupName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _btnConfirm
            // 
            this._btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnConfirm.Location = new System.Drawing.Point(228, 99);
            this._btnConfirm.Name = "_btnConfirm";
            this._btnConfirm.Size = new System.Drawing.Size(63, 26);
            this._btnConfirm.TabIndex = 10;
            this._btnConfirm.Text = "确定";
            this._btnConfirm.UseVisualStyleBackColor = true;
            this._btnConfirm.Click += new System.EventHandler(this._btnConfirm_Click);
            // 
            // _btnCancel
            // 
            this._btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._btnCancel.Location = new System.Drawing.Point(312, 99);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(63, 26);
            this._btnCancel.TabIndex = 11;
            this._btnCancel.Text = "取消";
            this._btnCancel.UseVisualStyleBackColor = true;
            this._btnCancel.Click += new System.EventHandler(this._btnCancel_Click);
            // 
            // _tbGroupName
            // 
            this._tbGroupName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._tbGroupName.BackColor = System.Drawing.Color.White;
            this._tbGroupName.Location = new System.Drawing.Point(70, 49);
            this._tbGroupName.Name = "_tbGroupName";
            this._tbGroupName.Size = new System.Drawing.Size(305, 23);
            this._tbGroupName.TabIndex = 13;
            // 
            // _labelGroupName
            // 
            this._labelGroupName.AutoSize = true;
            this._labelGroupName.Location = new System.Drawing.Point(26, 52);
            this._labelGroupName.Name = "_labelGroupName";
            this._labelGroupName.Size = new System.Drawing.Size(32, 17);
            this._labelGroupName.TabIndex = 12;
            this._labelGroupName.Text = "组名";
            // 
            // AddGroupForm
            // 
            this.AcceptButton = this._btnConfirm;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._btnCancel;
            this.ClientSize = new System.Drawing.Size(401, 150);
            this.Controls.Add(this._tbGroupName);
            this.Controls.Add(this._labelGroupName);
            this.Controls.Add(this._btnCancel);
            this.Controls.Add(this._btnConfirm);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "AddGroupForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "添加分组";
            this.Activated += new System.EventHandler(this.AddGroupForm_Activated);
            this.Load += new System.EventHandler(this.AddGroupForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _btnConfirm;
        private System.Windows.Forms.Button _btnCancel;
        private System.Windows.Forms.TextBox _tbGroupName;
        private System.Windows.Forms.Label _labelGroupName;
    }
}