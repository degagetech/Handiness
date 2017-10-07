using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SchemaViewer
{
    public partial class SchemaViewerForm : Form
    {
        //String[] columnRes = new String[] { null, "Personal", null };
        //String[] tableRes = new String[] { null, "Personal" };
        //String[] IndexColumnsRes = new String[] { "WLJ", null, null, null, null };
        ////MySql
        //MySqlDbProvider dpMysql = new MySqlDbProvider();
        //DbConnection connection = dpMysql.CreateConnection("server=192.168.29.128;Port=3306;Uid=root;Pwd=123456;DataBase=handinessOrm;Pooling=true;charset=utf8;");

        //    // MySqlClientFactory.

        //    //SqlServer 
        //    //SqlDbProvider dp = new SqlDbProvider();
        //    //DbConnection connection = dp.CreateConnection("Data Source=192.168.29.128;Uid=sa;Pwd=932444208;Initial Catalog=HandinessOrm;");

        //    //Oracle
        //    //  OracleDbProvider dp = new OracleDbProvider();
        //    // DbConnection connection = dp.CreateConnection(
        //    //"Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.29.128)(PORT=1521)))(CONNECT_DATA=(SERVICE_NAME=oracle)));User Id=wlj;Password=932444208;");


        //    //SQLite
        //    //SQLiteDbProvider dpSQLite = new SQLiteDbProvider();
        //    //DbDataAdapter da = dpSQLite.CreateDataAdapter();
        //    try
        //    {
        //        connection.Open();


        //        // String t = DbMetaDataCollectionNames.;
        //        //  DbMetaDataColumnNames a = new DbMetaDataColumnNames();
        //        //    String t1 = DbMetaDataColumnNames.ColumnSize;

        //        //  MetaCO
        //        //Type type = typeof(DbMetaDataColumnNames);
        //        //FieldInfo[] fieldInfos = type.GetFields();
        //        //foreach (FieldInfo info in fieldInfos)
        //        //{
        //        //    this.textBox1.Text += info.Name + " || " + info.GetValue(null).ToString()+System.Environment.NewLine;
        //        //}
        //        //   DataTable dt = connection.GetSchema("Tables", null);
        //        //     DataTable dt = connection.GetSchema("IndexColumns", IndexColumnsRes);
        //        //     DataTable dt = connection.GetSchema("Columns", new String[] {  "WLJ", null, null });
        //        //    DataTable dt = connection.GetSchema("PrimaryKeys", new String[] { "WLJ", null, null });
        //        //  DataTable dt = connection.GetSchema(DbMetaDataCollectionNames.MetaDataCollections, null);
        //        //      DataTable dt = connection.GetSchema("XMLSchemas", null);
        //        //DataTable dt = connection.GetSchema(DbMetaDataCollectionNames.Restrictions,null);
        //        // DataTable dt = connection.GetSchema(DbMetaDataCollectionNames.DataSourceInformation, null);
        //        DataTable dt = connection.GetSchema(DbMetaDataCollectionNames.DataTypes, null);
        //        //   DataTable dt = connection.GetSchema(DbMetaDataCollectionNames.ReservedWords, null);

        //        this.dataGridView1.DataSource = dt;
        //    }
        //    finally
        //    {
        //        connection.Close();
        //    }
        //}

        private Dictionary<String, Func<DbConnection>> _dbConnectionFacotry = new Dictionary<String, Func<DbConnection>>();

        public Func<DbConnection> CurrentConnectionFactory { get; private set; }
        public String CurrentConnectionString
        {
            get
            {
                return this._txtConnectionString.Text.Trim();
            }
        }
        public SchemaViewerForm()
        {
            InitializeComponent();
            this.Load += SchemaViewerForm_Load;
        }
        public SchemaViewerForm(Dictionary<String, Func<DbConnection>> dbConnectionFactory) : this()
        {
            this._dbConnectionFacotry = dbConnectionFactory;
        }
        private void SchemaViewerForm_Load(object sender, EventArgs e)
        {
            this.InitlizeView();
        }

        public void InitlizeView()
        {
            BindingSource source = new BindingSource();
            source.DataSource = this._dbConnectionFacotry;
            this._cmbDataBaseType.DisplayMember = "Key";
            this._cmbDataBaseType.ValueMember = "Value";
            this._cmbDataBaseType.DataSource = source;
            this._cmbCollectionName.Items.AddRange(
                new Object[] {
                DbMetaDataCollectionNames.Restrictions,
                DbMetaDataCollectionNames.DataTypes,
                DbMetaDataCollectionNames.MetaDataCollections,
                DbMetaDataCollectionNames.DataSourceInformation,
                DbMetaDataCollectionNames.ReservedWords
                   }
                );
            this._cmbCollectionName.SelectedIndex = 0;
        }
        private (Boolean successful, DbConnection connection, String failedReason) OpenConnection(Func<DbConnection> connectionFactory)
        {
            Boolean successful = false;
            DbConnection connection = null;
            String failedReason = String.Empty;
            String connectionStr = this.CurrentConnectionString.Trim();
            if (this.CurrentConnectionFactory != null
                && !String.IsNullOrEmpty(connectionStr))
            {
                connection = connectionFactory.Invoke();
                connection.ConnectionString = connectionStr;
                try
                {
                    connection.Open();
                    successful = true;
                }
                catch (Exception exc)
                {
                    failedReason = exc.Message;
                }
            }
            return (successful, connection, failedReason);
        }
        private void CloseConnection(DbConnection connection)
        {
            if (connection != null && connection.State == ConnectionState.Open)
            {
                connection.Close();
                connection.Dispose();
            }
        }
        private DataTable QueryMetaDataInfo(String collectionName, String[] restrictions = null)
        {
            var result = this.OpenConnection(this.CurrentConnectionFactory);
            DataTable dt = null;
            if (result.successful)
            {
                try
                {
                    dt = result.connection.GetSchema(collectionName, restrictions);
                }
                finally
                {
                    this.CloseConnection(result.connection);
                }
            }
            return dt;
        }
        private void ClearData()
        {
            this._dgvDataShow.DataSource = null;
        }
        private void ShowData(DataTable dt, Boolean isNewForm = false, String title = null)
        {
            if (!isNewForm)
            {
                this._dgvDataShow.DataSource = dt;
            }
            else
            {
                title = title ?? $"{this._cmbDataBaseType.Text},{this._cmbCollectionName.Text}";
                DataShowForm form = new DataShowForm(title, dt);
                form.Show();
            }
        }
        private void _cmbDataBaseType_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ClearData();
            Func<DbConnection> connectionFactory = this._cmbDataBaseType.SelectedValue as Func<DbConnection>;
            if (connectionFactory != null)
            {
                this.CurrentConnectionFactory = connectionFactory;
            }
            else
            {
                throw new Exception($"{this._cmbDataBaseType.SelectedText} connection factory object is null!");
            }
        }
        private String[] GetQueryRestriction()
        {
            String[] restrictions = null;
            String restrictionStr = this._txtRestriction.Text.Trim();
            restrictions = restrictionStr.Split(new Char[] { ';' });
            if (restrictions.Length > 0)
            {
                for (Int32 i = 0; i < restrictions.Length; ++i)
                {
                    restrictions[i] = restrictions[i].Trim();
                }
            }
            else
            {
                restrictions = null;
            }
            return restrictions;
        }
        private void _btnConfrim_Click(object sender, EventArgs e)
        {
            this.ClearData();
            DataTable dt = this.QueryMetaDataInfo(DbMetaDataCollectionNames.Restrictions);

            this.ShowData(dt, true, $"{this._cmbDataBaseType.Text},{DbMetaDataCollectionNames.Restrictions}");
        }
        private void Query()
        {
            String collectionName = this._cmbCollectionName.Text.Trim();
            String[] restrictions = this.GetQueryRestriction();
            DataTable dt = this.QueryMetaDataInfo(collectionName, restrictions);
            this.ShowData(dt,this._cbNewForm.Checked);
        }
        private void SchemaViewerForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void _btnQuery_Click(object sender, EventArgs e)
        {
            this.Query();
        }
    }
}
