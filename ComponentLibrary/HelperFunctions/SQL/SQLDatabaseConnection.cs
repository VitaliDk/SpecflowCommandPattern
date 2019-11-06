using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ComponentLibrary.HelperFunctions.SQL
{
    public class SQLDatabaseConnection
    {
        

        public static SqlConnection ConnectTo(string server, string database)
        {// to be refactored out to config settings
            string sqlConnectionString = "user id=ui_test_project;" + // svc_uat_sql
                                               $"password=h8VbTMTA65;server={server};" +
                                               "Trusted_Connection=FALSE;" +
                                               $"database={database}; " +
                                               "connection timeout=30";
            SqlConnection myConnection = new SqlConnection(sqlConnectionString);

            return myConnection;
        }
    }
}
