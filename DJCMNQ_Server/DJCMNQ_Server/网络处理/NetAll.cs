using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace DJCMNQ_Server
{
    class NetAll
    {
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

            public void Init()
            {
                this.DataQueue_Recv = new Queue<byte[]>();
                this.DataQueue_Send = new Queue<byte[]>();
            }
        }

        public static TCP_STRUCT ClientZK1 = new TCP_STRUCT();   //本机为服务器，远端为Client 
        public static TCP_STRUCT ClientZK2 = new TCP_STRUCT();   //本机为服务器，远端为Client 

        public static TCP_STRUCT Server_CRTa = new TCP_STRUCT();        //本机为Client，远端为Server


        public static void Init()
        {
            ClientZK1.Init();
            ClientZK2.Init();
        }




    }
}
