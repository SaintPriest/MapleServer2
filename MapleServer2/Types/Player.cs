using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using Maple2Storage.Types;
using Maple2Storage.Types.Metadata;
using MapleServer2.Constants;
using MapleServer2.Data.Static;
using MapleServer2.Enums;
using MapleServer2.Packets;
using MapleServer2.Servers.Game;

namespace MapleServer2.Types
{
    public class Player
    {
        // Bypass Key is constant PER ACCOUNT, unsure how it is validated
        // Seems like as long as it's valid, it doesn't matter though
        public readonly long UnknownId = 0x01EF80C2; //0x01CC3721;
        public GameSession Session;

        // Constant Values
        public long AccountId { get; private set; }
        public long CharacterId { get; private set; }
        public long CreationTime { get; private set; }
        public string Name { get; private set; }
        // Gender - 0 = male, 1 = female
        public byte Gender { get; private set; }

        // Job Group, according to jobgroupname.xml
        public bool Awakened { get; private set; }
        public Job Job { get; private set; }
        public JobCode JobCode => (JobCode) ((int) Job * 10 + (Awakened ? 1 : 0));

        // Mutable Values
        public Levels Levels { get; private set; }
        public int MapId;
        public int TitleId;
        public List<int> Titles = new List<int> { 0 };
        public List<short> Insignias = new List<short> { 0 };
        public short InsigniaId;
        public byte Animation;
        public PlayerStats Stats;
        public IFieldObject<Mount> Mount;
        public IFieldObject<Pet> Pet;
        public IFieldObject<GuideObject> Guide;
        public long VIPExpiration = 0;
        public int SuperChat;

        // Combat, Adventure, Lifestyle
        public int[] TrophyCount = new int[3] { 0, 0, 0 };
        public Dictionary<int, Trophy> TrophyData = new Dictionary<int, Trophy>();

        public List<ChatSticker> ChatSticker = new List<ChatSticker>() { };
        public List<int> FavoriteStickers = new List<int> { };
        public List<int> Emotes = new List<int>
        {
                90200011, 90200004, 90200024, 90200041, 90200042,
                90200001, 90200002, 90200003, 90200005, 90200006,
                90200007, 90200008, 90200009, 90200010,90200012,
                90200013, 90200014, 90200015, 90200016, 90200017,
                90200018, 90200019, 90200020, 90200021, 90200022,
                90200023, 90200025, 90200026, 90200027, 90200028,
                90200029, 90200030, 90200037, 90200038, 90200039,
                90200040, 90200043, 90200044, 90200045,90200046,
                90200047, 90200048, 90200049, 90200050,90200051,
                90200052, 90200053, 90200054, 90200055,90200056,
                90200057, 90200058, 90200059, 90200060,90200061,
                90200062, 90200063, 90200064, 90200065,90200066,
                90200067, 90200068, 90200069, 90200070,90200071,
                90200072, 90200073, 90200074, 90200075,90200076,
                90200077, 90200078, 90200079, 90200080,90200081,
                90200082, 90200083, 90200084, 90200085,90200086,
                90200087, 90200088, 90200089, 90200090,90200091,
                90200092, 90200093, 90200094, 90200095,90200096,
                90200097, 90200098, 90200099, 90200100,90200101,
                90200102, 90200103, 90200104, 90200105,90200106,
                90200107, 90200108, 90200109, 90200110,90200111,
                90200112, 90200113, 90200114, 90200115, 90200116,
                90200117, 90200118, 90200119, 90200120,90200121,
                90200122, 90200123, 90200124, 90200125,90200126,
                90200127, 90200128, 90200129, 90200130,90200131,
                90200132, 90200133, 90200134, 90200135, 90200136,
                90200137, 90200138, 90200139, 90200140, 90200141,
                90200142, 90200143, 90200144, 90200145,
                90220001, 90220002, 90220003, 90220004, 90220005,
                90220006, 90220007, 90220008, 90220009, 90220010,
                90220011, 90220012, 90220013, 90220014, 90220015,
                90220016, 90220017, 90220018, 90220019, 90220020,
                90220021, 90220022, 90220023, 90220024, 90220025,
                90220026,90220027, 90220028, 90220029
        };
        public NpcTalk NpcTalk;

        public CoordF Coord;
        public CoordF Rotation;
        public CoordF SafeBlock = CoordF.From(0, 0, 0);
        public bool OnAirMount = false;

        // Appearance
        public SkinColor SkinColor;

        public string GuildName = "Asian_Square";
        public string ProfileUrl = ""; // profile/e2/5a/2755104031905685000/637207943431921205.png
        public string Motto = "";

        // Home
        public int HomeMapId = 62000000;
        public int PlotMapId;
        public int HomePlotNumber;
        public int ApartmentNumber;
        public long HomeExpiration; // if player does not have a purchased plot, home expiration needs to be set to a far away date
        public string HomeName = "";

        public int ReturnMapId = (int) Map.Tria;
        public CoordF ReturnCoord = CoordF.From(-900, -900, 3000);

        public int MaxSkillTabs;
        public long ActiveSkillTabId;
        public SkillCast SkillCast = new SkillCast();

        public List<SkillTab> SkillTabs = new List<SkillTab>();
        public StatDistribution StatPointDistribution = new StatDistribution();

        public Dictionary<ItemSlot, Item> Equips = new Dictionary<ItemSlot, Item>();
        public Dictionary<ItemSlot, Item> Cosmetics = new Dictionary<ItemSlot, Item>();
        public List<Item> Badges = new List<Item>();
        public ItemSlot[] EquipSlots { get; }
        private ItemSlot DefaultEquipSlot => EquipSlots.Length > 0 ? EquipSlots[0] : ItemSlot.NONE;
        public bool IsBeauty => DefaultEquipSlot == ItemSlot.HR
                        || DefaultEquipSlot == ItemSlot.FA
                        || DefaultEquipSlot == ItemSlot.FD
                        || DefaultEquipSlot == ItemSlot.CL
                        || DefaultEquipSlot == ItemSlot.PA
                        || DefaultEquipSlot == ItemSlot.SH
                        || DefaultEquipSlot == ItemSlot.ER;

        public GameOptions GameOptions { get; private set; }

        public Inventory Inventory = new Inventory();
        public BankInventory BankInventory = new BankInventory();
        public DismantleInventory DismantleInventory = new DismantleInventory();
        public LockInventory LockInventory = new LockInventory();
        public HairInventory HairInventory = new HairInventory();

        public Mailbox Mailbox = new Mailbox();

        public List<Buddy> BuddyList = new List<Buddy>();

        public long PartyId;

        public long ClubId;
        // TODO make this as an array

        public int[] GroupChatId = new int[3];

        public long GuildId;
        public int GuildContribution;

        public Dictionary<int, Fishing> FishAlbum = new Dictionary<int, Fishing>();
        public Item FishingRod; // Possibly temp solution?
        public Wallet Wallet { get; private set; }
        public List<QuestStatus> QuestList = new List<QuestStatus>();

        private Task HpRegenThread;
        private Task SpRegenThread;
        private Task StaRegenThread;
        private readonly Task OnlineDurationThread;
        private readonly TimeInfo Timestamps;
        public Dictionary<int, PlayerStat> GatheringCount = new Dictionary<int, PlayerStat>();

        class TimeInfo
        {
            public long CharCreation;
            public long OnlineDuration;
            public long LastOnline;

            public TimeInfo(long charCreation = -1, long onlineDuration = 0, long lastOnline = -1)
            {
                CharCreation = charCreation;
                OnlineDuration = onlineDuration;
                LastOnline = lastOnline;
            }
        }

        public Player()
        {
            GameOptions = new GameOptions();
            Wallet = new Wallet(this);
            Levels = new Levels(this, 99, 0, 0, 1000, 0, new List<MasteryExp>(15));
            Timestamps = new TimeInfo(DateTimeOffset.UtcNow.ToUnixTimeSeconds());
        }

        public Player(long accountId, long characterId, string name, byte gender, Job job)
        {
            AccountId = accountId;
            CharacterId = characterId;
            Name = name;
            Gender = gender;
            Job = job;
            GameOptions = new GameOptions();
            Wallet = new Wallet(this);
            Levels = new Levels(this, playerLevel: 1, exp: 0, restExp: 0, prestigeLevel: 1, prestigeExp: 0, new List<MasteryExp>());
            Timestamps = new TimeInfo(DateTimeOffset.UtcNow.ToUnixTimeSeconds());
        }

