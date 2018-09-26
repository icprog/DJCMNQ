using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace DJCMNQ_Server
{

    /// <summary>
    /// 获取系统信息，包括系统时间，网卡信息，磁盘信息等
    /// </summary>
    class GetSysInfo
    {

        public static void GetNetInfo()
        {
            String netInfo = null;

            //2、获取本址IP
            IPAddress[] ips = Dns.GetHostAddresses(""); //当参数为""时返回本机所有IP
            netInfo += "通过Dns.GetHostAddresses(\"\")获取本机所有IP信息:\r\n";
            for (int i = 0; i < ips.Length; i++)
            {
                netInfo += string.Format("{0}) [ip:]{1}，  [ip类型:]{2}\r\n", i.ToString(), ips[i].ToString(), ips[i].AddressFamily);
            }


            //3、获取网卡的名字等信息
            netInfo += "\r\n以下是网卡接口数组中的信息。\r\n通过NetworkInterface.GetAllNetworkInterfaces()获取本机所有网卡接口信息:\r\n";
            int count = 0;
            foreach (NetworkInterface netInt in NetworkInterface.GetAllNetworkInterfaces())
            {
                count++;
                netInfo += string.Format("{0})接口名:{1}\r\n    接口类型:{2}\r\n    接口MAC:{3}\r\n    接口速度:{4}\r\n    接口描述信息:{5}\r\n", count, netInt.Name, netInt.NetworkInterfaceType, netInt.GetPhysicalAddress().ToString(), netInt.Speed / 1000 / 1000, netInt.Description);
                netInfo += "    接口配置的IP地址:\r\n";
                foreach (UnicastIPAddressInformation ipIntProp in netInt.GetIPProperties().UnicastAddresses.ToArray<UnicastIPAddressInformation>())
                {
                    netInfo += string.Format("    接口名:{0}，  ip:{1}，  ip类型:{2}\r\n", netInt.Name, ipIntProp.Address.ToString(), ipIntProp.Address.AddressFamily);

                }
            }

            netInfo += "\r\n";



            //4、进阶：如果本机有多个IP 如何获得 **** 重要 ****
            foreach (var item in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (item.OperationalStatus == OperationalStatus.Up && item.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
                {//先获取需要的接口。两个条件确定当前正在使用的网口。1、接口状态为up；2、接口类型为Ethernet。
                    count = 0;
                    foreach (var ipInfo in item.GetIPProperties().UnicastAddresses.ToArray())
                    {
                        if (ipInfo.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        {
                            netInfo += string.Format("本机正在使用接口为:{0}\r\n本机正在使用的IP为：{1}", item.Name, ipInfo.Address.ToString());
                            break;
                        }
                    }
                }
            }

            ////与上面一样，只不过用了Dns.GetHostAddresses()的方法
            //IPAddress[] dnsIps = Dns.GetHostAddresses(Dns.GetHostName());
            //for (int i = 0; i < dnsIps.Length; i++)
            //{
            //    if (dnsIps[i].AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
            //    {
            //        netInfo += "\r\nDns.GetHostAddresses()得到本机正在使用的IP为：" + dnsIps[i].ToString();
            //    }
            //}


            MajorLog.Info(netInfo);

        }

    }
}
