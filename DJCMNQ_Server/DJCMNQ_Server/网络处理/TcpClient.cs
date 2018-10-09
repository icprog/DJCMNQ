using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DJCMNQ_Server
{
    class TcpClient
    {
        /// <summary>
        /// 创建本地Socket连接到远端服务器Socket
        /// </summary>
        /// <param name="CTRS">Connect to Remote Server</param>
        public static void Connect(ref NetAll.RemoteServer_STRUCT CTRS)
        {
           // CTRS.timeoutMSec = 1000;//设置连接超时，初始化时设置了，此处也可单独重新设置

            CTRS.LocalSock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                CTRS.LocalSock.Bind(new IPEndPoint(IPAddress.Parse(CTRS.ClientIP), 0));
            }
            catch (Exception ex)
            {
                MajorLog.Error(ex.ToString());
                return;
            }

            CTRS.RemoteSock = new IPEndPoint(IPAddress.Parse(CTRS.ServerIP), int.Parse(CTRS.ServerPORT));

            var result = CTRS.LocalSock.BeginConnect(CTRS.RemoteSock, null, null);
            bool success = result.AsyncWaitHandle.WaitOne(CTRS.timeoutMSec, true);

            if (success)
            {
                try
                {
                    CTRS.LocalSock.EndConnect(result);//建立连接  
                    CTRS.IsConnected = true;
                    Trace.WriteLine("成功建立连接！");

                    if (CTRS.RemoteSock.Address.ToString() == NetAll.Server_CRTa.ServerIP)
                    {
                        new Thread(() => { SendToServer(ref NetAll.Server_CRTa); }).Start();
                        new Thread(() => { RecvFromServer(ref NetAll.Server_CRTa); }).Start();
                    }
                }
                catch
                {
                    CTRS.IsConnected = false;
                    Trace.WriteLine("建立连接失败！");
                }
            }
            else
            {
                CTRS.LocalSock.Close();
                CTRS.IsConnected = false;
                Trace.WriteLine("连接超时！");
            }

        }

        public static void Disconnect(ref NetAll.TCP_STRUCT CRT)
        {
            try
            {
                CRT.sck.Disconnect(true);
                CRT.sck.Close();
                CRT.IsConnected = false;
            }
            catch
            { }

        }

        private static void SendToServer(ref NetAll.RemoteServer_STRUCT CTRS)
        {   
            while (CTRS.IsConnected)
            {
                if (CTRS.DataQueue_Send.Count() > 0)
                {
                    byte[] SendByte = CTRS.DataQueue_Send.Dequeue();
                    CTRS.LocalSock.Send(SendByte);              
                }
                else
                {
                    Thread.Sleep(100);
                }
            }
        }


        private static void RecvFromServer(ref NetAll.RemoteServer_STRUCT CTRS)
        {
            while (CTRS.IsConnected)
            {
                try
                {
                    byte[] TempRecv = new byte[1024];
                    int RecvNum = CTRS.LocalSock.Receive(TempRecv);                 

                    if (RecvNum > 0)
                    {
                        byte[] RecvBuf = new byte[RecvNum];
                        Array.Copy(TempRecv, 0, RecvBuf, 0, RecvNum);

                        CTRS.DataQueue_Recv.Enqueue(RecvBuf);//将受到数据推入队列

                        //显示收到的数据，对方发的是ASCII字符串，直接转
                        String tempstr1 = System.Text.Encoding.Default.GetString(RecvBuf);
                        Trace.WriteLine(tempstr1);
                        //显示收到的数据，对方发的是Byte数组
                        String tempstr2 = null;
                        for (int i = 0; i < RecvBuf.Count(); i++) tempstr2 += RecvBuf[i].ToString("x2");
                        Trace.WriteLine(tempstr2);
                    }
                    else
                    {
                        Trace.WriteLine("Fun_RecvFromCRT 收到数据少于等于0！");
                        break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Trace.WriteLine("Fun_RecvFromCRT Exception leave!!");
                    break;
                }
            }
        }
    }
}
