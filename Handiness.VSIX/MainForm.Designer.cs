﻿namespace Handiness.VSIX
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
            this._lineTop = new Concision.Control.Line();
            this._sylStepStatus = new Concision.Control.Symbol();
            this._lineBottom = new Concision.Control.Line();
            this._btnCannel = new Concision.Control.Button();
            this._btnBuild = new Concision.Control.Button();
            this._lblTipInfo = new Concision.Control.Scutcheon();
            this.windowsButton1 = new Concision.Control.WindowsButton();
            this.windowsButton2 = new Concision.Control.WindowsButton();
            this._cbxMetadataProvider = new Concision.Control.Combobox();
            this.line1 = new Concision.Control.Line();
            this._cbxCodeTemplate = new Concision.Control.Combobox();
            this._cbxMapType = new Concision.Control.Combobox();
            this._cbxNameFormat = new Concision.Control.Combobox();
            this._cbxActiveProject = new Concision.Control.Combobox();
            this._pnlMetadataContainer = new Concision.Control.Panel();
            this._dgvTableSchema = new System.Windows.Forms.DataGridView();
            this._trvTable = new System.Windows.Forms.TreeView();
            this._sylSetting = new Concision.Control.Symbol();
            this._sylRefresh = new Concision.Control.Symbol();
            this.button1 = new Concision.Control.Button();
            this.button2 = new Concision.Control.Button();
            this._pnlMetadataContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvTableSchema)).BeginInit();
            this.SuspendLayout();
            // 
            // _btnCloseWindows
            // 
            this._btnCloseWindows.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnCloseWindows.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnCloseWindows.DownColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this._btnCloseWindows.EnabledAdsorb = true;
            this._btnCloseWindows.EnabledMousePierce = false;
            this._btnCloseWindows.Font = new System.Drawing.Font("FontAwesome", 12F);
            this._btnCloseWindows.ForeColor = System.Drawing.Color.White;
            this._btnCloseWindows.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(200)))), ((int)(((byte)(250)))));
            this._btnCloseWindows.IconSize = 12F;
            this._btnCloseWindows.Location = new System.Drawing.Point(859, 13);
            this._btnCloseWindows.Margin = new System.Windows.Forms.Padding(0);
            this._btnCloseWindows.Name = "_btnCloseWindows";
            this._btnCloseWindows.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(166)))), ((int)(((byte)(228)))));
            this._btnCloseWindows.Size = new System.Drawing.Size(30, 30);
            this._btnCloseWindows.TabIndex = 0;
            this._btnCloseWindows.Text = "";
            this._btnCloseWindows.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._btnCloseWindows.WindowsButtonType = Concision.Control.WindowsButtonType.Close;
            // 
            // _lineTop
            // 
            this._lineTop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._lineTop.CustomBursh = null;
            this._lineTop.EnabledMousePierce = false;
            this._lineTop.IsVertical = false;
            this._lineTop.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this._lineTop.LineLength = 900;
            this._lineTop.LineWidth = 2;
            this._lineTop.Location = new System.Drawing.Point(0, 56);
            this._lineTop.Margin = new System.Windows.Forms.Padding(0);
            this._lineTop.Name = "_lineTop";
            this._lineTop.Size = new System.Drawing.Size(900, 2);
            this._lineTop.TabIndex = 1;
            this._lineTop.Text = "line1";
            this._lineTop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _sylStepStatus
            // 
            this._sylStepStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this._sylStepStatus.EnabledMousePierce = true;
            this._sylStepStatus.Font = new System.Drawing.Font("FontAwesome", 15F);
            this._sylStepStatus.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this._sylStepStatus.Location = new System.Drawing.Point(9, 17);
            this._sylStepStatus.Margin = new System.Windows.Forms.Padding(0);
            this._sylStepStatus.Name = "_sylStepStatus";
            this._sylStepStatus.Size = new System.Drawing.Size(35, 23);
            this._sylStepStatus.SymbolColor = System.Drawing.SystemColors.ActiveCaption;
            this._sylStepStatus.SymbolPattern = "";
            this._sylStepStatus.SymbolSize = 15F;
            this._sylStepStatus.TabIndex = 2;
            this._sylStepStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _lineBottom
            // 
            this._lineBottom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._lineBottom.CustomBursh = null;
            this._lineBottom.EnabledMousePierce = false;
            this._lineBottom.IsVertical = false;
            this._lineBottom.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this._lineBottom.LineLength = 900;
            this._lineBottom.LineWidth = 2;
            this._lineBottom.Location = new System.Drawing.Point(9, 529);
            this._lineBottom.Margin = new System.Windows.Forms.Padding(0);
            this._lineBottom.Name = "_lineBottom";
            this._lineBottom.Size = new System.Drawing.Size(900, 2);
            this._lineBottom.TabIndex = 4;
            this._lineBottom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _btnCannel
            // 
            this._btnCannel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnCannel.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnCannel.DownColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this._btnCannel.EnabledMousePierce = false;
            this._btnCannel.EnabledWaitingClick = false;
            this._btnCannel.ForeColor = System.Drawing.Color.White;
            this._btnCannel.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(200)))), ((int)(((byte)(250)))));
            this._btnCannel.IsWaiting = false;
            this._btnCannel.Location = new System.Drawing.Point(788, 552);
            this._btnCannel.Margin = new System.Windows.Forms.Padding(0);
            this._btnCannel.Name = "_btnCannel";
            this._btnCannel.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(166)))), ((int)(((byte)(228)))));
            this._btnCannel.Size = new System.Drawing.Size(101, 30);
            this._btnCannel.TabIndex = 6;
            this._btnCannel.Text = "取消";
            this._btnCannel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._btnCannel.Click += new System.EventHandler(this._btnCannel_Click);
            // 
            // _btnBuild
            // 
            this._btnBuild.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnBuild.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnBuild.DownColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this._btnBuild.EnabledMousePierce = false;
            this._btnBuild.EnabledWaitingClick = false;
            this._btnBuild.ForeColor = System.Drawing.Color.White;
            this._btnBuild.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(200)))), ((int)(((byte)(250)))));
            this._btnBuild.IsWaiting = false;
            this._btnBuild.Location = new System.Drawing.Point(658, 552);
            this._btnBuild.Margin = new System.Windows.Forms.Padding(0);
            this._btnBuild.Name = "_btnBuild";
            this._btnBuild.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(166)))), ((int)(((byte)(228)))));
            this._btnBuild.Size = new System.Drawing.Size(101, 30);
            this._btnBuild.TabIndex = 5;
            this._btnBuild.Text = "组建";
            this._btnBuild.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._btnBuild.Click += new System.EventHandler(this._btnBuildControl_Click);
            // 
            // _lblTipInfo
            // 
            this._lblTipInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this._lblTipInfo.EnabledMousePierce = true;
            this._lblTipInfo.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this._lblTipInfo.ForeColor = System.Drawing.Color.White;
            this._lblTipInfo.Location = new System.Drawing.Point(54, 13);
            this._lblTipInfo.Margin = new System.Windows.Forms.Padding(0);
            this._lblTipInfo.Name = "_lblTipInfo";
            this._lblTipInfo.ScutcheonColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(166)))), ((int)(((byte)(228)))));
            this._lblTipInfo.ScutcheonShape = Concision.Control.ScutcheonShapeType.Square;
            this._lblTipInfo.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this._lblTipInfo.ShadowWidth = 1;
            this._lblTipInfo.Size = new System.Drawing.Size(235, 30);
            this._lblTipInfo.TabIndex = 3;
            this._lblTipInfo.Text = "帮助您构建实体类代码";
            this._lblTipInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // windowsButton1
            // 
            this.windowsButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.windowsButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.windowsButton1.DownColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this.windowsButton1.EnabledAdsorb = true;
            this.windowsButton1.EnabledMousePierce = false;
            this.windowsButton1.Font = new System.Drawing.Font("FontAwesome", 10F);
            this.windowsButton1.ForeColor = System.Drawing.Color.White;
            this.windowsButton1.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(200)))), ((int)(((byte)(250)))));
            this.windowsButton1.IconSize = 10F;
            this.windowsButton1.Location = new System.Drawing.Point(820, 13);
            this.windowsButton1.Margin = new System.Windows.Forms.Padding(0);
            this.windowsButton1.Name = "windowsButton1";
            this.windowsButton1.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(166)))), ((int)(((byte)(228)))));
            this.windowsButton1.Size = new System.Drawing.Size(30, 30);
            this.windowsButton1.TabIndex = 7;
            this.windowsButton1.Text = "";
            this.windowsButton1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.windowsButton1.WindowsButtonType = Concision.Control.WindowsButtonType.Maximize;
            // 
            // windowsButton2
            // 
            this.windowsButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.windowsButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.windowsButton2.DownColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this.windowsButton2.EnabledAdsorb = true;
            this.windowsButton2.EnabledMousePierce = false;
            this.windowsButton2.Font = new System.Drawing.Font("FontAwesome", 8F);
            this.windowsButton2.ForeColor = System.Drawing.Color.White;
            this.windowsButton2.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(200)))), ((int)(((byte)(250)))));
            this.windowsButton2.IconSize = 8F;
            this.windowsButton2.Location = new System.Drawing.Point(780, 13);
            this.windowsButton2.Margin = new System.Windows.Forms.Padding(0);
            this.windowsButton2.Name = "windowsButton2";
            this.windowsButton2.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(166)))), ((int)(((byte)(228)))));
            this.windowsButton2.Size = new System.Drawing.Size(30, 30);
            this.windowsButton2.TabIndex = 8;
            this.windowsButton2.Text = "";
            this.windowsButton2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.windowsButton2.WindowsButtonType = Concision.Control.WindowsButtonType.Minimize;
            // 
            // _cbxMetadataProvider
            // 
            this._cbxMetadataProvider.AutoDropDownHeight = true;
            this._cbxMetadataProvider.Cursor = System.Windows.Forms.Cursors.Hand;
            this._cbxMetadataProvider.DownColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this._cbxMetadataProvider.DropDownHeight = 0;
            this._cbxMetadataProvider.DropDownWidth = 250;
            this._cbxMetadataProvider.EnabledMousePierce = false;
            this._cbxMetadataProvider.EnabledWaitingClick = false;
            this._cbxMetadataProvider.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this._cbxMetadataProvider.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this._cbxMetadataProvider.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this._cbxMetadataProvider.IsWaiting = false;
            this._cbxMetadataProvider.ItemFont = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this._cbxMetadataProvider.ItemHeight = 20;
            this._cbxMetadataProvider.Location = new System.Drawing.Point(17, 72);
            this._cbxMetadataProvider.Margin = new System.Windows.Forms.Padding(0);
            this._cbxMetadataProvider.Name = "_cbxMetadataProvider";
            this._cbxMetadataProvider.NormalColor = System.Drawing.Color.WhiteSmoke;
            this._cbxMetadataProvider.SelectedIndex = -1;
            this._cbxMetadataProvider.SelectedText = null;
            this._cbxMetadataProvider.Size = new System.Drawing.Size(250, 35);
            this._cbxMetadataProvider.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this._cbxMetadataProvider.SymbolSize = 10F;
            this._cbxMetadataProvider.TabIndex = 9;
            this._cbxMetadataProvider.Text = "选择元数据提供者";
            this._cbxMetadataProvider.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // line1
            // 
            this.line1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.line1.CustomBursh = null;
            this.line1.EnabledMousePierce = false;
            this.line1.IsVertical = true;
            this.line1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this.line1.LineLength = 400;
            this.line1.LineWidth = 1;
            this.line1.Location = new System.Drawing.Point(285, 92);
            this.line1.Margin = new System.Windows.Forms.Padding(0);
            this.line1.Name = "line1";
            this.line1.Size = new System.Drawing.Size(1, 400);
            this.line1.TabIndex = 10;
            this.line1.Text = "line1";
            this.line1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _cbxCodeTemplate
            // 
            this._cbxCodeTemplate.AutoDropDownHeight = true;
            this._cbxCodeTemplate.Cursor = System.Windows.Forms.Cursors.Hand;
            this._cbxCodeTemplate.DownColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this._cbxCodeTemplate.DropDownHeight = 0;
            this._cbxCodeTemplate.DropDownWidth = 250;
            this._cbxCodeTemplate.EnabledMousePierce = false;
            this._cbxCodeTemplate.EnabledWaitingClick = false;
            this._cbxCodeTemplate.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this._cbxCodeTemplate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this._cbxCodeTemplate.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this._cbxCodeTemplate.IsWaiting = false;
            this._cbxCodeTemplate.ItemFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this._cbxCodeTemplate.ItemHeight = 20;
            this._cbxCodeTemplate.Location = new System.Drawing.Point(17, 124);
            this._cbxCodeTemplate.Margin = new System.Windows.Forms.Padding(0);
            this._cbxCodeTemplate.Name = "_cbxCodeTemplate";
            this._cbxCodeTemplate.NormalColor = System.Drawing.Color.WhiteSmoke;
            this._cbxCodeTemplate.SelectedIndex = -1;
            this._cbxCodeTemplate.SelectedText = null;
            this._cbxCodeTemplate.Size = new System.Drawing.Size(250, 35);
            this._cbxCodeTemplate.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this._cbxCodeTemplate.SymbolSize = 10F;
            this._cbxCodeTemplate.TabIndex = 11;
            this._cbxCodeTemplate.Text = "选择代码模板";
            this._cbxCodeTemplate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _cbxMapType
            // 
            this._cbxMapType.AutoDropDownHeight = true;
            this._cbxMapType.Cursor = System.Windows.Forms.Cursors.Hand;
            this._cbxMapType.DownColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this._cbxMapType.DropDownHeight = 0;
            this._cbxMapType.DropDownWidth = 250;
            this._cbxMapType.EnabledMousePierce = false;
            this._cbxMapType.EnabledWaitingClick = false;
            this._cbxMapType.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this._cbxMapType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this._cbxMapType.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this._cbxMapType.IsWaiting = false;
            this._cbxMapType.ItemFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this._cbxMapType.ItemHeight = 20;
            this._cbxMapType.Location = new System.Drawing.Point(17, 233);
            this._cbxMapType.Margin = new System.Windows.Forms.Padding(0);
            this._cbxMapType.Name = "_cbxMapType";
            this._cbxMapType.NormalColor = System.Drawing.Color.WhiteSmoke;
            this._cbxMapType.SelectedIndex = -1;
            this._cbxMapType.SelectedText = null;
            this._cbxMapType.Size = new System.Drawing.Size(250, 35);
            this._cbxMapType.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this._cbxMapType.SymbolSize = 10F;
            this._cbxMapType.TabIndex = 13;
            this._cbxMapType.Text = "选择类型映射";
            this._cbxMapType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _cbxNameFormat
            // 
            this._cbxNameFormat.AutoDropDownHeight = true;
            this._cbxNameFormat.Cursor = System.Windows.Forms.Cursors.Hand;
            this._cbxNameFormat.DownColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this._cbxNameFormat.DropDownHeight = 0;
            this._cbxNameFormat.DropDownWidth = 250;
            this._cbxNameFormat.EnabledMousePierce = false;
            this._cbxNameFormat.EnabledWaitingClick = false;
            this._cbxNameFormat.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this._cbxNameFormat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this._cbxNameFormat.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this._cbxNameFormat.IsWaiting = false;
            this._cbxNameFormat.ItemFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this._cbxNameFormat.ItemHeight = 20;
            this._cbxNameFormat.Location = new System.Drawing.Point(14, 178);
            this._cbxNameFormat.Margin = new System.Windows.Forms.Padding(0);
            this._cbxNameFormat.Name = "_cbxNameFormat";
            this._cbxNameFormat.NormalColor = System.Drawing.Color.WhiteSmoke;
            this._cbxNameFormat.SelectedIndex = -1;
            this._cbxNameFormat.SelectedText = null;
            this._cbxNameFormat.Size = new System.Drawing.Size(250, 35);
            this._cbxNameFormat.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this._cbxNameFormat.SymbolSize = 10F;
            this._cbxNameFormat.TabIndex = 14;
            this._cbxNameFormat.Text = "选择命名格式";
            this._cbxNameFormat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _cbxActiveProject
            // 
            this._cbxActiveProject.AutoDropDownHeight = true;
            this._cbxActiveProject.Cursor = System.Windows.Forms.Cursors.Hand;
            this._cbxActiveProject.DownColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this._cbxActiveProject.DropDownHeight = 0;
            this._cbxActiveProject.DropDownWidth = 250;
            this._cbxActiveProject.EnabledMousePierce = false;
            this._cbxActiveProject.EnabledWaitingClick = false;
            this._cbxActiveProject.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this._cbxActiveProject.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this._cbxActiveProject.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this._cbxActiveProject.IsWaiting = false;
            this._cbxActiveProject.ItemFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this._cbxActiveProject.ItemHeight = 20;
            this._cbxActiveProject.Location = new System.Drawing.Point(17, 286);
            this._cbxActiveProject.Margin = new System.Windows.Forms.Padding(0);
            this._cbxActiveProject.Name = "_cbxActiveProject";
            this._cbxActiveProject.NormalColor = System.Drawing.Color.WhiteSmoke;
            this._cbxActiveProject.SelectedIndex = -1;
            this._cbxActiveProject.SelectedText = null;
            this._cbxActiveProject.Size = new System.Drawing.Size(250, 35);
            this._cbxActiveProject.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this._cbxActiveProject.SymbolSize = 10F;
            this._cbxActiveProject.TabIndex = 15;
            this._cbxActiveProject.Text = "选择附加的项目";
            this._cbxActiveProject.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _pnlMetadataContainer
            // 
            this._pnlMetadataContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._pnlMetadataContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this._pnlMetadataContainer.BorderColor = System.Drawing.Color.Gray;
            this._pnlMetadataContainer.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this._pnlMetadataContainer.BorderWith = 1;
            this._pnlMetadataContainer.Controls.Add(this._dgvTableSchema);
            this._pnlMetadataContainer.Controls.Add(this._trvTable);
            this._pnlMetadataContainer.EnabledMousePierce = false;
            this._pnlMetadataContainer.IsDrawBorder = false;
            this._pnlMetadataContainer.Location = new System.Drawing.Point(306, 61);
            this._pnlMetadataContainer.Name = "_pnlMetadataContainer";
            this._pnlMetadataContainer.Size = new System.Drawing.Size(594, 465);
            this._pnlMetadataContainer.TabIndex = 16;
            // 
            // _dgvTableSchema
            // 
            this._dgvTableSchema.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dgvTableSchema.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this._dgvTableSchema.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._dgvTableSchema.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dgvTableSchema.Location = new System.Drawing.Point(180, 3);
            this._dgvTableSchema.Name = "_dgvTableSchema";
            this._dgvTableSchema.RowTemplate.Height = 23;
            this._dgvTableSchema.Size = new System.Drawing.Size(403, 459);
            this._dgvTableSchema.TabIndex = 1;
            // 
            // _trvTable
            // 
            this._trvTable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this._trvTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._trvTable.Dock = System.Windows.Forms.DockStyle.Left;
            this._trvTable.Location = new System.Drawing.Point(0, 0);
            this._trvTable.Name = "_trvTable";
            this._trvTable.Size = new System.Drawing.Size(174, 465);
            this._trvTable.TabIndex = 0;
            // 
            // _sylSetting
            // 
            this._sylSetting.Cursor = System.Windows.Forms.Cursors.Hand;
            this._sylSetting.EnabledMousePierce = false;
            this._sylSetting.Font = new System.Drawing.Font("FontAwesome", 15F);
            this._sylSetting.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this._sylSetting.Location = new System.Drawing.Point(213, 346);
            this._sylSetting.Margin = new System.Windows.Forms.Padding(0);
            this._sylSetting.Name = "_sylSetting";
            this._sylSetting.Size = new System.Drawing.Size(54, 34);
            this._sylSetting.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this._sylSetting.SymbolPattern = "";
            this._sylSetting.SymbolSize = 15F;
            this._sylSetting.TabIndex = 17;
            this._sylSetting.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._sylSetting.Click += new System.EventHandler(this._sylSetting_Click);
            // 
            // _sylRefresh
            // 
            this._sylRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this._sylRefresh.EnabledMousePierce = false;
            this._sylRefresh.Font = new System.Drawing.Font("FontAwesome", 15F);
            this._sylRefresh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this._sylRefresh.Location = new System.Drawing.Point(17, 346);
            this._sylRefresh.Margin = new System.Windows.Forms.Padding(0);
            this._sylRefresh.Name = "_sylRefresh";
            this._sylRefresh.Size = new System.Drawing.Size(54, 34);
            this._sylRefresh.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this._sylRefresh.SymbolPattern = "";
            this._sylRefresh.SymbolSize = 15F;
            this._sylRefresh.TabIndex = 18;
            this._sylRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._sylRefresh.Click += new System.EventHandler(this._sylRefresh_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.DownColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this.button1.EnabledMousePierce = false;
            this.button1.EnabledWaitingClick = false;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(200)))), ((int)(((byte)(250)))));
            this.button1.IsWaiting = false;
            this.button1.Location = new System.Drawing.Point(658, 552);
            this.button1.Margin = new System.Windows.Forms.Padding(0);
            this.button1.Name = "button1";
            this.button1.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(166)))), ((int)(((byte)(228)))));
            this.button1.Size = new System.Drawing.Size(101, 30);
            this.button1.TabIndex = 5;
            this.button1.Text = "组建";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.button1.Click += new System.EventHandler(this._btnBuildControl_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.DownColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this.button2.EnabledMousePierce = false;
            this.button2.EnabledWaitingClick = false;
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(200)))), ((int)(((byte)(250)))));
            this.button2.IsWaiting = false;
            this.button2.Location = new System.Drawing.Point(788, 552);
            this.button2.Margin = new System.Windows.Forms.Padding(0);
            this.button2.Name = "button2";
            this.button2.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(166)))), ((int)(((byte)(228)))));
            this.button2.Size = new System.Drawing.Size(101, 30);
            this.button2.TabIndex = 6;
            this.button2.Text = "取消";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.button2.Click += new System.EventHandler(this._btnCannel_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this._sylRefresh);
            this.Controls.Add(this._sylSetting);
            this.Controls.Add(this._pnlMetadataContainer);
            this.Controls.Add(this._cbxActiveProject);
            this.Controls.Add(this._cbxNameFormat);
            this.Controls.Add(this._cbxMapType);
            this.Controls.Add(this._cbxCodeTemplate);
            this.Controls.Add(this.line1);
            this.Controls.Add(this._cbxMetadataProvider);
            this.Controls.Add(this.windowsButton2);
            this.Controls.Add(this.windowsButton1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this._btnCannel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this._btnBuild);
            this.Controls.Add(this._lineBottom);
            this.Controls.Add(this._lblTipInfo);
            this.Controls.Add(this._sylStepStatus);
            this.Controls.Add(this._lineTop);
            this.Controls.Add(this._btnCloseWindows);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this._pnlMetadataContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dgvTableSchema)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Concision.Control.WindowsButton _btnCloseWindows;
        private Concision.Control.Line _lineTop;
        private Concision.Control.Symbol _sylStepStatus;
        private Concision.Control.Line _lineBottom;
        private Concision.Control.Button _btnCannel;
        private Concision.Control.Button _btnBuild;
        private Concision.Control.Scutcheon _lblTipInfo;
        private Concision.Control.WindowsButton windowsButton1;
        private Concision.Control.WindowsButton windowsButton2;
        private Concision.Control.Combobox _cbxMetadataProvider;
        private Concision.Control.Line line1;
        private Concision.Control.Combobox _cbxCodeTemplate;
        private Concision.Control.Combobox _cbxMapType;
        private Concision.Control.Combobox _cbxNameFormat;
        private Concision.Control.Combobox _cbxActiveProject;
        private Concision.Control.Panel _pnlMetadataContainer;
        private Concision.Control.Symbol _sylSetting;
        private Concision.Control.Symbol _sylRefresh;
        private System.Windows.Forms.TreeView _trvTable;
        private System.Windows.Forms.DataGridView _dgvTableSchema;
        private Concision.Control.Button button1;
        private Concision.Control.Button button2;
    }
}