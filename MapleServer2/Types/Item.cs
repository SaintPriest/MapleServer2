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

        public Player Owner;

        public EquipColor Color;

        public HairData HairD;

        public byte[] FaceDecorationD;
        public byte AppearanceFlag;

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
            Enchants = other.Enchants;
            EnchantExp = other.EnchantExp;
            CanRepackage = other.CanRepackage;
            Charges = other.Charges;
            TransferFlag = other.TransferFlag;
            RemainingTrades = other.RemainingTrades;
            PairedCharacterId = other.PairedCharacterId;
            PairedCharacterName = other.PairedCharacterName;
            Owner = other.Owner;
            Color = other.Color;
            HairD = other.HairD;
            AppearanceFlag = other.AppearanceFlag;
            Score = new MusicScore();
            Stats = new ItemStats(other.Stats);
        }

        public static Item Ear()
        {
            return new Item(10500001)
            {
                Uid = 2754959794416496488,
                CreationTime = 1558494660,
                Color = new EquipColor(),
            };
        }

        public static Item Hair()
        {
            return new Item(10200238) // 10200085 10200148 10200238
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(
                    Maple2Storage.Types.Color.Argb(0xFF, 194, 209, 96),
                    Maple2Storage.Types.Color.Argb(0xFF, 0x4C, 0x85, 0xDB),
                    Maple2Storage.Types.Color.Argb(0xFF, 64, 104, 54),
                    15
                ),
                HairD = new HairData(1.0f, 1.0f, new CoordF(), new CoordF(), new CoordF(), new CoordF()),
                AppearanceFlag = 2,
            };
        }

        public static Item Face()
        {
            return new Item(10300036)
            {
                Uid = 2754959794416496483,
                CreationTime = 1558494660,
                Color = EquipColor.Custom(
                     Maple2Storage.Types.Color.Argb(0xFF, 84, 127, 8),
                     Maple2Storage.Types.Color.Argb(0xFF, 0xF7, 0xE3, 0xE3),
                     Maple2Storage.Types.Color.Argb(0xFF, 8, 15, 0),
                     0
                 ),
                AppearanceFlag = 3,
            };
        }

        public static Item FaceDecoration()
        {
            return new Item(10400000)
            {
                Uid = 2754959794416496484,
                CreationTime = 1558494660,
                Color = new EquipColor(),
                FaceDecorationD = new byte[16],
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
                Color = EquipColor.Custom(
                    Maple2Storage.Types.Color.Argb(0xFF, 230, 230, 230),
                    Maple2Storage.Types.Color.Argb(0xFF, 0xC3, 0xDA, 0x3D),
                    Maple2Storage.Types.Color.Argb(0xFF, 150, 150, 150),
                    0x13
                ),
                AppearanceFlag = 0x5,
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
                Color = EquipColor.Custom(
                    Maple2Storage.Types.Color.Argb(0xFF, 239, 112, 145),
                    Maple2Storage.Types.Color.Argb(0xFF, 0xC3, 0xDA, 0x3D),
                    Maple2Storage.Types.Color.Argb(0xFF, 153, 66, 82),
                    0x13
                ),
                AppearanceFlag = 0x5,
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
                Color = EquipColor.Custom(
                    Maple2Storage.Types.Color.Argb(0xFF, 147, 226, 242),
                    Maple2Storage.Types.Color.Argb(0xFF, 0xC3, 0xDA, 0x3D),
                    Maple2Storage.Types.Color.Argb(0xFF, 89, 153, 165),
                    0x13
                ),
                AppearanceFlag = 0x5,
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
                Color = EquipColor.Custom(
                    Maple2Storage.Types.Color.Argb(0xFF, 147, 226, 242),
                    Maple2Storage.Types.Color.Argb(0xFF, 0xC3, 0xDA, 0x3D),
                    Maple2Storage.Types.Color.Argb(0xFF, 89, 153, 165),
                    0x13
                ),
                AppearanceFlag = 0x5,
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
                Color = EquipColor.Custom(
                    Maple2Storage.Types.Color.Argb(0xFF, 147, 226, 242),
                    Maple2Storage.Types.Color.Argb(0xFF, 0xC3, 0xDA, 0x3D),
                    Maple2Storage.Types.Color.Argb(0xFF, 89, 153, 165),
                    0x13
                ),
                AppearanceFlag = 0x5,
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

        public static Item Staff(Player owner)
        {
            return new Item(15200016)
            {
                Uid = 3430503306390578751,
                Rarity = 2,
                CreationTime = DateTimeOffset.UtcNow.ToUnixTimeSeconds(),
                Owner = owner,
                AppearanceFlag = 0x5,
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
                Color = EquipColor.Custom(
                    Maple2Storage.Types.Color.Argb(0xFF, 147, 226, 242),
                    Maple2Storage.Types.Color.Argb(0xFF, 0xC3, 0xDA, 0x3D),
                    Maple2Storage.Types.Color.Argb(0xFF, 89, 153, 165),
                    0x13
                ),
                AppearanceFlag = 0x5,
                TransferFlag = TransferFlag.Binds | TransferFlag.Splitable,
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

        public static Item Bow(Player owner)
        {
            // bow 15100216, Tairen Officer bow 15100302
            // [longsword]  Tairen Royal Longsword - 13200309
            // [shield] Tairen Royal Shield - 14100279
            // [greatsword] Tairen Royal Greatsword - 15000313
            // [scepter] Tairen Royal Scepter - 13300308
            // [codex] Tairen Royal Codex - 14000270
            // [staff] Tairen Royal Staff - 15200312
            // [cannon]  - 15300288
            // [bow] Tairen Royal Bow - 15100305
            // [dagger] Tairen Royal Knife - 13100314
            // [star] Tairen Royal Star - 13400307
            // [blade] Tairen Royal Blade - 15400294
            // [knuckles] Tairen Royal Knuckles - 15500226
            // [orb]  - 15600229
            return new Item(15100302)
            {
                Uid = 3430503306390578751, // Make sure its unique! If the UID is equipped, it will say "Equipped" on the item in your inventory
                Rarity = 4,
                CreationTime = DateTimeOffset.UtcNow.ToUnixTimeSeconds(),
                Owner = owner,
                Color = EquipColor.Custom(
                    Maple2Storage.Types.Color.Argb(0xFF, 147, 226, 242),
                    Maple2Storage.Types.Color.Argb(0xFF, 0xC3, 0xDA, 0x3D),
                    Maple2Storage.Types.Color.Argb(0xFF, 89, 153, 165),
                    0x13
                ),
                AppearanceFlag = 0x5,
                TransferFlag = TransferFlag.Binds | TransferFlag.Splitable,
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

        public static Item MaleSkirt()
        {
            return new Item(12200208)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(
                   Maple2Storage.Types.Color.Argb(0xFF, 230, 230, 230),
                    Maple2Storage.Types.Color.Argb(0xFF, 0x4C, 0x85, 0xDB),
                    Maple2Storage.Types.Color.Argb(0xFF, 150, 150, 150),
                    0
                ),
            };
        }

        public static Item Shirt()
        {
            return new Item(11400901)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(
                    Maple2Storage.Types.Color.Argb(0xFF, 133, 81, 165),
                    Maple2Storage.Types.Color.Argb(0xFF, 0x4C, 0x85, 0xDB),
                    Maple2Storage.Types.Color.Argb(0xFF, 53, 42, 71),
                    0
                ),
            };
        }

        public static Item LongSkirt()
        {
            return new Item(11500252)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(
                    Maple2Storage.Types.Color.Argb(0xFF, 133, 81, 165),
                    Maple2Storage.Types.Color.Argb(0xFF, 0x4C, 0x85, 0xDB),
                    Maple2Storage.Types.Color.Argb(0xFF, 53, 42, 71),
                    0
                ),
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
                Color = EquipColor.Custom(
                    Maple2Storage.Types.Color.Argb(0xFF, 194, 209, 96),
                    Maple2Storage.Types.Color.Argb(0xFF, 0xC3, 0xDA, 0x3D),
                    Maple2Storage.Types.Color.Argb(0xFF, 64, 104, 54),
                    0x13
                ),
                AppearanceFlag = 0x5,
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
                Color = EquipColor.Custom(
                    Maple2Storage.Types.Color.Argb(0xFF, 126, 204, 247),
                    Maple2Storage.Types.Color.Argb(0xFF, 0xC3, 0xDA, 0x3D),
                    Maple2Storage.Types.Color.Argb(0xFF, 72, 94, 168),
                    0x13
                ),
                AppearanceFlag = 0x5,
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
                Color = EquipColor.Custom(
                    Maple2Storage.Types.Color.Argb(0xFF, 147, 226, 242),
                    Maple2Storage.Types.Color.Argb(0xFF, 0xC3, 0xDA, 0x3D),
                    Maple2Storage.Types.Color.Argb(0xFF, 89, 153, 165),
                    0x13
                ),
                AppearanceFlag = 0x5,
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
                Color = EquipColor.Custom(
                    Maple2Storage.Types.Color.Argb(0xFF, 194, 209, 96),
                    Maple2Storage.Types.Color.Argb(0xFF, 0xC3, 0xDA, 0x3D),
                    Maple2Storage.Types.Color.Argb(0xFF, 64, 104, 54),
                    0x13
                ),
                AppearanceFlag = 0x5,
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
                Color = EquipColor.Custom(
                    Maple2Storage.Types.Color.Argb(0xFF, 147, 226, 242),
                    Maple2Storage.Types.Color.Argb(0xFF, 0xC3, 0xDA, 0x3D),
                    Maple2Storage.Types.Color.Argb(0xFF, 89, 153, 165),
                    0x13
                ),
                AppearanceFlag = 0x5,
                TransferFlag = TransferFlag.Binds | TransferFlag.Splitable,
            };
        }

        public static Item HairMale()
        {
            return new Item(10200003)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(
                    Maple2Storage.Types.Color.Argb(0xFF, 0198, 198, 193),
                    Maple2Storage.Types.Color.Argb(0xFF, 0x4C, 0x85, 0xDB),
                    Maple2Storage.Types.Color.Argb(0xFF, 149, 149, 143),
                    0
                ),
                AppearanceFlag = 2,
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
        public static Item AlkimiEarring()
        {
            return new Item(11250042)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(
                    Maple2Storage.Types.Color.Argb(0xFF, 194, 209, 96),
                    Maple2Storage.Types.Color.Argb(0xFF, 0x4C, 0x85, 0xDB),
                    Maple2Storage.Types.Color.Argb(0xFF, 64, 104, 54),
                    0
                ),
            };
        }
        public static Item FaceMale()
        {
            return new Item(10300035)
            {
                Uid = 2754959794416496483,
                CreationTime = 1558494660,
                Color = EquipColor.Custom(
                    Maple2Storage.Types.Color.Argb(0xFF, 84, 127, 8),
                    Maple2Storage.Types.Color.Argb(0xFF, 0xF7, 0xE3, 0xE3),
                    Maple2Storage.Types.Color.Argb(0xFF, 8, 15, 0),
                    0
                ),
                AppearanceFlag = 3,
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
        public static Item PriestEliteClothes()
        {
            return new Item(12200560)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(
                    Maple2Storage.Types.Color.Argb(0xFF, 119, 147, 68),
                    Maple2Storage.Types.Color.Argb(0xFF, 0x4C, 0x85, 0xDB),
                    Maple2Storage.Types.Color.Argb(0xFF, 32, 51, 30),
                    4
                ),
            };
        }
        public static Item PriestEliteShoes()
        {
            return new Item(11701236)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(
                    Maple2Storage.Types.Color.Argb(0xFF, 194, 209, 96),
                    Maple2Storage.Types.Color.Argb(0xFF, 0x4C, 0x85, 0xDB),
                    Maple2Storage.Types.Color.Argb(0xFF, 64, 104, 54),
                    0
                 ),
            };
        }

        public static Item ArcherEliteHat()
        {
            return new Item(11301364)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(
                    Maple2Storage.Types.Color.Argb(0xFF, 194, 209, 96),
                    Maple2Storage.Types.Color.Argb(0xFF, 0x4C, 0x85, 0xDB),
                    Maple2Storage.Types.Color.Argb(0xFF, 64, 104, 54),
                    0
                 ),
            };
        }

        public static Item ArcherEliteClothes()
        {
            return new Item(12200561)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(
                    Maple2Storage.Types.Color.Argb(0xFF, 119, 147, 68),
                    Maple2Storage.Types.Color.Argb(0xFF, 0x4C, 0x85, 0xDB),
                    Maple2Storage.Types.Color.Argb(0xFF, 32, 51, 30),
                    4
                ),
            };
        }

        public static Item ArcherEliteShoes()
        {
            return new Item(11701344)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(
                    Maple2Storage.Types.Color.Argb(0xFF, 194, 209, 96),
                    Maple2Storage.Types.Color.Argb(0xFF, 0x4C, 0x85, 0xDB),
                    Maple2Storage.Types.Color.Argb(0xFF, 64, 104, 54),
                    0
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

        public static Item WeddingHatMale()
        {
            return new Item(11301375)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
            };
        }

        public static Item WeddingHatFemale()
        {
            return new Item(11301376)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(
                   Maple2Storage.Types.Color.Argb(0xFF, 230, 230, 230),
                    Maple2Storage.Types.Color.Argb(0xFF, 0x4C, 0x85, 0xDB),
                    Maple2Storage.Types.Color.Argb(0xFF, 150, 150, 150),
                    0
                ),
            };
        }

        public static Item AlkimiGloves()
        {
            return new Item(11600661)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(
                   Maple2Storage.Types.Color.Argb(0xFF, 194, 209, 96),
                    Maple2Storage.Types.Color.Argb(0xFF, 0x4C, 0x85, 0xDB),
                    Maple2Storage.Types.Color.Argb(0xFF, 64, 104, 54),
                    0
                ),
            };
        }
        public static Item MouthMale()
        {
            return new Item(11050067)
            {
                Uid = 2754959794416496484,
                CreationTime = 1558494660,
                Color = EquipColor.Custom(
                    Maple2Storage.Types.Color.Argb(0xFF, 255, 168, 203),
                    Maple2Storage.Types.Color.Argb(0xFF, 0xF7, 0xE3, 0xE3),
                    Maple2Storage.Types.Color.Argb(0xFF, 205, 86, 106),
                    4
                ),
            };
        }

        public static Item Mouth()
        {
            return new Item(11050054)
            {
                Uid = 2754959794416496484,
                CreationTime = 1558494660,
                Color = EquipColor.Custom(
                    Maple2Storage.Types.Color.Argb(0xFF, 255, 168, 203),
                    Maple2Storage.Types.Color.Argb(0xFF, 0xF7, 0xE3, 0xE3),
                    Maple2Storage.Types.Color.Argb(0xFF, 205, 86, 106),
                    4
                ),
            };
        }

        public static Item WeddingClothesFemale()
        {
            return new Item(12200570)
            {
                Uid = 2754959794416496484,
                CreationTime = 1558494660,
                Color = EquipColor.Custom(
                    Maple2Storage.Types.Color.Argb(0xFF, 255, 168, 203),
                    Maple2Storage.Types.Color.Argb(0xFF, 0xF7, 0xE3, 0xE3),
                    Maple2Storage.Types.Color.Argb(0xFF, 180, 165, 248),
                    4
                )
            };
        }

        public static Item WeddingClothesMale()
        {
            return new Item(12200569)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(
                   Maple2Storage.Types.Color.Argb(0xFF, 230, 230, 230),
                    Maple2Storage.Types.Color.Argb(0xFF, 0x4C, 0x85, 0xDB),
                    Maple2Storage.Types.Color.Argb(0xFF, 150, 150, 150),
                    0
                ),
            };
        }

        public static Item PriestClothes()
        {
            return new Item(12200029)
            {
                Uid = 2754959794416496484,
                CreationTime = 1558494660,
                Color = EquipColor.Custom(
                    Maple2Storage.Types.Color.Argb(0xFF, 194, 209, 96),
                    Maple2Storage.Types.Color.Argb(0xFF, 0xF7, 0xE3, 0xE3),
                    Maple2Storage.Types.Color.Argb(0xFF, 64, 104, 54),
                    4
                )
            };
        }

        public static Item WeddingGloves()
        {
            return new Item(11610014)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(
                    Maple2Storage.Types.Color.Argb(0xFF, 230, 230, 230),
                    Maple2Storage.Types.Color.Argb(0xFF, 0x4C, 0x85, 0xDB),
                    Maple2Storage.Types.Color.Argb(0xFF, 150, 150, 150),
                    4
                 ),
            };
        }

        public static Item WeddingEarring()
        {
            return new Item(11250124)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(
                    Maple2Storage.Types.Color.Argb(0xFF, 230, 230, 230),
                    Maple2Storage.Types.Color.Argb(0xFF, 0x4C, 0x85, 0xDB),
                    Maple2Storage.Types.Color.Argb(0xFF, 150, 150, 150),
                    4
                 ),
            };
        }
        public static Item PriestEliteHat()
        {
            return new Item(11361388)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(
                    Maple2Storage.Types.Color.Argb(0xFF, 194, 209, 96),
                    Maple2Storage.Types.Color.Argb(0xFF, 0x4C, 0x85, 0xDB),
                    Maple2Storage.Types.Color.Argb(0xFF, 64, 104, 54),
                    0
                ),
            };
        }
        public static Item PriestHat()
        {
            return new Item(11300083)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(
                    Maple2Storage.Types.Color.Argb(0xFF, 194, 209, 96),
                    Maple2Storage.Types.Color.Argb(0xFF, 0x4C, 0x85, 0xDB),
                    Maple2Storage.Types.Color.Argb(0xFF, 64, 104, 54),
                    0
                ),
            };
        }

        public static Item WeddingShoesFemale()
        {
            return new Item(11710028)
            {
                Uid = 2754959794416496484,
                CreationTime = 1558494660,
                Color = EquipColor.Custom(
                    Maple2Storage.Types.Color.Argb(0xFF, 230, 230, 230),
                    Maple2Storage.Types.Color.Argb(0xFF, 0xF7, 0xE3, 0xE3),
                    Maple2Storage.Types.Color.Argb(0xFF, 150, 150, 150),
                    4
                )
            };
        }

        public static Item PriestShoes()
        {
            return new Item(11700073)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(
                    Maple2Storage.Types.Color.Argb(0xFF, 194, 209, 96),
                    Maple2Storage.Types.Color.Argb(0xFF, 0x4C, 0x85, 0xDB),
                    Maple2Storage.Types.Color.Argb(0xFF, 64, 104, 54),
                    0
                ),
            };
        }

        public static Item FairyClothFemale()
        {
            return new Item(12200495)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(
                    Maple2Storage.Types.Color.Argb(0xFF, 126, 204, 247),
                    Maple2Storage.Types.Color.Argb(0xFF, 0x4C, 0x85, 0xDB),
                    Maple2Storage.Types.Color.Argb(0xFF, 72, 94, 168),
                    0
                ),
            };
        }

        public static Item FairyClothMale()
        {
            return new Item(12200494)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(
                    Maple2Storage.Types.Color.Argb(0xFF, 126, 204, 247),
                    Maple2Storage.Types.Color.Argb(0xFF, 0x4C, 0x85, 0xDB),
                    Maple2Storage.Types.Color.Argb(0xFF, 72, 94, 168),
                    0
                ),
            };
        }

        public static Item FairyEarringFemale()
        {
            return new Item(11250090)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(
                    Maple2Storage.Types.Color.Argb(0xFF, 180, 165, 248),
                    Maple2Storage.Types.Color.Argb(0xFF, 0x4C, 0x85, 0xDB),
                    Maple2Storage.Types.Color.Argb(0xFF, 108, 96, 176),
                    0
                ),
            };
        }

        public static Item FairyEarringMale()
        {
            return new Item(11250077)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(
                    Maple2Storage.Types.Color.Argb(0xFF, 180, 165, 248),
                    Maple2Storage.Types.Color.Argb(0xFF, 0x4C, 0x85, 0xDB),
                    Maple2Storage.Types.Color.Argb(0xFF, 108, 96, 176),
                    0
                ),
            };
        }

        public static Item FairyHatFemale()
        {
            return new Item(11390942)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(
                    Maple2Storage.Types.Color.Argb(0xFF, 170, 47, 47),
                    Maple2Storage.Types.Color.Argb(0xFF, 0x4C, 0x85, 0xDB),
                    Maple2Storage.Types.Color.Argb(0xFF, 96, 19, 19),
                    0
                ),
            };
        }

        public static Item FairyHatMale()
        {
            return new Item(11390941)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(
                    Maple2Storage.Types.Color.Argb(0xFF, 170, 47, 47),
                    Maple2Storage.Types.Color.Argb(0xFF, 0x4C, 0x85, 0xDB),
                    Maple2Storage.Types.Color.Argb(0xFF, 96, 19, 19),
                    0
                ),
            };
        }

        public static Item FairyGlovesFemale()
        {
            return new Item(11604689)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(
                    Maple2Storage.Types.Color.Argb(0xFF, 255, 168, 203),
                    Maple2Storage.Types.Color.Argb(0xFF, 0x4C, 0x85, 0xDB),
                    Maple2Storage.Types.Color.Argb(0xFF, 205, 86, 106),
                    0
                ),
            };
        }

        public static Item FairyGlovesMale()
        {
            return new Item(11601003)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(
                    Maple2Storage.Types.Color.Argb(0xFF, 63, 59, 51),
                    Maple2Storage.Types.Color.Argb(0xFF, 0x4C, 0x85, 0xDB),
                    Maple2Storage.Types.Color.Argb(0xFF, 20, 18, 15),
                    0
                ),
            };
        }

        public static Item FairyShoesFemale()
        {
            return new Item(11790934)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(
                    Maple2Storage.Types.Color.Argb(0xFF, 255, 168, 203),
                    Maple2Storage.Types.Color.Argb(0xFF, 0x4C, 0x85, 0xDB),
                    Maple2Storage.Types.Color.Argb(0xFF, 205, 86, 106),
                    0
                ),
            };
        }

        public static Item FairyShoesMale()
        {
            return new Item(11790933)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(
                    Maple2Storage.Types.Color.Argb(0xFF, 63, 59, 51),
                    Maple2Storage.Types.Color.Argb(0xFF, 0x4C, 0x85, 0xDB),
                    Maple2Storage.Types.Color.Argb(0xFF, 20, 18, 15),
                    0
                ),
            };
        }

        public static Item FairyCapeFemale()
        {
            return new Item(11850144)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(
                    Maple2Storage.Types.Color.Argb(0xFF, 255, 168, 203),
                    Maple2Storage.Types.Color.Argb(0xFF, 0x4C, 0x85, 0xDB),
                    Maple2Storage.Types.Color.Argb(0xFF, 205, 86, 106),
                    0
                ),
            };
        }

        public static Item FairyCapeMale()
        {
            return new Item(11850129)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(
                    Maple2Storage.Types.Color.Argb(0xFF, 132, 130, 120),
                    Maple2Storage.Types.Color.Argb(0xFF, 0x4C, 0x85, 0xDB),
                    Maple2Storage.Types.Color.Argb(0xFF, 68, 68, 65),
                    0
                ),
            };
        }

        public static Item PerionEarring()
        {
            return new Item(11200087)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(
                    Maple2Storage.Types.Color.Argb(0xFF, 170, 47, 47),
                    Maple2Storage.Types.Color.Argb(0xFF, 0x4C, 0x85, 0xDB),
                    Maple2Storage.Types.Color.Argb(0xFF, 96, 19, 19),
                    0
                ),
            };
        }

        public static Item PerionHat()
        {
            return new Item(11301152)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(
                    Maple2Storage.Types.Color.Argb(0xFF, 147, 226, 242),
                    Maple2Storage.Types.Color.Argb(0xFF, 0x4C, 0x85, 0xDB),
                    Maple2Storage.Types.Color.Argb(0xFF, 89, 153, 165),
                    0
                ),
            };
        }

        public static Item PerionGlovesFemale()
        {
            return new Item(11601054)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(
                    Maple2Storage.Types.Color.Argb(0xFF, 122, 92, 77),
                    Maple2Storage.Types.Color.Argb(0xFF, 0x4C, 0x85, 0xDB),
                    Maple2Storage.Types.Color.Argb(0xFF, 53, 39, 29),
                    0
                ),
            };
        }

        public static Item PerionGlovesMale()
        {
            return new Item(11601053)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(
                    Maple2Storage.Types.Color.Argb(0xFF, 122, 92, 77),
                    Maple2Storage.Types.Color.Argb(0xFF, 0x4C, 0x85, 0xDB),
                    Maple2Storage.Types.Color.Argb(0xFF, 53, 39, 29),
                    0
                ),
            };
        }

        public static Item PerionShoesFemale()
        {
            return new Item(11701135)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(
                    Maple2Storage.Types.Color.Argb(0xFF, 122, 92, 77),
                    Maple2Storage.Types.Color.Argb(0xFF, 0x4C, 0x85, 0xDB),
                    Maple2Storage.Types.Color.Argb(0xFF, 53, 39, 29),
                    0
                ),
            };
        }

        public static Item PerionShoesMale()
        {
            return new Item(11701134)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(
                    Maple2Storage.Types.Color.Argb(0xFF, 122, 92, 77),
                    Maple2Storage.Types.Color.Argb(0xFF, 0x4C, 0x85, 0xDB),
                    Maple2Storage.Types.Color.Argb(0xFF, 53, 39, 29),
                    0
                ),
            };
        }

        public static Item PerionClothFemale()
        {
            return new Item(12200538)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(
                    Maple2Storage.Types.Color.Argb(0xFF, 147, 226, 242),
                    Maple2Storage.Types.Color.Argb(0xFF, 0x4C, 0x85, 0xDB),
                    Maple2Storage.Types.Color.Argb(0xFF, 89, 153, 165),
                    0
                ),
            };
        }

        public static Item PerionClothMale()
        {
            return new Item(12200537)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(
                    Maple2Storage.Types.Color.Argb(0xFF, 147, 226, 242),
                    Maple2Storage.Types.Color.Argb(0xFF, 0x4C, 0x85, 0xDB),
                    Maple2Storage.Types.Color.Argb(0xFF, 89, 153, 165),
                    0
                ),
            };
        }

        public static Item HanbokClothFemale()
        {
            return new Item(12200203)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(
                    Maple2Storage.Types.Color.Argb(0xFF, 170, 47, 47),
                    Maple2Storage.Types.Color.Argb(0xFF, 0x4C, 0x85, 0xDB),
                    Maple2Storage.Types.Color.Argb(0xFF, 96, 19, 19),
                    0
                ),
            };
        }

        public static Item HanbokHat()
        {
            return new Item(11300312)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
            };
        }

        public static Item HanbokGlovesFemale()
        {
            return new Item(11600240)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(
                    Maple2Storage.Types.Color.Argb(0xFF, 170, 47, 47),
                    Maple2Storage.Types.Color.Argb(0xFF, 0x4C, 0x85, 0xDB),
                    Maple2Storage.Types.Color.Argb(0xFF, 96, 19, 19),
                    0
                ),
            };
        }

        public static Item HanbokShoesFemale()
        {
            return new Item(11700274)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(
                    Maple2Storage.Types.Color.Argb(0xFF, 122, 92, 77),
                    Maple2Storage.Types.Color.Argb(0xFF, 0x4C, 0x85, 0xDB),
                    Maple2Storage.Types.Color.Argb(0xFF, 53, 39, 29),
                    0
                ),
            };
        }

        public static Item FlowerClothFemale()
        {
            return new Item(12200506)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(
                    Maple2Storage.Types.Color.Argb(0xFF, 76, 105, 181),
                    Maple2Storage.Types.Color.Argb(0xFF, 0x4C, 0x85, 0xDB),
                    Maple2Storage.Types.Color.Argb(0xFF, 23, 40, 79),
                    0
                ),
            };
        }

        public static Item FlowerGlovesFemale()
        {
            return new Item(11601018)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(
                    Maple2Storage.Types.Color.Argb(0xFF, 76, 105, 181),
                    Maple2Storage.Types.Color.Argb(0xFF, 0x4C, 0x85, 0xDB),
                    Maple2Storage.Types.Color.Argb(0xFF, 23, 40, 79),
                    0
                ),
            };
        }

        public static Item FlowerShoesFemale()
        {
            return new Item(11701093)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(
                    Maple2Storage.Types.Color.Argb(0xFF, 76, 105, 181),
                    Maple2Storage.Types.Color.Argb(0xFF, 0x4C, 0x85, 0xDB),
                    Maple2Storage.Types.Color.Argb(0xFF, 23, 40, 79),
                    0
                ),
            };
        }

        public static Item FlowerHatFemale()
        {
            return new Item(11301105)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(
                    Maple2Storage.Types.Color.Argb(0xFF, 76, 105, 181),
                    Maple2Storage.Types.Color.Argb(0xFF, 0x4C, 0x85, 0xDB),
                    Maple2Storage.Types.Color.Argb(0xFF, 23, 40, 79),
                    0
                ),
            };
        }

        public static Item FlowerEarringFemale()
        {
            return new Item(11250086)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(
                    Maple2Storage.Types.Color.Argb(0xFF, 76, 105, 181),
                    Maple2Storage.Types.Color.Argb(0xFF, 0x4C, 0x85, 0xDB),
                    Maple2Storage.Types.Color.Argb(0xFF, 23, 40, 79),
                    0
                ),
            };
        }

        public static Item FlowerCapeFemale()
        {
            return new Item(11850137)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(
                    Maple2Storage.Types.Color.Argb(0xFF, 76, 105, 181),
                    Maple2Storage.Types.Color.Argb(0xFF, 0x4C, 0x85, 0xDB),
                    Maple2Storage.Types.Color.Argb(0xFF, 23, 40, 79),
                    0
                ),
            };
        }

        public static Item SnowTailClothFemale()
        {
            return new Item(12200540)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(
                    Maple2Storage.Types.Color.Argb(0xFF, 76, 105, 181),
                    Maple2Storage.Types.Color.Argb(0xFF, 0x4C, 0x85, 0xDB),
                    Maple2Storage.Types.Color.Argb(0xFF, 23, 40, 79),
                    0
                ),
            };
        }

        public static Item SnowTailClothMale()
        {
            return new Item(12200539)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(
                    Maple2Storage.Types.Color.Argb(0xFF, 76, 105, 181),
                    Maple2Storage.Types.Color.Argb(0xFF, 0x4C, 0x85, 0xDB),
                    Maple2Storage.Types.Color.Argb(0xFF, 23, 40, 79),
                    0
                ),
            };
        }

        public static Item SnowTailShoesFemale()
        {
            return new Item(11701226)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(
                    Maple2Storage.Types.Color.Argb(0xFF, 76, 105, 181),
                    Maple2Storage.Types.Color.Argb(0xFF, 0x4C, 0x85, 0xDB),
                    Maple2Storage.Types.Color.Argb(0xFF, 23, 40, 79),
                    0
                ),
            };
        }

        public static Item SnowTailShoesMale()
        {
            return new Item(11701225)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(
                    Maple2Storage.Types.Color.Argb(0xFF, 76, 105, 181),
                    Maple2Storage.Types.Color.Argb(0xFF, 0x4C, 0x85, 0xDB),
                    Maple2Storage.Types.Color.Argb(0xFF, 23, 40, 79),
                    0
                ),
            };
        }

        public static Item SnowTailGlovesFemale()
        {
            return new Item(11601145)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(
                    Maple2Storage.Types.Color.Argb(0xFF, 76, 105, 181),
                    Maple2Storage.Types.Color.Argb(0xFF, 0x4C, 0x85, 0xDB),
                    Maple2Storage.Types.Color.Argb(0xFF, 23, 40, 79),
                    0
                ),
            };
        }

        public static Item SnowTailGlovesMale()
        {
            return new Item(11601144)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(
                    Maple2Storage.Types.Color.Argb(0xFF, 76, 105, 181),
                    Maple2Storage.Types.Color.Argb(0xFF, 0x4C, 0x85, 0xDB),
                    Maple2Storage.Types.Color.Argb(0xFF, 23, 40, 79),
                    0
                ),
            };
        }

        public static Item SnowTailEarringFemale()
        {
            return new Item(11250110)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(
                    Maple2Storage.Types.Color.Argb(0xFF, 76, 105, 181),
                    Maple2Storage.Types.Color.Argb(0xFF, 0x4C, 0x85, 0xDB),
                    Maple2Storage.Types.Color.Argb(0xFF, 23, 40, 79),
                    0
                ),
            };
        }

        public static Item SnowTailEarringMale()
        {
            return new Item(11250109)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(
                    Maple2Storage.Types.Color.Argb(0xFF, 76, 105, 181),
                    Maple2Storage.Types.Color.Argb(0xFF, 0x4C, 0x85, 0xDB),
                    Maple2Storage.Types.Color.Argb(0xFF, 23, 40, 79),
                    0
                ),
            };
        }

        public static Item SnowTailHatFemale()
        {
            return new Item(11301245)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(
                    Maple2Storage.Types.Color.Argb(0xFF, 76, 105, 181),
                    Maple2Storage.Types.Color.Argb(0xFF, 0x4C, 0x85, 0xDB),
                    Maple2Storage.Types.Color.Argb(0xFF, 23, 40, 79),
                    0
                ),
            };
        }

        public static Item SnowTailHatMale()
        {
            return new Item(11301244)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(
                    Maple2Storage.Types.Color.Argb(0xFF, 76, 105, 181),
                    Maple2Storage.Types.Color.Argb(0xFF, 0x4C, 0x85, 0xDB),
                    Maple2Storage.Types.Color.Argb(0xFF, 23, 40, 79),
                    0
                ),
            };
        }

        public static Item SnowTailCapeFemale()
        {
            return new Item(11850164)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(
                    Maple2Storage.Types.Color.Argb(0xFF, 76, 105, 181),
                    Maple2Storage.Types.Color.Argb(0xFF, 0x4C, 0x85, 0xDB),
                    Maple2Storage.Types.Color.Argb(0xFF, 23, 40, 79),
                    0
                ),
            };
        }

        public static Item SnowTailCapeMale()
        {
            return new Item(11850163)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(
                    Maple2Storage.Types.Color.Argb(0xFF, 76, 105, 181),
                    Maple2Storage.Types.Color.Argb(0xFF, 0x4C, 0x85, 0xDB),
                    Maple2Storage.Types.Color.Argb(0xFF, 23, 40, 79),
                    0
                ),
            };
        }

        public static Item TriaChefFemale()
        {
            return new Item(12200666)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(
                    Maple2Storage.Types.Color.Argb(0xFF, 119, 147, 68),
                    Maple2Storage.Types.Color.Argb(0xFF, 0x4C, 0x85, 0xDB),
                    Maple2Storage.Types.Color.Argb(0xFF, 32, 51, 30),
                    4
                ),
            };
        }

        public static Item TriaChefShoesFemale()
        {
            return new Item(11710049)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(
                    Maple2Storage.Types.Color.Argb(0xFF, 119, 147, 68),
                    Maple2Storage.Types.Color.Argb(0xFF, 0x4C, 0x85, 0xDB),
                    Maple2Storage.Types.Color.Argb(0xFF, 32, 51, 30),
                    4
                ),
            };
        }

        public static Item MapleArmorSuit()
        {
            return new Item(12200362)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(
                    Maple2Storage.Types.Color.Argb(0xFF, 244, 189, 88),
                    Maple2Storage.Types.Color.Argb(0xFF, 0x4C, 0x85, 0xDB),
                    Maple2Storage.Types.Color.Argb(0xFF, 163, 121, 39),
                    4
                ),
            };
        }

        public static Item MapleArmorHat()
        {
            return new Item(11300742)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(
                    Maple2Storage.Types.Color.Argb(0xFF, 244, 189, 88),
                    Maple2Storage.Types.Color.Argb(0xFF, 0x4C, 0x85, 0xDB),
                    Maple2Storage.Types.Color.Argb(0xFF, 163, 121, 39),
                    4
                ),
            };
        }

        public static Item MapleArmorGloves()
        {
            return new Item(11600665)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(
                    Maple2Storage.Types.Color.Argb(0xFF, 244, 189, 88),
                    Maple2Storage.Types.Color.Argb(0xFF, 0x4C, 0x85, 0xDB),
                    Maple2Storage.Types.Color.Argb(0xFF, 163, 121, 39),
                    4
                ),
            };
        }

        public static Item MapleArmorCape()
        {
            return new Item(11850079)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(
                    Maple2Storage.Types.Color.Argb(0xFF, 244, 189, 88),
                    Maple2Storage.Types.Color.Argb(0xFF, 0x4C, 0x85, 0xDB),
                    Maple2Storage.Types.Color.Argb(0xFF, 163, 121, 39),
                    4
                ),
            };
        }

        public static Item MapleArmorShoes()
        {
            return new Item(11700719)
            {
                Uid = 2867972925711604442,
                CreationTime = 1565575851,
                Color = EquipColor.Custom(
                    Maple2Storage.Types.Color.Argb(0xFF, 244, 189, 88),
                    Maple2Storage.Types.Color.Argb(0xFF, 0x4C, 0x85, 0xDB),
                    Maple2Storage.Types.Color.Argb(0xFF, 163, 121, 39),
                    4
                ),
            };
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
