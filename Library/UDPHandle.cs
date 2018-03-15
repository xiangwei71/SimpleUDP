using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Library
{
    public class CommandHelper
    {
        const string pair_join = "?";
        const string item_join = "&";
        //format => commandtype:content
        public static string[] GetPairs(string pack)
        {
            return pack.Split(pair_join.ToArray<char>());
        }

        //format => "ip,listenPort"
        public static string[] GetItems(string content)
        {
            return content.Split(item_join.ToArray<char>());
        }

        static string ReplaceKeyWorld(string str)
        {
            return str.Replace(pair_join, "").Replace(item_join, "");
        }

        public static string MakePackAddUser(string userId)
        {
            userId = ReplaceKeyWorld(userId);
            return ServerCommandType.add_user+ pair_join + userId;
        }

        public static string MakePackRemoveUser(string userId)
        {
            userId = ReplaceKeyWorld(userId);
            return ServerCommandType.remove_user + pair_join + userId;
        }

        public static string MakePackSay(string word)
        {
            word = ReplaceKeyWorld(word);

            return ServerCommandType.say + pair_join + word;
        }

        public static string MakePackGet(string word)
        {
            word = ReplaceKeyWorld(word);

            return ClientCommandType.get + pair_join + word;
        }
    }

    public class ServerCommandType
    {
        public const string add_user = "add_user";
        public const string remove_user = "remove_user";
        public const string say = "say";
    }

    public class ClientCommandType
    {
        public const string get = "get";
    }

    public class UDPHandle
    {
        //http://www.voidcn.com/article/p-ybrxkfvk-r.html
        class UDPState
        {
            public UdpClient udpClient;
            public IPEndPoint senderEP;
        }

        int listenPort;
        UdpClient client;

        public UdpClient Get()
        {
            return client;
        }

        public UDPHandle()
        {
            this.listenPort = 0;//自動找一個沒使用的port
        }

        public UDPHandle(int listenPort)
        {
            this.listenPort = listenPort;

            if(packHandler==null)
                packHandler = (commandType, content, EP) => { };//do nothing
        }

        public void StartReciver()
        {
            client = new UdpClient(listenPort);

            IPEndPoint senderEP = new IPEndPoint(IPAddress.Any, 0);
            Console.WriteLine("Waiting...");
            client.BeginReceive(BeginReceiveCallback, new UDPState { udpClient = this.client, senderEP = senderEP } );
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
                    string[] pairs = CommandHelper.GetPairs(pack);
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
