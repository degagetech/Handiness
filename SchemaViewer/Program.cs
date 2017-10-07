using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;
using Oracle.ManagedDataAccess.Client;
using MySql.Data.MySqlClient;
using System.Data.SQLite;
namespace SchemaViewer
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Dictionary<String, Func<DbConnection>> connections = new Dictionary<String, Func<DbConnection>>
            {
                 { "MySQL" , new Func<DbConnection>(()=>new MySqlConnection())},
                 { "Oracle" , new Func<DbConnection>(()=>new OracleConnection())},
                 { "SQL Server" , new Func<DbConnection>(()=>new SqlConnection())},
                 { "SQLite" , new Func<DbConnection>(()=>new SQLiteConnection())}
            };
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SchemaViewerForm(connections));
        }
    }
}
