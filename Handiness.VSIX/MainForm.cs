using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Concision;
using System.Reflection;
using System.Collections;
using Handiness.Metadata;
using System.Threading;
using Handiness.CodeBuild;
using EnvDTE;

using System.ComponentModel.Design;
using System.Globalization;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Task = System.Threading.Tasks.Task;
using System.IO;

namespace Handiness.VSIX
{
    public partial class MainForm : BaseForm
    {
        /// <summary>
        /// 元数据组建状态
        /// </summary>
        public enum MetadataBuildingStatus
        {
            Error,
            Building,
            Completed
        }
        /// <summary>
        /// 扫描类型
        /// </summary>
        public enum ScanProcessType
        {
            MetadataProvider,
            CodeTemplate,
            MappingType,
            NameModifier,
            Project
        }
        /// <summary>
        /// 组建状态 
        /// </summary>
        public enum BuildingStatus
        {
            Processing,
            Completed,
            ProjectChanging,
            ProjectChanged
        }
        /// <summary>
        /// 组建参数错误类型
        /// </summary>
        public enum BuildingParaErrors
        {
            None,
            MetadataProvider,
            CodeTemplate,
            MappingType,
            NameModifier,
            Project
        }
        /// <summary>
        /// 扫描类型改变时
        /// </summary>
        public event Action<ScanProcessType, Object> ScanProcessTypeChanged;
        public event Action<BuildingStatus, Object> BuildingStatusChanged;
        public event Action<MetadataBuildingStatus, Object> MetadataBuildingStatusChanged;

        public IServiceProvider ServiceProvider { get; set; }
        public BuildAssistPacket BuildAssistPacket { get; set; } = new BuildAssistPacket();

        public MainForm()
        {
            InitializeComponent();
            this.ScanProcessTypeChanged += MainForm_ScanProcessTypeChanged;
            this.MetadataBuildingStatusChanged += MainForm_MetadataBuildingStatusChanged;
            this.BuildingStatusChanged += MainForm_BuildingStatusChanged;
            this.SettingTreeStyle();
        }
        #region 事件注册
        private void MainForm_BuildingStatusChanged(BuildingStatus state, Object extra)
        {
            String stateInfo = String.Empty;
            switch (state)
            {
                case BuildingStatus.Processing: {
                        stateInfo = "组建中...";
                        this.DrawButtonStyle(this._btnCodeBuild, TextResource.BuildButtonTextWithBuilding, true);
                    } break;
                case BuildingStatus.ProjectChanging: stateInfo = "项目文件添加"; break;
                case BuildingStatus.ProjectChanged: stateInfo = "项目文件完成"; break;
                case BuildingStatus.Completed:
                default:
                    {
                        stateInfo = "组建完成";
                        this.DrawButtonStyle(this._btnCodeBuild, TextResource.BuildButtonTextWithNormal, false);
                    } break;
            }
            this.DrawTipInfo($"组建状态：{stateInfo}");
        }

