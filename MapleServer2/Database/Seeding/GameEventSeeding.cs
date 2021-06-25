using System.Collections.Generic;
using MapleServer2.Database.Types;

namespace MapleServer2.Database
{
    public static class GameEventSeeding
    {
        public static void Seed()
        {
            List<GameEvent> events = new List<GameEvent>
            {
                new GameEvent
                {
                    Type = GameEventType.StringBoard,
                    Active = true,
                    StringBoard = new List<StringBoardEvent>()
                    {
                        new StringBoardEvent
                        {
                            String = "MapleStory 2 edited by Diana, Game Version: v1.19p alpha 10, Follow me on discord: discord.gg/E96qZNA"
                        }
                    }
                },
                new GameEvent
                {
                    Type = GameEventType.BlueMarble,
                    Active = true,
                    Mapleopoly = new List<MapleopolyEvent>()
                    {
                        new MapleopolyEvent
                        {
                            TripAmount = 0,
                            ItemId = 40100050,
                            ItemRarity = 1,
                            ItemAmount = 300
                        },
                        new MapleopolyEvent
                        {
                            TripAmount = 1,
                            ItemId = 20301835,
                            ItemRarity = 1,
                            ItemAmount = 5
                        },
                        new MapleopolyEvent
                        {
                            TripAmount = 10,
                            ItemId = 31001060,
                            ItemRarity = 4,
                            ItemAmount = 3
                        },
                        new MapleopolyEvent
                        {
                            TripAmount = 20,
                            ItemId = 70100004,
                            ItemRarity = 1,
                            ItemAmount = 1
                        },
                        new MapleopolyEvent
                        {
                            TripAmount = 35,
                            ItemId = 20302684,
                            ItemRarity = 4,
                            ItemAmount = 2
                        },
                        new MapleopolyEvent
                        {
                            TripAmount = 50,
                            ItemId = 20302524,
                            ItemRarity = 1,
                            ItemAmount = 1
                        },
                    }
                },
                new GameEvent
                {
                    Type = GameEventType.UGCMapContractSale,
                    Active = false,
                    UGCMapContractSale = new UGCMapContractSaleEvent
                    {
                        DiscountAmount = 9000
                    }
                },
                new GameEvent
                {
                    Type = GameEventType.UGCMapExtensionSale,
                    Active = false,
                    UGCMapExtensionSale = new UGCMapExtensionSaleEvent
                    {
                        DiscountAmount = 9000
                    }
                },
                new GameEvent
                {
                    Type = GameEventType.EventFieldPopup,
                    Active = true,
                    FieldPopupEvent = new FieldPopupEvent
                    {
                        MapId = 63000049
                    }
                }
            };

            DatabaseManager.InsertGameEvents(events);
        }
    }
}
