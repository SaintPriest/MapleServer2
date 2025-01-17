﻿using MaplePacketLib2.Tools;
using MapleServer2.Constants;
using MapleServer2.Packets;
using MapleServer2.Servers.Game;

namespace MapleServer2.PacketHandlers.Game
{
    public class CharacterInfoHandler : GamePacketHandler
    {
        public override RecvOp OpCode => RecvOp.CHARACTER_INFO;

        public CharacterInfoHandler() : base() { }

        public override void Handle(GameSession session, PacketReader packet)
        {
            long characterId = packet.ReadLong();

            session.Send(CharacterInfoPacket.WriteCharacterInfo(characterId, GameServer.Storage.GetPlayerById(characterId)));
        }
    }
}
