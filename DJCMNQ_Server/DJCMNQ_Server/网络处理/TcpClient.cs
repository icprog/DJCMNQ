using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace DJCMNQ_Server
{
    class TcpClient
    {
        public static bool IsConfigured;

        public static void Connect(ref NetAll.TCP_STRUCT CRT)
        {
            CRT.timeoutMSec = 1000;
            CRT.sck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                IPAddress address = IPAddress.Parse(ConfigurationManager.AppSettings["LocalIP2"]);
                CRT.sck.Bind(new IPEndPoint(address, 0));
            }
            catch (Exception ex)
            {
                //       MessageBox.Show("无法建立连接");
                //Trace.WriteLine(ex.Message);
                return;
            }

            CRT.rep = new IPEndPoint(IPAddress.Parse(CRT.ServerIP), int.Parse(CRT.ServerPORT));

            var result = CRT.sck.BeginConnect(CRT.rep, null, null);
            bool success = result.AsyncWaitHandle.WaitOne(CRT.timeoutMSec, true);

            if (success)
            {
                try
                {
                    CRT.sck.EndConnect(result);//建立连接  
                    CRT.IsConnected = true;
                    Trace.WriteLine("成功建立连接！");


                }
                catch
                {
                    CRT.IsConnected = false;
                    Trace.WriteLine("建立连接失败！");
                }
            }
            else
            {
                CRT.sck.Close();
                CRT.IsConnected = false;
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

    }
}
