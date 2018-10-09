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
                //TcpServer MSV = new TcpServer();
                //MSV.Init();
                ////   MSV.ServerStart_Target1("8832", "172.22.1.32");
                //MSV.ServerStart_Target1("8832", "127.0.0.1");
                //Thread.Sleep(5);
                //byte[] temp1 = new byte[8] { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08 };
                byte[] temp2 = new byte[8] { 0x08, 0x07, 0x06, 0x05, 0x04, 0x03, 0x02, 0x01 };

                //NetAll.ClientZK1.DataQueue_Send.Enqueue(temp1);
                //NetAll.ClientZK2.DataQueue_Send.Enqueue(temp2);


                //TcpClient.Connect(ref NetAll.Server_CRTa);

                UdpServer.UdpServerStart(NetAll.UdpSock);
                UdpServer.UdpServerStart(NetAll.UdpSock2);

                Thread.Sleep(1000);
                for (int j = 0; j < 10; j++)
                {
            //        UdpServer.sendMsg("172.22.1.33", "8832", Function.StrToHexByte("EB90FFFF8832010203040506"));

             //       UdpServer.sendMsg("172.22.1.33", "8989", Function.StrToHexByte("EB90FFFF8833010203040506"));
             //       UdpServer.sendMsg("127.0.0.1", "8834", Function.StrToHexByte("EB90FFFF8834010203040506"));
                }
            }
            catch (Exception ex)
            {
                MajorLog.Error(ex.ToString());
            }
        }
    }
}
