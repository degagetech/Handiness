using Handiness2.Schema.Exporter.Windows.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Handiness2.Schema.Exporter.Windows
{
    public partial class SchemaCompareForm : BaseForm
    {
        public List<SchemaInfoTuple> SourceSchemaInfos { get; private set; }
        public List<SchemaInfoTuple> TargetSchemaInfos { get; private set; }

        private SchemaCompareForm()
        {
            InitializeComponent();
            this.Shown += SchemaCompareForm_Shown;
        }

        private void ShowTipInformation(String text = null)
        {
            this._labelTipInfo.Text = text;
            this._labelTipInfo.ForeColor = Color.White;
        }

        public SchemaCompareForm(List<SchemaInfoTuple> source, List<SchemaInfoTuple> target) : this()
        {
            this.SourceSchemaInfos = source;
            this.TargetSchemaInfos = target;
        }



        private async void SchemaCompareForm_Shown(Object sender, EventArgs e)
        {
            _imageListSrouceSchemaTree.Images.Add("tree_table", Resources.table);
            _imageListSrouceSchemaTree.Images.Add("tree_view", Resources.view);
            _imageListSrouceSchemaTree.Images.Add("tree_procedure", Resources.procedure);
            _imageListSrouceSchemaTree.Images.Add("tree_function", Resources.function);

            _imageListTargetSchemaTree.Images.Add("tree_table", Resources.table);
            _imageListTargetSchemaTree.Images.Add("tree_view", Resources.view);
            _imageListTargetSchemaTree.Images.Add("tree_procedure", Resources.procedure);
            _imageListTargetSchemaTree.Images.Add("tree_function", Resources.function);



        }

        

        private void RenderingSchemaTree(List<SchemaInfoTuple> schemaInfos, TreeView treeView)
        {

        }
    }
}
