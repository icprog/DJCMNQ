using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace connectsqlserver
{
    class SQLClass
    {
        //        public static string connsql = @"server=127.0.0.1;Database=DataBase_DJ;uid=sa;pwd=Dzs804";
         public static string connsql = @"server=127.0.0.1;Database=test_schema;uid=root;pwd=Shanghai804";
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

        //public static DataTable ExcuteQueryUsingDataAdapter(string myQuery)
        //{
        //    using (SqlConnection con = new SqlConnection(connsql))
        //    using (var dap = new SqlDataAdapter(myQuery, con))
        //    {
        //        // SqlDataAdapter dap = new SqlDataAdapter(myQuery, con);
        //        DataTable dt = new DataTable();
        //        dap.Fill(dt);
        //        return dt;
        //    }
        //}

        public static DataTable ExcuteQueryUsingDataAdapter(string myQuery)
        {
            using (MySqlConnection con = new MySqlConnection(connsql))
            using (MySqlDataAdapter dap = new MySqlDataAdapter(myQuery, con))
            {
                DataTable dt = new DataTable();
                dap.Fill(dt);
                return dt;
            }
        }




    }
}
