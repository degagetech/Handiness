namespace Handiness.CodeBuild
{
    partial class EditForm
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
            this._tbContent = new System.Windows.Forms.RichTextBox();
            this.scutcheon1 = new Concision.Controls.Scutcheon();
            this._btnCannel = new Concision.Controls.ConcisionButton();
            this._btnOk = new Concision.Controls.ConcisionButton();
            this.SuspendLayout();
            // 
            // windowsButton3
            // 
            this.windowsButton3.Location = new System.Drawing.Point(392, 9);
            // 
            // windowsButton2
            // 
            this.windowsButton2.Location = new System.Drawing.Point(441, 9);
            // 
            // windowsButton1
            // 
            this.windowsButton1.Location = new System.Drawing.Point(492, 9);
            // 
            // line1
            // 
            this.line1.LineLength = 645;
            this.line1.Size = new System.Drawing.Size(645, 2);
            // 
            // _tbContent
            // 
            this._tbContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._tbContent.BackColor = System.Drawing.Color.White;
            this._tbContent.Location = new System.Drawing.Point(15, 78);
            this._tbContent.Multiline = true;
            this._tbContent.Name = "_tbContent";
            this._tbContent.Size = new System.Drawing.Size(514, 525);
            this._tbContent.TabIndex = 10;
            // 
            // scutcheon1
            // 
            this.scutcheon1.EnabledMousePierce = false;
            this.scutcheon1.ForeColor = System.Drawing.Color.White;
            this.scutcheon1.Location = new System.Drawing.Point(18, 11);
            this.scutcheon1.Margin = new System.Windows.Forms.Padding(0);
            this.scutcheon1.Name = "scutcheon1";
            this.scutcheon1.ScutcheonColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(166)))), ((int)(((byte)(228)))));
            this.scutcheon1.ScutcheonShape = Concision.Controls.ScutcheonShapeType.Square;
            this.scutcheon1.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this.scutcheon1.ShadowWidth = 1;
            this.scutcheon1.Size = new System.Drawing.Size(107, 34);
            this.scutcheon1.TabIndex = 11;
            this.scutcheon1.Text = "配置编辑";
            this.scutcheon1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _btnCannel
            // 
            this._btnCannel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnCannel.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnCannel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._btnCannel.DownColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this._btnCannel.EnabledMousePierce = false;
            this._btnCannel.EnabledWaitingClick = false;
            this._btnCannel.ForeColor = System.Drawing.Color.White;
            this._btnCannel.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(200)))), ((int)(((byte)(250)))));
            this._btnCannel.IsWaiting = false;
            this._btnCannel.Location = new System.Drawing.Point(441, 615);
            this._btnCannel.Margin = new System.Windows.Forms.Padding(0);
            this._btnCannel.Name = "_btnCannel";
            this._btnCannel.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(166)))), ((int)(((byte)(228)))));
            this._btnCannel.Size = new System.Drawing.Size(88, 30);
            this._btnCannel.TabIndex = 13;
            this._btnCannel.Text = "取 消";
            this._btnCannel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._btnCannel.Click += new System.EventHandler(this._btnCannel_Click);
            // 
            // _btnOk
            // 
            this._btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnOk.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._btnOk.DownColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this._btnOk.EnabledMousePierce = false;
            this._btnOk.EnabledWaitingClick = false;
            this._btnOk.ForeColor = System.Drawing.Color.White;
            this._btnOk.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(200)))), ((int)(((byte)(250)))));
            this._btnOk.IsWaiting = false;
            this._btnOk.Location = new System.Drawing.Point(319, 615);
            this._btnOk.Margin = new System.Windows.Forms.Padding(0);
            this._btnOk.Name = "_btnOk";
            this._btnOk.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(166)))), ((int)(((byte)(228)))));
            this._btnOk.Size = new System.Drawing.Size(88, 30);
            this._btnOk.TabIndex = 12;
            this._btnOk.Text = "确 定";
            this._btnOk.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
            // 
            // EditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 659);
            this.Controls.Add(this._btnCannel);
            this.Controls.Add(this._btnOk);
            this.Controls.Add(this.scutcheon1);
            this.Controls.Add(this._tbContent);
            this.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.Name = "EditForm";
            this.Text = "EditForm";
            this.Controls.SetChildIndex(this.windowsButton1, 0);
            this.Controls.SetChildIndex(this.windowsButton2, 0);
            this.Controls.SetChildIndex(this.windowsButton3, 0);
            this.Controls.SetChildIndex(this.line1, 0);
            this.Controls.SetChildIndex(this._tbContent, 0);
            this.Controls.SetChildIndex(this.scutcheon1, 0);
            this.Controls.SetChildIndex(this._btnOk, 0);
            this.Controls.SetChildIndex(this._btnCannel, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox _tbContent;
        private Concision.Controls.Scutcheon scutcheon1;
        private Concision.Controls.ConcisionButton _btnCannel;
        private Concision.Controls.ConcisionButton _btnOk;
    }
}