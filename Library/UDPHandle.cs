using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        public static string MakePackAddUser(string ip,string port)
        {
            ip = ReplaceKeyWorld(ip);
            port = ReplaceKeyWorld(port);

            var items = new string[] { ip, port };
            return ServerCommandType.add_user+ pair_join + string.Join(item_join,items);
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
        public const string say = "say";
    }

    public class ClientCommandType
    {
        public const string get = "get";
    }

    public class UDPHandle
    {
        int listenPort;
        UdpClient receiver;
        Thread thread;

        public UDPHandle(int listenPort)
        {
            this.listenPort = listenPort;

            if(msgHandler==null)
                msgHandler = (commandType, content) => { };//do nothing
        }

        public void StartReciver()
        {
            receiver = new UdpClient(listenPort);

            thread = new Thread(new ThreadStart(DoReceive));
            thread.Start();
        }

        public void Quit()
        {
            if (thread != null)
            {
                thread.Interrupt();
                thread.Abort();

                thread = null;
            }

            if (receiver != null)
            {
                receiver.Close();
                receiver = null;
            }

            Console.WriteLine("finish");
        }

        public delegate void MsgHandler(string commandType, string content);
        public MsgHandler msgHandler;

        void DoReceive()
        {
            while (true)
            {
                Console.WriteLine("Waiting...");
                IPEndPoint senderEP = new IPEndPoint(IPAddress.Any, 0);
                byte[] data = receiver.Receive(ref senderEP);
                string pack = Encoding.UTF8.GetString(data);

                string[] pairs = CommandHelper.GetPairs(pack);
                string commandType = pairs[0];
                string content = pairs[1];

                msgHandler(commandType,content);
            }
        }
    }
}
