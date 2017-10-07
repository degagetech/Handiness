using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SchemaViewer
{
    public partial class DataShowForm : Form
    {
        public DataShowForm()
        {
            InitializeComponent();
        }
        public DataShowForm(String title,DataTable dt):this()
        {
            this.Text = title;
            this._dgvDataShow.DataSource = dt;
        }

        private void DataShowForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this._dgvDataShow.DataSource = null;
        }
    }
}
