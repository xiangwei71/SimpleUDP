using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleUDP;

namespace ChatProtocol
{
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

    public class CommandHelper
    {
        public static string MakePackAddUser(string userId)
        {
            userId = UDPHandle.ReplaceKeyWorld(userId);
            return ServerCommandType.add_user + UDPHandle.IS + userId;
        }

        public static string MakePackRemoveUser(string userId)
        {
            userId = UDPHandle.ReplaceKeyWorld(userId);
            return ServerCommandType.remove_user + UDPHandle.IS + userId;
        }

        public static string MakePackSay(string word)
        {
            word = UDPHandle.ReplaceKeyWorld(word);

            return ServerCommandType.say + UDPHandle.IS + word;
        }

        public static string MakePackGet(string word)
        {
            word = UDPHandle.ReplaceKeyWorld(word);

            return ClientCommandType.get + UDPHandle.IS + word;
        }
    }


}
