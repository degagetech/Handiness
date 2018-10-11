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
             
        }
    }
}