        private void MainForm_MetadataBuildingStatusChanged(MetadataBuildingStatus state, Object extra)
        {
            String stateInfo = String.Empty;
            switch (state)
            {
                case MetadataBuildingStatus.Building:
                    {
                        stateInfo = "组建中...";
                        this.DrawButtonStyle(this._btnCodeBuild, TextResource.BuildButtonTextWithConnection, true);
                    }
                    break;
                case MetadataBuildingStatus.Error:
                    {
                        stateInfo = "错误，无可用元数据提供者！";
                        this.DrawButtonStyle(this._btnCodeBuild, TextResource.BuildButtonTextWithNormal, false);
                    }
                    break;
                case MetadataBuildingStatus.Completed:
                default:
                    {
                        this.DrawButtonStyle(this._btnCodeBuild, TextResource.BuildButtonTextWithNormal, false);
                        stateInfo = "组建完成";
                    }
                    break;
            }
            this.DrawTipInfo($"元数据组建状态：{stateInfo}");
        }
        private void MainForm_ScanProcessTypeChanged(ScanProcessType scanType, Object extra = null)
        {
            String scanInfo = String.Empty;
            switch (scanType)
            {
                case ScanProcessType.CodeTemplate: scanInfo = "代码模板"; break;
                case ScanProcessType.MappingType: scanInfo = "映射类型"; break;
                case ScanProcessType.MetadataProvider: scanInfo = "元数据提供者"; break;
                case ScanProcessType.NameModifier: scanInfo = "名称修改器"; break;
                case ScanProcessType.Project: scanInfo = "可用项目"; break;
                default: break;
            }
            this.DrawTipInfo($"扫描可用选：{scanInfo}");
        }
        private void DrawParaErrorInfo(BuildingParaErrors error)
        {
            String errorInfo = String.Empty;
            switch (error)
            {
                case BuildingParaErrors.CodeTemplate: errorInfo = "代码模板"; break;
                case BuildingParaErrors.MappingType: errorInfo = "映射类型"; break;
                case BuildingParaErrors.MetadataProvider: errorInfo = "元数据提供者"; break;
                case BuildingParaErrors.NameModifier: errorInfo = "名称修改器"; break;
                case BuildingParaErrors.Project: errorInfo = "可用项目"; break;
                default: break;
            }
            this.DrawTipInfo($"参数错误：{errorInfo}");
        }
        #endregion
        /// <summary>
        /// 美化treeView
        /// </summary>
        protected void SettingTreeStyle()
        {

            //this._trvSchema.ImageList = new ImageList();
            //var nodeIcon = new Bitmap(@"Resources\table.png");
            //this._trvSchema.ImageList.Images.Add(nodeIcon);
            //this._trvSchema.ImageIndex = 0;
        }
        #region 事件触发
        protected void OnMetadataBuildingStatusChanged(MetadataBuildingStatus state, Object extra = null)
        {
            this.MetadataBuildingStatusChanged?.Invoke(state, extra);
        }
        protected void OnScanProcessTypeChanged(ScanProcessType processType, Object extra = null)
        {
            this.ScanProcessTypeChanged?.Invoke(processType, extra);
        }
        protected void OnBuildingStatusChanged(BuildingStatus state, Object extra = null)
        {
            this.BuildingStatusChanged?.Invoke(state, extra);
        }
        #endregion
        /// <summary>
        /// 扫描可用设置
        /// </summary>
        public async void ScanUseableSetting()
        {

            //扫描元数据提供者
            this.OnScanProcessTypeChanged(ScanProcessType.MetadataProvider);
            this.SuspendCombobox(this._cbxMetadataProvider);
            IEnumerable<IMetadataProvider> providers = await Task.Run(() =>
             {
                 return MetadataProvider.ExportMetadataProviders();
             });
            this.AddItemsCombobox<IMetadataProvider>(this._cbxMetadataProvider, providers, (t) => t.Explain);
            this.ResumeCombobox(this._cbxMetadataProvider);


            //扫描代码模板
            this.OnScanProcessTypeChanged(ScanProcessType.CodeTemplate);
            this.SuspendCombobox(this._cbxCodeTemplate);
            IEnumerable<CodeTemplateXml> codeTemplates = await Task.Run(() =>
            {
                return CodeTemplateXml.Search(TextResource.CodeTemplateFilesPath);
            });
            this.AddItemsCombobox<CodeTemplateXml>(this._cbxCodeTemplate, codeTemplates, (t) => t.Explain);
            this.ResumeCombobox(this._cbxCodeTemplate);

            //扫描类型映射
            this.OnScanProcessTypeChanged(ScanProcessType.MappingType);
            this.SuspendCombobox(this._cbxMapType);
            IEnumerable<TypeMappingXml> typeMappings = await Task.Run(() =>
            {
                return TypeMappingXml.Search(TextResource.TypeMappingFilesPath);
            });
            this.AddItemsCombobox<TypeMappingXml>(this._cbxMapType, typeMappings, (t) => t.Explain);
            this.ResumeCombobox(this._cbxMapType);


            //扫描名称修改器
            this.OnScanProcessTypeChanged(ScanProcessType.NameModifier);
            this.SuspendCombobox(this._cbxNameFormat);
            IEnumerable<INameModifier> nameModifiers = await Task.Run(() =>
            {
                //TODO:未添加名称修改器接口实现类扫描功能
                return new List<INameModifier> {
                    new PascalNameModifier()
                };
            });
            this.AddItemsCombobox<INameModifier>(this._cbxNameFormat, nameModifiers, (t) => t.Explain);
            this.ResumeCombobox(this._cbxNameFormat);


            //扫描可用项目
            this.OnScanProcessTypeChanged(ScanProcessType.Project);
            this.SuspendCombobox(this._cbxActiveProject);
            IEnumerable<EnvDTE.Project> projects = await Task.Run(() =>
            {
                IList<EnvDTE.Project> result = null;
                if (this.ServiceProvider != null)
                {
                    var dteObject = this.ServiceProvider.GetService(typeof(EnvDTE.DTE)) as EnvDTE.DTE;
                    Solution sln = dteObject.Solution;
                    Array startsProjects = sln.SolutionBuild.StartupProjects as Array;
                    if (startsProjects != null && startsProjects.Length > 0)
                    {
                        result = new List<EnvDTE.Project>();
                        foreach (EnvDTE.Project project in sln.Projects)
                        {
                            result.Add(project);
                        }
                    }
                }
                return result;
            });

            this.AddItemsCombobox<EnvDTE.Project>(this._cbxActiveProject, projects, (t) => t.Name);
            this.ResumeCombobox(this._cbxActiveProject);
        }
        #region Combobox 操作
        private void AddItemsCombobox<T>(Concision.Control.Combobox comboxbox, IEnumerable<T> items, Func<T, String> getText)
        {
            if (items != null)
            {
                comboxbox.Items.Clear();
                foreach (var item in items)
                {
                    comboxbox.Add(getText(item), item);
                }
            }
        }
        private void SuspendCombobox(Concision.Control.Combobox comboxbox, String text = "扫描中...")
        {
            comboxbox.Text = text;
            comboxbox.IsWaiting = true;
        }
        private void ResumeCombobox(Concision.Control.Combobox comboxbox, String text = null)
        {
            if (text != null) comboxbox.Text = text;
            else
            {
                if (comboxbox.Items.Count > 0)
                {
                    comboxbox.SelectedText = comboxbox.Items[0].Text;
                }
                else
                {
                    comboxbox.Text = "无可用扫描结果";
                }
            }
            comboxbox.IsWaiting = false;
        }
        #endregion

