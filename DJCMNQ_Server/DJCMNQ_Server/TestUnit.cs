using System;
using System.Collections.Generic;
using System.Configuration;
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
                MSV.ServerStart_Target1("8832", "172.22.1.32");

                Thread.Sleep(5);
                byte[] temp1 = new byte[8] { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08 };
                byte[] temp2 = new byte[8] { 0x08, 0x07, 0x06, 0x05, 0x04, 0x03, 0x02, 0x01 };

                NetAll.ClientZK1.DataQueue_Send.Enqueue(temp1);
                NetAll.ClientZK2.DataQueue_Send.Enqueue(temp2);

                NetAll.Server_CRTa.ServerIP = ConfigurationManager.AppSettings["Server_CRTa_Ip"];
                NetAll.Server_CRTa.ServerPORT = ConfigurationManager.AppSettings["Server_CRTa_Port"];
                TcpClient.Connect(ref NetAll.Server_CRTa);
                if (NetAll.Server_CRTa.IsConnected)
                {
        
                    
                }

            }
            catch (Exception ex)
            {
                MajorLog.Error(ex.ToString());

            }
        }
    }
}
