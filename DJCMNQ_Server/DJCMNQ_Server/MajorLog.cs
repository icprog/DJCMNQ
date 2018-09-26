using log4net;
using System;
using System.Collections.Generic;
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
        }

    }
}
