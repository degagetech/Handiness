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
using System.Diagnostics;

namespace Handiness2.Schema.Exporter.Windows
{
    public partial class SchemaExportForm : Form
    {
        public event Action<Object, IList<TableSchemaExtend>> CheckedTableSchemaChanged;

        public ISchemaProvider CurrentSchemaProvider { get; private set; }
        public ExportConfig CurrentExportConfig { get; private set; }
        public ISchemaExporter CurrentSchemaExporter { get; private set; }
        public String CurrentExportDirectory { get; private set; }

        public TreeNode TableNodeHead { get; private set; }
        public TreeNode ViewNodeHead { get; private set; }

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
            _iListSchemaTree.Images.Add("tree_table", Resources.table);
            _iListSchemaTree.Images.Add("tree_view", Resources.view);


        }

        private async void SchemaExportForm_Shown(Object sender, EventArgs e)
        {
            await this.LoadSchemaProvider();
            this._ctlExcelConfig.Initialize(this);
            this._ctlExcelConfig.SchemaExporter.ExportProgressChanged += SchemaExporter_ExportProgressChanged;
            //this._ctlExcelConfig.SchemaExporter.ExportCompleted += SchemaExporter_ExportCompleted;
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
                  this.ShowTipInformation($"正在导出 [{e.SchemaInfo.TableSchema.Name}] 的结构信息...");
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
                this.ClearSchemaInfo();

                var tableSchemaList = await TaskEx.Run(() => provider.LoadTableSchemaList());
                if (tableSchemaList.Count > 0)
                {

                    TreeNode tableNodeHead = new TreeNode(Resources.SchemaExportForm_TableNodeHead);
                    tableNodeHead.ImageIndex = 0;
                    this._tvSchema.Nodes.Add(tableNodeHead);
                    this.TableNodeHead = tableNodeHead;
                    foreach (var tableSchema in tableSchemaList)
                    {
                        var node = this.CreateTreeNode(tableSchema);
                        node.ImageIndex = 0;
                        tableNodeHead.Nodes.Add(node);
                        this._schemaInfoTable.Add(tableSchema.Name, new SchemaInfoTupleEx
                        {
                            TableSchema = tableSchema
                        });
                    }
                }


                var viewSchemaList = await TaskEx.Run(() => provider.LoadViewSchemaList());
                if (viewSchemaList.Count > 0)
                {
                    TreeNode viewNodeHead = new TreeNode(Resources.SchemaExportForm_ViewNodeHead);
                    viewNodeHead.ImageIndex = 1;
                    this._tvSchema.Nodes.Add(viewNodeHead);
                    this.ViewNodeHead = viewNodeHead;
                    foreach (var viewSchema in viewSchemaList)
                    {
                        var node = this.CreateTreeNode(viewSchema);
                        node.ImageIndex = 1;
                        viewNodeHead.Nodes.Add(node);
                        this._schemaInfoTable.Add(viewSchema.Name, new SchemaInfoTupleEx
                        {
                            TableSchema = viewSchema,
                            IsView = true
                        });
                    }
                }
            }
            finally
            {
                _isLoadingSchemaInfo = false;
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
        private async void _btnOpen_Click(object sender, EventArgs e)
        {
            if (this.CurrentSchemaProvider != null)
            {
                if (_isConnectOperating) return;
                _isConnectOperating = true;
                try
                {
                    if (this.CurrentSchemaProvider.Opened)
                    {
                        this.CurrentSchemaProvider.Close();
                        this._btnOpen.Image = Resources.connnect_closed;
                        this.ClearSchemaInfo();
                    }
                    else
                    {
                        if (this.GetConnectionStirng(out String connectionString))
                        {
                            try
                            {
                                this._waitConnect.Visible = true;
                                this._waitConnect.IsRolled = true;
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
                    }
                }
                finally
                {
                    _isConnectOperating = false;
                }
            }
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
        private Boolean _isLoadColumnSchema = false;
        private async void _tvSchema_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (_isLoadColumnSchema) return;
            _isLoadColumnSchema = true;
            try
            {
                var node = e.Node;
                if (node.Parent != null)
                {
                    var schema = e.Node.Tag as TableSchemaExtend;
                    var schemaInfo = this._schemaInfoTable[schema.Name] as SchemaInfoTupleEx;
                    Boolean needLoad = schemaInfo.ColumnSchems == null;

                    //加载表结构信息
                    if (needLoad)
                    {
                        _waitColumnSchemaLoad.IsRolled = true;
                        _waitColumnSchemaLoad.Visible = true;

                        try
                        {
                            schemaInfo.ColumnSchems = await this.GetColumnSchemasAsync(schemaInfo);

                        }
                        finally
                        {
                            _waitColumnSchemaLoad.IsRolled = false;
                            _waitColumnSchemaLoad.Visible = false;
                        }


                    }
                    this._dgvColumnSchema.DataSource = schemaInfo.ColumnSchems;
                }
            }
            finally
            {
                _isLoadColumnSchema = false;
            }

        }
        private Task<IList<ColumnSchemaExtend>> GetColumnSchemasAsync(SchemaInfoTupleEx schemaInfo)
        {
            if (!schemaInfo.IsView)
            {
                return TaskEx.Run(() => this.CurrentSchemaProvider.LoadColumnSchemaList(schemaInfo.TableSchema.Name));
            }
            else
            {
                return TaskEx.Run(() => this.CurrentSchemaProvider.LoadViewColumnSchemaList(schemaInfo.TableSchema.Name));
            }
        }
        private void _tbSelectdExportDirecotry_Click(Object sender, EventArgs e)
        {
            var result = _dialogExportDirectory.ShowDialog();
            if (result == DialogResult.OK)
            {
                this._tbExportDirectory.Text = this._dialogExportDirectory.SelectedPath;
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
            String caption = "提示";
            MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void ShowTipInformation(String text)
        {
            this._labelTipInfo.Text = text;
            this._labelTipInfo.ForeColor = this.ForeColor;
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
                //补全所有尚未获取的元数据信息
                IList<SchemaInfoTuple> schemaInfos = new List<SchemaInfoTuple>();
                foreach (var tableSchema in this.CheckedTableSchemas)
                {
                    var schemaInfo = this._schemaInfoTable[tableSchema.Name] as SchemaInfoTupleEx;
                    if (schemaInfo.ColumnSchems == null)
                    {
                        this.ShowTipInformation(String.Format("正在补全 [{0}] 的结构信息...", schemaInfo.TableSchema.Name));
                        schemaInfo.ColumnSchems = await this.GetColumnSchemasAsync(schemaInfo);
                    }
                    schemaInfos.Add(schemaInfo);
                }
                this.CurrentSchemaExporter.Export(this.CurrentExportDirectory,schemaInfos,this.CurrentExportConfig);

                String exportCompleted = "导出完成！";
                this.ShowTipInformation(exportCompleted);
                this.ShowDialogTipInformation(exportCompleted);
            }
            catch (Exception exc)
            {
                this.ShowErrorInformation("导出时发生异常！" + exc.Message);
                MessageBox.Show(exc.ToString(),"异常",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            finally
            {
                this.EnableContol(true);
            }
        }
        private void EnableContol(Boolean enabled)
        {
            this._btnExport.Enabled = enabled;
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
    }
    public class SchemaInfoTupleEx : SchemaInfoTuple
    {
        public Boolean IsView { get; set; }
    }
}

