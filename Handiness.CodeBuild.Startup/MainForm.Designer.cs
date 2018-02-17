namespace Handiness.CodeBuild
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this._wbtnClose = new Concision.Controls.WindowsButton();
            this._lineTop = new Concision.Controls.Line();
            this._sylStepStatus = new Concision.Controls.Symbol();
            this._lineBottom = new Concision.Controls.Line();
            this._lblTipInfo = new Concision.Controls.Scutcheon();
            this._wbtnMax = new Concision.Controls.WindowsButton();
            this._wbtnMin = new Concision.Controls.WindowsButton();
            this._cbxMetadataProvider = new Concision.Controls.ConcisionCombobox();
            this._lineLeftRight = new Concision.Controls.Line();
            this._cbxCodeTemplate = new Concision.Controls.ConcisionCombobox();
            this._cbxMapType = new Concision.Controls.ConcisionCombobox();
            this._cbxNameFormat = new Concision.Controls.ConcisionCombobox();
            this._cbxActiveProject = new Concision.Controls.ConcisionCombobox();
            this._dgvTableSchema = new System.Windows.Forms.DataGridView();
            this._trvSchema = new System.Windows.Forms.TreeView();
            this._sylSetting = new Concision.Controls.Symbol();
            this._sylRefresh = new Concision.Controls.Symbol();
            this._btnCodeBuild = new Concision.Controls.ConcisionButton();
            this._btnCannel = new Concision.Controls.ConcisionButton();
            this._lblTip = new System.Windows.Forms.Label();
            this._tipTable = new System.Windows.Forms.ToolTip(this.components);
            this._symbolConnection = new Concision.Controls.Symbol();
            this._rbProject = new System.Windows.Forms.RadioButton();
            this._rbDirectory = new System.Windows.Forms.RadioButton();
            this._txtDirectory = new System.Windows.Forms.TextBox();
            this._symbolSelectDirectory = new Concision.Controls.Symbol();
            this._fbdDirectorySelect = new System.Windows.Forms.FolderBrowserDialog();
            this._cbSelected = new System.Windows.Forms.CheckBox();
            this._symbolEditTemplate = new Concision.Controls.Symbol();
            this._symbolEditMapper = new Concision.Controls.Symbol();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this._dgvTableSchema)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
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
            this._wbtnClose.WindowsButtonType = Concision.Controls.WindowsButtonType.Close;
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
            this._lblTipInfo.ScutcheonShape = Concision.Controls.ScutcheonShapeType.Square;
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
            this._wbtnMax.WindowsButtonType = Concision.Controls.WindowsButtonType.Maximize;
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
            this._wbtnMin.WindowsButtonType = Concision.Controls.WindowsButtonType.Minimize;
            // 
            // _cbxMetadataProvider
            // 
            this._cbxMetadataProvider.AutoDropDownHeight = true;
            this._cbxMetadataProvider.Cursor = System.Windows.Forms.Cursors.Hand;
            this._cbxMetadataProvider.DialogResult = System.Windows.Forms.DialogResult.None;
            this._cbxMetadataProvider.DownColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this._cbxMetadataProvider.DropDownHeight = 2;
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
            this._cbxMetadataProvider.SelectedValue = null;
            this._cbxMetadataProvider.Size = new System.Drawing.Size(250, 35);
            this._cbxMetadataProvider.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this._cbxMetadataProvider.SymbolSize = 10F;
            this._cbxMetadataProvider.TabIndex = 9;
            this._cbxMetadataProvider.Text = "选择元数据提供者";
            this._cbxMetadataProvider.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this._lineLeftRight.Location = new System.Drawing.Point(288, 92);
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
            this._cbxCodeTemplate.DialogResult = System.Windows.Forms.DialogResult.None;
            this._cbxCodeTemplate.DownColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this._cbxCodeTemplate.DropDownHeight = 2;
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
            this._cbxCodeTemplate.SelectedValue = null;
            this._cbxCodeTemplate.Size = new System.Drawing.Size(250, 35);
            this._cbxCodeTemplate.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this._cbxCodeTemplate.SymbolSize = 10F;
            this._cbxCodeTemplate.TabIndex = 11;
            this._cbxCodeTemplate.Text = "选择代码模板";
            this._cbxCodeTemplate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _cbxMapType
            // 
            this._cbxMapType.AutoDropDownHeight = true;
            this._cbxMapType.Cursor = System.Windows.Forms.Cursors.Hand;
            this._cbxMapType.DialogResult = System.Windows.Forms.DialogResult.None;
            this._cbxMapType.DownColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this._cbxMapType.DropDownHeight = 2;
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
            this._cbxMapType.SelectedValue = null;
            this._cbxMapType.Size = new System.Drawing.Size(250, 35);
            this._cbxMapType.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this._cbxMapType.SymbolSize = 10F;
            this._cbxMapType.TabIndex = 13;
            this._cbxMapType.Text = "选择类型映射";
            this._cbxMapType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _cbxNameFormat
            // 
            this._cbxNameFormat.AutoDropDownHeight = true;
            this._cbxNameFormat.Cursor = System.Windows.Forms.Cursors.Hand;
            this._cbxNameFormat.DialogResult = System.Windows.Forms.DialogResult.None;
            this._cbxNameFormat.DownColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this._cbxNameFormat.DropDownHeight = 2;
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
            this._cbxNameFormat.SelectedValue = null;
            this._cbxNameFormat.Size = new System.Drawing.Size(250, 35);
            this._cbxNameFormat.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this._cbxNameFormat.SymbolSize = 10F;
            this._cbxNameFormat.TabIndex = 14;
            this._cbxNameFormat.Text = "选择命名格式";
            this._cbxNameFormat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _cbxActiveProject
            // 
            this._cbxActiveProject.AutoDropDownHeight = true;
            this._cbxActiveProject.Cursor = System.Windows.Forms.Cursors.Hand;
            this._cbxActiveProject.DialogResult = System.Windows.Forms.DialogResult.None;
            this._cbxActiveProject.DownColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this._cbxActiveProject.DropDownHeight = 2;
            this._cbxActiveProject.DropDownWidth = 250;
            this._cbxActiveProject.EnabledMousePierce = false;
            this._cbxActiveProject.EnabledWaitingClick = false;
            this._cbxActiveProject.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this._cbxActiveProject.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this._cbxActiveProject.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this._cbxActiveProject.IsWaiting = false;
            this._cbxActiveProject.ItemFont = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this._cbxActiveProject.ItemHeight = 30;
            this._cbxActiveProject.Location = new System.Drawing.Point(17, 321);
            this._cbxActiveProject.Margin = new System.Windows.Forms.Padding(0);
            this._cbxActiveProject.Name = "_cbxActiveProject";
            this._cbxActiveProject.NormalColor = System.Drawing.Color.WhiteSmoke;
            this._cbxActiveProject.SelectedIndex = -1;
            this._cbxActiveProject.SelectedText = null;
            this._cbxActiveProject.SelectedValue = null;
            this._cbxActiveProject.Size = new System.Drawing.Size(250, 35);
            this._cbxActiveProject.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this._cbxActiveProject.SymbolSize = 10F;
            this._cbxActiveProject.TabIndex = 15;
            this._cbxActiveProject.Text = "选择附加的项目";
            this._cbxActiveProject.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _dgvTableSchema
            // 
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this._dgvTableSchema.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this._dgvTableSchema.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._dgvTableSchema.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this._dgvTableSchema.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this._dgvTableSchema.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this._dgvTableSchema.ColumnHeadersHeight = 30;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._dgvTableSchema.DefaultCellStyle = dataGridViewCellStyle7;
            this._dgvTableSchema.Dock = System.Windows.Forms.DockStyle.Fill;
            this._dgvTableSchema.GridColor = System.Drawing.SystemColors.ControlLight;
            this._dgvTableSchema.Location = new System.Drawing.Point(0, 0);
            this._dgvTableSchema.Name = "_dgvTableSchema";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(166)))), ((int)(((byte)(228)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this._dgvTableSchema.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this._dgvTableSchema.RowHeadersVisible = false;
            this._dgvTableSchema.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(166)))), ((int)(((byte)(228)))));
            this._dgvTableSchema.RowTemplate.Height = 30;
            this._dgvTableSchema.Size = new System.Drawing.Size(392, 468);
            this._dgvTableSchema.TabIndex = 1;
            // 
            // _trvSchema
            // 
            this._trvSchema.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this._trvSchema.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._trvSchema.CheckBoxes = true;
            this._trvSchema.Dock = System.Windows.Forms.DockStyle.Fill;
            this._trvSchema.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this._trvSchema.HotTracking = true;
            this._trvSchema.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this._trvSchema.Location = new System.Drawing.Point(0, 0);
            this._trvSchema.Name = "_trvSchema";
            this._trvSchema.ShowLines = false;
            this._trvSchema.ShowNodeToolTips = true;
            this._trvSchema.Size = new System.Drawing.Size(197, 468);
            this._trvSchema.TabIndex = 0;
            this._trvSchema.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this._trvSchema_NodeMouseClick);
            // 
            // _sylSetting
            // 
            this._sylSetting.Cursor = System.Windows.Forms.Cursors.Hand;
            this._sylSetting.EnabledMousePierce = false;
            this._sylSetting.Font = new System.Drawing.Font("FontAwesome", 15F);
            this._sylSetting.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this._sylSetting.Location = new System.Drawing.Point(166, 472);
            this._sylSetting.Margin = new System.Windows.Forms.Padding(0);
            this._sylSetting.Name = "_sylSetting";
            this._sylSetting.Size = new System.Drawing.Size(35, 34);
            this._sylSetting.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this._sylSetting.SymbolPattern = "";
            this._sylSetting.SymbolSize = 15F;
            this._sylSetting.TabIndex = 17;
            this._sylSetting.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._tipTable.SetToolTip(this._sylSetting, "设置命名空间及连接字符串");
            this._sylSetting.Click += new System.EventHandler(this._sylSetting_Click);
            // 
            // _sylRefresh
            // 
            this._sylRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this._sylRefresh.EnabledMousePierce = false;
            this._sylRefresh.Font = new System.Drawing.Font("FontAwesome", 15F);
            this._sylRefresh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this._sylRefresh.Location = new System.Drawing.Point(210, 472);
            this._sylRefresh.Margin = new System.Windows.Forms.Padding(0);
            this._sylRefresh.Name = "_sylRefresh";
            this._sylRefresh.Size = new System.Drawing.Size(32, 34);
            this._sylRefresh.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this._sylRefresh.SymbolPattern = "";
            this._sylRefresh.SymbolSize = 15F;
            this._sylRefresh.TabIndex = 18;
            this._sylRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._tipTable.SetToolTip(this._sylRefresh, "刷新所有的项目");
            this._sylRefresh.Click += new System.EventHandler(this._sylRefresh_Click);
            // 
            // _btnCodeBuild
            // 
            this._btnCodeBuild.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnCodeBuild.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnCodeBuild.DialogResult = System.Windows.Forms.DialogResult.None;
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
            this._btnCannel.DialogResult = System.Windows.Forms.DialogResult.None;
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
            // _symbolConnection
            // 
            this._symbolConnection.Cursor = System.Windows.Forms.Cursors.Hand;
            this._symbolConnection.EnabledMousePierce = false;
            this._symbolConnection.Font = new System.Drawing.Font("FontAwesome", 15F);
            this._symbolConnection.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this._symbolConnection.Location = new System.Drawing.Point(119, 473);
            this._symbolConnection.Margin = new System.Windows.Forms.Padding(0);
            this._symbolConnection.Name = "_symbolConnection";
            this._symbolConnection.Size = new System.Drawing.Size(35, 34);
            this._symbolConnection.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this._symbolConnection.SymbolPattern = "";
            this._symbolConnection.SymbolSize = 15F;
            this._symbolConnection.TabIndex = 27;
            this._symbolConnection.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._tipTable.SetToolTip(this._symbolConnection, "连接到数据库，并获取元数据信息");
            this._symbolConnection.Click += new System.EventHandler(this._symbolConnection_Click);
            // 
            // _rbProject
            // 
            this._rbProject.AutoSize = true;
            this._rbProject.Location = new System.Drawing.Point(9, 287);
            this._rbProject.Name = "_rbProject";
            this._rbProject.Size = new System.Drawing.Size(86, 21);
            this._rbProject.TabIndex = 20;
            this._rbProject.TabStop = true;
            this._rbProject.Text = "附加至项目";
            this._rbProject.UseVisualStyleBackColor = true;
            this._rbProject.CheckedChanged += new System.EventHandler(this._rbProject_CheckedChanged);
            // 
            // _rbDirectory
            // 
            this._rbDirectory.AutoSize = true;
            this._rbDirectory.Location = new System.Drawing.Point(9, 374);
            this._rbDirectory.Name = "_rbDirectory";
            this._rbDirectory.Size = new System.Drawing.Size(86, 21);
            this._rbDirectory.TabIndex = 21;
            this._rbDirectory.TabStop = true;
            this._rbDirectory.Text = "生成到目录";
            this._rbDirectory.UseVisualStyleBackColor = true;
            this._rbDirectory.CheckedChanged += new System.EventHandler(this._rbDirectory_CheckedChanged);
            // 
            // _txtDirectory
            // 
            this._txtDirectory.BackColor = System.Drawing.Color.WhiteSmoke;
            this._txtDirectory.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this._txtDirectory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this._txtDirectory.Location = new System.Drawing.Point(17, 408);
            this._txtDirectory.Name = "_txtDirectory";
            this._txtDirectory.Size = new System.Drawing.Size(225, 26);
            this._txtDirectory.TabIndex = 22;
            // 
            // _symbolSelectDirectory
            // 
            this._symbolSelectDirectory.Cursor = System.Windows.Forms.Cursors.Hand;
            this._symbolSelectDirectory.EnabledMousePierce = false;
            this._symbolSelectDirectory.Font = new System.Drawing.Font("FontAwesome", 13F);
            this._symbolSelectDirectory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this._symbolSelectDirectory.Location = new System.Drawing.Point(245, 408);
            this._symbolSelectDirectory.Margin = new System.Windows.Forms.Padding(0);
            this._symbolSelectDirectory.Name = "_symbolSelectDirectory";
            this._symbolSelectDirectory.Size = new System.Drawing.Size(35, 30);
            this._symbolSelectDirectory.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this._symbolSelectDirectory.SymbolPattern = "";
            this._symbolSelectDirectory.SymbolSize = 13F;
            this._symbolSelectDirectory.TabIndex = 23;
            this._symbolSelectDirectory.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._symbolSelectDirectory.Click += new System.EventHandler(this._symbolSelectDirectory_Click);
            // 
            // _fbdDirectorySelect
            // 
            this._fbdDirectorySelect.Description = "选择保存的文件夹";
            // 
            // _cbSelected
            // 
            this._cbSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._cbSelected.AutoSize = true;
            this._cbSelected.Location = new System.Drawing.Point(289, 535);
            this._cbSelected.Name = "_cbSelected";
            this._cbSelected.Size = new System.Drawing.Size(92, 21);
            this._cbSelected.TabIndex = 24;
            this._cbSelected.Text = "全选/全不选";
            this._cbSelected.UseVisualStyleBackColor = true;
            this._cbSelected.CheckedChanged += new System.EventHandler(this._cbSelected_CheckedChanged);
            // 
            // _symbolEditTemplate
            // 
            this._symbolEditTemplate.Cursor = System.Windows.Forms.Cursors.Hand;
            this._symbolEditTemplate.EnabledMousePierce = false;
            this._symbolEditTemplate.Font = new System.Drawing.Font("FontAwesome", 10F);
            this._symbolEditTemplate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this._symbolEditTemplate.Location = new System.Drawing.Point(271, 136);
            this._symbolEditTemplate.Margin = new System.Windows.Forms.Padding(0);
            this._symbolEditTemplate.Name = "_symbolEditTemplate";
            this._symbolEditTemplate.Size = new System.Drawing.Size(15, 15);
            this._symbolEditTemplate.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this._symbolEditTemplate.SymbolPattern = "";
            this._symbolEditTemplate.SymbolSize = 10F;
            this._symbolEditTemplate.TabIndex = 25;
            this._symbolEditTemplate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._symbolEditTemplate.Click += new System.EventHandler(this._symbolEditTemplate_Click);
            // 
            // _symbolEditMapper
            // 
            this._symbolEditMapper.Cursor = System.Windows.Forms.Cursors.Hand;
            this._symbolEditMapper.EnabledMousePierce = false;
            this._symbolEditMapper.Font = new System.Drawing.Font("FontAwesome", 10F);
            this._symbolEditMapper.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this._symbolEditMapper.Location = new System.Drawing.Point(271, 249);
            this._symbolEditMapper.Margin = new System.Windows.Forms.Padding(0);
            this._symbolEditMapper.Name = "_symbolEditMapper";
            this._symbolEditMapper.Size = new System.Drawing.Size(15, 15);
            this._symbolEditMapper.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this._symbolEditMapper.SymbolPattern = "";
            this._symbolEditMapper.SymbolSize = 10F;
            this._symbolEditMapper.TabIndex = 26;
            this._symbolEditMapper.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._symbolEditMapper.Click += new System.EventHandler(this._symbolEditMapper_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(292, 61);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this._trvSchema);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this._dgvTableSchema);
            this.splitContainer1.Size = new System.Drawing.Size(593, 468);
            this.splitContainer1.SplitterDistance = 197;
            this.splitContainer1.TabIndex = 28;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this._symbolConnection);
            this.Controls.Add(this._symbolEditMapper);
            this.Controls.Add(this._symbolEditTemplate);
            this.Controls.Add(this._cbSelected);
            this.Controls.Add(this._symbolSelectDirectory);
            this.Controls.Add(this._txtDirectory);
            this.Controls.Add(this._rbDirectory);
            this.Controls.Add(this._rbProject);
            this.Controls.Add(this._lblTip);
            this.Controls.Add(this._sylRefresh);
            this.Controls.Add(this._sylSetting);
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
            ((System.ComponentModel.ISupportInitialize)(this._dgvTableSchema)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Concision.Controls.WindowsButton _wbtnClose;
        private Concision.Controls.Line _lineTop;
        private Concision.Controls.Symbol _sylStepStatus;
        private Concision.Controls.Line _lineBottom;
        private Concision.Controls.Scutcheon _lblTipInfo;
        private Concision.Controls.WindowsButton _wbtnMax;
        private Concision.Controls.WindowsButton _wbtnMin;
        private Concision.Controls.ConcisionCombobox _cbxMetadataProvider;
        private Concision.Controls.Line _lineLeftRight;
        private Concision.Controls.ConcisionCombobox _cbxCodeTemplate;
        private Concision.Controls.ConcisionCombobox _cbxMapType;
        private Concision.Controls.ConcisionCombobox _cbxNameFormat;
        private Concision.Controls.ConcisionCombobox _cbxActiveProject;
        private Concision.Controls.Symbol _sylSetting;
        private Concision.Controls.Symbol _sylRefresh;
        private System.Windows.Forms.TreeView _trvSchema;
        private System.Windows.Forms.DataGridView _dgvTableSchema;
        private Concision.Controls.ConcisionButton _btnCodeBuild;
        private Concision.Controls.ConcisionButton _btnCannel;
        private System.Windows.Forms.Label _lblTip;
        private System.Windows.Forms.ToolTip _tipTable;
        private System.Windows.Forms.RadioButton _rbProject;
        private System.Windows.Forms.RadioButton _rbDirectory;
        private System.Windows.Forms.TextBox _txtDirectory;
        private Concision.Controls.Symbol _symbolSelectDirectory;
        private System.Windows.Forms.FolderBrowserDialog _fbdDirectorySelect;
        private System.Windows.Forms.CheckBox _cbSelected;
        private Concision.Controls.Symbol _symbolEditTemplate;
        private Concision.Controls.Symbol _symbolEditMapper;
        private Concision.Controls.Symbol _symbolConnection;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}