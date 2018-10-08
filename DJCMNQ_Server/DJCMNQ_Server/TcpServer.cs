﻿using System;
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


        public void Init()
        {
            TcpClient.Init();
            TcpClient.ClientZK1.ClientIP = ConfigurationManager.AppSettings["ZK1IP"];
            TcpClient.ClientZK2.ClientIP = ConfigurationManager.AppSettings["ZK2IP"];

            ServerOn = true;
            TcpClient.ClientZK1.IsConnected = false;
            TcpClient.ClientZK2.IsConnected = false;

        }

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

        public void ServerStart_Target1(string LocalServerPort, string LocalServerIP)
        {
            Trace.WriteLine("Enter ServerStart_Target1");

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


        public void ServerStart()
        {
            Trace.WriteLine("------------------------进入ServerStart");
            TcpClient.Init();
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
                        Trace.WriteLine(RemoteIpStr);
                        if (RemoteIpStr == TcpClient.ClientZK1.ClientIP)
                        {
                            TcpClient.ClientZK1.IsConnected = true;
                            
                            ClientSocket.Send(Data.WelCome);
                            new Thread(() => { RecvFromClient(ClientSocket,ref TcpClient.ClientZK1); }).Start();
                            new Thread(() => { SendToClient(ClientSocket,ref TcpClient.ClientZK1); }).Start();

                        }
                        if (RemoteIpStr == TcpClient.ClientZK2.ClientIP)
                        {
                            TcpClient.ClientZK2.IsConnected = true;
                            ClientSocket.Send(Data.WelCome);
                            new Thread(() => { RecvFromClient(ClientSocket,ref TcpClient.ClientZK2); }).Start();
                            new Thread(() => { SendToClient(ClientSocket, ref TcpClient.ClientZK2); }).Start();
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
                Trace.WriteLine("Server already off!!!");
            }
        }
          

        private void SendToClient(object ClientSocket,ref TcpClient.TCP_STRUCT TempClient)
        {
            Trace.WriteLine("SendMSG Thread Start... "+TempClient.ClientIP);
            Socket myClientSocket = (Socket)ClientSocket;
            while (ServerOn && myClientSocket.Connected)
            {
                if (TempClient.DataQueue_Send.Count > 0)
                {
                    myClientSocket.Send(TempClient.DataQueue_Send.Dequeue());
                }
            }
        }


        private void RecvFromClient(object ClientSocket,ref TcpClient.TCP_STRUCT TempClient)
        {
            Trace.WriteLine("RecvFromClient!!");
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
                    Trace.WriteLine(e.Message);
                    myClientSocket.Shutdown(SocketShutdown.Both);
                    myClientSocket.Close();
                    //      fileZK1.Close();
                    // TcpClient.ClientZK1.IsConnected = false;
                    TempClient.IsConnected = false;
                    
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
            // TcpClient.ClientZK1.IsConnected = false;
            TempClient.IsConnected = false;
            Trace.WriteLine("leave!!");
        }     


    }
}
