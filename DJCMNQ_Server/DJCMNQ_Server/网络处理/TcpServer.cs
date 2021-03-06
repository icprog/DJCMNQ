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
        public static bool ServerOn = false;//一键启动所有服务器监听

        //改成统一的模板，目标实现Server监听这块可以直接拷贝使用
        public bool ServerOn_Target1 = false;//监听Target1的服务器标志
        public static Socket ServerSockcet_Target1;
   

        public void Init()
        {
            ServerOn = true;

            new Thread(() => { TranPortData(ref NetAll.ClientZK1, ref NetAll.ClientZK2); }).Start();
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
                MyLog.Error(ex.ToString());                
            }
        }


        public void ServerStop_Target1()
        {
            Trace.WriteLine("Enter ServerStop_Target1");
            ServerOn_Target1 = false;
            //连接到本机Server上的远端Client关闭
            NetAll.ClientZK1.IsConnected = false;
            NetAll.ClientZK2.IsConnected = false;

            // Data.ServerConnectEvent.Set();
            try
            {
                ServerSockcet_Target1.Close();
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
                        if (RemoteIpStr == NetAll.ClientZK1.ClientIP)
                        {
                            NetAll.ClientZK1.IsConnected = true;
                            
                            ClientSocket.Send(Data.WelCome);
                            new Thread(() => { RecvFromClient(ClientSocket,ref NetAll.ClientZK1); }).Start();
                            new Thread(() => { SendToClient(ClientSocket,ref NetAll.ClientZK1); }).Start();

                        }
                        if (RemoteIpStr == NetAll.ClientZK2.ClientIP)
                        {
                            NetAll.ClientZK2.IsConnected = true;
                            ClientSocket.Send(Data.WelCome);
                            new Thread(() => { RecvFromClient(ClientSocket,ref NetAll.ClientZK2); }).Start();
                            new Thread(() => { SendToClient(ClientSocket, ref NetAll.ClientZK2); }).Start();
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
          


        private void SendToClient(object ClientSocket,ref NetAll.TCP_STRUCT TempClient)
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


        private void RecvFromClient(object ClientSocket,ref NetAll.TCP_STRUCT TempClient)
        {
            Trace.WriteLine("RecvFromClient!!");
            Socket myClientSocket = (Socket)ClientSocket;
            while (ServerOn && myClientSocket.Connected)
            {
                try
                {
                    byte[] FrontRecvBuf = new byte[4096];
                    int RecvNum = myClientSocket.Receive(FrontRecvBuf);
                    if (RecvNum > 0)
                    {
                        //处理收到的数据
                        String tempstr = "";
                        byte[] RecvdBuf = new byte[RecvNum];
                        for (int i = 0; i < RecvNum; i++)
                        {
                            RecvdBuf[i] = FrontRecvBuf[i];
                            tempstr += FrontRecvBuf[i].ToString("x2");
                        }
                        Trace.WriteLine(tempstr);
                        TempClient.DataQueue_Recv.Enqueue(RecvdBuf);
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
            TempClient.IsConnected = false;
            Trace.WriteLine("leave!!");
        }

        private void TranPortData(ref NetAll.TCP_STRUCT Client1,ref NetAll.TCP_STRUCT Client2)
        {
            while (ServerOn)
            {
                if (Client1.DataQueue_Recv.Count > 0)
                {
                    Client2.DataQueue_Send.Enqueue(Client1.DataQueue_Recv.Dequeue());
                }
                else if (Client2.DataQueue_Recv.Count > 0)
                {
                    Client1.DataQueue_Send.Enqueue(Client2.DataQueue_Recv.Dequeue());
                }
                else
                {
                    Thread.Sleep(500);
                }
            }

        }


    }
}