        protected override void OnShown(EventArgs e)
        {
            this.ScanUseableSetting();
            base.OnShown(e);
        }



        private void _btnCannel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _btnCodeBuildControl_Click(object sender, EventArgs e)
        {
            this.Building();
        }

 
        private async void Building()
        {
            var result = this.SettingParameter(this.BuildAssistPacket);
            if (!result.isOk)
            {
                DrawParaErrorInfo(result.error);
                return;
            }
            this.OnBuildingStatusChanged(BuildingStatus.Processing);
          
            await Task.Run(() =>
            {
                CodeBuilder codeBuilder = new CodeBuilder(
                    this.BuildAssistPacket.Schemas,
                    this.BuildAssistPacket.CodeTemplate,
                    this.BuildAssistPacket.TypeMapper,
                    this.BuildAssistPacket.NameModifier,
                    this.BuildAssistPacket.NameSpace
                    );
                var codes = codeBuilder.Building();
                foreach (var code in codes)
                {
                    this.AddCodeToProject(code.Name, code.Code);
                }
            });
            this.OnBuildingStatusChanged(BuildingStatus.Completed);
        }
        private void AddCodeToProject(String name, String code)
        {
            FileInfo fileInfo = null;
            //生成临时代码文件
            using (Stream stream = new FileStream(name, FileMode.Create, FileAccess.Write, FileShare.None,
                8096, FileOptions.WriteThrough))
            {
                fileInfo = new FileInfo(name);
                StreamWriter writer = new StreamWriter(stream);
                writer.Write(code);
                writer.Flush();
            }
            var projectItem = this.QueryProjectItem(this.BuildAssistPacket.Project, name);
            if (projectItem != null) projectItem.Delete();
            //往指定项目添加代码文件
            this.BuildAssistPacket.Project.ProjectItems.AddFromFileCopy(fileInfo.FullName);
            fileInfo.Delete();
        }
        /// <summary>
        /// 获取指定名称的项目文件对象
        /// </summary>
        private ProjectItem QueryProjectItem(EnvDTE.Project project, String name)
        {

            foreach (ProjectItem item in project.ProjectItems)
            {
                String fileName = item.Name;
                if (name == fileName)
                {
                    return item;
                }
            }
            return null;
        }
        private void DrawButtonStyle(Concision.Control.Button button, String text, Boolean isWaiting = false)
        {
            button.IsWaiting = isWaiting;
            button.Text = text;
        }

