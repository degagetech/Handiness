using Microsoft.Data.ConnectionUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Handiness2.Schema;
using System.Threading.Tasks;
using Handiness2.Schema.Exporter.Windows.Properties;
using System.IO;
using AgilityConfig;
using System.Diagnostics;

namespace Handiness2.Schema.Exporter.Windows
{
    public partial class SchemaExportForm : BaseForm
    {
        public event Action<Object, IList<TableSchemaExtend>> CheckedTableSchemaChanged;

        public ISchemaProvider CurrentSchemaProvider { get; private set; }
        public ExportConfig CurrentExportConfig { get; private set; }
        public ISchemaExporter CurrentSchemaExporter { get; private set; }
        public String CurrentExportDirectory { get; private set; }

        public TreeNode TableNodeHead { get; private set; }
        public TreeNode ViewNodeHead { get; private set; }


        public SchemaLoadType CurrentSchemaLoadType { get; set; } = SchemaLoadType.Connection;

        public GlobalConfig CurrentGlobalConfig { get; set; }
        public String CurrentGlobalPath { get; set; }
        public ExportType CurrentExportType { get; private set; }

        public Dictionary<String, SchemaInfoTuple> _schemaInfoTable = new Dictionary<String, SchemaInfoTuple>();

        public IList<TableSchemaExtend> CheckedTableSchemas { get; private set; }


        // private Boolean _isExporting = false;

        public SchemaExportForm()
        {
            InitializeComponent();
        }

        private void _btnEditorConnectionString_Click(Object sender, EventArgs e)
        {
            String connectionString = this.BuildDbConnectionString();
            if (!String.IsNullOrEmpty(connectionString))
            {
                this._tbConnectionString.Text = connectionString;
            }

        }
        private String BuildDbConnectionString()
        {
            String connectionString = null;
            using (var dialog = new DataConnectionDialog())
            {

                DataSource.AddStandardDataSources(dialog);
                dialog.DataSources.Add(DataSource.SqlDataSource);
                dialog.DataSources.Add(DataSource.SqlFileDataSource);
                dialog.DataSources.Add(DataSource.OracleDataSource);

                DialogResult userChoice = DataConnectionDialog.Show(dialog);
                if (userChoice == DialogResult.OK)
                {
                    connectionString = dialog.ConnectionString;
                }
            }
            return connectionString;
        }

        private void SchemaExportForm_HelpButtonClicked(Object sender, CancelEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/WangLangJing/Handiness");
        }

        private void SchemaExportForm_Load(Object sender, EventArgs e)
        {
            this._dgvColumnSchema.AutoGenerateColumns = false;
            this._colName.DataPropertyName = nameof(ColumnSchemaExtend.Name);
            this._colPrimary.DataPropertyName = nameof(ColumnSchemaExtend.IsPrimaryKey);
            this._colType.DataPropertyName = nameof(ColumnSchemaExtend.DbTypeString);
            this._colLength.DataPropertyName = nameof(ColumnSchemaExtend.Length);
            this._colNullable.DataPropertyName = nameof(ColumnSchemaExtend.IsNullable);
            this._colExplain.DataPropertyName = nameof(ColumnSchemaExtend.Explain);

            this._cbSchemaProvider.DisplayMember = nameof(ISchemaProvider.Name);

            //树状图的类型图像
            _iListSchemaTree.Images.Add("tree_table", Resources.table);
            _iListSchemaTree.Images.Add("tree_view", Resources.view);
            _iListSchemaTree.Images.Add("tree_procedure", Resources.procedure);
            _iListSchemaTree.Images.Add("tree_function", Resources.function);
        }

        private async void SchemaExportForm_Shown(Object sender, EventArgs e)
        {
            await this.LoadSchemaProvider();

            this._ctlExcelConfig.Initialize(this);
            this._ctlExcelConfig.SchemaExporter.ExportProgressChanged += SchemaExporter_ExportProgressChanged;
            String desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            this._tbExportDirectory.Text = desktopPath;

            this._sfdSaveSchema.InitialDirectory = desktopPath;
            this._ofdLoadSchema.InitialDirectory = desktopPath;
            this._sfdAsConfig.InitialDirectory = desktopPath;

            this.RenderSchemaLoadType(this.CurrentSchemaLoadType);

            this._pageCode.Enabled = false;


        }

