using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Login_EDP
{
    internal class MyDatabase
    {

        string connString = "server=localhost;port=3306;username=root;password=;database=db_users;";
        MySqlConnection conn;

        public MyDatabase()
        {
            conn = new MySqlConnection(connString);
        }

        public bool TestConnection()
        {
            try
            {
                conn.Open();
                conn.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection Error: " + ex.Message);
                return false;
            }
        }

        public DataTable ExecuteReturnQuery(string sql, MySqlParameter[] parameters)
        {
            DataTable dt = new DataTable();
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                if (parameters != null) cmd.Parameters.AddRange(parameters);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Query Error: " + ex.Message);
            }
            return dt;
        }

        public bool ExecuteNonQuery(string sql, MySqlParameter[] parameters)
        {
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                if (parameters != null) cmd.Parameters.AddRange(parameters);

                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            } 
            catch (Exception ex)
            {
                MessageBox.Show("Execution Error: " + ex.Message);
                if (conn.State == ConnectionState.Open) conn.Close();
                return false;
            }
        }
    }
}
