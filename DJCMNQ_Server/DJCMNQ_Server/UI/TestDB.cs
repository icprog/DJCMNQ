using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DJCMNQ_Server
{
    public partial class TestDB : Form
    {
        public TestDB()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string myQuery = "select * from Table_ZK";
                dataGridView1.DataSource = DbApi.ExcuteQueryUsingDataAdapter(myQuery);

            }
            catch (Exception ex)
            {
                MessageBox.Show("错误信息：" + ex.Message, "出现错误");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String CmdStr = "delete from Table_ZK where IP = '192.168.1.1'";
            DbApi.SqlExcuteCMD(CmdStr);

            string myQuery = "select * from Table_ZK";
            dataGridView1.DataSource = DbApi.ExcuteQueryUsingDataAdapter(myQuery);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String CmdStr = "insert into Table_ZK(IP,来源,目的,时间,内容) values ('192.168.1.1','对接总线','地面设备','2017-07-01','5a5a5a5a5a5a5a5a')";
            DbApi.SqlExcuteCMD(CmdStr);

            string myQuery = "select * from Table_ZK";
            dataGridView1.DataSource = DbApi.ExcuteQueryUsingDataAdapter(myQuery);
        }

        private void TestDB_Load(object sender, EventArgs e)
        {

        }
    }
}
