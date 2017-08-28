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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this._wbtnClose = new Concision.Control.WindowsButton();
            this._lineTop = new Concision.Control.Line();
            this._sylStepStatus = new Concision.Control.Symbol();
            this._lineBottom = new Concision.Control.Line();
            this._lblTipInfo = new Concision.Control.Scutcheon();
            this._wbtnMax = new Concision.Control.WindowsButton();
            this._wbtnMin = new Concision.Control.WindowsButton();
            this._cbxMetadataProvider = new Concision.Control.Combobox();
            this._lineLeftRight = new Concision.Control.Line();
            this._cbxCodeTemplate = new Concision.Control.Combobox();
            this._cbxMapType = new Concision.Control.Combobox();
            this._cbxNameFormat = new Concision.Control.Combobox();
            this._cbxActiveProject = new Concision.Control.Combobox();
            this._pnlMetadataContainer = new Concision.Control.Panel();
            this._dgvTableSchema = new System.Windows.Forms.DataGridView();
            this._trvSchema = new System.Windows.Forms.TreeView();
            this._sylSetting = new Concision.Control.Symbol();
            this._sylRefresh = new Concision.Control.Symbol();
            this._btnCodeBuild = new Concision.Control.Button();
            this._btnCannel = new Concision.Control.Button();
            this._lblTip = new System.Windows.Forms.Label();
            this._tipTable = new System.Windows.Forms.ToolTip(this.components);
            this._pnlMetadataContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvTableSchema)).BeginInit();
            this.SuspendLayout();
            // 
            // _wbtnClose
            // 
            this._wbtnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._wbtnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this._wbtnClose.DownColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this._wbtnClose.EnabledMousePierce = false;
            this._wbtnClose.Font = new System.Drawing.Font("FontAwesome", 14F);
            this._wbtnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this._wbtnClose.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(200)))), ((int)(((byte)(250)))));
            this._wbtnClose.IconSize = 14F;
            this._wbtnClose.Location = new System.Drawing.Point(850, 13);
            this._wbtnClose.Margin = new System.Windows.Forms.Padding(0);
            this._wbtnClose.Name = "_wbtnClose";
            this._wbtnClose.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this._wbtnClose.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this._wbtnClose.ShadowWidth = 1F;
            this._wbtnClose.Size = new System.Drawing.Size(35, 35);
            this._wbtnClose.TabIndex = 0;
            this._wbtnClose.Text = "";
            this._wbtnClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._wbtnClose.WindowsButtonType = Concision.Control.WindowsButtonType.Close;
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
            // _wbtnMax
            // 
            this._wbtnMax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._wbtnMax.Cursor = System.Windows.Forms.Cursors.Hand;
            this._wbtnMax.DownColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this._wbtnMax.EnabledMousePierce = false;
            this._wbtnMax.Font = new System.Drawing.Font("FontAwesome", 11F);
            this._wbtnMax.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this._wbtnMax.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(200)))), ((int)(((byte)(250)))));
            this._wbtnMax.IconSize = 11F;
            this._wbtnMax.Location = new System.Drawing.Point(815, 13);
            this._wbtnMax.Margin = new System.Windows.Forms.Padding(0);
            this._wbtnMax.Name = "_wbtnMax";
            this._wbtnMax.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this._wbtnMax.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this._wbtnMax.ShadowWidth = 1F;
            this._wbtnMax.Size = new System.Drawing.Size(35, 35);
            this._wbtnMax.TabIndex = 7;
            this._wbtnMax.Text = "";
            this._wbtnMax.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._wbtnMax.WindowsButtonType = Concision.Control.WindowsButtonType.Maximize;
            // 
            // _wbtnMin
            // 
            this._wbtnMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._wbtnMin.Cursor = System.Windows.Forms.Cursors.Hand;
            this._wbtnMin.DownColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this._wbtnMin.EnabledMousePierce = false;
            this._wbtnMin.Font = new System.Drawing.Font("FontAwesome", 10F);
            this._wbtnMin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this._wbtnMin.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(200)))), ((int)(((byte)(250)))));
            this._wbtnMin.IconSize = 10F;
            this._wbtnMin.Location = new System.Drawing.Point(780, 13);
            this._wbtnMin.Margin = new System.Windows.Forms.Padding(0);
            this._wbtnMin.Name = "_wbtnMin";
            this._wbtnMin.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this._wbtnMin.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this._wbtnMin.ShadowWidth = 1F;
            this._wbtnMin.Size = new System.Drawing.Size(35, 35);
            this._wbtnMin.TabIndex = 8;
            this._wbtnMin.Text = "";
            this._wbtnMin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._wbtnMin.WindowsButtonType = Concision.Control.WindowsButtonType.Minimize;
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
            this._cbxMetadataProvider.ItemHeight = 30;
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
            // _lineLeftRight
            // 
            this._lineLeftRight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this._lineLeftRight.CustomBursh = null;
            this._lineLeftRight.EnabledMousePierce = false;
            this._lineLeftRight.IsVertical = true;
            this._lineLeftRight.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this._lineLeftRight.LineLength = 400;
            this._lineLeftRight.LineWidth = 1;
            this._lineLeftRight.Location = new System.Drawing.Point(285, 92);
            this._lineLeftRight.Margin = new System.Windows.Forms.Padding(0);
            this._lineLeftRight.Name = "_lineLeftRight";
            this._lineLeftRight.Size = new System.Drawing.Size(1, 400);
            this._lineLeftRight.TabIndex = 10;
            this._lineLeftRight.Text = "line1";
            this._lineLeftRight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this._cbxCodeTemplate.ItemFont = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this._cbxCodeTemplate.ItemHeight = 30;
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
            this._cbxMapType.ItemFont = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this._cbxMapType.ItemHeight = 30;
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
            this._cbxNameFormat.ItemFont = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this._cbxNameFormat.ItemHeight = 30;
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
            this._cbxActiveProject.ItemFont = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this._cbxActiveProject.ItemHeight = 30;
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
            this._pnlMetadataContainer.Controls.Add(this._trvSchema);
            this._pnlMetadataContainer.EnabledMousePierce = false;
            this._pnlMetadataContainer.IsDrawBorder = false;
            this._pnlMetadataContainer.Location = new System.Drawing.Point(306, 61);
            this._pnlMetadataContainer.Name = "_pnlMetadataContainer";
            this._pnlMetadataContainer.Size = new System.Drawing.Size(594, 465);
            this._pnlMetadataContainer.TabIndex = 16;
            // 
            // _dgvTableSchema
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this._dgvTableSchema.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this._dgvTableSchema.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dgvTableSchema.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._dgvTableSchema.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this._dgvTableSchema.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this._dgvTableSchema.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this._dgvTableSchema.ColumnHeadersHeight = 30;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._dgvTableSchema.DefaultCellStyle = dataGridViewCellStyle3;
            this._dgvTableSchema.GridColor = System.Drawing.SystemColors.ControlLight;
            this._dgvTableSchema.Location = new System.Drawing.Point(180, 3);
            this._dgvTableSchema.Name = "_dgvTableSchema";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(166)))), ((int)(((byte)(228)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this._dgvTableSchema.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this._dgvTableSchema.RowHeadersVisible = false;
            this._dgvTableSchema.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(166)))), ((int)(((byte)(228)))));
            this._dgvTableSchema.RowTemplate.Height = 30;
            this._dgvTableSchema.Size = new System.Drawing.Size(403, 459);
            this._dgvTableSchema.TabIndex = 1;
            // 
            // _trvSchema
            // 
            this._trvSchema.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this._trvSchema.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._trvSchema.CheckBoxes = true;
            this._trvSchema.Dock = System.Windows.Forms.DockStyle.Left;
            this._trvSchema.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this._trvSchema.HotTracking = true;
            this._trvSchema.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this._trvSchema.Location = new System.Drawing.Point(0, 0);
            this._trvSchema.Name = "_trvSchema";
            this._trvSchema.ShowLines = false;
            this._trvSchema.ShowNodeToolTips = true;
            this._trvSchema.Size = new System.Drawing.Size(174, 465);
            this._trvSchema.TabIndex = 0;
            this._trvSchema.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this._trvSchema_NodeMouseClick);
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
            // _btnCodeBuild
            // 
            this._btnCodeBuild.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnCodeBuild.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnCodeBuild.DownColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this._btnCodeBuild.EnabledMousePierce = false;
            this._btnCodeBuild.EnabledWaitingClick = false;
            this._btnCodeBuild.ForeColor = System.Drawing.Color.White;
            this._btnCodeBuild.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(200)))), ((int)(((byte)(250)))));
            this._btnCodeBuild.IsWaiting = false;
            this._btnCodeBuild.Location = new System.Drawing.Point(660, 552);
            this._btnCodeBuild.Margin = new System.Windows.Forms.Padding(0);
            this._btnCodeBuild.Name = "_btnCodeBuild";
            this._btnCodeBuild.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(166)))), ((int)(((byte)(228)))));
            this._btnCodeBuild.Size = new System.Drawing.Size(101, 30);
            this._btnCodeBuild.TabIndex = 5;
            this._btnCodeBuild.Text = "组建";
            this._btnCodeBuild.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._btnCodeBuild.Click += new System.EventHandler(this._btnCodeBuildControl_Click);
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
            // _lblTip
            // 
            this._lblTip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._lblTip.AutoEllipsis = true;
            this._lblTip.Location = new System.Drawing.Point(14, 565);
            this._lblTip.Name = "_lblTip";
            this._lblTip.Size = new System.Drawing.Size(500, 17);
            this._lblTip.TabIndex = 19;
            this._lblTip.Text = "##";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this._lblTip);
            this.Controls.Add(this._sylRefresh);
            this.Controls.Add(this._sylSetting);
            this.Controls.Add(this._pnlMetadataContainer);
            this.Controls.Add(this._cbxActiveProject);
            this.Controls.Add(this._cbxNameFormat);
            this.Controls.Add(this._cbxMapType);
            this.Controls.Add(this._cbxCodeTemplate);
            this.Controls.Add(this._lineLeftRight);
            this.Controls.Add(this._cbxMetadataProvider);
            this.Controls.Add(this._wbtnMin);
            this.Controls.Add(this._wbtnMax);
            this.Controls.Add(this._btnCannel);
            this.Controls.Add(this._btnCodeBuild);
            this.Controls.Add(this._lineBottom);
            this.Controls.Add(this._lblTipInfo);
            this.Controls.Add(this._sylStepStatus);
            this.Controls.Add(this._lineTop);
            this.Controls.Add(this._wbtnClose);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this._pnlMetadataContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dgvTableSchema)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Concision.Control.WindowsButton _wbtnClose;
        private Concision.Control.Line _lineTop;
        private Concision.Control.Symbol _sylStepStatus;
        private Concision.Control.Line _lineBottom;
        private Concision.Control.Scutcheon _lblTipInfo;
        private Concision.Control.WindowsButton _wbtnMax;
        private Concision.Control.WindowsButton _wbtnMin;
        private Concision.Control.Combobox _cbxMetadataProvider;
        private Concision.Control.Line _lineLeftRight;
        private Concision.Control.Combobox _cbxCodeTemplate;
        private Concision.Control.Combobox _cbxMapType;
        private Concision.Control.Combobox _cbxNameFormat;
        private Concision.Control.Combobox _cbxActiveProject;
        private Concision.Control.Panel _pnlMetadataContainer;
        private Concision.Control.Symbol _sylSetting;
        private Concision.Control.Symbol _sylRefresh;
        private System.Windows.Forms.TreeView _trvSchema;
        private System.Windows.Forms.DataGridView _dgvTableSchema;
        private Concision.Control.Button _btnCodeBuild;
        private Concision.Control.Button _btnCannel;
        private System.Windows.Forms.Label _lblTip;
        private System.Windows.Forms.ToolTip _tipTable;
    }
}