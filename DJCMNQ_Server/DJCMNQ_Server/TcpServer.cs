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
    class TcpServer
    {
        public MainForm myForm;

        private static byte[] RecvBuf = new byte[1024];
        private static int ServerPort = 8888;
        static Socket ServerSocket;
        public bool ServerOn = false;//监听总控
        public bool ServerOn_GT = false;//监听高通

        private static int ServerPort2 = 7777;
        static Socket ServerSocket2;


        //改成统一的模板，目标实现Server监听这块可以直接拷贝使用
        //
        //
        public bool ServerOn_Target1 = false;//监听Target1的服务器标志
        public static int ServerPort_Target1 = 8888;//与Target1通信的服务器Socket的端口号
        public static Socket ServerSockcet_Target1;

        public void ServerStart_Target1(string TargetIp, string LocalServerPort, string LocalServerIP)
        {
            ServerSockcet_Target1 = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress ServerIP = IPAddress.Parse(LocalServerIP);
            int ServerPort = int.Parse(LocalServerPort);
            try
            {
                ServerSockcet_Target1.Bind(new IPEndPoint(ServerIP, ServerPort));
                ServerSockcet_Target1.Listen(10);
                ServerSockcet_Target1.BeginAccept(new AsyncCallback(onCall), ServerSockcet_Target1);
            }
            catch (Exception ex)
            {
                MajorLog.Error(ex.ToString());
            }
        }


        public void ServerStart2()
        {
            TcpClient.ClientGT.ClientIP = ConfigurationManager.AppSettings["GTIP"];

            ServerOn_GT = true;
            TcpClient.ClientGT.IsConnected = false;

            ServerPort2 = int.Parse(ConfigurationManager.AppSettings["LocalPort2_GT"]);
            ServerSocket2 = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress address2 = IPAddress.Parse(ConfigurationManager.AppSettings["LocalIP2"]);
            try
            {
                ServerSocket2.Bind(new IPEndPoint(address2, ServerPort2));
                ServerSocket2.Listen(10);
                ServerSocket2.BeginAccept(new AsyncCallback(onCall_GT), ServerSocket2);
            }
            catch (Exception ex)
            {
                MyLog.Error("监听高通地测失败，检查IP设置和网络连接");
                Trace.WriteLine(ex.Message);
                ServerOn_GT = false;
            }
        }




        public void ServerStop2()
        {
            ServerOn_GT = false;
            TcpClient.ClientGT.IsConnected = false;
            //Data.ServerConnectEvent2.Set();
            try
            {
                ServerSocket2.Close();
            }
            catch (Exception ex)
            {
                MyLog.Error("无法关闭，错误原因:" + ex.Message);
            }
        }

        public void ServerStart()
        {
            Trace.WriteLine("------------------------进入ServerStart");
            TcpClient.ClientZK1.ClientIP = ConfigurationManager.AppSettings["ZK1IP"];
            TcpClient.ClientZK2.ClientIP = ConfigurationManager.AppSettings["ZK2IP"];

            ServerOn = true;
            TcpClient.ClientZK1.IsConnected = false;
            TcpClient.ClientZK2.IsConnected = false;

            ServerPort = int.Parse(ConfigurationManager.AppSettings["LocalPort1_ZK"]);
            ServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            IPAddress address = IPAddress.Parse(ConfigurationManager.AppSettings["LocalIP1"]);
            try
            {
                ServerSocket.Bind(new IPEndPoint(address, ServerPort));
                //  ServerSocket.Bind(new IPEndPoint(IPAddress.Any, ServerPort));
                ServerSocket.Listen(10);
                ServerSocket.BeginAccept(new AsyncCallback(onCall), ServerSocket);//继续接受其他客户端的连接  
            }
            catch (Exception ex)
            {
                MyLog.Error("监听总控设备失败，检查IP设置和网络连接");
                Trace.WriteLine(ex.Message);
                ServerOn = false;
            }
            Trace.WriteLine("------------------------退出ServerStart");
        }

        public void ServerStop()
        {
            Trace.WriteLine("------------------------进入ServerStop");
            ServerOn = false;
            TcpClient.ClientZK1.IsConnected = false;
            TcpClient.ClientZK2.IsConnected = false;
            // Data.ServerConnectEvent.Set();
            try
            {
                ServerSocket.Close();
            }
            catch (Exception ex)
            {
                MyLog.Error("无法关闭，错误原因:" + ex.Message);
            }
            Trace.WriteLine("------------------------退出ServerStop");
        }


        private void onCall(IAsyncResult ar)
        {
            Trace.WriteLine("onCall");
            Socket serverSoc = (Socket)ar.AsyncState;
            if (ServerOn)
            {
                try
                {
                    Socket ClientSocket = serverSoc.EndAccept(ar);
                    if (serverSoc != null)
                    {
                        serverSoc.BeginAccept(new AsyncCallback(onCall), serverSoc);
                        IPEndPoint tmppoint = (IPEndPoint)ClientSocket.RemoteEndPoint;
                        String RemoteIpStr = tmppoint.Address.ToString();
                        Console.WriteLine(RemoteIpStr);
                        if (RemoteIpStr == TcpClient.ClientZK1.ClientIP)
                        {
                            TcpClient.ClientZK1.IsConnected = true;
                            new Thread(() => { RecvFromClientZK1(ClientSocket); }).Start();
                            new Thread(() => { SendToClientZK1(ClientSocket); }).Start();

                        }
                        if (RemoteIpStr == TcpClient.ClientZK2.ClientIP)
                        {
                            TcpClient.ClientZK2.IsConnected = true;
                            new Thread(() => { RecvFromClientZK2(ClientSocket); }).Start();
                            new Thread(() => { SendToClientZK2(ClientSocket); }).Start();
                        }
                    }
                }
                catch (SocketException ex)
                {
                    //  
                }
            }
            else
            {
                Console.WriteLine("Server already off!!!");
            }
        }

        private void onCall_GT(IAsyncResult ar)
        {
            Trace.WriteLine("onCall_GT");
            Socket serverSoc = (Socket)ar.AsyncState;
            if (ServerOn_GT)
            {
                try
                {
                    Socket ClientSocket = serverSoc.EndAccept(ar);
                    if (serverSoc != null)
                    {
                        serverSoc.BeginAccept(new AsyncCallback(onCall_GT), serverSoc);
                        IPEndPoint tmppoint = (IPEndPoint)ClientSocket.RemoteEndPoint;
                        String RemoteIpStr = tmppoint.Address.ToString();
                        Console.WriteLine(RemoteIpStr);
                        if (RemoteIpStr == TcpClient.ClientGT.ClientIP)
                        {
                            TcpClient.ClientGT.IsConnected = true;

                            new Thread(() => { RecvFromClientGT(ClientSocket); }).Start();
                            new Thread(() => { SendToClientGT(ClientSocket); }).Start();

                        }
                    }
                }
                catch (SocketException ex)
                {
                    Trace.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Server already off!!!");
            }
        }

        private void SendToClientGT(object ClientSocket)
        {
            Trace.WriteLine("启动遥测前段设备给高通转发线程");
            Socket myClientSocket = (Socket)ClientSocket;
            //while (ServerOn_GT && myClientSocket.Connected)
            //{
            //    if (Data.DataQueue_GT.Count > 0)
            //    {
            //        byte[] temp = Data.DataQueue_GT.Dequeue();
            //        myClientSocket.Send(temp);

            //    }
            //}
        }

        private void SendToClientZK1(object ClientSocket)
        {
            Trace.WriteLine("启动遥测前段设备--》总控1发送线程");
            Socket myClientSocket = (Socket)ClientSocket;
            //while (ServerOn && myClientSocket.Connected && Data.MS1orMS2 == 1)
            //{
            //    if (Data.DataQueue_ZK_ACK.Count > 0)
            //    {
            //        myClientSocket.Send(Data.DataQueue_ZK_ACK.Dequeue());
            //    }
            //}
        }

        private void SendToClientZK2(object ClientSocket)
        {
            Trace.WriteLine("启动遥测前段设备--》总控1发送线程");
            Socket myClientSocket = (Socket)ClientSocket;
            //while (ServerOn && myClientSocket.Connected && Data.MS1orMS2 == 2)
            //{
            //    if (Data.DataQueue_ZK_ACK.Count > 0)
            //    {
            //        myClientSocket.Send(Data.DataQueue_ZK_ACK.Dequeue());
            //    }
            //}
        }


        private void RecvFromClientGT(object ClientSocket)
        {
            Trace.WriteLine("RecvFromClientGT!!");
            Socket myClientSocket = (Socket)ClientSocket;
            while (ServerOn_GT && myClientSocket.Connected)
            {
                try
                {
                    byte[] RecvBufZK1 = new byte[2048];
                    int RecvNum = myClientSocket.Receive(RecvBufZK1);
                    if (RecvNum > 0)
                    {
                        //处理收到的数据
                        String tempstr = "";
                        byte[] RecvBufToFile = new byte[RecvNum];
                        for (int i = 0; i < RecvNum; i++)
                        {
                            RecvBufToFile[i] = RecvBufZK1[i];
                            tempstr += RecvBufZK1[i].ToString("x2");
                        }
                        Trace.WriteLine(tempstr);

                    }
                    else
                    {
                        Trace.WriteLine("收到数据少于等于0！");
                        break;
                    }
                }
                catch (Exception ex)
                {
                    myClientSocket.Shutdown(SocketShutdown.Both);
                    myClientSocket.Close();

                    TcpClient.ClientGT.IsConnected = false;
                    Trace.WriteLine("Exception leave from RecvFromGT!!" + ex.Message);
                    break;
                }
            }

            if (myClientSocket.Connected)
            {
                Trace.WriteLine("服务器主动关闭socket!");
                myClientSocket.Shutdown(SocketShutdown.Both);
                myClientSocket.Close();
            }

            TcpClient.ClientGT.IsConnected = false;
            Trace.WriteLine("leave Server GT!!");

        }

        private void RecvFromClientZK1(object ClientSocket)
        {
            Trace.WriteLine("RecvFromClientZK1!!");
            Socket myClientSocket = (Socket)ClientSocket;
            while (ServerOn && myClientSocket.Connected)
            {
                try
                {
                    byte[] RecvBufZK1 = new byte[4096];
                    int RecvNum = myClientSocket.Receive(RecvBufZK1);
                    if (RecvNum > 0)
                    {
                        //处理收到的数据
                        String tempstr = "";
                        byte[] RecvBufToFile = new byte[RecvNum];
                        for (int i = 0; i < RecvNum; i++)
                        {
                            RecvBufToFile[i] = RecvBufZK1[i];
                            tempstr += RecvBufZK1[i].ToString("x2");
                        }
                        Trace.WriteLine(tempstr);

                    }
                    else
                    {
                        Trace.WriteLine("收到数据少于等于0！");
                        break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    myClientSocket.Shutdown(SocketShutdown.Both);
                    myClientSocket.Close();
                    //      fileZK1.Close();
                    TcpClient.ClientZK1.IsConnected = false;
                    Trace.WriteLine("Exception leave!!");
                    break;
                }
            }

            if (myClientSocket.Connected)
            {
                Trace.WriteLine("服务器主动关闭socket!");
                myClientSocket.Shutdown(SocketShutdown.Both);
                myClientSocket.Close();
            }

            //   fileZK1.Close();
            TcpClient.ClientZK1.IsConnected = false;
            Trace.WriteLine("leave!!");
        }

        private void RecvFromClientZK2(object ClientSocket)
        {
            Console.WriteLine("RecvFromClientZK2!!");
            byte[] RecvBufZK2 = new byte[4096];
            Socket myClientSocket = (Socket)ClientSocket;
            while (true)
            {
                try
                {
                    int RecvNum = myClientSocket.Receive(RecvBufZK2);
                    if (RecvNum > 0)
                    {
                        //处理收到的数据
                    }
                    else
                    {
                        break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    myClientSocket.Shutdown(SocketShutdown.Both);
                    myClientSocket.Close();
                    TcpClient.ClientZK2.IsConnected = false;
                    Trace.WriteLine("Exception leave 2 !!");
                    break;
                }
            }

            if (myClientSocket.Connected)
            {
                Trace.WriteLine("服务器主动关闭socket!");
                myClientSocket.Shutdown(SocketShutdown.Both);
                myClientSocket.Close();
            }

            TcpClient.ClientZK2.IsConnected = false;
            Trace.WriteLine("leave!!");
        }


    }
}