        public static Player Char1(long accountId, long characterId, string name = "priestDiana")
        {
            Job job = Job.Priest;
            PlayerStats stats = new PlayerStats();
            int mapId = (int) Map.Ellinia;
            MapPlayerSpawn spawn = MapEntityStorage.GetRandomPlayerSpawn(mapId);
            StatDistribution statPointDistribution = new StatDistribution(totalStats: 0);
            List<SkillTab> skillTabs = new List<SkillTab>
            {
                new SkillTab(job)
            };

            Player player = new Player
            {
                SkillTabs = skillTabs,
                StatPointDistribution = statPointDistribution,
                MapId = mapId,
                AccountId = accountId,
                CharacterId = characterId,
                Name = name,
                Gender = 1,
                HomeName = "HomeName",
                Coord = CoordF.From(spawn.Coord.X, spawn.Coord.Y, spawn.Coord.Z), // Lith Harbor (2000062)
                // Coord = CoordF.From(500, 500, 15000), // Tria
                Job = job,
                SkinColor = new SkinColor()
                {
                    Primary = Color.Argb(255, 253, 210, 194),
                    Secondary = Color.Argb(255, 253, 210, 194)
                },
                CreationTime = DateTimeOffset.Now.ToUnixTimeSeconds() + Environment.TickCount,
                Equips = new Dictionary<ItemSlot, Item> {
                    { ItemSlot.ER, Item.EarFemale() },
                    { ItemSlot.HR, Item.HairFemale() },
                    { ItemSlot.FA, Item.FaceFemale() },
                    { ItemSlot.FD, Item.FaceDecorationFemale() },
                    { ItemSlot.CL, Item.WeddingClothesFemale() },
                    { ItemSlot.SH, Item.WeddingShoesFemale() },
                    { ItemSlot.EA, Item.WeddingEarringFemale() },
                    //{ ItemSlot.CP, Item.PriestEliteHat() },
                    { ItemSlot.GL, Item.WeddingGlovesFemale() },
                },
                Stats = stats,
                InsigniaId = 0,
                Awakened = true,
            };
            player.Equips.Add(ItemSlot.RH, Item.Scepter(player));
            player.Equips.Add(ItemSlot.LH, Item.Codex(player));
            return player;
        }

        public static Player Char2(long accountId, long characterId, string name = "priestApollo")
        {
            Job job = Job.Priest;
            PlayerStats stats = new PlayerStats();
            int mapId = (int) Map.Ellinia;
            MapPlayerSpawn spawn = MapEntityStorage.GetRandomPlayerSpawn(mapId);
            List<SkillTab> skillTabs = new List<SkillTab>
            {
                new SkillTab(job)
            };

            Player player = new Player
            {
                SkillTabs = skillTabs,
                MapId = mapId,
                AccountId = accountId,
                CharacterId = characterId,
                Name = name,
                Gender = 0,
                HomeName = "HomeName",
                Coord = CoordF.From(spawn.Coord.X, spawn.Coord.Y, spawn.Coord.Z),
                Job = job,
                SkinColor = new SkinColor()
                {
                    Primary = Color.Argb(255, 253, 210, 194),
                    Secondary = Color.Argb(255, 253, 210, 194)
                },
                CreationTime = DateTimeOffset.Now.ToUnixTimeSeconds() + Environment.TickCount,
                Equips = new Dictionary<ItemSlot, Item> {
                    { ItemSlot.ER, Item.EarMale() },
                    { ItemSlot.HR, Item.HairMale() },
                    { ItemSlot.FA, Item.FaceMale() },
                    { ItemSlot.FD, Item.FaceDecorationMale() },
                    { ItemSlot.CL, Item.MagicStoneShirt() },
                    { ItemSlot.PA, Item.MaleSkirt() },
                    { ItemSlot.SH, Item.MagicStoneShoes() },
                    { ItemSlot.EA, Item.AlkimiEarring() },
                    { ItemSlot.GL, Item.AlkimiGloves() },
                    { ItemSlot.CP, Item.PriestEliteHat() },
                    //{ ItemSlot.MT, Item.FairyCapeMale()},
                    //{ ItemSlot.EY, Item.Glasses()},
                },
                Stats = stats,
                InsigniaId = 0,
                Awakened = true,
            };
            player.Equips.Add(ItemSlot.RH, Item.Scepter(player));
            player.Equips.Add(ItemSlot.LH, Item.Codex(player));
            return player;
        }

        public static Player Char3(long accountId, long characterId, string name = "knightDiana")
        {
            Job job = Job.Knight;
            PlayerStats stats = new PlayerStats();
            int mapId = (int) Map.Ellinia;
            MapPlayerSpawn spawn = MapEntityStorage.GetRandomPlayerSpawn(mapId);
            StatDistribution statPointDistribution = new StatDistribution(totalStats: 0);
            List<SkillTab> skillTabs = new List<SkillTab>
            {
                new SkillTab(job)
            };

            Player player = new Player
            {
                SkillTabs = skillTabs,
                StatPointDistribution = statPointDistribution,
                MapId = mapId,
                AccountId = accountId,
                CharacterId = characterId,
                Name = name,
                Gender = 1,
                HomeName = "HomeName",
                Coord = CoordF.From(spawn.Coord.X, spawn.Coord.Y, spawn.Coord.Z),
                //Coord = CoordF.From(2850, 2550, 1800), // Lith Harbor (2000062)
                // Coord = CoordF.From(500, 500, 15000), // Tria
                Job = job,
                SkinColor = new SkinColor()
                {
                    Primary = Color.Argb(255, 253, 210, 194),
                    Secondary = Color.Argb(255, 253, 210, 194)
                },
                CreationTime = DateTimeOffset.Now.ToUnixTimeSeconds() + Environment.TickCount,
                Equips = new Dictionary<ItemSlot, Item> {
                    { ItemSlot.ER, Item.EarFemale() },
                    { ItemSlot.HR, Item.HairFemale() },
                    { ItemSlot.FA, Item.FaceFemale() },
                    { ItemSlot.FD, Item.FaceDecorationFemale() },
                    { ItemSlot.CL, Item.WeddingClothesFemale() },
                    { ItemSlot.SH, Item.WeddingShoesFemale() },
                    { ItemSlot.EA, Item.WeddingEarringFemale() },
                    //{ ItemSlot.CP, Item.PriestEliteHat() },
                    { ItemSlot.GL, Item.WeddingGlovesFemale()},
                    //{ ItemSlot.RH, Item.GreatSwordOutfit()},
                    //{ ItemSlot.MT, Item.FlowerCapeFemale()},
                },
                Stats = stats,
                GameOptions = new GameOptions(),
                Mailbox = new Mailbox(),
                InsigniaId = 0,
                Awakened = true,
            };
            player.Equips.Add(ItemSlot.RH, Item.LongSword(player));
            player.Equips.Add(ItemSlot.LH, Item.Shield(player));
            return player;
        }

        public static Player Char4(long accountId, long characterId, string name = "gunnerDiana")
        {
            Job job = Job.HeavyGunner;
            PlayerStats stats = new PlayerStats();
            int mapId = (int) Map.Ellinia;
            MapPlayerSpawn spawn = MapEntityStorage.GetRandomPlayerSpawn(mapId);
            StatDistribution statPointDistribution = new StatDistribution(totalStats: 0);
            List<SkillTab> skillTabs = new List<SkillTab>
            {
                new SkillTab(job)
            };

            Player player = new Player
            {
                SkillTabs = skillTabs,
                StatPointDistribution = statPointDistribution,
                MapId = mapId,
                AccountId = accountId,
                CharacterId = characterId,
                Name = name,
                Gender = 1,
                HomeName = "HomeName",
                Coord = CoordF.From(spawn.Coord.X, spawn.Coord.Y, spawn.Coord.Z),
                //Coord = CoordF.From(2850, 2550, 1800), // Lith Harbor (2000062)
                // Coord = CoordF.From(500, 500, 15000), // Tria
                Job = job,
                SkinColor = new SkinColor()
                {
                    Primary = Color.Argb(255, 253, 210, 194),
                    Secondary = Color.Argb(255, 253, 210, 194)
                },
                CreationTime = DateTimeOffset.Now.ToUnixTimeSeconds() + Environment.TickCount,
                Equips = new Dictionary<ItemSlot, Item> {
                    { ItemSlot.ER, Item.EarFemale() },
                    { ItemSlot.HR, Item.HairFemale() },
                    { ItemSlot.FA, Item.FaceFemale() },
                    { ItemSlot.FD, Item.FaceDecorationFemale() },
                    { ItemSlot.CL, Item.WeddingClothesFemale() },
                    { ItemSlot.SH, Item.WeddingShoesFemale() },
                    { ItemSlot.EA, Item.WeddingEarringFemale() },
                    //{ ItemSlot.CP, Item.PriestEliteHat() },
                    { ItemSlot.GL, Item.WeddingGlovesFemale() },
                    //{ ItemSlot.MT, Item.MapleArmorCape() },
                    //{ ItemSlot.RH, Item.GreatSwordOutfit()}
                    //{ ItemSlot.MT, Item.FlowerCapeFemale()},
                },
                Stats = stats,
                GameOptions = new GameOptions(),
                Mailbox = new Mailbox(),
                InsigniaId = 0,
                Awakened = true,
            };
            player.Equips.Add(ItemSlot.RH, Item.Cannon(player));
            //player.Equips.Add(ItemSlot.LH, Item.Codex(player));
            return player;
        }

