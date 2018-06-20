using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Handiness2.Schema.Exporter.Windows
{
    public partial class BaseExportConfigControl : UserControl
    {
        public ISchemaExporter SchemaExporter { get; private set; }
        public ExportConfig ExportConfig { get; private set; }

        public BaseExportConfigControl()
        {
            InitializeComponent();
        }
    }
}
