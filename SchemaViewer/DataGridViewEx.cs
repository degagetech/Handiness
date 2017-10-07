using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SchemaViewer
{
    public partial class DataGridViewEx : DataGridView
    {
        public DataGridViewEx():base()
        {
            this.DoubleBuffered = true;
        }
    }
}
