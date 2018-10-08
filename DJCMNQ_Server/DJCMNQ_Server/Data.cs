using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/// <summary>
/// 全局变量
/// </summary>
namespace DJCMNQ_Server
{
    class Data
    {

        public static Queue<byte[]> DataQueue_ZK_ACK = new Queue<byte[]>();        //用于给总控发送应答帧

        public static byte[] WelCome = new byte[7] { (byte)'W', (byte)'e', (byte)'l',
                      (byte)'C', (byte)'o',(byte) 'm',(byte)'e'};//'Welcome'
    }
}
