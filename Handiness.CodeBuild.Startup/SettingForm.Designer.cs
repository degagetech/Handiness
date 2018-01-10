namespace Handiness.CodeBuild
{
    partial class SettingForm
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
            this.windowsButton1 = new Concision.Controls.WindowsButton();
            this._btnCannel = new Concision.Controls.ConcisionButton();
            this._btnOk = new Concision.Controls.ConcisionButton();
            this.line1 = new Concision.Controls.Line();
            this.symbol1 = new Concision.Controls.Symbol();
            this.scutcheon1 = new Concision.Controls.Scutcheon();
            this.scutcheon2 = new Concision.Controls.Scutcheon();
            this.scutcheon3 = new Concision.Controls.Scutcheon();
            this._txtNameSpace = new System.Windows.Forms.TextBox();
            this._eprNamesapce = new System.Windows.Forms.ErrorProvider(this.components);
            this._eprConnectionString = new System.Windows.Forms.ErrorProvider(this.components);
            this._cbConnectionString = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this._eprNamesapce)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._eprConnectionString)).BeginInit();
            this.SuspendLayout();
            // 
            // windowsButton1
            // 
            this.windowsButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.windowsButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.windowsButton1.DownColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this.windowsButton1.EnabledMousePierce = false;
            this.windowsButton1.Font = new System.Drawing.Font("FontAwesome", 10F);
            this.windowsButton1.ForeColor = System.Drawing.Color.White;
            this.windowsButton1.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(200)))), ((int)(((byte)(250)))));
            this.windowsButton1.IconSize = 10F;
            this.windowsButton1.Location = new System.Drawing.Point(551, 16);
            this.windowsButton1.Margin = new System.Windows.Forms.Padding(0);
            this.windowsButton1.Name = "windowsButton1";
            this.windowsButton1.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(166)))), ((int)(((byte)(228)))));
            this.windowsButton1.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this.windowsButton1.ShadowWidth = 1F;
            this.windowsButton1.Size = new System.Drawing.Size(25, 25);
            this.windowsButton1.TabIndex = 0;
            this.windowsButton1.Text = "";
            this.windowsButton1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.windowsButton1.WindowsButtonType = Concision.Controls.WindowsButtonType.Close;
            // 
            // _btnCannel
            // 
            this._btnCannel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnCannel.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnCannel.DialogResult = System.Windows.Forms.DialogResult.None;
            this._btnCannel.DownColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this._btnCannel.EnabledMousePierce = false;
            this._btnCannel.EnabledWaitingClick = false;
            this._btnCannel.ForeColor = System.Drawing.Color.White;
            this._btnCannel.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(200)))), ((int)(((byte)(250)))));
            this._btnCannel.IsWaiting = false;
            this._btnCannel.Location = new System.Drawing.Point(488, 184);
            this._btnCannel.Margin = new System.Windows.Forms.Padding(0);
            this._btnCannel.Name = "_btnCannel";
            this._btnCannel.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(166)))), ((int)(((byte)(228)))));
            this._btnCannel.Size = new System.Drawing.Size(88, 30);
            this._btnCannel.TabIndex = 8;
            this._btnCannel.Text = "取 消";
            this._btnCannel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._btnCannel.Click += new System.EventHandler(this._btnCannel_Click);
            // 
            // _btnOk
            // 
            this._btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnOk.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnOk.DialogResult = System.Windows.Forms.DialogResult.None;
            this._btnOk.DownColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this._btnOk.EnabledMousePierce = false;
            this._btnOk.EnabledWaitingClick = false;
            this._btnOk.ForeColor = System.Drawing.Color.White;
            this._btnOk.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(200)))), ((int)(((byte)(250)))));
            this._btnOk.IsWaiting = false;
            this._btnOk.Location = new System.Drawing.Point(366, 184);
            this._btnOk.Margin = new System.Windows.Forms.Padding(0);
            this._btnOk.Name = "_btnOk";
            this._btnOk.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(166)))), ((int)(((byte)(228)))));
            this._btnOk.Size = new System.Drawing.Size(88, 30);
            this._btnOk.TabIndex = 7;
            this._btnOk.Text = "确 定";
            this._btnOk.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
            // 
            // line1
            // 
            this.line1.CustomBursh = null;
            this.line1.EnabledMousePierce = false;
            this.line1.IsVertical = false;
            this.line1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this.line1.LineLength = 600;
            this.line1.LineWidth = 2;
            this.line1.Location = new System.Drawing.Point(0, 51);
            this.line1.Margin = new System.Windows.Forms.Padding(0);
            this.line1.Name = "line1";
            this.line1.Size = new System.Drawing.Size(600, 2);
            this.line1.TabIndex = 9;
            this.line1.Text = "line1";
            this.line1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // symbol1
            // 
            this.symbol1.EnabledMousePierce = false;
            this.symbol1.Font = new System.Drawing.Font("FontAwesome", 18F);
            this.symbol1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this.symbol1.Location = new System.Drawing.Point(13, 16);
            this.symbol1.Margin = new System.Windows.Forms.Padding(0);
            this.symbol1.Name = "symbol1";
            this.symbol1.Size = new System.Drawing.Size(52, 23);
            this.symbol1.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this.symbol1.SymbolPattern = "";
            this.symbol1.SymbolSize = 18F;
            this.symbol1.TabIndex = 10;
            this.symbol1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // scutcheon1
            // 
            this.scutcheon1.EnabledMousePierce = false;
            this.scutcheon1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.scutcheon1.ForeColor = System.Drawing.Color.White;
            this.scutcheon1.Location = new System.Drawing.Point(69, 13);
            this.scutcheon1.Margin = new System.Windows.Forms.Padding(0);
            this.scutcheon1.Name = "scutcheon1";
            this.scutcheon1.ScutcheonColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.scutcheon1.ScutcheonShape = Concision.Controls.ScutcheonShapeType.Square;
            this.scutcheon1.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this.scutcheon1.ShadowWidth = 1;
            this.scutcheon1.Size = new System.Drawing.Size(80, 30);
            this.scutcheon1.TabIndex = 11;
            this.scutcheon1.Text = "设置";
            this.scutcheon1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // scutcheon2
            // 
            this.scutcheon2.EnabledMousePierce = false;
            this.scutcheon2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.scutcheon2.ForeColor = System.Drawing.Color.White;
            this.scutcheon2.Location = new System.Drawing.Point(23, 77);
            this.scutcheon2.Margin = new System.Windows.Forms.Padding(0);
            this.scutcheon2.Name = "scutcheon2";
            this.scutcheon2.ScutcheonColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this.scutcheon2.ScutcheonShape = Concision.Controls.ScutcheonShapeType.Square;
            this.scutcheon2.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this.scutcheon2.ShadowWidth = 1;
            this.scutcheon2.Size = new System.Drawing.Size(98, 30);
            this.scutcheon2.TabIndex = 12;
            this.scutcheon2.Text = "命名空间：";
            this.scutcheon2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // scutcheon3
            // 
            this.scutcheon3.EnabledMousePierce = false;
            this.scutcheon3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.scutcheon3.ForeColor = System.Drawing.Color.White;
            this.scutcheon3.Location = new System.Drawing.Point(23, 128);
            this.scutcheon3.Margin = new System.Windows.Forms.Padding(0);
            this.scutcheon3.Name = "scutcheon3";
            this.scutcheon3.ScutcheonColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this.scutcheon3.ScutcheonShape = Concision.Controls.ScutcheonShapeType.Square;
            this.scutcheon3.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this.scutcheon3.ShadowWidth = 1;
            this.scutcheon3.Size = new System.Drawing.Size(98, 30);
            this.scutcheon3.TabIndex = 13;
            this.scutcheon3.Text = "连接字符串：";
            this.scutcheon3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _txtNameSpace
            // 
            this._txtNameSpace.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this._txtNameSpace.Location = new System.Drawing.Point(140, 79);
            this._txtNameSpace.Name = "_txtNameSpace";
            this._txtNameSpace.Size = new System.Drawing.Size(436, 26);
            this._txtNameSpace.TabIndex = 14;
            this._txtNameSpace.Validating += new System.ComponentModel.CancelEventHandler(this._txtNameSpace_Validating);
            // 
            // _eprNamesapce
            // 
            this._eprNamesapce.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink;
            this._eprNamesapce.ContainerControl = this;
            // 
            // _eprConnectionString
            // 
            this._eprConnectionString.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink;
            this._eprConnectionString.ContainerControl = this;
            // 
            // _cbConnectionString
            // 
            this._cbConnectionString.FormattingEnabled = true;
            this._cbConnectionString.Items.AddRange(new object[] {
            "SQL Server：Data Source=117.48.197.78;Uid=sa;Pwd=932444208wlj-;Initial Catalog=bio" +
                "bank;",
            "Oracle：Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=192.16" +
                "8.182.104)(PORT=1521)))(CONNECT_DATA=(SERVICE_NAME=test)));User Id=wlj;Password=" +
                "932444208",
            "MySQL：server=117.47.197.48;Port=3306;Uid=root;Pwd=123456;DataBase=handinessorm;Po" +
                "oling=true;charset=utf8;]",
            "SQLite：Data Source=.\\test.db;UTF8Encoding=True;"});
            this._cbConnectionString.Location = new System.Drawing.Point(140, 130);
            this._cbConnectionString.Name = "_cbConnectionString";
            this._cbConnectionString.Size = new System.Drawing.Size(436, 25);
            this._cbConnectionString.TabIndex = 15;
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 235);
            this.Controls.Add(this._cbConnectionString);
            this.Controls.Add(this._txtNameSpace);
            this.Controls.Add(this.scutcheon3);
            this.Controls.Add(this.scutcheon2);
            this.Controls.Add(this.scutcheon1);
            this.Controls.Add(this.symbol1);
            this.Controls.Add(this.line1);
            this.Controls.Add(this._btnCannel);
            this.Controls.Add(this._btnOk);
            this.Controls.Add(this.windowsButton1);
            this.Name = "SettingForm";
            this.Text = "SettingForm";
            ((System.ComponentModel.ISupportInitialize)(this._eprNamesapce)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._eprConnectionString)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Concision.Controls.WindowsButton windowsButton1;
        private Concision.Controls.ConcisionButton _btnCannel;
        private Concision.Controls.ConcisionButton _btnOk;
        private Concision.Controls.Line line1;
        private Concision.Controls.Symbol symbol1;
        private Concision.Controls.Scutcheon scutcheon1;
        private Concision.Controls.Scutcheon scutcheon2;
        private Concision.Controls.Scutcheon scutcheon3;
        private System.Windows.Forms.TextBox _txtNameSpace;
        private System.Windows.Forms.ErrorProvider _eprNamesapce;
        private System.Windows.Forms.ErrorProvider _eprConnectionString;
        private System.Windows.Forms.ComboBox _cbConnectionString;
    }
}