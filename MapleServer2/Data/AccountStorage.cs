using System.Collections.Generic;
using MapleServer2.Types;

namespace MapleServer2.Data
{
    // Class for retrieving and storing account data
    public static class AccountStorage
    {
        // Temp account and character ids
        public const long DEFAULT_ACCOUNT_ID = 1;

        public static int TickCount { get; set; }

        public static readonly Dictionary<long, List<long>> AccountCharacters = new();
        public static readonly Dictionary<long, Player> Characters = new();

        static AccountStorage()
        {
            // Add temp characters
            long defaultCharId1 = 1;
            long defaultCharId2 = 2;
            long defaultCharId3 = 3;
            long defaultCharId4 = 4;
            long defaultCharId5 = 5;
            long defaultCharId6 = 6;
            long defaultCharId7 = 7;
            long defaultCharId8 = 8;
            long defaultCharId9 = 9;
            long defaultCharId10 = 10;
            long defaultCharId11 = 11;
            long defaultCharId12 = 12;
            long defaultCharId13 = 13;
            long defaultCharId14 = 14;

            AccountCharacters.Add(DEFAULT_ACCOUNT_ID, new List<long>
            { defaultCharId1, defaultCharId2, defaultCharId3, defaultCharId4, defaultCharId5,
               defaultCharId6, defaultCharId7, defaultCharId8, defaultCharId9, defaultCharId10,
               defaultCharId11, defaultCharId12, defaultCharId13, defaultCharId14 });

            Characters.Add(defaultCharId1, Player.Char1(DEFAULT_ACCOUNT_ID, defaultCharId1));
            Characters.Add(defaultCharId2, Player.Char2(DEFAULT_ACCOUNT_ID, defaultCharId2));
            Characters.Add(defaultCharId3, Player.Char3(DEFAULT_ACCOUNT_ID, defaultCharId3));
            Characters.Add(defaultCharId4, Player.Char4(DEFAULT_ACCOUNT_ID, defaultCharId4));
            Characters.Add(defaultCharId5, Player.Char5(DEFAULT_ACCOUNT_ID, defaultCharId5));
            Characters.Add(defaultCharId6, Player.Char6(DEFAULT_ACCOUNT_ID, defaultCharId6));
            Characters.Add(defaultCharId7, Player.Char7(DEFAULT_ACCOUNT_ID, defaultCharId7));
            Characters.Add(defaultCharId8, Player.Char8(DEFAULT_ACCOUNT_ID, defaultCharId8));
            Characters.Add(defaultCharId9, Player.Char9(DEFAULT_ACCOUNT_ID, defaultCharId9));
            Characters.Add(defaultCharId10, Player.Char10(DEFAULT_ACCOUNT_ID, defaultCharId10));
            Characters.Add(defaultCharId11, Player.Char11(DEFAULT_ACCOUNT_ID, defaultCharId11));
            Characters.Add(defaultCharId12, Player.Char12(DEFAULT_ACCOUNT_ID, defaultCharId12));
            Characters.Add(defaultCharId13, Player.Char13(DEFAULT_ACCOUNT_ID, defaultCharId13));
            Characters.Add(defaultCharId14, Player.Char14(DEFAULT_ACCOUNT_ID, defaultCharId14));
        }

        // Retrieves a list of character ids for an account
        public static List<long> ListCharacters(long accountId)
        {
            return AccountCharacters.GetValueOrDefault(accountId, new List<long>());
        }

        // Adds new character
        public static void AddCharacter(Player data)
        {
            Characters.Add(data.CharacterId, data);
        }

        // Retrieves a specific character for an account
        public static Player GetCharacter(long characterId)
        {
            return Characters.GetValueOrDefault(characterId);
        }

        // Updates a character
        public static void UpdateCharacter(Player data)
        {
            Characters.Remove(data.CharacterId);
            Characters.Add(data.CharacterId, data);
        }
    }
}