        public static Player Char5(long accountId, long characterId, string name = "archerDiana")
        {
            Job job = Job.Archer;
            PlayerStats stats = new PlayerStats();
            int mapId = (int) Map.Ellinia;
            MapPlayerSpawn spawn = MapEntityStorage.GetRandomPlayerSpawn(mapId);
            StatDistribution statPointDistribution = new StatDistribution(totalStats: 0);
            List<SkillTab> skillTabs = new List<SkillTab>
            {
                new SkillTab(job)
            };

            Player player = new Player
            {
                SkillTabs = skillTabs,
                StatPointDistribution = statPointDistribution,
                MapId = mapId,
                AccountId = accountId,
                CharacterId = characterId,
                Name = name,
                Gender = 1,
                HomeName = "HomeName",
                Coord = CoordF.From(spawn.Coord.X, spawn.Coord.Y, spawn.Coord.Z),
                //Coord = CoordF.From(2850, 2550, 1800), // Lith Harbor (2000062)
                // Coord = CoordF.From(500, 500, 15000), // Tria
                Job = job,
                SkinColor = new SkinColor()
                {
                    Primary = Color.Argb(255, 253, 210, 194),
                    Secondary = Color.Argb(255, 253, 210, 194)
                },
                CreationTime = DateTimeOffset.Now.ToUnixTimeSeconds() + Environment.TickCount,
                Equips = new Dictionary<ItemSlot, Item> {
                    { ItemSlot.ER, Item.EarFemale() },
                    { ItemSlot.HR, Item.HairFemale() },
                    { ItemSlot.FA, Item.FaceFemale() },
                    { ItemSlot.FD, Item.FaceDecorationFemale() },
                    //{ ItemSlot.PA, Item.LongSkirt() },
                    { ItemSlot.CL, Item.WeddingClothesFemale() },
                    { ItemSlot.SH, Item.WeddingShoesFemale() },
                    { ItemSlot.EA, Item.WeddingEarringFemale() },
                    //{ ItemSlot.CP, Item.PriestEliteHat() },
                    { ItemSlot.GL, Item.WeddingGlovesFemale()},
                    //{ ItemSlot.RH, Item.GreatSwordOutfit()},
                    //{ ItemSlot.MT, Item.FlowerCapeFemale()},
                },
                Stats = stats,
                GameOptions = new GameOptions(),
                Mailbox = new Mailbox(),
                InsigniaId = 0,
                Awakened = true,
            };
            player.Equips.Add(ItemSlot.RH, Item.Bow(player));
            //player.Equips.Add(ItemSlot.LH, Item.Codex(player));
            return player;
        }

        public static Player Char6(long accountId, long characterId, string name = "wizardDiana")
        {
            Job job = Job.Wizard;
            PlayerStats stats = new PlayerStats();
            int mapId = (int) Map.Ellinia;
            MapPlayerSpawn spawn = MapEntityStorage.GetRandomPlayerSpawn(mapId);
            StatDistribution statPointDistribution = new StatDistribution(totalStats: 0);
            List<SkillTab> skillTabs = new List<SkillTab>
            {
                new SkillTab(job)
            };

            Player player = new Player
            {
                SkillTabs = skillTabs,
                StatPointDistribution = statPointDistribution,
                MapId = mapId,
                AccountId = accountId,
                CharacterId = characterId,
                Name = name,
                Gender = 1,
                HomeName = "HomeName",
                Coord = CoordF.From(spawn.Coord.X, spawn.Coord.Y, spawn.Coord.Z),
                //Coord = CoordF.From(2850, 2550, 1800), // Lith Harbor (2000062)
                // Coord = CoordF.From(500, 500, 15000), // Tria
                Job = job,
                SkinColor = new SkinColor()
                {
                    Primary = Color.Argb(255, 253, 210, 194),
                    Secondary = Color.Argb(255, 253, 210, 194)
                },
                CreationTime = DateTimeOffset.Now.ToUnixTimeSeconds() + Environment.TickCount,
                Equips = new Dictionary<ItemSlot, Item> {
                    { ItemSlot.ER, Item.EarFemale() },
                    { ItemSlot.HR, Item.HairFemale() },
                    { ItemSlot.FA, Item.FaceFemale() },
                    { ItemSlot.FD, Item.FaceDecorationFemale() },
                    { ItemSlot.CL, Item.WeddingClothesFemale() },
                    { ItemSlot.SH, Item.WeddingShoesFemale() },
                    { ItemSlot.EA, Item.WeddingEarringFemale() },
                    //{ ItemSlot.CP, Item.PriestEliteHat() },
                    { ItemSlot.GL, Item.WeddingGlovesFemale()},
                    //{ ItemSlot.RH, Item.GreatSwordOutfit()},
                    //{ ItemSlot.MT, Item.FlowerCapeFemale()},
                },
                Stats = stats,
                GameOptions = new GameOptions(),
                Mailbox = new Mailbox(),
                InsigniaId = 0,
                Awakened = true,
            };
            player.Equips.Add(ItemSlot.RH, Item.Staff(player));
            //player.Equips.Add(ItemSlot.LH, Item.Codex(player));
            return player;
        }

        public static Player Char7(long accountId, long characterId, string name = "soulbinderDiana")
        {
            Job job = Job.SoulBinder;
            PlayerStats stats = new PlayerStats();
            int mapId = (int) Map.Ellinia;
            MapPlayerSpawn spawn = MapEntityStorage.GetRandomPlayerSpawn(mapId);
            StatDistribution statPointDistribution = new StatDistribution(totalStats: 0);
            List<SkillTab> skillTabs = new List<SkillTab>
            {
                new SkillTab(job)
            };

            Player player = new Player
            {
                SkillTabs = skillTabs,
                StatPointDistribution = statPointDistribution,
                MapId = mapId,
                AccountId = accountId,
                CharacterId = characterId,
                Name = name,
                Gender = 1,
                HomeName = "HomeName",
                Coord = CoordF.From(spawn.Coord.X, spawn.Coord.Y, spawn.Coord.Z),
                //Coord = CoordF.From(2850, 2550, 1800), // Lith Harbor (2000062)
                // Coord = CoordF.From(500, 500, 15000), // Tria
                Job = job,
                SkinColor = new SkinColor()
                {
                    Primary = Color.Argb(255, 253, 210, 194),
                    Secondary = Color.Argb(255, 253, 210, 194)
                },
                CreationTime = DateTimeOffset.Now.ToUnixTimeSeconds() + Environment.TickCount,
                Equips = new Dictionary<ItemSlot, Item> {
                    { ItemSlot.ER, Item.EarFemale() },
                    { ItemSlot.HR, Item.HairFemale() },
                    { ItemSlot.FA, Item.FaceFemale() },
                    { ItemSlot.FD, Item.FaceDecorationFemale() },
                    { ItemSlot.CL, Item.WeddingClothesFemale() },
                    { ItemSlot.SH, Item.WeddingShoesFemale() },
                    { ItemSlot.EA, Item.WeddingEarringFemale() },
                    //{ ItemSlot.CP, Item.PriestEliteHat() },
                    { ItemSlot.GL, Item.WeddingGlovesFemale()},
                    //{ ItemSlot.RH, Item.GreatSwordOutfit()},
                    //{ ItemSlot.MT, Item.FlowerCapeFemale()},
                },
                Stats = stats,
                GameOptions = new GameOptions(),
                Mailbox = new Mailbox(),
                InsigniaId = 0,
                Awakened = true,
            };
            player.Equips.Add(ItemSlot.RH, Item.Orb(player));
            //player.Equips.Add(ItemSlot.LH, Item.Codex(player));
            return player;
        }

