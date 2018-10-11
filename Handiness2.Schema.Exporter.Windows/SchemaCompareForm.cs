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
        public SchemaCompareForm()
        {
            InitializeComponent();
        }
        public SchemaCompareForm(List<SchemaInfoTuple> source, List<SchemaInfoTuple> target) : this()
        {
           
        }
    }
}
