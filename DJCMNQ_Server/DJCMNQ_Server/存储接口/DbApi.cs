using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DJCMNQ_Server
{
    class DbApi
    {

        public static string connsql = @"server=192.168.1.250;Database=TestDB1;uid=sa;pwd=Shanghai804";

        public static void SqlExcuteCMD(String CmdStr)
        {
            using (var con = new SqlConnection(connsql))
            using (var cmd = new SqlCommand(CmdStr, con))
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }


        public static DataTable ExcuteQueryUsingDataReader(string myQuery)
        {
            DataTable dt = new DataTable();
            using (var con = new SqlConnection(connsql))
            using (var cmd = new SqlCommand(myQuery, con))
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
            using (SqlConnection con = new SqlConnection(connsql))
            using (var dap = new SqlDataAdapter(myQuery, con))
            {
                // SqlDataAdapter dap = new SqlDataAdapter(myQuery, con);
                DataTable dt = new DataTable();
                dap.Fill(dt);
                return dt;
            }
        }

    }
}