        public static Player Char8(long accountId, long characterId, string name = "berserkerDiana")
        {
            Job job = Job.Berserker;
            PlayerStats stats = new PlayerStats();
            int mapId = (int) Map.Ellinia;
            MapPlayerSpawn spawn = MapEntityStorage.GetRandomPlayerSpawn(mapId);
            StatDistribution statPointDistribution = new StatDistribution(totalStats: 0);
            List<SkillTab> skillTabs = new List<SkillTab>
            {
                new SkillTab(job)
            };

            Player player = new Player
            {
                SkillTabs = skillTabs,
                StatPointDistribution = statPointDistribution,
                MapId = mapId,
                AccountId = accountId,
                CharacterId = characterId,
                Name = name,
                Gender = 1,
                HomeName = "HomeName",
                Coord = CoordF.From(spawn.Coord.X, spawn.Coord.Y, spawn.Coord.Z),
                //Coord = CoordF.From(2850, 2550, 1800), // Lith Harbor (2000062)
                // Coord = CoordF.From(500, 500, 15000), // Tria
                Job = job,
                SkinColor = new SkinColor()
                {
                    Primary = Color.Argb(255, 253, 210, 194),
                    Secondary = Color.Argb(255, 253, 210, 194)
                },
                CreationTime = DateTimeOffset.Now.ToUnixTimeSeconds() + Environment.TickCount,
                Equips = new Dictionary<ItemSlot, Item> {
                    { ItemSlot.ER, Item.EarFemale() },
                    { ItemSlot.HR, Item.HairFemale() },
                    { ItemSlot.FA, Item.FaceFemale() },
                    { ItemSlot.FD, Item.FaceDecorationFemale() },
                    { ItemSlot.CL, Item.WeddingClothesFemale() },
                    { ItemSlot.SH, Item.WeddingShoesFemale() },
                    { ItemSlot.EA, Item.WeddingEarringFemale() },
                    //{ ItemSlot.CP, Item.PriestEliteHat() },
                    { ItemSlot.GL, Item.WeddingGlovesFemale()},
                    //{ ItemSlot.RH, Item.GreatSwordOutfit()},
                    //{ ItemSlot.MT, Item.FlowerCapeFemale()},
                },
                Stats = stats,
                GameOptions = new GameOptions(),
                Mailbox = new Mailbox(),
                InsigniaId = 0,
                Awakened = true,
            };
            player.Equips.Add(ItemSlot.RH, Item.GreatSword(player));
            //player.Equips.Add(ItemSlot.LH, Item.Codex(player));
            return player;
        }

        public static Player Char9(long accountId, long characterId, string name = "runebladeDiana")
        {
            Job job = Job.Runeblade;
            PlayerStats stats = new PlayerStats();
            int mapId = (int) Map.Ellinia;
            MapPlayerSpawn spawn = MapEntityStorage.GetRandomPlayerSpawn(mapId);
            StatDistribution statPointDistribution = new StatDistribution(totalStats: 0);
            List<SkillTab> skillTabs = new List<SkillTab>
            {
                new SkillTab(job)
            };

            Player player = new Player
            {
                SkillTabs = skillTabs,
                StatPointDistribution = statPointDistribution,
                MapId = mapId,
                AccountId = accountId,
                CharacterId = characterId,
                Name = name,
                Gender = 1,
                HomeName = "HomeName",
                Coord = CoordF.From(spawn.Coord.X, spawn.Coord.Y, spawn.Coord.Z),
                //Coord = CoordF.From(2850, 2550, 1800), // Lith Harbor (2000062)
                // Coord = CoordF.From(500, 500, 15000), // Tria
                Job = job,
                SkinColor = new SkinColor()
                {
                    Primary = Color.Argb(255, 253, 210, 194),
                    Secondary = Color.Argb(255, 253, 210, 194)
                },
                CreationTime = DateTimeOffset.Now.ToUnixTimeSeconds() + Environment.TickCount,
                Equips = new Dictionary<ItemSlot, Item> {
                    { ItemSlot.ER, Item.EarFemale() },
                    { ItemSlot.HR, Item.HairFemale() },
                    { ItemSlot.FA, Item.FaceFemale() },
                    { ItemSlot.FD, Item.FaceDecorationFemale() },
                    { ItemSlot.CL, Item.WeddingClothesFemale() },
                    { ItemSlot.SH, Item.WeddingShoesFemale() },
                    { ItemSlot.EA, Item.WeddingEarringFemale() },
                    //{ ItemSlot.CP, Item.PriestEliteHat() },
                    { ItemSlot.GL, Item.WeddingGlovesFemale()},
                    //{ ItemSlot.RH, Item.GreatSwordOutfit()},
                    //{ ItemSlot.MT, Item.FlowerCapeFemale()},
                },
                Stats = stats,
                GameOptions = new GameOptions(),
                Mailbox = new Mailbox(),
                InsigniaId = 0,
                Awakened = true,
            };
            player.Equips.Add(ItemSlot.RH, Item.Blade(player));
            //player.Equips.Add(ItemSlot.LH, Item.Codex(player));
            return player;
        }

        public static Player Char10(long accountId, long characterId, string name = "assassinDiana")
        {
            Job job = Job.Assassin;
            PlayerStats stats = new PlayerStats();
            int mapId = (int) Map.Ellinia;
            MapPlayerSpawn spawn = MapEntityStorage.GetRandomPlayerSpawn(mapId);
            StatDistribution statPointDistribution = new StatDistribution(totalStats: 0);
            List<SkillTab> skillTabs = new List<SkillTab>
            {
                new SkillTab(job)
            };

            Player player = new Player
            {
                SkillTabs = skillTabs,
                StatPointDistribution = statPointDistribution,
                MapId = mapId,
                AccountId = accountId,
                CharacterId = characterId,
                Name = name,
                Gender = 1,
                HomeName = "HomeName",
                Coord = CoordF.From(spawn.Coord.X, spawn.Coord.Y, spawn.Coord.Z),
                //Coord = CoordF.From(2850, 2550, 1800), // Lith Harbor (2000062)
                // Coord = CoordF.From(500, 500, 15000), // Tria
                Job = job,
                SkinColor = new SkinColor()
                {
                    Primary = Color.Argb(255, 253, 210, 194),
                    Secondary = Color.Argb(255, 253, 210, 194)
                },
                CreationTime = DateTimeOffset.Now.ToUnixTimeSeconds() + Environment.TickCount,
                Equips = new Dictionary<ItemSlot, Item> {
                    { ItemSlot.ER, Item.EarFemale() },
                    { ItemSlot.HR, Item.HairFemale() },
                    { ItemSlot.FA, Item.FaceFemale() },
                    { ItemSlot.FD, Item.FaceDecorationFemale() },
                    { ItemSlot.CL, Item.WeddingClothesFemale() },
                    { ItemSlot.SH, Item.WeddingShoesFemale() },
                    { ItemSlot.EA, Item.WeddingEarringFemale() },
                    //{ ItemSlot.CP, Item.PriestEliteHat() },
                    { ItemSlot.GL, Item.WeddingGlovesFemale()},
                    //{ ItemSlot.RH, Item.GreatSwordOutfit()},
                    //{ ItemSlot.MT, Item.FlowerCapeFemale()},
                },
                Stats = stats,
                GameOptions = new GameOptions(),
                Mailbox = new Mailbox(),
                InsigniaId = 0,
                Awakened = true,
            };
            player.Equips.Add(ItemSlot.RH, Item.ThrowStar(player));
            player.Equips.Add(ItemSlot.LH, Item.ThrowStar(player));
            return player;
        }

        public static Player Char11(long accountId, long characterId, string name = "thiefDiana")
        {
            Job job = Job.Thief;
            PlayerStats stats = new PlayerStats();
            int mapId = (int) Map.Ellinia;
            MapPlayerSpawn spawn = MapEntityStorage.GetRandomPlayerSpawn(mapId);
            StatDistribution statPointDistribution = new StatDistribution(totalStats: 0);
            List<SkillTab> skillTabs = new List<SkillTab>
            {
                new SkillTab(job)
            };

            Player player = new Player
            {
                SkillTabs = skillTabs,
                StatPointDistribution = statPointDistribution,
                MapId = mapId,
                AccountId = accountId,
                CharacterId = characterId,
                Name = name,
                Gender = 1,
                HomeName = "HomeName",
                Coord = CoordF.From(spawn.Coord.X, spawn.Coord.Y, spawn.Coord.Z),
                //Coord = CoordF.From(2850, 2550, 1800), // Lith Harbor (2000062)
                // Coord = CoordF.From(500, 500, 15000), // Tria
                Job = job,
                SkinColor = new SkinColor()
                {
                    Primary = Color.Argb(255, 253, 210, 194),
                    Secondary = Color.Argb(255, 253, 210, 194)
                },
                CreationTime = DateTimeOffset.Now.ToUnixTimeSeconds() + Environment.TickCount,
                Equips = new Dictionary<ItemSlot, Item> {
                    { ItemSlot.ER, Item.EarFemale() },
                    { ItemSlot.HR, Item.HairFemale() },
                    { ItemSlot.FA, Item.FaceFemale() },
                    { ItemSlot.FD, Item.FaceDecorationFemale() },
                    { ItemSlot.CL, Item.WeddingClothesFemale() },
                    { ItemSlot.SH, Item.WeddingShoesFemale() },
                    { ItemSlot.EA, Item.WeddingEarringFemale() },
                    //{ ItemSlot.CP, Item.PriestEliteHat() },
                    { ItemSlot.GL, Item.WeddingGlovesFemale()},
                    //{ ItemSlot.RH, Item.GreatSwordOutfit()},
                    //{ ItemSlot.MT, Item.FlowerCapeFemale()},
                },
                Stats = stats,
                GameOptions = new GameOptions(),
                Mailbox = new Mailbox(),
                InsigniaId = 0,
                Awakened = true,
            };
            player.Equips.Add(ItemSlot.RH, Item.Dagger(player));
            player.Equips.Add(ItemSlot.LH, Item.Dagger(player));
            return player;
        }

