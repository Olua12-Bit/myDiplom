using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Text;
using MySql.Data.MySqlClient;

namespace Tutorial.SqlConn
{
    class DBOLESQLUtils
    {

        public static OleDbConnection
                 GetDBConnection(string provider, string username, string source,string password)
        {
            
          String connString = "Provider=" + provider + ";User ID=" + username + ";Data Source="+source+ "; Jet OLEDB:Database Password="+password;
            OleDbConnection conn = new OleDbConnection(connString);

            return conn;
        }

    }
}
