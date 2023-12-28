using System.Collections.Generic;
using System.Data.SqlClient;

namespace PuzzleGame
{
    class Modify
    {
        public Modify()
        {
        }
        SqlCommand cmd;
        SqlDataReader rdr;
        Connection connection = new Connection();
        public List<Player> players(string query)
        {
            List<Player> list = new List<Player>();
            using (SqlConnection conn = connection.GetConnection())
            {
                cmd = new SqlCommand(query, conn);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    list.Add(new Player(rdr.GetString(0), rdr.GetString(1)));
                }
                conn.Close();
            }
            return list;
        }
        public void Command(string query)
        {
            using (SqlConnection conn = connection.GetConnection())
            {
                cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}