        public static Player Char12(long accountId, long characterId, string name = "strikerDiana")
        {
            Job job = Job.Striker;
            PlayerStats stats = new PlayerStats();
            int mapId = (int) Map.Ellinia;
            MapPlayerSpawn spawn = MapEntityStorage.GetRandomPlayerSpawn(mapId);
            StatDistribution statPointDistribution = new StatDistribution(totalStats: 0);
            List<SkillTab> skillTabs = new List<SkillTab>
            {
                new SkillTab(job)
            };

            Player player = new Player
            {
                SkillTabs = skillTabs,
                StatPointDistribution = statPointDistribution,
                MapId = mapId,
                AccountId = accountId,
                CharacterId = characterId,
                Name = name,
                Gender = 1,
                HomeName = "HomeName",
                Coord = CoordF.From(spawn.Coord.X, spawn.Coord.Y, spawn.Coord.Z),
                //Coord = CoordF.From(2850, 2550, 1800), // Lith Harbor (2000062)
                // Coord = CoordF.From(500, 500, 15000), // Tria
                Job = job,
                SkinColor = new SkinColor()
                {
                    Primary = Color.Argb(255, 253, 210, 194),
                    Secondary = Color.Argb(255, 253, 210, 194)
                },
                CreationTime = DateTimeOffset.Now.ToUnixTimeSeconds() + Environment.TickCount,
                Equips = new Dictionary<ItemSlot, Item> {
                    { ItemSlot.ER, Item.EarFemale() },
                    { ItemSlot.HR, Item.HairFemale() },
                    { ItemSlot.FA, Item.FaceFemale() },
                    { ItemSlot.FD, Item.FaceDecorationFemale() },
                    { ItemSlot.CL, Item.WeddingClothesFemale() },
                    { ItemSlot.SH, Item.WeddingShoesFemale() },
                    { ItemSlot.EA, Item.WeddingEarringFemale() },
                    //{ ItemSlot.CP, Item.PriestEliteHat() },
                    { ItemSlot.GL, Item.WeddingGlovesFemale()},
                    //{ ItemSlot.RH, Item.GreatSwordOutfit()},
                    //{ ItemSlot.MT, Item.FlowerCapeFemale()},
                },
                Stats = stats,
                GameOptions = new GameOptions(),
                Mailbox = new Mailbox(),
                InsigniaId = 0,
                Awakened = true,
            };
            player.Equips.Add(ItemSlot.RH, Item.Knuckles(player));
            //player.Equips.Add(ItemSlot.LH, Item.Codex(player));
            return player;
        }

        public static Player Char13(long accountId, long characterId, string name = "gamemasterDiana")
        {
            Job job = Job.GameMaster;
            PlayerStats stats = new PlayerStats();
            int mapId = (int) Map.Ellinia;
            MapPlayerSpawn spawn = MapEntityStorage.GetRandomPlayerSpawn(mapId);
            StatDistribution statPointDistribution = new StatDistribution(totalStats: 0);
            List<SkillTab> skillTabs = new List<SkillTab>
            {
                new SkillTab(job)
            };

            Player player = new Player
            {
                SkillTabs = skillTabs,
                StatPointDistribution = statPointDistribution,
                MapId = mapId,
                AccountId = accountId,
                CharacterId = characterId,
                Name = name,
                Gender = 1,
                HomeName = "HomeName",
                Coord = CoordF.From(spawn.Coord.X, spawn.Coord.Y, spawn.Coord.Z),
                //Coord = CoordF.From(2850, 2550, 1800), // Lith Harbor (2000062)
                // Coord = CoordF.From(500, 500, 15000), // Tria
                Job = job,
                SkinColor = new SkinColor()
                {
                    Primary = Color.Argb(255, 253, 210, 194),
                    Secondary = Color.Argb(255, 253, 210, 194)
                },
                CreationTime = DateTimeOffset.Now.ToUnixTimeSeconds() + Environment.TickCount,
                Equips = new Dictionary<ItemSlot, Item> {
                    { ItemSlot.ER, Item.EarFemale() },
                    { ItemSlot.HR, Item.HairFemale() },
                    { ItemSlot.FA, Item.FaceFemale() },
                    { ItemSlot.FD, Item.FaceDecorationFemale() },
                    { ItemSlot.CL, Item.WeddingClothesFemale() },
                    { ItemSlot.SH, Item.WeddingShoesFemale() },
                    { ItemSlot.EA, Item.WeddingEarringFemale() },
                    //{ ItemSlot.CP, Item.PriestEliteHat() },
                    { ItemSlot.GL, Item.WeddingGlovesFemale()},
                    //{ ItemSlot.RH, Item.GreatSwordOutfit()},
                    //{ ItemSlot.MT, Item.FlowerCapeFemale()},
                },
                Stats = stats,
                GameOptions = new GameOptions(),
                Mailbox = new Mailbox(),
                InsigniaId = 0,
                Awakened = true,
            };
            //player.Equips.Add(ItemSlot.RH, Item.Knuckles(player));
            //player.Equips.Add(ItemSlot.LH, Item.Codex(player));
            return player;
        }

        public static Player Char14(long accountId, long characterId, string name = "beginnerDiana")
        {
            Job job = Job.None;
            PlayerStats stats = new PlayerStats();
            int mapId = (int) Map.Ellinia;
            MapPlayerSpawn spawn = MapEntityStorage.GetRandomPlayerSpawn(mapId);
            StatDistribution statPointDistribution = new StatDistribution(totalStats: 0);
            List<SkillTab> skillTabs = new List<SkillTab>
            {
                new SkillTab(job)
            };

            Player player = new Player
            {
                SkillTabs = skillTabs,
                StatPointDistribution = statPointDistribution,
                MapId = mapId,
                AccountId = accountId,
                CharacterId = characterId,
                Name = name,
                Gender = 1,
                HomeName = "HomeName",
                Coord = CoordF.From(spawn.Coord.X, spawn.Coord.Y, spawn.Coord.Z),
                //Coord = CoordF.From(2850, 2550, 1800), // Lith Harbor (2000062)
                // Coord = CoordF.From(500, 500, 15000), // Tria
                Job = job,
                SkinColor = new SkinColor()
                {
                    Primary = Color.Argb(255, 253, 210, 194),
                    Secondary = Color.Argb(255, 253, 210, 194)
                },
                CreationTime = DateTimeOffset.Now.ToUnixTimeSeconds() + Environment.TickCount,
                Equips = new Dictionary<ItemSlot, Item> {
                    { ItemSlot.ER, Item.EarFemale() },
                    { ItemSlot.HR, Item.HairFemale() },
                    { ItemSlot.FA, Item.FaceFemale() },
                    { ItemSlot.FD, Item.FaceDecorationFemale() },
                    { ItemSlot.CL, Item.WeddingClothesFemale() },
                    { ItemSlot.SH, Item.WeddingShoesFemale() },
                    { ItemSlot.EA, Item.WeddingEarringFemale() },
                    //{ ItemSlot.CP, Item.PriestEliteHat() },
                    { ItemSlot.GL, Item.WeddingGlovesFemale()},
                    //{ ItemSlot.RH, Item.GreatSwordOutfit()},
                    //{ ItemSlot.MT, Item.FlowerCapeFemale()},
                },
                Stats = stats,
                GameOptions = new GameOptions(),
                Mailbox = new Mailbox(),
                InsigniaId = 0,
                Awakened = true,
            };
            //player.Equips.Add(ItemSlot.RH, Item.Knuckles(player));
            //player.Equips.Add(ItemSlot.LH, Item.Codex(player));
            return player;
        }

