using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleUDP;

namespace ChatProtocol
{
    public class ChatServerCommandType
    {
        public const string add_user = "add_user";
        public const string remove_user = "remove_user";
        public const string say = "say";
    }

    public class ChatClientCommandType
    {
        public const string get = "get";
    }

    public class ChatCommandHelper
    {
        public static string MakePackAddUser(string userId)
        {
            userId = UDPHandle.ReplaceKeyWorld(userId);
            return ChatServerCommandType.add_user + UDPHandle.IS + userId;
        }

        public static string MakePackRemoveUser(string userId)
        {
            userId = UDPHandle.ReplaceKeyWorld(userId);
            return ChatServerCommandType.remove_user + UDPHandle.IS + userId;
        }

        public static string MakePackSay(string word)
        {
            word = UDPHandle.ReplaceKeyWorld(word);

            return ChatServerCommandType.say + UDPHandle.IS + word;
        }

        public static string MakePackGet(string word)
        {
            word = UDPHandle.ReplaceKeyWorld(word);

            return ChatClientCommandType.get + UDPHandle.IS + word;
        }
    }


}
