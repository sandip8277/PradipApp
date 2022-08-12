using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;

namespace QuickReviewReports.Helper
{
    public class ConnectionHelper
    {
        public SqlConnection GetSqlConnection()
        {
            //Read connection string from app.config
            string connectionString= ConfigurationManager.ConnectionStrings["QRRConnectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);
            return conn;
        }
    }
}