        public static Player Char15(long accountId, long characterId, string name = "MEGA10")
        {
            Job job = Job.Knight;
            PlayerStats stats = new PlayerStats();
            int mapId = (int) Map.Ellinia;
            MapPlayerSpawn spawn = MapEntityStorage.GetRandomPlayerSpawn(mapId);
            List<SkillTab> skillTabs = new List<SkillTab>
            {
                new SkillTab(job)
            };

            Player player = new Player
            {
                SkillTabs = skillTabs,
                MapId = mapId,
                AccountId = accountId,
                CharacterId = characterId,
                Name = name,
                Gender = 0,
                HomeName = "HomeName",
                Coord = CoordF.From(spawn.Coord.X, spawn.Coord.Y, spawn.Coord.Z),
                Job = job,
                SkinColor = new SkinColor()
                {
                    Primary = Color.Argb(255, 252, 225, 214),
                    Secondary = Color.Argb(255, 253, 210, 194)
                },
                CreationTime = DateTimeOffset.Now.ToUnixTimeSeconds() + Environment.TickCount,
                Equips = new Dictionary<ItemSlot, Item> {
                    { ItemSlot.ER, Item.EarMale() },
                    { ItemSlot.HR, Item.HairMEGA10() },
                    { ItemSlot.FA, Item.FaceMEGA10() },
                    { ItemSlot.FD, Item.FaceDecorationMale() },
                    { ItemSlot.CL, Item.WeddingClothesMale() },
                    { ItemSlot.SH, Item.WeddingShoesMale() },
                    { ItemSlot.EA, Item.WeddingEarringMale() },
                    { ItemSlot.GL, Item.WeddingGlovesMale() },
                    { ItemSlot.CP, Item.PriestHat() },
                    //{ ItemSlot.MT, Item.FairyCapeMale()},
                    { ItemSlot.EY, Item.GlassesMale()},
                },
                Stats = stats,
                InsigniaId = 0,
                Awakened = true,
            };
            player.Equips.Add(ItemSlot.RH, Item.LongSword(player));
            player.Equips.Add(ItemSlot.LH, Item.Shield(player));
            return player;
        }

        public static Player Char16(long accountId, long characterId, string name = "priestDianav4")
        {
            Job job = Job.Priest;
            PlayerStats stats = new PlayerStats();
            int mapId = (int) Map.Ellinia;
            MapPlayerSpawn spawn = MapEntityStorage.GetRandomPlayerSpawn(mapId);
            StatDistribution statPointDistribution = new StatDistribution(totalStats: 0);
            List<SkillTab> skillTabs = new List<SkillTab>
            {
                new SkillTab(job)
            };

            Player player = new Player
            {
                SkillTabs = skillTabs,
                StatPointDistribution = statPointDistribution,
                MapId = mapId,
                AccountId = accountId,
                CharacterId = characterId,
                Name = name,
                Gender = 1,
                HomeName = "HomeName",
                Coord = CoordF.From(spawn.Coord.X, spawn.Coord.Y, spawn.Coord.Z), // Lith Harbor (2000062)
                // Coord = CoordF.From(500, 500, 15000), // Tria
                Job = job,
                SkinColor = new SkinColor()
                {
                    Primary = Color.Argb(255, 253, 210, 194),
                    Secondary = Color.Argb(255, 253, 210, 194)
                },
                CreationTime = DateTimeOffset.Now.ToUnixTimeSeconds() + Environment.TickCount,
                Equips = new Dictionary<ItemSlot, Item> {
                    { ItemSlot.ER, Item.EarFemale() },
                    { ItemSlot.HR, Item.HairFemalev4() },
                    { ItemSlot.FA, Item.FaceFemale() },
                    { ItemSlot.FD, Item.FaceDecorationFemale() },
                    { ItemSlot.CL, Item.PriestClothes() },
                    { ItemSlot.SH, Item.PriestShoes() },
                    { ItemSlot.EA, Item.AlkimiEarring() },
                    { ItemSlot.CP, Item.PriestHat() },
                    { ItemSlot.GL, Item.AlkimiGloves() },
                },
                Stats = stats,
                InsigniaId = 0,
                Awakened = true,
            };
            player.Equips.Add(ItemSlot.RH, Item.Scepter(player));
            player.Equips.Add(ItemSlot.LH, Item.Codex(player));
            return player;
        }

        public static Player Char17(long accountId, long characterId, string name = "priestDianav3")
        {
            Job job = Job.Priest;
            PlayerStats stats = new PlayerStats();
            int mapId = (int) Map.Ellinia;
            MapPlayerSpawn spawn = MapEntityStorage.GetRandomPlayerSpawn(mapId);
            StatDistribution statPointDistribution = new StatDistribution(totalStats: 0);
            List<SkillTab> skillTabs = new List<SkillTab>
            {
                new SkillTab(job)
            };

            Player player = new Player
            {
                SkillTabs = skillTabs,
                StatPointDistribution = statPointDistribution,
                MapId = mapId,
                AccountId = accountId,
                CharacterId = characterId,
                Name = name,
                Gender = 1,
                HomeName = "HomeName",
                Coord = CoordF.From(spawn.Coord.X, spawn.Coord.Y, spawn.Coord.Z), // Lith Harbor (2000062)
                // Coord = CoordF.From(500, 500, 15000), // Tria
                Job = job,
                SkinColor = new SkinColor()
                {
                    Primary = Color.Argb(255, 253, 210, 194),
                    Secondary = Color.Argb(255, 253, 210, 194)
                },
                CreationTime = DateTimeOffset.Now.ToUnixTimeSeconds() + Environment.TickCount,
                Equips = new Dictionary<ItemSlot, Item> {
                    { ItemSlot.ER, Item.EarFemale() },
                    { ItemSlot.HR, Item.HairFemalev3() },
                    { ItemSlot.FA, Item.FaceFemale() },
                    { ItemSlot.FD, Item.FaceDecorationFemale() },
                    { ItemSlot.CL, Item.PriestEliteClothes() },
                    { ItemSlot.SH, Item.PriestEliteShoes() },
                    { ItemSlot.EA, Item.AlkimiEarring() },
                    { ItemSlot.CP, Item.PriestEliteHat() },
                    { ItemSlot.GL, Item.AlkimiGloves() },
                },
                Stats = stats,
                InsigniaId = 0,
                Awakened = true,
            };
            player.Equips.Add(ItemSlot.RH, Item.Scepter(player));
            player.Equips.Add(ItemSlot.LH, Item.Codex(player));
            return player;
        }

        public static Player Char18(long accountId, long characterId, string name = "priestDianav3.1")
        {
            Job job = Job.Priest;
            PlayerStats stats = new PlayerStats();
            int mapId = (int) Map.Ellinia;
            MapPlayerSpawn spawn = MapEntityStorage.GetRandomPlayerSpawn(mapId);
            StatDistribution statPointDistribution = new StatDistribution(totalStats: 0);
            List<SkillTab> skillTabs = new List<SkillTab>
            {
                new SkillTab(job)
            };

            Player player = new Player
            {
                SkillTabs = skillTabs,
                StatPointDistribution = statPointDistribution,
                MapId = mapId,
                AccountId = accountId,
                CharacterId = characterId,
                Name = name,
                Gender = 1,
                HomeName = "HomeName",
                Coord = CoordF.From(spawn.Coord.X, spawn.Coord.Y, spawn.Coord.Z), // Lith Harbor (2000062)
                // Coord = CoordF.From(500, 500, 15000), // Tria
                Job = job,
                SkinColor = new SkinColor()
                {
                    Primary = Color.Argb(255, 253, 210, 194),
                    Secondary = Color.Argb(255, 253, 210, 194)
                },
                CreationTime = DateTimeOffset.Now.ToUnixTimeSeconds() + Environment.TickCount,
                Equips = new Dictionary<ItemSlot, Item> {
                    { ItemSlot.ER, Item.EarFemale() },
                    { ItemSlot.HR, Item.HairFemale() },
                    { ItemSlot.FA, Item.FaceFemale() },
                    { ItemSlot.FD, Item.FaceDecorationFemale() },
                    { ItemSlot.CL, Item.FairyClothFemale() },
                    { ItemSlot.SH, Item.FairyShoesFemale() },
                    { ItemSlot.EA, Item.FairyEarringFemale() },
                   // { ItemSlot.CP, Item.PriestEliteHat() },
                    { ItemSlot.GL, Item.FairyGlovesFemale() },
                },
                Stats = stats,
                InsigniaId = 0,
                Awakened = true,
            };
            player.Equips.Add(ItemSlot.RH, Item.Scepter(player));
            player.Equips.Add(ItemSlot.LH, Item.Codex(player));
            return player;
        }

