using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace DJCMNQ_Server
{
    class DbApi
    {

        public static string connsql = @"server=192.168.1.250;Database=TestDB1;uid=sa;pwd=Shanghai804;SslMode = none";

        public static void SqlExcuteCMD(String CmdStr)
        {
            using (MySqlConnection con = new MySqlConnection(connsql))
            using (MySqlCommand cmd = new MySqlCommand(CmdStr, con))
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }


        public static DataTable ExcuteQueryUsingDataReader(string myQuery)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection con = new MySqlConnection(connsql))
            using (MySqlCommand cmd = new MySqlCommand(myQuery, con))
            {
                con.Open();
                using (var dr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (dr.HasRows)
                    {
                        dt.Load(dr);
                    }
                    //while(dr.Read())
                    //{
                    //    //....
                    //}
                }
                return dt;
            }
        }

        public static DataTable ExcuteQueryUsingDataAdapter(string myQuery)
        {
            using (MySqlConnection con = new MySqlConnection(connsql))
            using (MySqlDataAdapter dap = new MySqlDataAdapter(myQuery, con))
            {
                // SqlDataAdapter dap = new SqlDataAdapter(myQuery, con);
                DataTable dt = new DataTable();
                dap.Fill(dt);
                return dt;
            }
        }

    }
}
