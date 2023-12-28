using System.Data.SqlClient;

namespace PuzzleGame
{
    class Connection
    {
        private static string strConn = @"Data Source=JIBRIL\MSSQLSERVER04;Initial Catalog=LTTQ;Integrated Security=True";
        private SqlConnection sqlConn;
        public Connection()
        {
            sqlConn = new SqlConnection(strConn);
            sqlConn.Open();
        }
        public SqlConnection GetConnection()
        {
            return sqlConn;
        }
    }
}