        private void SchemaExporter_ExportCompleted(Object sender, SchemaExportCompletedEventArgs e)
        {
            //TODO:导出完成时
        }

        private void SchemaExporter_ExportProgressChanged(Object sender, SchemaExportEventArgs e)
        {
            //TODO:导出进度变化时
            Action action = () =>
              {
                  this._pbarExportProcess.Maximum = e.Total;
                  this._pbarExportProcess.Value = e.Current;
                  this._labelExprtProcess.Text = $"{e.Current.ToString()}/{e.Total.ToString()}";
                  if (e.SchemaInfo != null)
                  {
                      this.ShowTipInformation($"正在导出 [{e.SchemaInfo.TableSchema.Name}] 的结构信息...");
                  }
              };
            this.Invoke(action);

        }

        private async Task LoadSchemaProvider()
        {
            this._waitSchemProvider.Visible = true;


            this._waitSchemProvider.IsRolled = true;
            try
            {
                ProviderFactory factory = new ProviderFactory();
                var providers = await TaskEx.Run(() => factory.LoadSchemProviders());
                if (providers.Count > 0)
                {
                    this._cbSchemaProvider.DataSource = providers;
                }
            }
            finally
            {
                this._waitSchemProvider.IsRolled = false;
                this._waitSchemProvider.Visible = false;
            }
        }

        private void _cbSchemaProvider_SelectedValueChanged(object sender, EventArgs e)
        {
            ISchemaProvider provider = this._cbSchemaProvider.SelectedValue as ISchemaProvider;
            if (provider != null)
            {
                if (this.CurrentSchemaProvider != null && this.CurrentSchemaProvider.Opened)
                {
                    this.CurrentSchemaProvider.Close();
                    this._btnOpen.Image = Resources.connnect_closed;
                    this.ClearSchemaInfo();
                }
                this._labelProviderExplain.Text = provider.Explain;
                this.CurrentSchemaProvider = provider;
            }
        }
        private void ClearSchemaInfo()
        {
            this._tvSchema.Nodes.Clear();
            this.TableNodeHead = null;
            this.ViewNodeHead = null;
            this._dgvColumnSchema.DataSource = null;
            this._schemaInfoTable.Clear();
        }

        private Boolean GetConnectionStirng(out String connectionString)
        {
            connectionString = this._tbConnectionString.Text.Trim();
            return !String.IsNullOrEmpty(connectionString);
        }

        private Boolean _isLoadingSchemaInfo = false;
        private async Task LoadSchemaInfo(ISchemaProvider provider)
        {
            if (this._isLoadingSchemaInfo) return;

            _isLoadingSchemaInfo = true;
            try
            {
                List<SchemaInfoTuple> schemaInfos = new List<SchemaInfoTuple>();
                //加载表结构信息
                #region Load Table 
                this.ShowTipInformation("正在加载表信息...");
                var tableSchemaList = await TaskEx.Run(() => provider.LoadTableSchemaList());
                if (tableSchemaList.Count > 0)
                {
                    foreach (var tableSchema in tableSchemaList)
                    {
                        schemaInfos.Add(new SchemaInfoTuple
                        {
                            TableSchema = tableSchema,
                            SchemaType = SchemaType.Table
                        });
                    }
                }
                #endregion

                //加载视图信息
                #region Load View
                this.ShowTipInformation("正在加载视图信息...");
                var viewSchemaList = await TaskEx.Run(() => provider.LoadViewSchemaList());
                if (viewSchemaList.Count > 0)
                {
                    foreach (var viewSchema in viewSchemaList)
                    {
                        schemaInfos.Add(new SchemaInfoTuple
                        {
                            TableSchema = viewSchema,
                            SchemaType = SchemaType.View
                        });
                    }
                }
                #endregion

                //加载存储过程

                //加载函数
                this.ShowSchemaLoadType(SchemaLoadType.Connection);
                this.ShowSchemaInfoTuples(schemaInfos);
                this.ShowTipInformation("结构信息加载完毕！");
            }
            finally
            {
                _isLoadingSchemaInfo = false;
            }
        }

