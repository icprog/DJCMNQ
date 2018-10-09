using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace DJCMNQ_Server
{
    class NetAll
    {
        #region 本机为服务器

        public struct TCP_STRUCT
        {
            public string ClientIP;
            public string ClientPort;
            public int timeoutMSec;
            public bool IsConnected;
            public IPEndPoint rep;
            public Socket sck;
            public string ServerIP;
            public string ServerPORT;
            public Queue<byte[]> DataQueue_Recv;
            public Queue<byte[]> DataQueue_Send;

            public TCP_STRUCT(string ip1)
            {
                ClientIP = ip1;
                ClientPort = null;
                timeoutMSec = 0;
                IsConnected = false;
                rep = null;
                sck = null;
                ServerIP = null;
                ServerPORT = null;
                this.DataQueue_Recv = new Queue<byte[]>();
                this.DataQueue_Send = new Queue<byte[]>();
            }
        }

        public static TCP_STRUCT ClientZK1 = new TCP_STRUCT(ConfigurationManager.AppSettings["ZK1IP"]);   //本机为服务器，远端为Client 
        public static TCP_STRUCT ClientZK2 = new TCP_STRUCT(ConfigurationManager.AppSettings["ZK2IP"]);   //本机为服务器，远端为Client 


        #endregion



        #region 本机为客户端连接远端服务器


        public struct RemoteServer_STRUCT
        {
            public string ClientIP;
            public string ClientPort;
            public int timeoutMSec;
            public bool IsConnected;
            public IPEndPoint RemoteSock;
            public Socket LocalSock;
            public string ServerIP;
            public string ServerPORT;
            public Queue<byte[]> DataQueue_Recv;
            public Queue<byte[]> DataQueue_Send;

            public RemoteServer_STRUCT(string localClientIP, string remoteServerIP, string remoteServerPort)
            {
                ClientIP = localClientIP;
                ClientPort = null;
                timeoutMSec = 1000;
                IsConnected = false;
                RemoteSock = null;
                LocalSock = null;
                ServerIP = remoteServerIP;
                ServerPORT = remoteServerPort;
                this.DataQueue_Recv = new Queue<byte[]>();
                this.DataQueue_Send = new Queue<byte[]>();
            }

        }


        public static RemoteServer_STRUCT Server_CRTa = new RemoteServer_STRUCT(
            ConfigurationManager.AppSettings["LocalIP1"],
            ConfigurationManager.AppSettings["RemoteServer1_IP"],
            ConfigurationManager.AppSettings["RemoteServer1_Port"]);        //本机为Client，远端为Server

        #endregion



        #region 本机为服务器,UDP方式

        public struct UDP_STRUCT
        {
            public Socket Sock;
            public string ClientIP;
            public string ClientPort;
            public Queue<byte[]> DataQueue_Recv;
            public Queue<byte[]> DataQueue_Send;

            public UDP_STRUCT(string ip1,string port1)
            {
                ClientIP = ip1;
                ClientPort = port1;

                Sock = null;

                this.DataQueue_Recv = new Queue<byte[]>();
                this.DataQueue_Send = new Queue<byte[]>();
            }
        }

        public static UDP_STRUCT UdpSock = new UDP_STRUCT(
            ConfigurationManager.AppSettings["UdpSock_IP1"], 
            ConfigurationManager.AppSettings["UdpSock_Port1"]);   //本机为服务器，远端为Client 

        public static UDP_STRUCT UdpSock2 = new UDP_STRUCT(
    ConfigurationManager.AppSettings["UdpSock_IP2"],
    ConfigurationManager.AppSettings["UdpSock_Port2"]);   //本机为服务器，远端为Client 

        #endregion

    }
}
