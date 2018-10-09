using log4net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DJCMNQ_Server
{
    class MajorLog
    {

        private static ILog m_log = LogManager.GetLogger("ProgramLog");
        private static ILog m_log222 = LogManager.GetLogger("ProgramLog222");


        public static void Debug(string info)
        {
            m_log.Debug(info);
        }

        public static void Info(string info)
        {
            m_log.Info(info);
        }

        public static void Error(string info)
        {
            m_log.Error(info);
            Trace.WriteLine(info);
            MyLog.Error("监听总控设备失败，检查IP设置和网络连接");
        }

    }
}
