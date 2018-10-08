using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DJCMNQ_Server
{
    class TestUnit
    {


        public static void TestDemo1()
        {
            Trace.WriteLine("Enter TestDemo1");
            try
            {
                TcpServer MSV = new TcpServer();
                MSV.Init();
                MSV.ServerStart_Target1("8899", "127.0.0.1");

                MSV.ServerStart_Target1("9988", "127.0.0.1");

                Thread.Sleep(5);
                byte[] temp = new byte[8] { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08 };

                TcpClient.ClientZK1.DataQueue_Send.Enqueue(temp);


            }
            catch (Exception ex)
            {
                MajorLog.Error(ex.ToString());

            }
        }
    }
}
