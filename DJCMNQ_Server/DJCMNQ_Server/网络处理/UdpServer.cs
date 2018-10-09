using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DJCMNQ_Server
{
    class UdpServer
    {
      //  public static Socket UdpServerSock;
     //   public static Socket UdpServerSock_2;

        public static bool ServerOn = false;

        public static void UdpServerStart(NetAll.UDP_STRUCT UdpSock)
        {
            Trace.WriteLine("Enter ServerStart_Target1");

            UdpSock.Sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPAddress ServerIP = IPAddress.Parse(UdpSock.ClientIP);
            int ServerPort = int.Parse(UdpSock.ClientPort);
            try
            {
                UdpSock.Sock.Bind(new IPEndPoint(ServerIP, ServerPort));
                ServerOn = true;
                new Thread(() => { ReciveMsg(ref UdpSock); }).Start();//开启接收消息线程


            }
            catch (Exception ex)
            {
                MajorLog.Error(ex.ToString());
            }
        }

        /// <summary>
        /// 接收发送给本机ip对应端口号的数据报
        /// </summary>
        static void ReciveMsg(ref NetAll.UDP_STRUCT UdpSock)
        {
            while (ServerOn)
            {
                EndPoint point = new IPEndPoint(IPAddress.Any, 0);//用来保存发送方的ip和端口号
                byte[] buffer = new byte[1024];
                try
                {
                    int length = UdpSock.Sock.ReceiveFrom(buffer, ref point);//接收数据报

                    //接收字符串显示
                    string message = Encoding.UTF8.GetString(buffer, 0, length);
                    Trace.WriteLine(point.ToString() + "Recv:" + message);
                    //接收Byte显示
                    string temp = null;
                    for (int i = 0; i < length; i++) temp += buffer[i].ToString("x2");
                    Trace.WriteLine(point.ToString() + "Recv:" + temp);
                }
                catch (Exception ex)
                {
                    Trace.WriteLine(point.ToString());
                    Trace.WriteLine(ex.ToString());
                }
            }
        }



        /// <summary>
        /// 调用此函数才会关闭UdpServerSock
        /// </summary>
        public static void UdpServerStop()
        {
            ServerOn = false;

        }


        /// <summary>
        /// 向特定ip的主机的端口发送数据报
        /// </summary>
        //public static void sendMsg(string RemoteIp, string RemotePort, byte[] SendBuf)
        //{
        //    try
        //    {
        //        EndPoint point = new IPEndPoint(IPAddress.Parse(RemoteIp), int.Parse(RemotePort));
        //        UdpServerSock.SendTo(SendBuf, point);
        //    }
        //    catch(Exception ex)
        //    {
        //        Trace.WriteLine(ex.ToString());
        //    }

        //}
      
    }
}
