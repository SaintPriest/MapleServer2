using System;
using System.Collections.Generic;
using Maple2Storage.Types;
using Maple2Storage.Types.Metadata;
using MapleServer2.Data.Static;
using MapleServer2.Enums;
using MapleServer2.Tools;

namespace MapleServer2.Types
{
    public class Item
    {
        public int Level { get; set; }
        public InventoryTab InventoryTab { get; private set; }
        public ItemSlot ItemSlot { get; private set; }
        public GemSlot GemSlot { get; private set; }
        public int Rarity { get; set; }
        public int StackLimit { get; private set; }
        public bool EnableBreak { get; private set; }
        public bool IsTwoHand { get; private set; }
        public bool IsDress { get; private set; }
        public bool IsTemplate { get; set; }
        public bool IsCustomScore { get; set; }
        public int PlayCount { get; set; }
        public byte Gender { get; }
        public string FileName { get; set; }
        public int SkillId { get; set; }
        public List<Job> RecommendJobs { get; set; }
        public List<ItemContent> Content { get; private set; }
        public ItemFunction Function { get; set; }
        public string Tag { get; set; }
        public int ShopID { get; set; }

        public readonly int Id;
        public long Uid;
        public short Slot;
        public int Amount;

        public long CreationTime;
        public long ExpiryTime;

        public int TimesAttributesChanged;
        public bool IsLocked;
        public long UnlockTime;
        public short RemainingGlamorForges;
        public int GachaDismantleId;
        public int Enchants;
        // EnchantExp (10000 = 100%) for Peachy
        public int EnchantExp;
        public bool CanRepackage;
        public int Charges;
        public TransferFlag TransferFlag;
        public int RemainingTrades;

        // For friendship badges
        public long PairedCharacterId;
        public string PairedCharacterName;
        public int PetSkinBadgeId;
        public byte[] TransparencyBadgeBools = new byte[10];

        public Player Owner;

        public EquipColor Color;

        public HairData HairD;

        public HatData HatD;

        public byte[] FaceDecorationD;

        public MusicScore Score;

        public ItemStats Stats;

        public Item(int id)
        {
            Id = id;
            Level = ItemMetadataStorage.GetLevel(id);
            Uid = GuidGenerator.Long();
            InventoryTab = ItemMetadataStorage.GetTab(id);
            ItemSlot = ItemMetadataStorage.GetSlot(id);
            GemSlot = ItemMetadataStorage.GetGem(id);
            Rarity = ItemMetadataStorage.GetRarity(id);
            StackLimit = ItemMetadataStorage.GetStackLimit(id);
            EnableBreak = ItemMetadataStorage.GetEnableBreak(id);
            IsTwoHand = ItemMetadataStorage.GetIsTwoHand(id);
            IsDress = ItemMetadataStorage.GetIsDress(id);
            IsTemplate = ItemMetadataStorage.GetIsTemplate(id);
            IsCustomScore = ItemMetadataStorage.GetIsCustomScore(id);
            Gender = ItemMetadataStorage.GetGender(id);
            RemainingGlamorForges = ItemExtractionMetadataStorage.GetExtractionCount(id);
            PlayCount = ItemMetadataStorage.GetPlayCount(id);
            FileName = ItemMetadataStorage.GetFileName(id);
            SkillId = ItemMetadataStorage.GetSkillID(id);
            RecommendJobs = ItemMetadataStorage.GetRecommendJobs(id);
            Content = ItemMetadataStorage.GetContent(id);
            Function = ItemMetadataStorage.GetFunction(id);
            Tag = ItemMetadataStorage.GetTag(id);
            ShopID = ItemMetadataStorage.GetShopID(id);
            Slot = -1;
            Amount = 1;
            Score = new MusicScore();
            Stats = new ItemStats(id, Rarity, Level);
            Color = ItemMetadataStorage.GetEquipColor(id);
            CanRepackage = true; // If false, item becomes untradable
        }

        // Make a copy of item
        public Item(Item other)
        {
            Id = other.Id;
            InventoryTab = other.InventoryTab;
            ItemSlot = other.ItemSlot;
            GemSlot = other.GemSlot;
            Rarity = other.Rarity;
            StackLimit = other.StackLimit;
            EnableBreak = other.EnableBreak;
            IsTwoHand = other.IsTwoHand;
            IsDress = other.IsDress;
            IsTemplate = other.IsTemplate;
            IsCustomScore = other.IsCustomScore;
            PlayCount = other.PlayCount;
            FileName = other.FileName;
            Content = other.Content;
            Function = other.Function;
            Uid = other.Uid;
            Slot = other.Slot;
            Amount = other.Amount;
            CreationTime = other.CreationTime;
            ExpiryTime = other.ExpiryTime;
            TimesAttributesChanged = other.TimesAttributesChanged;
            IsLocked = other.IsLocked;
            UnlockTime = other.UnlockTime;
            RemainingGlamorForges = other.RemainingGlamorForges;
            GachaDismantleId = other.GachaDismantleId;
            Enchants = other.Enchants;
            EnchantExp = other.EnchantExp;
            CanRepackage = other.CanRepackage;
            Charges = other.Charges;
            TransferFlag = other.TransferFlag;
            RemainingTrades = other.RemainingTrades;
            PairedCharacterId = other.PairedCharacterId;
            PairedCharacterName = other.PairedCharacterName;
            PetSkinBadgeId = other.PetSkinBadgeId;
            Owner = other.Owner;
            Color = other.Color;
            HairD = other.HairD;
            HatD = other.HatD;
            Score = new MusicScore();
            Stats = new ItemStats(other.Stats);
        }

        public static Item EarFemale()
        {
            return new Item(10500001)
            {
                Uid = 2754959794416496488,
                CreationTime = 1558494660,
                Color = new EquipColor(),
            };
        }

        public static Item EarMale()
        {
            return new Item(10500001)
            {
                Uid = 2754959794416496488,
                CreationTime = 1558494660,
                Color = new EquipColor(),
            };
        }

