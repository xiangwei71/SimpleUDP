using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleUDP;

namespace NetworkBattleProtocol
{
    public class NetworkBattleServerCommandType
    {
        public const string move_player = "move_player";
    }

    public class NetworkBattleClientCommandType
    {
        public const string sync_player = "sync_player_move";
    }

    public class NetworkBattleCommandHelper
    {
        public static string MovePlayer(string userId,float x,float z)
        {
            userId = UDPHandle.ReplaceKeyWorld(userId);
            return NetworkBattleServerCommandType.move_player + UDPHandle.IS + userId+ UDPHandle.AND + x + UDPHandle.AND + z;
        }

        public static string SyncPlayerMove(string userId, float x, float z)
        {
            userId = UDPHandle.ReplaceKeyWorld(userId);
            return NetworkBattleClientCommandType.sync_player + UDPHandle.IS + userId + UDPHandle.AND + x + UDPHandle.AND + z;
        }
    }
}
