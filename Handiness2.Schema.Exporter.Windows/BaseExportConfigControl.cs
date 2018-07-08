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
        public virtual ISchemaExporter SchemaExporter { get; protected set; }
        public virtual ExportConfig ExportConfig { get; protected set; }

        public SchemaExportForm SchemaExportForm { get; private set; }

        public BaseExportConfigControl()
        {
            InitializeComponent();
        }
        public virtual void ImportConfigInfo(String configString)
        {

        }
        public virtual String ExportConfigInfo()
        {
            return null;
        }
        public virtual Boolean  IsValidExportConfig(out String errorMessage)
        {
            errorMessage = null;
            return false;
        }
        public virtual void ResetConfigInfo()
        {

        }
        public virtual void Initialize(SchemaExportForm form)
        {
            this.SchemaExportForm = form;
        }
    }
}