        public static Item HairFemale()
        {
            return new Item(10200238) // 10200085 10200148 10200238 10200011
            {  // 10200238
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(MixedColor.Custom(
                    Maple2Storage.Types.Color.Argb(255, 194, 209, 96),
                    Maple2Storage.Types.Color.Argb(255, 76, 133, 219),
                    Maple2Storage.Types.Color.Argb(255, 64, 104, 54)
                    ),
                15, 2
                ),
                //Color = EquipColor.Custom(MixedColor.Custom(
                //    Maple2Storage.Types.Color.Argb(255, 198, 198, 193),
                //    Maple2Storage.Types.Color.Argb(255, 76, 133, 219),
                //    Maple2Storage.Types.Color.Argb(255, 149, 149, 143)
                //    ),
                //15, 2
                //),
                // 10200011 10200085 10200148
                //HairD = new HairData(1.0f, 1.0f, new CoordF(), new CoordF(), new CoordF(), new CoordF()), // 10200238
                HairD = new HairData(1.0f, 1.0f, CoordF.From((float) 38.359235, (float) -15.343262, (float) -25.796207), CoordF.From((float) 21.872501, (float) -77.55839, (float) 3.081891), CoordF.From((float) 38.359235, (float) -15.722893, (float) 25.415237), CoordF.From((float) 157.2916, (float) -77.55905, (float) -3.0907118)), // 10200011
            };
        }

        public static Item HairFemalev4()
        {
            return new Item(10200085)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(MixedColor.Custom(
                    Maple2Storage.Types.Color.Argb(255, 198, 198, 193),
                    Maple2Storage.Types.Color.Argb(255, 76, 133, 219),
                    Maple2Storage.Types.Color.Argb(255, 149, 149, 143)
                    ),
                15, 2
                ),
                HairD = new HairData(1.0f, 0.5f, new CoordF(), new CoordF(), new CoordF(), new CoordF()), // 10200238
            };
        }

