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

        private static ILog m_log = LogManager.GetLogger("ProgramLog");
        private static ILog m_log222 = LogManager.GetLogger("ProgramLog222");

        private void MainForm_Load(object sender, EventArgs e)
        {
            m_log.Debug("这是一个Debug日志");
            m_log.Info("这是一个Info日志");
            m_log.Warn("这是一个Warn日志");
            m_log.Error("这是一个Error日志");
            m_log.Fatal("这是一个Fatal日志");

            m_log222.Debug("这是一个Debug日志");
            m_log222.Info("这是一个Info日志");
            m_log222.Warn("这是一个Warn日志");
            m_log222.Error("这是一个Error日志");
            m_log222.Fatal("这是一个Fatal日志");
        }

        /// <summary>
        /// 一键连接所有外部设备，开启所有Server监听，所有Client开启连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ConnectAll_Click(object sender, EventArgs e)
        {

        }
    }
}