        public void ShowSchemaInfoTuples(List<SchemaInfoTuple> schemaInfos)
        {
            this.ClearSchemaInfo();

            var schemaGroups = schemaInfos.GroupBy(t => t.SchemaType);
            foreach (var group in schemaGroups)
            {
                var schemaInfoList = group.ToList();
                Int32 imageIndex = (Int32)group.Key;
                switch (group.Key)
                {
                    case SchemaType.Table:
                        {
                            TreeNode tableNodeHead = new TreeNode(Resources.SchemaExportForm_TableNodeHead);
                            tableNodeHead.ImageIndex = imageIndex;
                            this._tvSchema.Nodes.Add(tableNodeHead);
                            this.TableNodeHead = tableNodeHead;
                            foreach (var schemaInfo in schemaInfoList)
                            {
                                var node = this.CreateTreeNode(schemaInfo.TableSchema);
                                node.ImageIndex = imageIndex;
                                tableNodeHead.Nodes.Add(node);
                                this._schemaInfoTable.Add(schemaInfo.TableSchema.Name, schemaInfo);
                            }
                        }
                        break;
                    case SchemaType.View:
                        {
                            TreeNode viewNodeHead = new TreeNode(Resources.SchemaExportForm_ViewNodeHead);
                            viewNodeHead.ImageIndex = imageIndex;
                            this._tvSchema.Nodes.Add(viewNodeHead);
                            this.ViewNodeHead = viewNodeHead;
                            foreach (var schemaInfo in schemaInfoList)
                            {
                                var node = this.CreateTreeNode(schemaInfo.TableSchema);
                                node.ImageIndex = imageIndex;
                                viewNodeHead.Nodes.Add(node);
                                this._schemaInfoTable.Add(schemaInfo.TableSchema.Name, schemaInfo);
                            }
                        }
                        break;
                }
            }
        }

        private Boolean _isConnectOperating = false;

        private TreeNode CreateTreeNode(TableSchemaExtend tableSchema)
        {
            TreeNode node = new TreeNode(tableSchema.Name);
            node.ToolTipText = tableSchema.Explain;
            node.Tag = tableSchema;
            return node;
        }