        public static Player Char19(long accountId, long characterId, string name = "priestDianav4.1")
        {
            Job job = Job.Priest;
            PlayerStats stats = new PlayerStats();
            int mapId = (int) Map.Ellinia;
            MapPlayerSpawn spawn = MapEntityStorage.GetRandomPlayerSpawn(mapId);
            StatDistribution statPointDistribution = new StatDistribution(totalStats: 0);
            List<SkillTab> skillTabs = new List<SkillTab>
            {
                new SkillTab(job)
            };

            Player player = new Player
            {
                SkillTabs = skillTabs,
                StatPointDistribution = statPointDistribution,
                MapId = mapId,
                AccountId = accountId,
                CharacterId = characterId,
                Name = name,
                Gender = 1,
                HomeName = "HomeName",
                Coord = CoordF.From(spawn.Coord.X, spawn.Coord.Y, spawn.Coord.Z), // Lith Harbor (2000062)
                // Coord = CoordF.From(500, 500, 15000), // Tria
                Job = job,
                SkinColor = new SkinColor()
                {
                    Primary = Color.Argb(255, 253, 210, 194),
                    Secondary = Color.Argb(255, 253, 210, 194)
                },
                CreationTime = DateTimeOffset.Now.ToUnixTimeSeconds() + Environment.TickCount,
                Equips = new Dictionary<ItemSlot, Item> {
                    { ItemSlot.ER, Item.EarFemale() },
                    { ItemSlot.HR, Item.HairFemale() },
                    { ItemSlot.FA, Item.FaceFemale() },
                    { ItemSlot.FD, Item.FaceDecorationFemale() },
                    { ItemSlot.CL, Item.PerionClothFemale() },
                    { ItemSlot.SH, Item.PerionShoesFemale() },
                    { ItemSlot.EA, Item.PerionEarring() },
                    //{ ItemSlot.CP, Item.PriestEliteHat() },
                    { ItemSlot.GL, Item.PerionGlovesFemale() },
                },
                Stats = stats,
                InsigniaId = 0,
                Awakened = true,
            };
            player.Equips.Add(ItemSlot.RH, Item.Scepter(player));
            player.Equips.Add(ItemSlot.LH, Item.Codex(player));
            return player;
        }

        public static Player Char20(long accountId, long characterId, string name = "priestDianav4.2")
        {
            Job job = Job.Priest;
            PlayerStats stats = new PlayerStats();
            int mapId = (int) Map.Ellinia;
            MapPlayerSpawn spawn = MapEntityStorage.GetRandomPlayerSpawn(mapId);
            StatDistribution statPointDistribution = new StatDistribution(totalStats: 0);
            List<SkillTab> skillTabs = new List<SkillTab>
            {
                new SkillTab(job)
            };

            Player player = new Player
            {
                SkillTabs = skillTabs,
                StatPointDistribution = statPointDistribution,
                MapId = mapId,
                AccountId = accountId,
                CharacterId = characterId,
                Name = name,
                Gender = 1,
                HomeName = "HomeName",
                Coord = CoordF.From(spawn.Coord.X, spawn.Coord.Y, spawn.Coord.Z), // Lith Harbor (2000062)
                // Coord = CoordF.From(500, 500, 15000), // Tria
                Job = job,
                SkinColor = new SkinColor()
                {
                    Primary = Color.Argb(255, 253, 210, 194),
                    Secondary = Color.Argb(255, 253, 210, 194)
                },
                CreationTime = DateTimeOffset.Now.ToUnixTimeSeconds() + Environment.TickCount,
                Equips = new Dictionary<ItemSlot, Item> {
                    { ItemSlot.ER, Item.EarFemale() },
                    { ItemSlot.HR, Item.HairFemalev4() },
                    { ItemSlot.FA, Item.FaceFemale() },
                    { ItemSlot.FD, Item.FaceDecorationFemale() },
                    { ItemSlot.CL, Item.WeddingClothesFemale() },
                    { ItemSlot.SH, Item.WeddingShoesFemale() },
                    { ItemSlot.EA, Item.WeddingEarringFemale() },
                    { ItemSlot.CP, Item.PriestEliteHat() },
                    { ItemSlot.GL, Item.WeddingGlovesFemale() },
                },
                Stats = stats,
                InsigniaId = 0,
                Awakened = true,
            };
            player.Equips.Add(ItemSlot.RH, Item.Scepter(player));
            player.Equips.Add(ItemSlot.LH, Item.Codex(player));
            return player;
        }

        public static Player Char21(long accountId, long characterId, string name = "priestDianav5.1")
        {
            Job job = Job.Priest;
            PlayerStats stats = new PlayerStats();
            int mapId = (int) Map.Ellinia;
            MapPlayerSpawn spawn = MapEntityStorage.GetRandomPlayerSpawn(mapId);
            StatDistribution statPointDistribution = new StatDistribution(totalStats: 0);
            List<SkillTab> skillTabs = new List<SkillTab>
            {
                new SkillTab(job)
            };

            Player player = new Player
            {
                SkillTabs = skillTabs,
                StatPointDistribution = statPointDistribution,
                MapId = mapId,
                AccountId = accountId,
                CharacterId = characterId,
                Name = name,
                Gender = 1,
                HomeName = "HomeName",
                Coord = CoordF.From(spawn.Coord.X, spawn.Coord.Y, spawn.Coord.Z), // Lith Harbor (2000062)
                // Coord = CoordF.From(500, 500, 15000), // Tria
                Job = job,
                SkinColor = new SkinColor()
                {
                    Primary = Color.Argb(255, 253, 210, 194),
                    Secondary = Color.Argb(255, 253, 210, 194)
                },
                CreationTime = DateTimeOffset.Now.ToUnixTimeSeconds() + Environment.TickCount,
                Equips = new Dictionary<ItemSlot, Item> {
                    { ItemSlot.ER, Item.EarFemale() },
                    { ItemSlot.HR, Item.HairFemale() },
                    { ItemSlot.FA, Item.FaceFemale() },
                    { ItemSlot.FD, Item.FaceDecorationFemale() },
                    { ItemSlot.CL, Item.SlikenHanbokClothFemale() },
                    { ItemSlot.SH, Item.SlikenHanbokShoesFemale() },
                    { ItemSlot.EA, Item.AlkimiEarring() },
                    //{ ItemSlot.CP, Item.PriestEliteHat() },
                    { ItemSlot.GL, Item.SlikenHanbokGlovesFemale() },
                },
                Stats = stats,
                InsigniaId = 0,
                Awakened = true,
            };
            player.Equips.Add(ItemSlot.RH, Item.Scepter(player));
            player.Equips.Add(ItemSlot.LH, Item.Codex(player));
            return player;
        }

        public static Player Char22(long accountId, long characterId, string name = "priestDianav2")
        {
            Job job = Job.Priest;
            PlayerStats stats = new PlayerStats();
            int mapId = (int) Map.Ellinia;
            MapPlayerSpawn spawn = MapEntityStorage.GetRandomPlayerSpawn(mapId);
            StatDistribution statPointDistribution = new StatDistribution(totalStats: 0);
            List<SkillTab> skillTabs = new List<SkillTab>
            {
                new SkillTab(job)
            };

            Player player = new Player
            {
                SkillTabs = skillTabs,
                StatPointDistribution = statPointDistribution,
                MapId = mapId,
                AccountId = accountId,
                CharacterId = characterId,
                Name = name,
                Gender = 1,
                HomeName = "HomeName",
                Coord = CoordF.From(spawn.Coord.X, spawn.Coord.Y, spawn.Coord.Z), // Lith Harbor (2000062)
                // Coord = CoordF.From(500, 500, 15000), // Tria
                Job = job,
                SkinColor = new SkinColor()
                {
                    Primary = Color.Argb(255, 253, 210, 194),
                    Secondary = Color.Argb(255, 253, 210, 194)
                },
                CreationTime = DateTimeOffset.Now.ToUnixTimeSeconds() + Environment.TickCount,
                Equips = new Dictionary<ItemSlot, Item> {
                    { ItemSlot.ER, Item.EarFemale() },
                    { ItemSlot.HR, Item.HairFemalev3() },
                    { ItemSlot.FA, Item.FaceFemale() },
                    { ItemSlot.FD, Item.FaceDecorationFemale() },
                    { ItemSlot.CL, Item.PriestDefaultClothFemale() },
                    { ItemSlot.SH, Item.PriestDefaultShoesFemale() },
                    { ItemSlot.EA, Item.AlkimiEarring() },
                    { ItemSlot.CP, Item.PriestEliteHat() },
                    { ItemSlot.GL, Item.AlkimiGloves() },
                },
                Stats = stats,
                InsigniaId = 0,
                Awakened = true,
            };
            player.Equips.Add(ItemSlot.RH, Item.Scepter(player));
            player.Equips.Add(ItemSlot.LH, Item.Codex(player));
            return player;
        }