        private void _sylSetting_Click(object sender, EventArgs e)
        {
            IMetadataProvider provider = this._cbxMetadataProvider.SelectedValue as IMetadataProvider;
            if (provider == null)
            {
                this.OnMetadataBuildingStatusChanged(MetadataBuildingStatus.Error);
           
                return;
            }
            SettingForm form = new SettingForm(this.BuildAssistPacket);
            if (DialogResult.OK == form.ShowDialog())
            {
                this.BuildingMetadata(provider);
            }
        }
        private void DrawTipInfo(String text)
        {
            this._lblTip.Text = text;
        }
        private async void BuildingMetadata(IMetadataProvider provider)
        {
            this.OnMetadataBuildingStatusChanged(MetadataBuildingStatus.Building);
            String info = String.Empty;
            var result = await Task.Run(() =>
             {
                 String errorInfo = String.Empty;
                 Boolean isCmpld = true;
                 List<Tuple<TableSchema, IEnumerable<ColumnSchema>>>
                 list = new List<Tuple<TableSchema, IEnumerable<ColumnSchema>>>();
                 try
                 {
                     provider.Open(this.BuildAssistPacket.ConnectionString);
                     var tableSchemas = provider.GetTableSchemas();
                     foreach (var tableSchema in tableSchemas)
                     {
                         IEnumerable<ColumnSchema> colSchemas = provider.GetColumnSchemas(tableSchema.Name);
                         list.Add(Tuple.Create(tableSchema, colSchemas));
                     }
                 }
                 catch (Exception exc)
                 {
                     isCmpld = false;
                     errorInfo = exc.Message;
                 }
                 finally
                 {
                     provider.Close();
                 }
                 return (isCmpld, list, errorInfo);
             });
            if (result.Item1 && result.Item2.Count > 0)
            {
                this._trvSchema.Nodes.Clear();
                this._dgvTableSchema.Rows.Clear();
                this._dgvTableSchema.DataSource = result.Item2[0].Item2;
                foreach (var schema in result.Item2)
                {
                    this.DrawMetadata(schema);
                }
            }
            else
            {
                info = result.Item3;
            }
            this.DrawTipInfo(info);
            this.OnMetadataBuildingStatusChanged(MetadataBuildingStatus.Completed);
        }
        private void DrawMetadata(Tuple<TableSchema, IEnumerable<ColumnSchema>> schema)
        {
            TreeNode tableNode = new TreeNode(schema.Item1.Name);
            tableNode.ToolTipText = schema.Item1.Explain ?? schema.Item1.Name;
            tableNode.Checked = true;
            this._trvSchema.Nodes.Add(tableNode);
            tableNode.Tag = schema;
        }
        private (Boolean isOk, BuildingParaErrors error) SettingParameter(BuildAssistPacket assistPacket)
        {
            Boolean passed = false;
            assistPacket.Schemas = this.GetCheckedSchemas();

            assistPacket.MetadataProvider = this._cbxMetadataProvider.SelectedValue as IMetadataProvider;
            if (assistPacket.MetadataProvider == null) return (passed, BuildingParaErrors.MappingType);

            assistPacket.NameModifier = this._cbxNameFormat.SelectedValue as INameModifier;
            if (assistPacket.NameModifier == null) return (passed, BuildingParaErrors.NameModifier);

            assistPacket.CodeTemplate = this._cbxCodeTemplate.SelectedValue as CodeTemplateXml;
            if (assistPacket.CodeTemplate == null) return (passed, BuildingParaErrors.CodeTemplate);

            TypeMappingXml typeMapping = this._cbxMapType.SelectedValue as TypeMappingXml;
            if (typeMapping == null) return (passed, BuildingParaErrors.MappingType);


            assistPacket.TypeMapper = new TypeMapper(typeMapping);

            assistPacket.Project = this._cbxActiveProject.SelectedValue as EnvDTE.Project;
            if (assistPacket.Project == null) return (passed, BuildingParaErrors.Project);

            passed = true;
            return (passed, BuildingParaErrors.None);
        }
        private void _sylRefresh_Click(object sender, EventArgs e)
        {
            this.ScanUseableSetting();
        }
        private IEnumerable<(TableSchema tableSchema, IEnumerable<ColumnSchema> colSchemas)> GetCheckedSchemas()
        {
            List<(TableSchema tableSchema, IEnumerable<ColumnSchema> colSchemas)> schemas =
                new List<(TableSchema tableSchema, IEnumerable<ColumnSchema> colSchemas)>();
            foreach (TreeNode node in this._trvSchema.Nodes)
            {
                if (node.Checked)
                {
                    Tuple<TableSchema, IEnumerable<ColumnSchema>> metaData = (Tuple<TableSchema, IEnumerable<ColumnSchema>>)(node.Tag);
                    schemas.Add((metaData.Item1, metaData.Item2));
                }
            }
            return schemas;
        }
        private void _trvSchema_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            Tuple<TableSchema, IEnumerable<ColumnSchema>> schema = (Tuple<TableSchema, IEnumerable<ColumnSchema>>)(e.Node.Tag);
            this._dgvTableSchema.DataSource = schema.Item2;
        }
    }
}