        public static Item HairMale()
        {
            return new Item(10200003)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(MixedColor.Custom(
                    Maple2Storage.Types.Color.Argb(255, 198, 198, 193),
                    Maple2Storage.Types.Color.Argb(255, 76, 133, 219),
                    Maple2Storage.Types.Color.Argb(255, 149, 149, 143)
                    ),
                    10, 4
                ),
                HairD = new HairData(1.0f, 1.0f, new CoordF(), new CoordF(), new CoordF(), new CoordF()),
            };
        }

        public static Item HairMEGA10()
        {
            return new Item(10200003)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(MixedColor.Custom(
                    Maple2Storage.Types.Color.Argb(255, 249, 137, 77),
                    Maple2Storage.Types.Color.Argb(255, 76, 133, 219),
                    Maple2Storage.Types.Color.Argb(255, 178, 105, 57)
                    ),
                10, 0
                ),
                HairD = new HairData(1.0f, 1.0f, new CoordF(), new CoordF(), new CoordF(), new CoordF()),
            };
        }

        public static Item FaceFemale()
        {
            return new Item(10300036)
            {
                Uid = 2754959794416496483,
                CreationTime = 1558494660,
                Color = EquipColor.Custom(MixedColor.Custom(
                     Maple2Storage.Types.Color.Argb(255, 84, 127, 8),
                     Maple2Storage.Types.Color.Argb(255, 247, 227, 227),
                     Maple2Storage.Types.Color.Argb(255, 8, 15, 0)
                    ),
                 0, 3
                 ),
            };
        }

        public static Item FaceMale()
        {
            return new Item(10300035)
            {
                Uid = 2754959794416496483,
                CreationTime = 1558494660,
                Color = EquipColor.Custom(MixedColor.Custom(
                    Maple2Storage.Types.Color.Argb(255, 84, 127, 8),
                    Maple2Storage.Types.Color.Argb(255, 0xF7, 0xE3, 0xE3),
                    Maple2Storage.Types.Color.Argb(255, 8, 15, 0)
                    ),
                10, 0
                ),
            };
        }

        public static Item FaceMEGA10()
        {
            return new Item(10300035)
            {
                Uid = 2754959794416496483,
                CreationTime = 1558494660,
                Color = EquipColor.Custom(MixedColor.Custom(
                    Maple2Storage.Types.Color.Argb(0xFF, 165, 165, 165),
                    Maple2Storage.Types.Color.Argb(0xFF, 0xF7, 0xE3, 0xE3),
                    Maple2Storage.Types.Color.Argb(0xFF, 5, 4, 4)
                    ),
                10, 0
                ),
            };
        }

        public static Item FaceDecorationFemale()
        {
            return new Item(10400000)
            {
                Uid = 2754959794416496484,
                CreationTime = 1558494660,
                Color = new EquipColor(),
                FaceDecorationD = new byte[16],
            };
        }

        public static Item FaceDecorationMale()
        {
            return new Item(10400000)
            {
                Uid = 2754959794416496484,
                CreationTime = 1558494660,
                Color = new EquipColor(),
                FaceDecorationD = new byte[16],
            };
        }

        public static Item TutorialBow(Player owner)
        {
            return new Item(15100216)
            {
                Uid = 3430503306390578751,
                Rarity = 1,
                CreationTime = DateTimeOffset.UtcNow.ToUnixTimeSeconds(),
                Owner = owner,
                Color = EquipColor.Custom(MixedColor.Custom(
                    Maple2Storage.Types.Color.Argb(255, 188, 188, 179),
                    Maple2Storage.Types.Color.Argb(255, 195, 218, 61),
                    Maple2Storage.Types.Color.Argb(255, 176, 180, 186)
                    ),
                    10, 19
                ),
                TransferFlag = TransferFlag.Binds | TransferFlag.Splitable,
            };
        }

        public static Item Bow(Player owner)
        {
            return new Item(15100302)
            {
                Uid = 3430503306390578751,
                Rarity = 5,
                CreationTime = DateTimeOffset.UtcNow.ToUnixTimeSeconds(),
                Owner = owner,
                Color = EquipColor.Custom(MixedColor.Custom(
                    Maple2Storage.Types.Color.Argb(255, 147, 226, 242),
                    Maple2Storage.Types.Color.Argb(255, 195, 218, 61),
                    Maple2Storage.Types.Color.Argb(255, 89, 153, 165)
                ),
                10, 19
                ),
                TransferFlag = TransferFlag.Binds | TransferFlag.Splitable,
            };
        }

        public static Item Scepter(Player owner)
        {
            return new Item(13300041)
            {
                Uid = 3430503306390578751,
                Rarity = 4,
                CreationTime = DateTimeOffset.UtcNow.ToUnixTimeSeconds(),
                Owner = owner,
                Color = EquipColor.Custom(MixedColor.Custom(
                    Maple2Storage.Types.Color.Argb(255, 194, 209, 96),
                    Maple2Storage.Types.Color.Argb(255, 195, 218, 61),
                    Maple2Storage.Types.Color.Argb(255, 64, 104, 54)
                ),
                10, 19
                ),
                TransferFlag = TransferFlag.Binds | TransferFlag.Splitable,
            };
        }

        public static Item Codex(Player owner)
        {
            return new Item(14000030)
            {
                Uid = 3430503306390578751,
                Rarity = 4,
                CreationTime = DateTimeOffset.UtcNow.ToUnixTimeSeconds(),
                Owner = owner,
                Color = EquipColor.Custom(MixedColor.Custom(
                    Maple2Storage.Types.Color.Argb(255, 126, 204, 247),
                    Maple2Storage.Types.Color.Argb(255, 195, 218, 61),
                    Maple2Storage.Types.Color.Argb(255, 72, 94, 168)
                    ),
                10, 19
                ),
                TransferFlag = TransferFlag.Binds | TransferFlag.Splitable,
            };
        }

        public static Item Orb(Player owner)
        {
            return new Item(15600229)
            {
                Uid = 3430503306390578751,
                Rarity = 4,
                Owner = owner,
                CreationTime = DateTimeOffset.UtcNow.ToUnixTimeSeconds(),
                Color = EquipColor.Custom(MixedColor.Custom(
                    Maple2Storage.Types.Color.Argb(255, 230, 230, 230),
                    Maple2Storage.Types.Color.Argb(255, 195, 218, 61),
                    Maple2Storage.Types.Color.Argb(255, 150, 150, 150)
                    ),
                10, 19
                ),
                TransferFlag = TransferFlag.Binds | TransferFlag.Splitable,
            };
        }

        public static Item Cannon(Player owner)
        {
            return new Item(15300288)
            {
                Uid = 3430503306390578751,
                Rarity = 4,
                Owner = owner,
                CreationTime = DateTimeOffset.UtcNow.ToUnixTimeSeconds(),
                Color = EquipColor.Custom(MixedColor.Custom(
                    Maple2Storage.Types.Color.Argb(255, 239, 112, 145),
                    Maple2Storage.Types.Color.Argb(255, 195, 218, 61),
                    Maple2Storage.Types.Color.Argb(255, 153, 66, 82)
                    ),
                10, 19
                ),
                TransferFlag = TransferFlag.Binds | TransferFlag.Splitable,
            };
        }

        public static Item LongSword(Player owner)
        {
            return new Item(13200306)
            {
                Uid = 3430503306390578751,
                Rarity = 4,
                CreationTime = DateTimeOffset.UtcNow.ToUnixTimeSeconds(),
                Owner = owner,
                Color = EquipColor.Custom(MixedColor.Custom(
                    Maple2Storage.Types.Color.Argb(255, 147, 226, 242),
                    Maple2Storage.Types.Color.Argb(255, 195, 218, 61),
                    Maple2Storage.Types.Color.Argb(255, 89, 153, 165)
                    ),
                10, 19
                ),
                TransferFlag = TransferFlag.Binds | TransferFlag.Splitable,
            };
        }

        public static Item Shield(Player owner)
        {
            return new Item(14100276)
            {
                Uid = 3430503306390578751,
                Rarity = 4,
                CreationTime = DateTimeOffset.UtcNow.ToUnixTimeSeconds(),
                Owner = owner,
                Color = EquipColor.Custom(MixedColor.Custom(
                    Maple2Storage.Types.Color.Argb(255, 147, 226, 242),
                    Maple2Storage.Types.Color.Argb(255, 195, 218, 61),
                    Maple2Storage.Types.Color.Argb(255, 89, 153, 165)
                    ),
                10, 19
                ),
                TransferFlag = TransferFlag.Binds | TransferFlag.Splitable,
            };
        }

        public static Item GreatSword(Player owner)
        {
            return new Item(15000310)
            {
                Uid = 3430503306390578751,
                Rarity = 4,
                CreationTime = DateTimeOffset.UtcNow.ToUnixTimeSeconds(),
                Owner = owner,
                Color = EquipColor.Custom(MixedColor.Custom(
                    Maple2Storage.Types.Color.Argb(255, 147, 226, 242),
                    Maple2Storage.Types.Color.Argb(255, 195, 218, 61),
                    Maple2Storage.Types.Color.Argb(255, 89, 153, 165)
                    ),
                10, 19
                ),
                TransferFlag = TransferFlag.Binds | TransferFlag.Splitable,
            };
        }

        public static Item Staff(Player owner)
        {
            return new Item(15200016)
            {
                Uid = 3430503306390578751,
                Rarity = 2,
                CreationTime = DateTimeOffset.UtcNow.ToUnixTimeSeconds(),
                Owner = owner,
                TransferFlag = TransferFlag.Binds | TransferFlag.Splitable,
            };
        }

        public static Item Dagger(Player owner)
        {
            return new Item(13100311)
            {
                Uid = 3430503306390578751,
                Rarity = 4,
                CreationTime = DateTimeOffset.UtcNow.ToUnixTimeSeconds(),
                Owner = owner,
                Color = EquipColor.Custom(MixedColor.Custom(
                    Maple2Storage.Types.Color.Argb(255, 147, 226, 242),
                    Maple2Storage.Types.Color.Argb(255, 195, 218, 61),
                    Maple2Storage.Types.Color.Argb(255, 89, 153, 165)
                    ),
                10, 19
                ),
                TransferFlag = TransferFlag.Binds | TransferFlag.Splitable,
            };
        }

        public static Item Knuckles(Player owner)
        {
            return new Item(15500223)
            {
                Uid = 3430503306390578751,
                Rarity = 4,
                CreationTime = DateTimeOffset.UtcNow.ToUnixTimeSeconds(),
                Owner = owner,
                Color = EquipColor.Custom(MixedColor.Custom(
                    Maple2Storage.Types.Color.Argb(255, 147, 226, 242),
                    Maple2Storage.Types.Color.Argb(255, 195, 218, 61),
                    Maple2Storage.Types.Color.Argb(255, 89, 153, 165)
                    ),
                10, 19
                ),
                TransferFlag = TransferFlag.Binds | TransferFlag.Splitable,
            };
        }

        public static Item ThrowStar(Player owner)
        {
            return new Item(13460307)
            {
                Uid = 3430503306390578751,
                Rarity = 4,
                CreationTime = DateTimeOffset.UtcNow.ToUnixTimeSeconds(),
                Owner = owner,
                Color = EquipColor.Custom(MixedColor.Custom(
                    Maple2Storage.Types.Color.Argb(0xFF, 194, 209, 96),
                    Maple2Storage.Types.Color.Argb(255, 195, 218, 61),
                    Maple2Storage.Types.Color.Argb(0xFF, 64, 104, 54)
                    ),
                10, 19
                ),
                TransferFlag = TransferFlag.Binds | TransferFlag.Splitable,
            };
        }

        public static Item Blade(Player owner)
        {
            return new Item(15460190)
            {
                Uid = 3430503306390578751,
                Rarity = 4,
                CreationTime = DateTimeOffset.UtcNow.ToUnixTimeSeconds(),
                Owner = owner,
                Color = EquipColor.Custom(MixedColor.Custom(
                    Maple2Storage.Types.Color.Argb(255, 147, 226, 242),
                    Maple2Storage.Types.Color.Argb(255, 195, 218, 61),
                    Maple2Storage.Types.Color.Argb(255, 89, 153, 165)
                    ),
                10, 19
                ),
                TransferFlag = TransferFlag.Binds | TransferFlag.Splitable,
            };
        }

        public static Item GreatSwordOutfit()
        {
            return new Item(15000118)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
            };
        }

        public static Item DaggerOutfit()
        {
            return new Item(13100177)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
            };
        }

        public static Item AlkimiEarring()
        {
            return new Item(11250042)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(MixedColor.Custom(
                    Maple2Storage.Types.Color.Argb(0xFF, 194, 209, 96),
                    Maple2Storage.Types.Color.Argb(0xFF, 0x4C, 0x85, 0xDB),
                    Maple2Storage.Types.Color.Argb(0xFF, 64, 104, 54)
                    ),
                10, 4
                ),
            };
        }

        public static Item AlkimiGloves()
        {
            return new Item(11600661)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(MixedColor.Custom(
                    Maple2Storage.Types.Color.Argb(255, 194, 209, 96),
                    Maple2Storage.Types.Color.Argb(255, 76, 133, 219),
                    Maple2Storage.Types.Color.Argb(255, 64, 104, 54)
                    ),
                10, 4
                ),
            };
        }

        public static Item ArcherEliteHat()
        {
            return new Item(11301364)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(MixedColor.Custom(
                    Maple2Storage.Types.Color.Argb(255, 194, 209, 96),
                    Maple2Storage.Types.Color.Argb(255, 76, 133, 219),
                    Maple2Storage.Types.Color.Argb(255, 64, 104, 54)
                    ),
                10, 4
                ),
            };
        }

        public static Item ArcherEliteClothes()
        {
            return new Item(12200561)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(MixedColor.Custom(
                    Maple2Storage.Types.Color.Argb(255, 119, 147, 68),
                    Maple2Storage.Types.Color.Argb(255, 76, 133, 219),
                    Maple2Storage.Types.Color.Argb(255, 32, 51, 30)
                    ),
                10, 4
                ),
            };
        }

        public static Item ArcherEliteShoes()
        {
            return new Item(11701344)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(MixedColor.Custom(
                    Maple2Storage.Types.Color.Argb(0xFF, 194, 209, 96),
                    Maple2Storage.Types.Color.Argb(255, 76, 133, 219),
                    Maple2Storage.Types.Color.Argb(0xFF, 64, 104, 54)
                    ),
                10, 4
                ),
            };
        }

        public static Item FairyHatFemale()
        {
            return new Item(11390942)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(MixedColor.Custom(
                    Maple2Storage.Types.Color.Argb(255, 170, 47, 47),
                    Maple2Storage.Types.Color.Argb(255, 76, 133, 219),
                    Maple2Storage.Types.Color.Argb(255, 96, 19, 19)
                    ),
                10, 4
                ),
            };
        }

        public static Item FairyHatMale()
        {
            return new Item(11390941)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(MixedColor.Custom(
                    Maple2Storage.Types.Color.Argb(255, 170, 47, 47),
                    Maple2Storage.Types.Color.Argb(255, 76, 133, 219),
                    Maple2Storage.Types.Color.Argb(255, 96, 19, 19)
                    ),
                10, 4
                ),
            };
        }

        public static Item FairyEarringFemale()
        {
            return new Item(11250090)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(MixedColor.Custom(
                    Maple2Storage.Types.Color.Argb(255, 180, 165, 248),
                    Maple2Storage.Types.Color.Argb(255, 76, 133, 219),
                    Maple2Storage.Types.Color.Argb(255, 108, 96, 176)
                    ),
                10, 4
                ),
            };
        }

        public static Item FairyEarringMale()
        {
            return new Item(11250077)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(MixedColor.Custom(
                    Maple2Storage.Types.Color.Argb(255, 180, 165, 248),
                    Maple2Storage.Types.Color.Argb(255, 76, 133, 219),
                    Maple2Storage.Types.Color.Argb(255, 108, 96, 176)
                    ),
                10, 4
                ),
            };
        }

        public static Item FairyCapeFemale()
        {
            return new Item(11850144)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(MixedColor.Custom(
                    Maple2Storage.Types.Color.Argb(255, 255, 168, 203),
                    Maple2Storage.Types.Color.Argb(255, 76, 133, 219),
                    Maple2Storage.Types.Color.Argb(255, 205, 86, 106)
                    ),
                10, 4
                ),
            };
        }

        public static Item FairyCapeMale()
        {
            return new Item(11850129)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(MixedColor.Custom(
                    Maple2Storage.Types.Color.Argb(255, 132, 130, 120),
                    Maple2Storage.Types.Color.Argb(255, 76, 133, 219),
                    Maple2Storage.Types.Color.Argb(255, 68, 68, 65)
                    ),
                10, 4
                ),
            };
        }

        public static Item FairyGlovesFemale()
        {
            return new Item(11604689)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(MixedColor.Custom(
                    Maple2Storage.Types.Color.Argb(255, 255, 168, 203),
                    Maple2Storage.Types.Color.Argb(255, 76, 133, 219),
                    Maple2Storage.Types.Color.Argb(255, 205, 86, 106)
                    ),
                10, 4
                ),
            };
        }

        public static Item FairyGlovesMale()
        {
            return new Item(11601003)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(MixedColor.Custom(
                    Maple2Storage.Types.Color.Argb(255, 63, 59, 51),
                    Maple2Storage.Types.Color.Argb(255, 76, 133, 219),
                    Maple2Storage.Types.Color.Argb(255, 20, 18, 15)
                    ),
                10, 4
                ),
            };
        }

        public static Item FairyClothFemale()
        {
            return new Item(12200495)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(MixedColor.Custom(
                    Maple2Storage.Types.Color.Argb(255, 126, 204, 247),
                    Maple2Storage.Types.Color.Argb(255, 76, 133, 219),
                    Maple2Storage.Types.Color.Argb(255, 72, 94, 168)
                    ),
                10, 4
                ),
            };
        }

        public static Item FairyClothMale()
        {
            return new Item(12200494)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(MixedColor.Custom(
                    Maple2Storage.Types.Color.Argb(255, 126, 204, 247),
                    Maple2Storage.Types.Color.Argb(255, 76, 133, 219),
                    Maple2Storage.Types.Color.Argb(255, 72, 94, 168)
                    ),
                10, 4
                ),
            };
        }

        public static Item FairyShoesFemale()
        {
            return new Item(11790934)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(MixedColor.Custom(
                    Maple2Storage.Types.Color.Argb(255, 255, 168, 203),
                    Maple2Storage.Types.Color.Argb(255, 76, 133, 219),
                    Maple2Storage.Types.Color.Argb(255, 205, 86, 106)
                    ),
                10, 4
                ),
            };
        }

        public static Item FairyShoesMale()
        {
            return new Item(11790933)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(MixedColor.Custom(
                    Maple2Storage.Types.Color.Argb(255, 63, 59, 51),
                    Maple2Storage.Types.Color.Argb(255, 76, 133, 219),
                    Maple2Storage.Types.Color.Argb(255, 20, 18, 15)
                    ),
                10, 4
                ),
            };
        }

        public static Item FlowerHatFemale()
        {
            return new Item(11301105)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(MixedColor.Custom(
                    Maple2Storage.Types.Color.Argb(255, 76, 105, 181),
                    Maple2Storage.Types.Color.Argb(255, 76, 133, 219),
                    Maple2Storage.Types.Color.Argb(255, 23, 40, 79)
                    ),
                10, 4
                ),
            };
        }

        public static Item FlowerEarringFemale()
        {
            return new Item(11250086)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(MixedColor.Custom(
                    Maple2Storage.Types.Color.Argb(255, 76, 105, 181),
                    Maple2Storage.Types.Color.Argb(255, 76, 133, 219),
                    Maple2Storage.Types.Color.Argb(255, 23, 40, 79)
                    ),
                10, 4
                ),
            };
        }

        public static Item FlowerGlovesFemale()
        {
            return new Item(11601018)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(MixedColor.Custom(
                    Maple2Storage.Types.Color.Argb(255, 76, 105, 181),
                    Maple2Storage.Types.Color.Argb(255, 76, 133, 219),
                    Maple2Storage.Types.Color.Argb(255, 23, 40, 79)
                    ),
                10, 4
                ),
            };
        }

        public static Item FlowerClothFemale()
        {
            return new Item(12200506)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(MixedColor.Custom(
                    Maple2Storage.Types.Color.Argb(255, 76, 105, 181),
                    Maple2Storage.Types.Color.Argb(255, 76, 133, 219),
                    Maple2Storage.Types.Color.Argb(255, 23, 40, 79)
                    ),
                10, 4
                ),
            };
        }

        public static Item FlowerShoesFemale()
        {
            return new Item(11701093)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(MixedColor.Custom(
                    Maple2Storage.Types.Color.Argb(255, 76, 105, 181),
                    Maple2Storage.Types.Color.Argb(255, 76, 133, 219),
                    Maple2Storage.Types.Color.Argb(255, 23, 40, 79)
                    ),
                10, 4
                ),
            };
        }

        public static Item Glasses()
        {
            return new Item(11120401)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
            };
        }

        public static Item LongSkirt()
        {
            return new Item(11500252)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(MixedColor.Custom(
                    Maple2Storage.Types.Color.Argb(255, 133, 81, 165),
                    Maple2Storage.Types.Color.Argb(255, 76, 133, 219),
                    Maple2Storage.Types.Color.Argb(255, 53, 42, 71)
                    ),
                10, 4
                ),
            };
        }

        public static Item MaleSkirt()
        {
            return new Item(12200208)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(MixedColor.Custom(
                    Maple2Storage.Types.Color.Argb(255, 230, 230, 230),
                    Maple2Storage.Types.Color.Argb(255, 76, 133, 219),
                    Maple2Storage.Types.Color.Argb(255, 150, 150, 150)
                    ),
                10, 4
                ),
            };
        }

        public static Item MapleArmorHat()
        {
            return new Item(11300742)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(MixedColor.Custom(
                    Maple2Storage.Types.Color.Argb(255, 244, 189, 88),
                    Maple2Storage.Types.Color.Argb(255, 76, 133, 219),
                    Maple2Storage.Types.Color.Argb(255, 163, 121, 39)
                    ),
                10, 4
                ),
            };
        }

        public static Item MapleArmorCape()
        {
            return new Item(11850079)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(MixedColor.Custom(
                    Maple2Storage.Types.Color.Argb(255, 244, 189, 88),
                    Maple2Storage.Types.Color.Argb(255, 76, 133, 219),
                    Maple2Storage.Types.Color.Argb(255, 163, 121, 39)
                    ),
                10, 4
                ),
            };
        }

        public static Item MapleArmorGloves()
        {
            return new Item(11600665)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(MixedColor.Custom(
                    Maple2Storage.Types.Color.Argb(255, 244, 189, 88),
                    Maple2Storage.Types.Color.Argb(255, 76, 133, 219),
                    Maple2Storage.Types.Color.Argb(255, 163, 121, 39)
                    ),
                10, 4
                ),
            };
        }

        public static Item MapleArmorSuit()
        {
            return new Item(12200362)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(MixedColor.Custom(
                    Maple2Storage.Types.Color.Argb(255, 244, 189, 88),
                    Maple2Storage.Types.Color.Argb(255, 76, 133, 219),
                    Maple2Storage.Types.Color.Argb(255, 163, 121, 39)
                    ),
                10, 4
                ),
            };
        }

        public static Item MapleArmorShoes()
        {
            return new Item(11700719)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(MixedColor.Custom(
                    Maple2Storage.Types.Color.Argb(255, 244, 189, 88),
                    Maple2Storage.Types.Color.Argb(255, 76, 133, 219),
                    Maple2Storage.Types.Color.Argb(255, 163, 121, 39)
                    ),
                10, 4
                ),
            };
        }

        public static Item PerionHat()
        {
            return new Item(11301152)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(MixedColor.Custom(
                    Maple2Storage.Types.Color.Argb(255, 147, 226, 242),
                    Maple2Storage.Types.Color.Argb(255, 76, 133, 219),
                    Maple2Storage.Types.Color.Argb(255, 89, 153, 165)
                    ),
                10, 4
                ),
            };
        }

        public static Item PerionEarring()
        {
            return new Item(11200087)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(MixedColor.Custom(
                    Maple2Storage.Types.Color.Argb(255, 170, 47, 47),
                    Maple2Storage.Types.Color.Argb(255, 76, 133, 219),
                    Maple2Storage.Types.Color.Argb(255, 96, 19, 19)
                    ),
                10, 4
                ),
            };
        }

        public static Item PerionGlovesFemale()
        {
            return new Item(11601054)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(MixedColor.Custom(
                    Maple2Storage.Types.Color.Argb(255, 122, 92, 77),
                    Maple2Storage.Types.Color.Argb(255, 76, 133, 219),
                    Maple2Storage.Types.Color.Argb(255, 53, 39, 29)
                    ),
                10, 4
                ),
            };
        }

        public static Item PerionGlovesMale()
        {
            return new Item(11601053)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(MixedColor.Custom(
                    Maple2Storage.Types.Color.Argb(255, 122, 92, 77),
                    Maple2Storage.Types.Color.Argb(255, 76, 133, 219),
                    Maple2Storage.Types.Color.Argb(255, 53, 39, 29)
                    ),
                10, 4
                ),
            };
        }

        public static Item PerionClothFemale()
        {
            return new Item(12200538)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(MixedColor.Custom(
                    Maple2Storage.Types.Color.Argb(255, 147, 226, 242),
                    Maple2Storage.Types.Color.Argb(255, 76, 133, 219),
                    Maple2Storage.Types.Color.Argb(255, 89, 153, 165)
                    ),
                10, 4
                ),
            };
        }

        public static Item PerionClothMale()
        {
            return new Item(12200537)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(MixedColor.Custom(
                    Maple2Storage.Types.Color.Argb(255, 147, 226, 242),
                    Maple2Storage.Types.Color.Argb(255, 76, 133, 219),
                    Maple2Storage.Types.Color.Argb(255, 89, 153, 165)
                    ),
                10, 4
                ),
            };
        }

        public static Item PerionShoesFemale()
        {
            return new Item(11701135)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(MixedColor.Custom(
                    Maple2Storage.Types.Color.Argb(255, 122, 92, 77),
                    Maple2Storage.Types.Color.Argb(255, 76, 133, 219),
                    Maple2Storage.Types.Color.Argb(255, 53, 39, 29)
                    ),
                10, 4
                ),
            };
        }

        public static Item PerionShoesMale()
        {
            return new Item(11701134)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(MixedColor.Custom(
                    Maple2Storage.Types.Color.Argb(255, 122, 92, 77),
                    Maple2Storage.Types.Color.Argb(255, 76, 133, 219),
                    Maple2Storage.Types.Color.Argb(255, 53, 39, 29)
                    ),
                10, 4
                ),
            };
        }

        public static Item PriestHat()
        {
            return new Item(11300083)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(MixedColor.Custom(
                    Maple2Storage.Types.Color.Argb(255, 194, 209, 96),
                    Maple2Storage.Types.Color.Argb(255, 76, 133, 219),
                    Maple2Storage.Types.Color.Argb(255, 64, 104, 54)
                    ),
                10, 4
                ),
            };
        }

        public static Item PriestClothes()
        {
            return new Item(12200029)
            {
                Uid = 2754959794416496484,
                CreationTime = 1558494660,
                Color = EquipColor.Custom(MixedColor.Custom(
                    Maple2Storage.Types.Color.Argb(255, 194, 209, 96),
                    Maple2Storage.Types.Color.Argb(255, 76, 133, 219),
                    Maple2Storage.Types.Color.Argb(255, 64, 104, 54)
                    ),
                10, 4
                ),
            };
        }

        public static Item PriestShoes()
        {
            return new Item(11700073)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(MixedColor.Custom(
                    Maple2Storage.Types.Color.Argb(255, 194, 209, 96),
                    Maple2Storage.Types.Color.Argb(255, 76, 133, 219),
                    Maple2Storage.Types.Color.Argb(255, 64, 104, 54)
                    ),
                10, 4
                ),
            };
        }

        public static Item PriestEliteHat()
        {
            return new Item(11361388)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(MixedColor.Custom(
                    Maple2Storage.Types.Color.Argb(255, 194, 209, 96),
                    Maple2Storage.Types.Color.Argb(255, 76, 133, 219),
                    Maple2Storage.Types.Color.Argb(255, 64, 104, 54)
                    ),
                10, 4
                ),
            };
        }

        public static Item PriestEliteClothes()
        {
            return new Item(12200560)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(MixedColor.Custom(
                    Maple2Storage.Types.Color.Argb(255, 119, 147, 68),
                    Maple2Storage.Types.Color.Argb(255, 76, 133, 219),
                    Maple2Storage.Types.Color.Argb(255, 32, 51, 30)
                    ),
                10, 4
                ),
            };
        }

        public static Item PriestEliteShoes()
        {
            return new Item(11701236)
            {
                Uid = 2754959794416496484,
                CreationTime = 1558494660,
                Color = EquipColor.Custom(MixedColor.Custom(
                    Maple2Storage.Types.Color.Argb(255, 194, 209, 96),
                    Maple2Storage.Types.Color.Argb(255, 76, 133, 219),
                    Maple2Storage.Types.Color.Argb(255, 64, 104, 54)
                    ),
                 10, 4
                 ),
            };
        }

        public static Item Shirt()
        {
            return new Item(11400901)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(MixedColor.Custom(
                    Maple2Storage.Types.Color.Argb(255, 133, 81, 165),
                    Maple2Storage.Types.Color.Argb(255, 76, 133, 219),
                    Maple2Storage.Types.Color.Argb(255, 53, 42, 71)
                    ),
                10, 4
                ),
            };
        }

        public static Item SnowTailHatFemale()
        {
            return new Item(11301245)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(MixedColor.Custom(
                    Maple2Storage.Types.Color.Argb(255, 76, 105, 181),
                    Maple2Storage.Types.Color.Argb(255, 76, 133, 219),
                    Maple2Storage.Types.Color.Argb(255, 23, 40, 79)
                    ),
                10, 4
                ),
            };
        }

        public static Item SnowTailHatMale()
        {
            return new Item(11301244)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(MixedColor.Custom(
                    Maple2Storage.Types.Color.Argb(255, 76, 105, 181),
                    Maple2Storage.Types.Color.Argb(255, 76, 133, 219),
                    Maple2Storage.Types.Color.Argb(255, 23, 40, 79)
                    ),
                10, 4
                ),
            };
        }

        public static Item SnowTailEarringFemale()
        {
            return new Item(11250110)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(MixedColor.Custom(
                    Maple2Storage.Types.Color.Argb(255, 76, 105, 181),
                    Maple2Storage.Types.Color.Argb(255, 76, 133, 219),
                    Maple2Storage.Types.Color.Argb(255, 23, 40, 79)
                    ),
                10, 4
                ),
            };
        }

        public static Item SnowTailEarringMale()
        {
            return new Item(11250109)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(MixedColor.Custom(
                    Maple2Storage.Types.Color.Argb(255, 76, 105, 181),
                    Maple2Storage.Types.Color.Argb(255, 76, 133, 219),
                    Maple2Storage.Types.Color.Argb(255, 23, 40, 79)
                    ),
                10, 4
                ),
            };
        }

        public static Item SnowTailCapeFemale()
        {
            return new Item(11850164)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(MixedColor.Custom(
                    Maple2Storage.Types.Color.Argb(255, 76, 105, 181),
                    Maple2Storage.Types.Color.Argb(255, 76, 133, 219),
                    Maple2Storage.Types.Color.Argb(255, 23, 40, 79)
                    ),
                10, 4
                ),
            };
        }

        public static Item SnowTailCapeMale()
        {
            return new Item(11850163)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(MixedColor.Custom(
                    Maple2Storage.Types.Color.Argb(255, 76, 105, 181),
                    Maple2Storage.Types.Color.Argb(255, 76, 133, 219),
                    Maple2Storage.Types.Color.Argb(255, 23, 40, 79)
                    ),
                10, 4
                ),
            };
        }

        public static Item SnowTailGlovesFemale()
        {
            return new Item(11601145)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(MixedColor.Custom(
                    Maple2Storage.Types.Color.Argb(255, 76, 105, 181),
                    Maple2Storage.Types.Color.Argb(255, 76, 133, 219),
                    Maple2Storage.Types.Color.Argb(255, 23, 40, 79)
                    ),
                10, 4
                ),
            };
        }

        public static Item SnowTailGlovesMale()
        {
            return new Item(11601144)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(MixedColor.Custom(
                    Maple2Storage.Types.Color.Argb(255, 76, 105, 181),
                    Maple2Storage.Types.Color.Argb(255, 76, 133, 219),
                    Maple2Storage.Types.Color.Argb(255, 23, 40, 79)
                    ),
                10, 4
                ),
            };
        }

        public static Item SnowTailClothFemale()
        {
            return new Item(12200540)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(MixedColor.Custom(
                    Maple2Storage.Types.Color.Argb(255, 76, 105, 181),
                    Maple2Storage.Types.Color.Argb(255, 76, 133, 219),
                    Maple2Storage.Types.Color.Argb(255, 23, 40, 79)
                    ),
                10, 4
                ),
            };
        }

        public static Item SnowTailClothMale()
        {
            return new Item(12200539)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(MixedColor.Custom(
                    Maple2Storage.Types.Color.Argb(255, 76, 105, 181),
                    Maple2Storage.Types.Color.Argb(255, 76, 133, 219),
                    Maple2Storage.Types.Color.Argb(255, 23, 40, 79)
                    ),
                10, 4
                ),
            };
        }

        public static Item SnowTailShoesFemale()
        {
            return new Item(11701226)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(MixedColor.Custom(
                    Maple2Storage.Types.Color.Argb(255, 76, 105, 181),
                    Maple2Storage.Types.Color.Argb(255, 76, 133, 219),
                    Maple2Storage.Types.Color.Argb(255, 23, 40, 79)
                    ),
                10, 4
                ),
            };
        }

        public static Item SnowTailShoesMale()
        {
            return new Item(11701225)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(MixedColor.Custom(
                    Maple2Storage.Types.Color.Argb(255, 76, 105, 181),
                    Maple2Storage.Types.Color.Argb(255, 76, 133, 219),
                    Maple2Storage.Types.Color.Argb(255, 23, 40, 79)
                    ),
                10, 4
                ),
            };
        }

        public static Item TriaChefFemale()
        {
            return new Item(12200666)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(MixedColor.Custom(
                    Maple2Storage.Types.Color.Argb(255, 119, 147, 68),
                    Maple2Storage.Types.Color.Argb(255, 76, 133, 219),
                    Maple2Storage.Types.Color.Argb(255, 32, 51, 30)
                    ),
                10, 4
                ),
            };
        }

        public static Item TriaChefShoesFemale()
        {
            return new Item(11710049)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(MixedColor.Custom(
                    Maple2Storage.Types.Color.Argb(255, 119, 147, 68),
                    Maple2Storage.Types.Color.Argb(255, 76, 133, 219),
                    Maple2Storage.Types.Color.Argb(255, 32, 51, 30)
                    ),
                10, 4
                ),
            };
        }

        public static Item WeddingHatFemale()
        {
            return new Item(11301376)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(MixedColor.Custom(
                    Maple2Storage.Types.Color.Argb(255, 230, 230, 230),
                    Maple2Storage.Types.Color.Argb(255, 76, 133, 219),
                    Maple2Storage.Types.Color.Argb(255, 150, 150, 150)
                    ),
                10, 4
                ),
            };
        }

        public static Item WeddingHatMale()
        {
            return new Item(11301375)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
            };
        }

        public static Item WeddingEarringFemale()
        {
            return new Item(11250124)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(MixedColor.Custom(
                    Maple2Storage.Types.Color.Argb(255, 230, 230, 230),
                    Maple2Storage.Types.Color.Argb(255, 76, 133, 219),
                    Maple2Storage.Types.Color.Argb(255, 150, 150, 150)
                    ),
                10, 4
                ),
            };
        }

        public static Item WeddingEarringMale()
        {
            return new Item(11250123)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(MixedColor.Custom(
                    Maple2Storage.Types.Color.Argb(255, 230, 230, 230),
                    Maple2Storage.Types.Color.Argb(255, 76, 133, 219),
                    Maple2Storage.Types.Color.Argb(255, 150, 150, 150)
                    ),
                10, 4
                ),
            };
        }

        public static Item WeddingMouthFemale()
        {
            return new Item(11050054)
            {
                Uid = 2754959794416496484,
                CreationTime = 1558494660,
                Color = EquipColor.Custom(MixedColor.Custom(
                    Maple2Storage.Types.Color.Argb(255, 255, 168, 203),
                    Maple2Storage.Types.Color.Argb(255, 247, 227, 227),
                    Maple2Storage.Types.Color.Argb(255, 205, 86, 106)
                    ),
                10, 4
                ),
            };
        }

        public static Item WeddingMouthMale()
        {
            return new Item(11050053)
            {
                Uid = 2754959794416496484,
                CreationTime = 1558494660,
                Color = EquipColor.Custom(MixedColor.Custom(
                    Maple2Storage.Types.Color.Argb(255, 255, 168, 203),
                    Maple2Storage.Types.Color.Argb(255, 247, 227, 227),
                    Maple2Storage.Types.Color.Argb(255, 205, 86, 106)
                    ),
                10, 4
                ),
            };
        }

        public static Item WeddingGlovesFemale()
        {
            return new Item(11610014)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(MixedColor.Custom(
                    Maple2Storage.Types.Color.Argb(255, 230, 230, 230),
                    Maple2Storage.Types.Color.Argb(255, 76, 133, 219),
                    Maple2Storage.Types.Color.Argb(255, 150, 150, 150)
                    ),
                10, 4
                ),
            };
        }

        public static Item WeddingGlovesMale()
        {
            return new Item(11610013)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(MixedColor.Custom(
                    Maple2Storage.Types.Color.Argb(255, 230, 230, 230),
                    Maple2Storage.Types.Color.Argb(255, 76, 133, 219),
                    Maple2Storage.Types.Color.Argb(255, 150, 150, 150)
                    ),
                10, 4
                ),
            };
        }

        public static Item WeddingClothesFemale()
        {
            return new Item(12200570)
            {
                Uid = 2754959794416496484,
                CreationTime = 1558494660,
                Color = EquipColor.Custom(MixedColor.Custom(
                    Maple2Storage.Types.Color.Argb(255, 255, 168, 203),
                    Maple2Storage.Types.Color.Argb(255, 247, 227, 227),
                    Maple2Storage.Types.Color.Argb(255, 180, 165, 248)
                    ),
                10, 4
                ),
            };
        }

        public static Item WeddingClothesMale()
        {
            return new Item(12200569)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(MixedColor.Custom(
                    Maple2Storage.Types.Color.Argb(255, 230, 230, 230),
                    Maple2Storage.Types.Color.Argb(255, 247, 227, 227),
                    Maple2Storage.Types.Color.Argb(255, 150, 150, 150)
                    ),
                10, 4
                ),
            };
        }

        public static Item WeddingShoesFemale()
        {
            return new Item(11710028)
            {
                Uid = 2754959794416496484,
                CreationTime = 1558494660,
                Color = EquipColor.Custom(MixedColor.Custom(
                    Maple2Storage.Types.Color.Argb(255, 230, 230, 230),
                    Maple2Storage.Types.Color.Argb(255, 247, 227, 227),
                    Maple2Storage.Types.Color.Argb(255, 150, 150, 150)
                    ),
                10, 4
                ),
            };
        }

        public static Item WeddingShoesMale()
        {
            return new Item(11710027)
            {
                Uid = 2754959794416496484,
                CreationTime = 1558494660,
                Color = EquipColor.Custom(MixedColor.Custom(
                    Maple2Storage.Types.Color.Argb(255, 63, 59, 51),
                    Maple2Storage.Types.Color.Argb(255, 247, 227, 227),
                    Maple2Storage.Types.Color.Argb(255, 20, 18, 15)
                    ),
                10, 4
                ),
            };
        }

        public bool TrySplit(int amount, out Item splitItem)
        {
            if (Amount <= amount)
            {
                splitItem = null;
                return false;
            }

            splitItem = new Item(this);
            Amount -= amount;
            splitItem.Amount = amount;
            splitItem.Slot = -1;
            splitItem.Uid = Environment.TickCount64;
            return true;
        }

        public static bool IsWeapon(ItemSlot slot)
        {
            return slot == ItemSlot.RH || slot == ItemSlot.LH || slot == ItemSlot.OH;
        }

        public static bool IsAccessory(ItemSlot slot)
        {
            return slot == ItemSlot.FH || slot == ItemSlot.EA || slot == ItemSlot.PD || slot == ItemSlot.RI || slot == ItemSlot.BE;
        }

        public static bool IsArmor(ItemSlot slot)
        {
            return slot == ItemSlot.CP || slot == ItemSlot.CL || slot == ItemSlot.PA || slot == ItemSlot.GL || slot == ItemSlot.SH || slot == ItemSlot.MT;
        }

        public static bool IsPet(int itemId)
        {
            return itemId >= 60000001 && itemId < 61000000;
        }
    }
}