        public static Player Char23(long accountId, long characterId, string name = "PureWhiteDiana")
        {
            Job job = Job.HeavyGunner;
            PlayerStats stats = new PlayerStats();
            int mapId = (int) Map.Ellinia;
            MapPlayerSpawn spawn = MapEntityStorage.GetRandomPlayerSpawn(mapId);
            StatDistribution statPointDistribution = new StatDistribution(totalStats: 0);
            List<SkillTab> skillTabs = new List<SkillTab>
            {
                new SkillTab(job)
            };

            Player player = new Player
            {
                SkillTabs = skillTabs,
                StatPointDistribution = statPointDistribution,
                MapId = mapId,
                AccountId = accountId,
                CharacterId = characterId,
                Name = name,
                Gender = 1,
                HomeName = "HomeName",
                Coord = CoordF.From(spawn.Coord.X, spawn.Coord.Y, spawn.Coord.Z), // Lith Harbor (2000062)
                // Coord = CoordF.From(500, 500, 15000), // Tria
                Job = job,
                SkinColor = new SkinColor()
                {
                    Primary = Color.Argb(255, 250, 234, 225),
                    Secondary = Color.Argb(255, 250, 234, 225)
                },
                CreationTime = DateTimeOffset.Now.ToUnixTimeSeconds() + Environment.TickCount,
                Equips = new Dictionary<ItemSlot, Item> {
                    { ItemSlot.ER, Item.EarFemale() },
                    { ItemSlot.HR, Item.HairFemalePureWhite() },
                    { ItemSlot.FA, Item.FaceFemalePureWhite() },
                    { ItemSlot.FD, Item.FaceDecorationFemale() },
                    { ItemSlot.CL, Item.WeddingClothesFemalePureWhite() },
                    { ItemSlot.SH, Item.WeddingShoesFemalePureWhite() },
                    { ItemSlot.EA, Item.WeddingEarringFemalePureWhite() },
                    //{ ItemSlot.EY, Item.GlassesFemale()},
                    //{ ItemSlot.CP, Item.PriestEliteHat() },
                    //{ ItemSlot.GL, Item.AlkimiGloves() },
                },
                Stats = stats,
                InsigniaId = 0,
                Awakened = true,
            };
            player.Equips.Add(ItemSlot.RH, Item.Cannon(player));
            //player.Equips.Add(ItemSlot.LH, Item.Codex(player));
            return player;
        }

        public static Player Char24(long accountId, long characterId, string name = "priestPWDiana")
        {
            Job job = Job.Priest;
            PlayerStats stats = new PlayerStats();
            int mapId = (int) Map.Ellinia;
            MapPlayerSpawn spawn = MapEntityStorage.GetRandomPlayerSpawn(mapId);
            StatDistribution statPointDistribution = new StatDistribution(totalStats: 0);
            List<SkillTab> skillTabs = new List<SkillTab>
            {
                new SkillTab(job)
            };

            Player player = new Player
            {
                SkillTabs = skillTabs,
                StatPointDistribution = statPointDistribution,
                MapId = mapId,
                AccountId = accountId,
                CharacterId = characterId,
                Name = name,
                Gender = 1,
                HomeName = "HomeName",
                Coord = CoordF.From(spawn.Coord.X, spawn.Coord.Y, spawn.Coord.Z), // Lith Harbor (2000062)
                // Coord = CoordF.From(500, 500, 15000), // Tria
                Job = job,
                SkinColor = new SkinColor()
                {
                    Primary = Color.Argb(255, 250, 234, 225),
                    Secondary = Color.Argb(255, 250, 234, 225)
                },
                CreationTime = DateTimeOffset.Now.ToUnixTimeSeconds() + Environment.TickCount,
                Equips = new Dictionary<ItemSlot, Item> {
                    { ItemSlot.ER, Item.EarFemale() },
                    { ItemSlot.HR, Item.HairFemalePureWhite() },
                    { ItemSlot.FA, Item.FaceFemalePureWhite() },
                    { ItemSlot.FD, Item.FaceDecorationFemale() },
                    { ItemSlot.CL, Item.WeddingClothesFemalePureWhite() },
                    { ItemSlot.SH, Item.WeddingShoesFemalePureWhite() },
                    { ItemSlot.EA, Item.WeddingEarringFemalePureWhite() },
                    //{ ItemSlot.EY, Item.GlassesFemale()},
                    //{ ItemSlot.CP, Item.PriestEliteHat() },
                    //{ ItemSlot.GL, Item.AlkimiGloves() },
                },
                Stats = stats,
                InsigniaId = 0,
                Awakened = true,
            };
            player.Equips.Add(ItemSlot.RH, Item.Scepter(player));
            player.Equips.Add(ItemSlot.LH, Item.Codex(player));
            return player;
        }

        public void Warp(MapPlayerSpawn spawn, int mapId)
        {
            MapId = mapId;
            Coord = spawn.Coord.ToFloat();
            Rotation = spawn.Rotation.ToFloat();
            Session.Send(FieldPacket.RequestEnter(Session.FieldPlayer));
        }

        public Dictionary<ItemSlot, Item> GetEquippedInventory(InventoryTab tab)
        {
            switch (tab)
            {
                case InventoryTab.Gear:
                    return Equips;
                case InventoryTab.Outfit:
                    return Cosmetics;
                default:
                    break;
            }
            return null;
        }

        public Item GetEquippedItem(long itemUid)
        {
            Item gearItem = Equips.FirstOrDefault(x => x.Value.Uid == itemUid).Value;
            if (gearItem == null)
            {
                Item cosmeticItem = Cosmetics.FirstOrDefault(x => x.Value.Uid == itemUid).Value;
                return cosmeticItem;
            }
            return gearItem;
        }

        public void ConsumeHp(int amount)
        {
            Stats.Decrease(PlayerStatId.Hp, amount);

            // TODO: merge regen updates with larger packets
            if (HpRegenThread == null || HpRegenThread.IsCompleted)
            {
                HpRegenThread = StartRegen(PlayerStatId.Hp, PlayerStatId.HpRegen, PlayerStatId.HpRegenTime);
            }
        }

        public void ConsumeSp(int amount)
        {
            Stats.Decrease(PlayerStatId.Spirit, amount);

            // TODO: merge regen updates with larger packets
            if (SpRegenThread == null || SpRegenThread.IsCompleted)
            {
                SpRegenThread = StartRegen(PlayerStatId.Spirit, PlayerStatId.SpRegen, PlayerStatId.SpRegenTime);
            }
        }

        public void ConsumeStamina(int amount)
        {
            Stats.Decrease(PlayerStatId.Stamina, amount);

            // TODO: merge regen updates with larger packets
            if (StaRegenThread == null || StaRegenThread.IsCompleted)
            {
                StaRegenThread = StartRegen(PlayerStatId.Stamina, PlayerStatId.StaRegen, PlayerStatId.StaRegenTime);
            }
        }

        private Task StartRegen(PlayerStatId statId, PlayerStatId regenStatId, PlayerStatId timeStatId)
        {
            return Task.Run(async () =>
            {
                await Task.Delay(Stats[timeStatId].Current);

                // TODO: Check if regen-enabled
                while (Stats[statId].Current < Stats[statId].Max)
                {
                    lock (Stats)
                    {
                        Stats[statId] = AddStatRegen(statId, regenStatId);
                        Session.Send(StatPacket.UpdateStats(Session.FieldPlayer, statId));
                    }
                    await Task.Delay(Stats[timeStatId].Current);
                }
            });
        }

        private PlayerStat AddStatRegen(PlayerStatId statIndex, PlayerStatId regenStatIndex)
        {
            PlayerStat stat = Stats[statIndex];
            int regen = Stats[regenStatIndex].Current;
            int postRegen = Math.Clamp(stat.Current + regen, 0, stat.Max);
            return new PlayerStat(stat.Max, stat.Min, postRegen);
        }

        public void IncrementGatheringCount(int recipeID, int amount)
        {
            if (!GatheringCount.ContainsKey(recipeID))
            {
                int maxLimit = (int) (RecipeMetadataStorage.GetRecipe(recipeID).NormalPropLimitCount * 1.4);
                GatheringCount[recipeID] = new PlayerStat(maxLimit, 0, 0);
            }
            if ((GatheringCount[recipeID].Current + amount) <= GatheringCount[recipeID].Max)
            {
                PlayerStat stat = GatheringCount[recipeID];
                stat.Current += amount;
                GatheringCount[recipeID] = stat;
            }
        }

        public bool IsVip()
        {
            return VIPExpiration > DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        }

        public void TrophyUpdate(int trophyId, long addAmount, int sendUpdateInterval = 1)
        {
            if (!TrophyData.ContainsKey(trophyId))
            {
                TrophyData[trophyId] = new Trophy(trophyId);
            }
            TrophyData[trophyId].AddCounter(Session, addAmount);
            if (TrophyData[trophyId].Counter % sendUpdateInterval == 0)
            {
                Session.Send(TrophyPacket.WriteUpdate(TrophyData[trophyId]));
            }
        }

        private Task OnlineTimer(PlayerStatId statId)
        {
            return Task.Run(async () =>
            {
                await Task.Delay(60000);
                lock (Timestamps)
                {
                    Timestamps.OnlineDuration += 1;
                    Timestamps.LastOnline = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
                    TrophyUpdate(23100001, 1);
                }
            });
        }
    }
}
