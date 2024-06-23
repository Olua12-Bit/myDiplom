using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Text;
using MySql.Data.MySqlClient;

namespace Tutorial.SqlConn
{
    class DBUtils
    {
        public static OleDbConnection GetDBConnection()
        {
            string provider= "Microsoft.Jet.OLEDB.4.0";
            string username = "Admin";
           string source = "ManicureDB.mdb";
            string password = "1W=p_+4bMfs5-q*";

            return DBOLESQLUtils.GetDBConnection(provider,username,source, password);
        }

    }
}