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
    public partial class ExcelTemplateItemEditorForm : Form
    {
        public ExcelExportTemplateConfig ExportTemplateConfig { get; private set; }
        public ExcelTemplateItemEditorForm()
        {
            InitializeComponent();
        }
        public ExcelTemplateItemEditorForm(ExcelExportTemplateConfig config) : this()
        {
            this.ExportTemplateConfig = config;
            this._pgTemplateItemEditor.SelectedObject = config;
        }
    }
}
