using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace DJCMNQ_Server
{
    public partial class MainForm : Form
    {
        TestDB myTestDb = new TestDB();
        public MainForm()
        {
            InitializeComponent();

            //启动日志
            MyLog.richTextBox1 = richTextBox1;
            MyLog.path = Program.GetStartupPath() + @"日志\";
            MyLog.lines = 50;
            MyLog.start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(myTestDb==null)
            {
                myTestDb = new TestDB();
            }
            else
            {
                myTestDb.Activate();
            }
            myTestDb.ShowDialog();
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            MajorLog.Debug("这是一个Debug日志");
          //GetSysInfo.GetNetInfo();
         //   TestUnit.TestDemo1();
        }

        /// <summary>
        /// 一键连接所有外部设备，开启所有Server监听，所有Client开启连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ConnectAll_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            UdpServer.UdpServerStop();
            Thread.Sleep(500);

        }
    }
}
