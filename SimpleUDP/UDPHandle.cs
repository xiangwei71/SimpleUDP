using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace SimpleUDP
{
    public class UDPHandle
    {
        public const string IS = "?";
        public const string AND = "&";

        //format => commandtype:content
        public static string[] GetPairs(string pack)
        {
            return pack.Split(UDPHandle.IS.ToArray<char>());
        }

        //format => "ip,listenPort"
        public static string[] GetItems(string content)
        {
            return content.Split(UDPHandle.AND.ToArray<char>());
        }

        public static string ReplaceKeyWorld(string str)
        {
            return str.Replace(UDPHandle.IS, "").Replace(UDPHandle.AND, "");
        }

        //http://www.voidcn.com/article/p-ybrxkfvk-r.html
        class UDPState
        {
            public UdpClient udpClient;
            public IPEndPoint senderEP;
        }

        int bindPort;
        UdpClient client;

        public UdpClient Get()
        {
            return client;
        }

        public UDPHandle()
        {
            this.bindPort = 0;//自動找一個沒使用的port
        }

        public UDPHandle(int bindPort)
        {
            this.bindPort = bindPort;

            if (packHandler == null)
                packHandler = (commandType, content, EP) => { };//do nothing
        }

        public void StartReciver()
        {
            client = new UdpClient(bindPort);

            IPEndPoint senderEP = new IPEndPoint(IPAddress.Any, 0);
            Console.WriteLine("Waiting...");
            client.BeginReceive(BeginReceiveCallback, new UDPState { udpClient = this.client, senderEP = senderEP });
        }

        void BeginReceiveCallback(IAsyncResult ar)
        {

            try
            {
                if (ar.AsyncState is UDPState s)
                {
                    UdpClient udpClient = s.udpClient;

                    IPEndPoint EP = s.senderEP;
                    Byte[] receiveBytes = udpClient.EndReceive(ar, ref EP);
                    string pack = Encoding.UTF8.GetString(receiveBytes);

                    //handle msg
                    string[] pairs = GetPairs(pack);
                    string commandType = pairs[0];
                    string content = pairs[1];
                    packHandler(commandType, content, EP);

                    Console.WriteLine("Waiting...");
                    udpClient.BeginReceive(BeginReceiveCallback, s);
                }
            }
            catch (Exception)
            {
            }
        }

        public void Quit()
        {
            if (client != null)
            {
                client.Close();
                client = null;
            }

            Console.WriteLine("finish");
        }

        public delegate void PackHandler(string commandType, string content, IPEndPoint EP);
        public PackHandler packHandler;
    }
}
