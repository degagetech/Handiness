namespace Handiness.VSIX
{
    partial class MainForm
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
            this._btnCloseWindows = new Concision.Control.WindowsButton();
            this._lineSplit = new Concision.Control.Line();
            this._sylStepStatus = new Concision.Control.Symbol();
            this._lblTipInfo = new Concision.Control.Scutcheon();
            this.SuspendLayout();
            // 
            // _btnCloseWindows
            // 
            this._btnCloseWindows.DownColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this._btnCloseWindows.EnabledAdsorb = true;
            this._btnCloseWindows.EnabledMousePierce = false;
            this._btnCloseWindows.Font = new System.Drawing.Font("FontAwesome", 10F);
            this._btnCloseWindows.ForeColor = System.Drawing.Color.White;
            this._btnCloseWindows.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(200)))), ((int)(((byte)(250)))));
            this._btnCloseWindows.IconSize = 10F;
            this._btnCloseWindows.Location = new System.Drawing.Point(663, 13);
            this._btnCloseWindows.Margin = new System.Windows.Forms.Padding(0);
            this._btnCloseWindows.Name = "_btnCloseWindows";
            this._btnCloseWindows.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(166)))), ((int)(((byte)(228)))));
            this._btnCloseWindows.Size = new System.Drawing.Size(26, 25);
            this._btnCloseWindows.TabIndex = 0;
            this._btnCloseWindows.Text = "";
            this._btnCloseWindows.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._btnCloseWindows.WindowsButtonType = Concision.Control.WindowsButtonType.Close;
            // 
            // _lineSplit
            // 
            this._lineSplit.CustomBursh = null;
            this._lineSplit.EnabledMousePierce = false;
            this._lineSplit.IsVertical = false;
            this._lineSplit.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this._lineSplit.LineLength = 700;
            this._lineSplit.LineWidth = 2;
            this._lineSplit.Location = new System.Drawing.Point(0, 50);
            this._lineSplit.Margin = new System.Windows.Forms.Padding(0);
            this._lineSplit.Name = "_lineSplit";
            this._lineSplit.Size = new System.Drawing.Size(700, 2);
            this._lineSplit.TabIndex = 1;
            this._lineSplit.Text = "line1";
            this._lineSplit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _sylStepStatus
            // 
            this._sylStepStatus.EnabledMousePierce = false;
            this._sylStepStatus.Font = new System.Drawing.Font("FontAwesome", 15F);
            this._sylStepStatus.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this._sylStepStatus.Location = new System.Drawing.Point(9, 13);
            this._sylStepStatus.Margin = new System.Windows.Forms.Padding(0);
            this._sylStepStatus.Name = "_sylStepStatus";
            this._sylStepStatus.Size = new System.Drawing.Size(35, 23);
            this._sylStepStatus.SymbolColor = System.Drawing.SystemColors.ActiveCaption;
            this._sylStepStatus.SymbolPattern = "";
            this._sylStepStatus.SymbolSize = 15F;
            this._sylStepStatus.TabIndex = 2;
            this._sylStepStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _lblTipInfo
            // 
            this._lblTipInfo.EnabledMousePierce = false;
            this._lblTipInfo.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this._lblTipInfo.ForeColor = System.Drawing.Color.White;
            this._lblTipInfo.Location = new System.Drawing.Point(54, 13);
            this._lblTipInfo.Margin = new System.Windows.Forms.Padding(0);
            this._lblTipInfo.Name = "_lblTipInfo";
            this._lblTipInfo.ScutcheonColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(166)))), ((int)(((byte)(228)))));
            this._lblTipInfo.ScutcheonShape = Concision.Control.ScutcheonShapeType.Square;
            this._lblTipInfo.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this._lblTipInfo.ShadowWidth = 1;
            this._lblTipInfo.Size = new System.Drawing.Size(191, 30);
            this._lblTipInfo.TabIndex = 3;
            this._lblTipInfo.Text = "帮助您生成实体类";
            this._lblTipInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 500);
            this.Controls.Add(this._lblTipInfo);
            this.Controls.Add(this._sylStepStatus);
            this.Controls.Add(this._lineSplit);
            this.Controls.Add(this._btnCloseWindows);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);

        }

        #endregion

        private Concision.Control.WindowsButton _btnCloseWindows;
        private Concision.Control.Line _lineSplit;
        private Concision.Control.Symbol _sylStepStatus;
        private Concision.Control.Scutcheon _lblTipInfo;
    }
}