        private async Task OpenConnection(String connectionString)
        {
            try
            {
                this._waitConnect.Visible = true;
                this._waitConnect.IsRolled = true;
                this._toolTip.SetToolTip(this._btnOpen, "关闭连接");
                await TaskEx.Run(() => this.CurrentSchemaProvider.Open(connectionString));
                await this.LoadSchemaInfo(this.CurrentSchemaProvider);
                this._btnOpen.Image = Resources.connect_opened;
            }
            catch (ProviderConnectException exc)
            {
                MessageBox.Show(String.Format(Resources.SchemaExportForm_ConnectException, exc.Message), Resources.HintText, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                this._waitConnect.Visible = false;
                this._waitConnect.IsRolled = false;
            }
        }
        private void CloseConnection()
        {
            this.CurrentSchemaProvider.Close();
            this._toolTip.SetToolTip(this._btnOpen, "打开连接");
            this._btnOpen.Image = Resources.connnect_closed;

        }
        private async Task SwitchConnectState()
        {
            if (this.CurrentSchemaProvider != null)
            {
                if (_isConnectOperating) return;
                _isConnectOperating = true;
                try
                {
                    if (this.CurrentSchemaProvider.Opened)
                    {
                        this.CloseConnection();
                        this.ClearSchemaInfo();
                    }
                    else
                    {
                        if (this.GetConnectionStirng(out String connectionString))
                        {
                            await this.OpenConnection(connectionString);
                        }
                    }
                }
                finally
                {
                    _isConnectOperating = false;
                }
            }
        }
        private async void _btnOpen_Click(object sender, EventArgs e)
        {
            await this.SwitchConnectState();
        }

        private void _tvSchema_AfterCheck(object sender, TreeViewEventArgs e)
        {

            this._tvSchema.AfterCheck -= _tvSchema_AfterCheck;
            var node = e.Node;
            if (node.Parent != null)
            {
                if (node.Checked)
                {
                    node.Parent.Checked = true;
                }
            }
            else
            {
                if (node.Nodes != null)
                {
                    foreach (TreeNode cn in node.Nodes)
                    {
                        if (cn.Checked != node.Checked)
                        {
                            cn.Checked = node.Checked;
                        }

                    }
                }
            }
            this.RaiseCheckedTableSchemaChanged();
            this._tvSchema.AfterCheck += _tvSchema_AfterCheck;
        }
        public IList<TableSchemaExtend> GetCheckedNodesData()
        {
            IList<TableSchemaExtend> schemas = new List<TableSchemaExtend>();
            if (this.TableNodeHead != null)
            {
                foreach (TreeNode node in this.TableNodeHead.Nodes)
                {
                    if (node.Checked)
                    {
                        var schema = node.Tag as TableSchemaExtend;
                        schemas.Add(schema);
                    }

                }
            }
            if (this.ViewNodeHead != null)
            {
                foreach (TreeNode node in this.ViewNodeHead.Nodes)
                {
                    if (node.Checked)
                    {
                        var schema = node.Tag as TableSchemaExtend;
                        schemas.Add(schema);
                    }
                }
            }

            return schemas;
        }
        private void RaiseCheckedTableSchemaChanged()
        {
            var schemas = this.GetCheckedNodesData();
            this.CheckedTableSchemas = schemas;
            this.CheckedTableSchemaChanged?.Invoke(this, schemas);
        }
        private Boolean _isLoadingColumnSchema = false;
        private async void _tvSchema_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (_isLoadingColumnSchema) return;
            this._isLoadingColumnSchema = true;
            this._tvSchema.Enabled = false;
            try
            {
                var node = e.Node;
                if (node.Parent != null)
                {
                    var schema = e.Node.Tag as TableSchemaExtend;
                    var schemaInfo = this._schemaInfoTable[schema.Name] as SchemaInfoTuple;
                    Boolean needLoad = schemaInfo.ColumnSchemas == null;

                    //加载表结构信息
                    if (needLoad)
                    {
                        _waitColumnSchemaLoad.IsRolled = true;
                        _waitColumnSchemaLoad.Visible = true;

                        try
                        {
                            await this.CompleteSchemaDetails(schemaInfo);
                        }
                        finally
                        {
                            _waitColumnSchemaLoad.IsRolled = false;
                            _waitColumnSchemaLoad.Visible = false;
                        }
                    }

                    //显示列结构信息
                    this._dgvColumnSchema.DataSource = schemaInfo.ColumnSchemas;
                }
            }
            finally
            {
                _isLoadingColumnSchema = false;
                this._tvSchema.Enabled = true;
            }

        }
        private Task<List<ColumnSchemaExtend>> GetColumnSchemasAsync(SchemaInfoTuple schemaInfo)
        {
            return TaskEx.Run(() =>
              {
                  List<ColumnSchemaExtend> result = new List<ColumnSchemaExtend>();
                  IList<ColumnSchemaExtend> getData = null;
                  switch (schemaInfo.SchemaType)
                  {
                      case SchemaType.Table:
                          {
                              getData = this.CurrentSchemaProvider.LoadColumnSchemaList(schemaInfo.TableSchema.Name);
                          }
                          break;
                      case SchemaType.View:
                          {
                              getData = this.CurrentSchemaProvider.LoadViewColumnSchemaList(schemaInfo.TableSchema.Name);
                          }
                          break;
                      default: break;
                  }
                  if (getData != null)
                  {
                      result = new List<ColumnSchemaExtend>(getData);
                  }
                  return result;
              });
        }
        private void _tbSelectdExportDirecotry_Click(Object sender, EventArgs e)
        {
            var result = _fbdExportDirectory.ShowDialog();
            if (result == DialogResult.OK)
            {
                this._tbExportDirectory.Text = this._fbdExportDirectory.SelectedPath;
            }
        }
        private BaseExportConfigControl GetCurrentExportConfigControl()
        {
            BaseExportConfigControl control = this._tabExportConfig.SelectedTab.Controls[0] as BaseExportConfigControl;
            return control;
        }
        private Boolean CheckExportParameter()
        {
            Boolean valid = false;
            if (this.CheckedTableSchemas?.Count <= 0)
            {
                this.ShowDialogTipInformation("至少选择一个元数据信息！");
                return valid;
            }
            var control = this.GetCurrentExportConfigControl();
            if (!(valid = control.IsValidExportConfig(out String errorMessage)))
            {
                this.ShowDialogTipInformation("导出配置无效！" + errorMessage);
                return valid;
            }
            else
            {
                this.CurrentExportConfig = control.ExportConfig;
            }
            this.CurrentSchemaExporter = control.SchemaExporter;
            if (this.CurrentSchemaExporter == null)
            {
                this.ShowDialogTipInformation("尚未提供导出器！");
                return valid;
            }
            var exportPath = this._tbExportDirectory.Text.Trim();
            if (String.IsNullOrEmpty(exportPath) || !Directory.Exists(exportPath))
            {
                this.ShowDialogTipInformation("导出目录无效！");
                return valid;
            }
            else
            {
                this.CurrentExportDirectory = exportPath;
            }
            valid = true;
            return valid;
        }
        private void ShowDialogTipInformation(String text)
        {
            String caption = Resources.HintText;
            MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void ShowTipInformation(String text = null)
        {
            this._labelTipInfo.Text = text;
            this._labelTipInfo.ForeColor = Color.White;
        }
        private void ShowErrorInformation(String text)
        {
            this._labelTipInfo.Text = text;
            this._labelTipInfo.ForeColor = Color.Red;
        }
        private void FillExportConfig()
        {

        }
        private async void Export()
        {
            this.EnableContol(false);
            try
            {
                IList<SchemaInfoTuple> schemaInfos = null;
                switch (this.CurrentSchemaLoadType)
                {
                    case SchemaLoadType.Connection:
                        {
                            //补全所有尚未获取的元数据信息
                            schemaInfos = new List<SchemaInfoTuple>();
                            foreach (var tableSchema in this.CheckedTableSchemas)
                            {
                                var schemaInfo = this._schemaInfoTable[tableSchema.Name];
                                if (schemaInfo.ColumnSchemas == null)
                                {
                                    this.ShowTipInformation(String.Format("正在补全 [{0}] 的结构信息...", schemaInfo.TableSchema.Name));
                                    schemaInfo.ColumnSchemas = await this.GetColumnSchemasAsync(schemaInfo);
                                }
                                schemaInfos.Add(schemaInfo);
                            }
                        }
                        break;
                    case SchemaLoadType.SchemaFile:
                        {
                            foreach (var tableSchema in this.CheckedTableSchemas)
                            {
                                var schemaInfo = this._schemaInfoTable[tableSchema.Name];
                                schemaInfos.Add(schemaInfo);
                            }
                        }
                        break;
                }

                this.ShowTipInformation("正在写入结构信息到文件中...");
                await TaskEx.Run(() =>
                {
                    this.CurrentSchemaExporter.Export(this.CurrentExportDirectory, schemaInfos, this.CurrentExportConfig);
                });


                String exportCompleted = "导出完成！";
                this.ShowTipInformation(exportCompleted);
                this.ShowDialogTipInformation(exportCompleted);
            }
            catch (Exception exc)
            {
                this.ShowErrorInformation("导出时发生异常！" + exc.Message);
                MessageBox.Show(exc.ToString(), Resources.Exception_Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.EnableContol(true);
            }
        }
        public void ShowSchemaLoadType(SchemaLoadType loadType)
        {
            this.CurrentSchemaLoadType = loadType;
            this.RenderSchemaLoadType(loadType);
        }
        private void RenderSchemaLoadType(SchemaLoadType loadType)
        {
            switch (loadType)
            {
                case SchemaLoadType.Connection:
                    {
                        this._lblLoadTypeSymbol.Image = Resources.schema_load_database;
                        this._toolTip.SetToolTip(this._lblLoadTypeSymbol, "以数据库为结构源");
                    }
                    break;
                case SchemaLoadType.SchemaFile:
                    {
                        this._lblLoadTypeSymbol.Image = Resources.schema_load_file;
                        this._toolTip.SetToolTip(this._lblLoadTypeSymbol, "以文件为结构源");
                    }
                    break;
            }
        }
        private void EnableContol(Boolean enabled)
        {
            this._btnExport.Enabled = enabled;
            this._stripItemSaveCurrentConfig.Enabled = enabled;
            this._stripReadConfig.Enabled = enabled;
            this._stripItemAsConfig.Enabled = enabled;

            this._btnOpen.Enabled = enabled;
            this._tabExportConfig.Enabled = enabled;
            this._tvSchema.Enabled = enabled;
            this._dgvColumnSchema.Enabled = enabled;
            this._tbExportDirectory.Enabled = enabled;
            this._btnSelectdExportDirectory.Enabled = enabled;
            this._cbSchemaProvider.Enabled = enabled;
        }
        private void _btnExport_Click(Object sender, EventArgs e)
        {
            if (this.CheckExportParameter())
            {
                this.Export();
            }
        }

        private void SchemaExportForm_FormClosing(Object sender, FormClosingEventArgs e)
        {
            this.CurrentSchemaProvider.Close();
        }

        private async void _stripReadConfig_Click(Object sender, EventArgs e)
        {
            this._dialogOpenFile.Title = Resources.SchemaExportForm_ReadConfig;
            if (this._dialogOpenFile.ShowDialog() == DialogResult.OK)
            {
                String fileName = this._dialogOpenFile.FileName;
                try
                {
                    var config = AgilityConfig.AgilityConfig.LoadConfig<GlobalConfig>(fileName);

                    this._ctlExcelConfig.ImportConfigInfo(config.ExcelExportConfigString);
                    await this.RenderingGlobalConfig(config);

                    //都完成后保存存储信息
                    this.CurrentGlobalPath = fileName;
                    fileName = Path.GetFileName(this.CurrentGlobalPath);

                    this._stripItemSaveCurrentConfig.Text = $"保存配置 {fileName} (&S)";
                    this._stripItemAsConfig.Text = $"配置 {fileName} 另存为(&A)";

                    this.CurrentGlobalConfig = config;
                }
                catch (Exception exc)
                {
                    MessageBox.Show("无效的配置文件！" + exc.Message);
                }

            }
        }

        private async Task RenderingGlobalConfig(GlobalConfig config)
        {
            this._tbConnectionString.Text = config.ConnectionString;
            this._tbExportDirectory.Text = config.OutputDirecotry;
            if (!String.IsNullOrEmpty(config.ConnectionString))
            {
                if (this.CurrentSchemaProvider.Opened)
                {
                    this.CloseConnection();
                }
                await this.OpenConnection(config.ConnectionString);
                HashSet<String> nameTable = new HashSet<String>(config.SelectedSchemaInfo);
                //循环遍历并选中结构信息
                if (this.TableNodeHead != null)
                {
                    foreach (TreeNode node in this.TableNodeHead.Nodes)
                    {
                        var schema = node.Tag as TableSchemaExtend;
                        if (nameTable.Contains(schema.Name))
                        {
                            node.Checked = true;
                        }
                    }
                }
                if (this.ViewNodeHead != null)
                {
                    foreach (TreeNode node in this.ViewNodeHead.Nodes)
                    {
                        var schema = node.Tag as TableSchemaExtend;
                        if (nameTable.Contains(schema.Name))
                        {
                            node.Checked = true;
                        }
                    }
                }

                switch (config.SelectExportType)
                {
                    case ExportType.Excel:
                        {
                            this._tabExportConfig.SelectedTab = this._pageExcel;
                        }
                        break;
                }
            }
        }
        private void _stripItemSaveCurrentConfig_Click(Object sender, EventArgs e)
        {
            String filePath = null;
            if (this.CurrentGlobalPath == null)
            {
                this._sfdAsConfig.Title = Resources.SchemaExportForm_SaveCurrentConfig;
                if (this._sfdAsConfig.ShowDialog() == DialogResult.OK)
                {
                    filePath = this._sfdAsConfig.FileName;
                }
            }
            else
            {
                filePath = this.CurrentGlobalPath;
            }

            if (filePath != null)
            {
                this.SaveGlobalConfig(filePath);
            }
        }
        private void SaveGlobalConfig(String filePath)
        {
            this.Cursor = Cursors.WaitCursor;
            GlobalConfig config = new GlobalConfig();
            config.ConnectionString = this._tbConnectionString.Text;
            config.OutputDirecotry = this._tbExportDirectory.Text;
            config.ExcelExportConfigString = this._ctlExcelConfig.ExportConfigInfo();
            config.SelectExportType = this.CurrentExportType;
            config.SelectedSchemaInfo = this.CheckedTableSchemas.Select(t => t.Name).ToList();
            config.Save(filePath);
            this.Cursor = Cursors.Default;
        }
        private void _stripAsConfig_Click(Object sender, EventArgs e)
        {
            this._sfdAsConfig.Title = Resources.SchemaExportForm_AsCurrentConfig;
            if (this._sfdAsConfig.ShowDialog() == DialogResult.OK)
            {
                String filePath = this._sfdAsConfig.FileName;
                this.SaveGlobalConfig(filePath);
            }
        }

        private void _tabExportConfig_SelectedIndexChanged(Object sender, EventArgs e)
        {
            if (this._tabExportConfig.SelectedTab == this._pageExcel)
            {
                this.CurrentExportType = ExportType.Excel;
            }
            else if (this._tabExportConfig.SelectedTab == this._pageCode)
            {
                MessageBox.Show(this, "此导出类型尚未支持！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this._tabExportConfig.SelectedTab = this._pageExcel;
            }

        }

        private void _tsmiAboutTool_Click(object sender, EventArgs e)
        {
            AboutForm form = new AboutForm();
            form.ShowDialog(this);
        }

        private async void _tsmiSaveSchemaToFile_Click(object sender, EventArgs e)
        {
            var dialogResult = this._sfdSaveSchema.ShowDialog();
            if (dialogResult != DialogResult.OK)
            {
                return;
            }
            var savePath = this._sfdSaveSchema.FileName;
            //选择存储路径
            //补全结构信息
            //序列化到文件中
            this.EnableContol(false);
            try
            {
                List<SchemaInfoTuple> schemaInfos = this._schemaInfoTable.Values.ToList();
                switch (this.CurrentSchemaLoadType)
                {
                    case SchemaLoadType.Connection:
                        {
                            //补全所有尚未获取的元数据信息
                            foreach (var schemaInfo in schemaInfos)
                            {
                                if (schemaInfo.ColumnSchemas == null)
                                {
                                    await this.CompleteSchemaDetails(schemaInfo);
                                }
                            }
                        }
                        break;
                    case SchemaLoadType.SchemaFile:
                        {

                        }
                        break;
                }
                this.ShowTipInformation("正在保存结构信息到文件中...");
                try
                {
                    await TaskEx.Run(() =>
                    {
                        XmlSerializer.Serialize(schemaInfos, savePath);
                    });
                    String message = "已保存当前的所有结构信息！";
                    MessageBox.Show(this, message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.ShowTipInformation(message);
                }
                catch (Exception exc)
                {
                    this.ShowTipInformation();
                    MessageBox.Show(this, "保存失败！" + exc.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            finally
            {
                this.EnableContol(true);
            }



        }

        private async Task CompleteSchemaDetails(SchemaInfoTuple schemaInfo)
        {
            this.ShowTipInformation($"正在补全 [{schemaInfo.TableSchema.Name}] 的结构信息...");
            var detailSchemas = await this.GetColumnSchemasAsync(schemaInfo);
            schemaInfo.ColumnSchemas = detailSchemas;
            this.ShowTipInformation();
        }

        private async void _tsmiLoadSchemaFromFile_Click(Object sender, EventArgs e)
        {
            String selectFilePath = null;
            var dialogResult = this._ofdLoadSchema.ShowDialog();
            if (dialogResult != DialogResult.OK)
            {
                return;
            }

            selectFilePath = this._ofdLoadSchema.FileName;
            this.EnableContol(false);
            this.ShowTipInformation("稍后，正在从文件中加载结构信息...");
            List<SchemaInfoTuple> schemaInfos = null;
            try
            {
                if (this.CurrentSchemaProvider.Opened)
                {
                    this.CloseConnection();
                }
                try
                {
                    schemaInfos = await this.LoadSchemaFromFile(selectFilePath);
                    if (schemaInfos == null || schemaInfos.Count == 0)
                    {
                        String invalidMessage = "未能从结构文件中加载到有效信息！";
                        this.ShowTipInformation(invalidMessage);
                        MessageBox.Show(this, invalidMessage, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    this.ShowSchemaLoadType(SchemaLoadType.SchemaFile);

                    this.ShowSchemaInfoTuples(schemaInfos);

                    this.ShowTipInformation("结构信息加载完毕！");
                }
                catch (Exception exc)
                {
                    this.ShowTipInformation();
                    MessageBox.Show(this, "结构信息加载失败！" + exc.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            finally
            {
                this.EnableContol(true);
            }

        }

        private Task<List<SchemaInfoTuple>> LoadSchemaFromFile(String path)
        {
            return TaskEx.Run(() =>
            {
                return XmlSerializer.DeSerialize<List<SchemaInfoTuple>>(path);
            });
        }
        /// <summary>
        /// 判断指定的结构集合是否需要补全细节信息
        /// </summary>
        /// <param name="schemaInfos"></param>
        /// <returns>返回一个二元组，如果需要则第二组件中包含需要补全明细的结构集合</returns>
        public (Boolean requried, List<SchemaInfoTuple> requiredSchemas) RequiredCompleteSchemaDetails(List<SchemaInfoTuple> schemaInfos)
        {
            Boolean required = false;
            var requiredSchemas = schemaInfos.Where(t => (t.SchemaType == SchemaType.Table || t.SchemaType == SchemaType.View) && t.ColumnSchemas == null).ToList();
            if (requiredSchemas.Count > 0)
            {
                required = true;
            }
            return (required, requiredSchemas);
        }

        private async void _tsmiCompareFromFile_Click(object sender, EventArgs e)
        {
            if (this.IsBusyingState(true))
            {
                return;
            }
            this.EnableContol(false);
            this.EnterBusyingState();
            try
            {
                //准备源结构信息
                #region 准备源结构信息
                //如果当前结构的加载方式是连接，则需要补全结构明细信息
                List<SchemaInfoTuple> sourceSchemaInfos = this._schemaInfoTable.Values.ToList();
                switch (this.CurrentSchemaLoadType)
                {
                    case SchemaLoadType.Connection:
                        {
                            var requriedResult = this.RequiredCompleteSchemaDetails(sourceSchemaInfos);
                            if (requriedResult.requried)
                            {
                                var dialogResult = MessageBox.Show(this, "系统需要补全源结构信息以用于比较，是否继续？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (dialogResult != DialogResult.Yes)
                                {
                                    return;
                                }
                                foreach (var schema in requriedResult.requiredSchemas)
                                {
                                    await this.CompleteSchemaDetails(schema);
                                }
                            }
                        }
                        break;
                    case SchemaLoadType.SchemaFile:
                        {

                        }
                        break;
                }

                #endregion

                //准备目标结构信息
                #region 准备目标结构信息
                List<SchemaInfoTuple> targetSchemaInfos = null;
                String targetSchemaFilePath = null;
                var selectResult = this._ofdLoadSchema.ShowDialog();
                if (selectResult != DialogResult.OK)
                {
                    return;
                }
                targetSchemaFilePath = this._ofdLoadSchema.FileName;
                try
                {
                    this.ShowTipInformation("正在从文件中获取目标结构的信息...");
                    targetSchemaInfos = await this.LoadSchemaFromFile(targetSchemaFilePath);

                    if (targetSchemaInfos == null || targetSchemaInfos.Count == 0)
                    {
                        String message = "操作已停止，目标结构无有效信息！";
                        this.ShowTipInformation();
                        MessageBox.Show(this, message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                }
                catch (Exception exc)
                {
                    String message = "操作已终止，目标结构加载失败！";
                    this.ShowErrorInformation(message);
                    MessageBox.Show(this, message + exc.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                #endregion

                //开始比较
                SchemaCompareForm compareForm = new SchemaCompareForm(sourceSchemaInfos, targetSchemaInfos);
                //  String fileName = Path.GetFileName(targetSchemaFilePath);
                compareForm.Text = $"与 {targetSchemaFilePath} 中的结构信息比较";
                compareForm.Show();

                this.ShowTipInformation();
            }
            finally
            {
                this.EnableContol(false);
                this.LeaveBusyingState();
            }
        }
    }

}

