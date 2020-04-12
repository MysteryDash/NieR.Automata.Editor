using System.Collections.Generic;
using System.IO;

namespace NieR.Automata.Editor
{
    class Chip
    {
        private static readonly byte[] Padding =
        {
            0xFF, 0xFF, 0xFF, 0xFF,
            0xFF, 0xFF, 0xFF, 0xFF,
            0xFF, 0xFF, 0xFF, 0xFF,
            0x00, 0x00, 0x00, 0x00,
        };

        public static Chip Empty { get; } = new Chip()
        {
            BaseCode = unchecked((int)0xFFFFFFFF),
            BaseId = unchecked((int)0xFFFFFFFF),
            Type = unchecked((int)0xFFFFFFFF),
            Level = unchecked((int)0xFFFFFFFF),
            Weight = unchecked((int)0xFFFFFFFF),
            SlotA = unchecked((int)0xFFFFFFFF),
            SlotB = unchecked((int)0xFFFFFFFF),
            SlotC = unchecked((int)0xFFFFFFFF),
            HasLevels = true,
            Name = "Empty"
        };

        public static IReadOnlyDictionary<int, Chip> Chips { get; } = new Dictionary<int, Chip>()
        {
            [0x00000001] = new Chip() { BaseCode = 0x00000000, BaseId = 0x00000BB9, Type = 0x00000001, Weight = 0x00000004, HasLevels = true, Name = "Weapon Attack Up" },
            [0x00000002] = new Chip() { BaseCode = 0x00000009, BaseId = 0x00000BC2, Type = 0x00000002, Weight = 0x00000004, HasLevels = true, Name = "Down-Attack Up" },
            [0x00000003] = new Chip() { BaseCode = 0x00000012, BaseId = 0x00000BCB, Type = 0x00000003, Weight = 0x00000004, HasLevels = true, Name = "Critical Up" },
            [0x00000004] = new Chip() { BaseCode = 0x0000001B, BaseId = 0x00000BD4, Type = 0x00000004, Weight = 0x00000004, HasLevels = true, Name = "Ranged Attack Up" },
            [0x00000005] = new Chip() { BaseCode = 0x000000A3, BaseId = 0x00000BDD, Type = 0x00000005, Weight = 0x00000004, HasLevels = true, Name = "Fast Cooldown" },
            [0x00000006] = new Chip() { BaseCode = 0x00000049, BaseId = 0x00000BE6, Type = 0x00000006, Weight = 0x00000004, HasLevels = true, Name = "Melee Defence Up" },
            [0x00000007] = new Chip() { BaseCode = 0x00000052, BaseId = 0x00000BEF, Type = 0x00000007, Weight = 0x00000004, HasLevels = true, Name = "Ranged Defence Up" },
            [0x00000008] = new Chip() { BaseCode = 0x0000005B, BaseId = 0x00000BF8, Type = 0x00000008, Weight = 0x00000004, HasLevels = true, Name = "Anti Chain Damage" },
            [0x00000009] = new Chip() { BaseCode = 0x0000006D, BaseId = 0x00000C01, Type = 0x00000009, Weight = 0x00000004, HasLevels = true, Name = "Max HP Up" },
            [0x0000000A] = new Chip() { BaseCode = 0x00000076, BaseId = 0x00000C0A, Type = 0x0000000A, Weight = 0x00000004, HasLevels = true, Name = "Offensive Heal" },
            [0x0000000B] = new Chip() { BaseCode = 0x0000007F, BaseId = 0x00000C13, Type = 0x0000000B, Weight = 0x00000004, HasLevels = true, Name = "Deadly Heal" },
            [0x0000000C] = new Chip() { BaseCode = 0x00000088, BaseId = 0x00000C1C, Type = 0x0000000C, Weight = 0x00000004, HasLevels = true, Name = "Auto-Heal" },
            [0x0000000D] = new Chip() { BaseCode = 0x000000AC, BaseId = 0x00000C25, Type = 0x0000000D, Weight = 0x00000004, HasLevels = true, Name = "Evade Range Up" },
            [0x0000000E] = new Chip() { BaseCode = 0x000000B5, BaseId = 0x00000C2E, Type = 0x0000000E, Weight = 0x00000004, HasLevels = true, Name = "Moving Speed Up" },
            [0x0000000F] = new Chip() { BaseCode = 0x000000BE, BaseId = 0x00000C37, Type = 0x0000000F, Weight = 0x00000004, HasLevels = true, Name = "Drop Rate Up" },
            [0x00000010] = new Chip() { BaseCode = 0x000000C7, BaseId = 0x00000C40, Type = 0x00000010, Weight = 0x00000004, HasLevels = true, Name = "EXP Gain Up" },
            [0x00000011] = new Chip() { BaseCode = 0x00000024, BaseId = 0x00000C49, Type = 0x00000011, Weight = 0x00000004, HasLevels = true, Name = "Shock Wave" },
            [0x00000012] = new Chip() { BaseCode = 0x0000002D, BaseId = 0x00000C52, Type = 0x00000012, Weight = 0x00000004, HasLevels = true, Name = "Last Stand" },
            [0x00000013] = new Chip() { BaseCode = 0x00000091, BaseId = 0x00000C5B, Type = 0x00000013, Weight = 0x00000004, HasLevels = true, Name = "Damage Absorb" },
            [0x00000014] = new Chip() { BaseCode = 0x000000D0, BaseId = 0x00000C64, Type = 0x00000014, Weight = 0x00000004, HasLevels = true, Name = "Vengeance" },
            [0x00000015] = new Chip() { BaseCode = 0x0000009A, BaseId = 0x00000C6D, Type = 0x00000015, Weight = 0x00000004, HasLevels = true, Name = "Reset" },
            [0x00000016] = new Chip() { BaseCode = 0x000000D9, BaseId = 0x00000C76, Type = 0x00000016, Weight = 0x00000004, HasLevels = true, Name = "Overclock" },
            [0x00000017] = new Chip() { BaseCode = 0x00000064, BaseId = 0x00000C7F, Type = 0x00000017, Weight = 0x00000004, HasLevels = true, Name = "Resilience" },
            [0x00000018] = new Chip() { BaseCode = 0x00000036, BaseId = 0x00000C91, Type = 0x00000018, Weight = 0x00000004, HasLevels = true, Name = "Counter" },
            [0x00000019] = new Chip() { BaseCode = 0x000000E2, BaseId = 0x00000C9A, Type = 0x00000019, Weight = 0x00000004, HasLevels = true, Name = "Taunt Up" },
            [0x0000001A] = new Chip() { BaseCode = 0x0000003F, BaseId = 0x00000CA3, Type = 0x0000001A, Weight = 0x00000004, HasLevels = true, Name = "Charge Attack" },
            [0x0000001B] = new Chip() { BaseCode = 0x000000EB, BaseId = 0x00000CAC, Type = 0x0000001B, Weight = 0x00000004, HasLevels = true, Name = "Auto-use Item" },
            [0x0000001D] = new Chip() { BaseCode = 0x000000FD, BaseId = 0x00000CBE, Type = 0x0000001D, Weight = 0x00000004, HasLevels = true, Name = "Hijack Boost" },
            [0x0000001E] = new Chip() { BaseCode = 0x00000106, BaseId = 0x00000CD9, Type = 0x0000001E, Weight = 0x00000004, HasLevels = true, Name = "Stun" },
            [0x0000001F] = new Chip() { BaseCode = 0x0000010F, BaseId = 0x00000CE2, Type = 0x0000001F, Weight = 0x00000004, HasLevels = true, Name = "Combust" },
            [0x00000022] = new Chip() { BaseCode = 0x00000118, BaseId = 0x00000CFD, Type = 0x00000022, Weight = 0x00000004, HasLevels = true, Name = "Heal Drops Up" },
            [0x00000023] = new Chip() { BaseCode = 0x000000F5, BaseId = 0x00000C88, Type = 0x00000023, Weight = 0x00000006, HasLevels = false, Name = "Item Scan" },
            [0x00000026] = new Chip() { BaseCode = 0x00000121, BaseId = 0x00000D06, Type = 0x00000026, Weight = 0x00000006, HasLevels = false, Name = "Death Rattle" },
            [0x00000027] = new Chip() { BaseCode = 0x00000123, BaseId = 0x00000D07, Type = 0x00000027, Weight = 0x00000002, HasLevels = false, Name = "HUD: HP Gauge" },
            [0x00000028] = new Chip() { BaseCode = 0x0000012D, BaseId = 0x00000D08, Type = 0x00000028, Weight = 0x00000003, HasLevels = false, Name = "HUD: Sound Waves" },
            [0x00000029] = new Chip() { BaseCode = 0x00000126, BaseId = 0x00000D09, Type = 0x00000029, Weight = 0x00000002, HasLevels = false, Name = "HUD: Enemy Data" },
            [0x0000002A] = new Chip() { BaseCode = 0x00000122, BaseId = 0x00000D0A, Type = 0x0000002A, Weight = 0x00000002, HasLevels = false, Name = "OS Chip" },
            [0x0000002C] = new Chip() { BaseCode = 0x000000F6, BaseId = 0x00000D0B, Type = 0x0000002C, Weight = 0x00000006, HasLevels = false, Name = "Evasive System" },
            [0x0000002D] = new Chip() { BaseCode = 0x00000048, BaseId = 0x00000D0C, Type = 0x0000002D, Weight = 0x00000006, HasLevels = false, Name = "Continuous Combo" },
            [0x0000002E] = new Chip() { BaseCode = 0x000000F7, BaseId = 0x00000D0D, Type = 0x0000002E, Weight = 0x00000006, HasLevels = false, Name = "Bullet Detonation" },
            [0x0000002F] = new Chip() { BaseCode = 0x000000F4, BaseId = 0x00000D0E, Type = 0x0000002F, Weight = 0x00000006, HasLevels = false, Name = "Auto-collect Items" },
            [0x00000030] = new Chip() { BaseCode = 0x00000125, BaseId = 0x00000D0F, Type = 0x00000030, Weight = 0x00000002, HasLevels = false, Name = "HUD: Skill Gauge" },
            [0x00000031] = new Chip() { BaseCode = 0x00000129, BaseId = 0x00000D10, Type = 0x00000031, Weight = 0x00000002, HasLevels = false, Name = "HUD: Text Log" },
            [0x00000032] = new Chip() { BaseCode = 0x00000127, BaseId = 0x00000D11, Type = 0x00000032, Weight = 0x00000002, HasLevels = false, Name = "HUD: Mini-map" },
            [0x00000033] = new Chip() { BaseCode = 0x00000124, BaseId = 0x00000D12, Type = 0x00000033, Weight = 0x00000001, HasLevels = false, Name = "HUD: EXP Gauge" },
            [0x00000034] = new Chip() { BaseCode = 0x0000012A, BaseId = 0x00000D13, Type = 0x00000034, Weight = 0x00000001, HasLevels = false, Name = "HUD: Save Points" },
            [0x00000035] = new Chip() { BaseCode = 0x0000012C, BaseId = 0x00000D14, Type = 0x00000035, Weight = 0x00000003, HasLevels = false, Name = "HUD: Damage Values" },
            [0x00000036] = new Chip() { BaseCode = 0x00000128, BaseId = 0x00000D15, Type = 0x00000036, Weight = 0x00000001, HasLevels = false, Name = "HUD: Objectives" },
            [0x00000037] = new Chip() { BaseCode = 0x0000012E, BaseId = 0x00000D16, Type = 0x00000037, Weight = 0x00000003, HasLevels = false, Name = "HUD: Control" },
            [0x0000003A] = new Chip() { BaseCode = 0x0000012B, BaseId = 0x00000D19, Type = 0x0000003A, Weight = 0x00000003, HasLevels = false, Name = "HUD: Fishing Spots" },
            [0x0000003B] = new Chip() { BaseCode = 0x000000F8, BaseId = 0x00000D1A, Type = 0x0000003B, Weight = 0x00000001, HasLevels = false, Name = "Auto-Attack" },
            [0x0000003C] = new Chip() { BaseCode = 0x000000F9, BaseId = 0x00000D1B, Type = 0x0000003C, Weight = 0x00000001, HasLevels = false, Name = "Auto-Fire" },
            [0x0000003D] = new Chip() { BaseCode = 0x000000FA, BaseId = 0x00000D1C, Type = 0x0000003D, Weight = 0x00000001, HasLevels = false, Name = "Auto-Evade" },
            [0x0000003E] = new Chip() { BaseCode = 0x000000FB, BaseId = 0x00000D1D, Type = 0x0000003E, Weight = 0x00000001, HasLevels = false, Name = "Auto-Program" },
            [0x0000003F] = new Chip() { BaseCode = 0x000000FC, BaseId = 0x00000D1E, Type = 0x0000003F, Weight = 0x00000001, HasLevels = false, Name = "Auto-Weapon Switch" },
            [Empty.Type] = Empty
        };

        public static IReadOnlyDictionary<int, int> MinimumWeightForLevel { get; } = new Dictionary<int, int>()
        {
            [0] = 4,
            [1] = 5,
            [2] = 6,
            [3] = 7,
            [4] = 9,
            [5] = 11,
            [6] = 14,
            [7] = 17,
            [8] = 21,
        };

        public string Name { get; private set; }
        public bool HasLevels { get; private set; }
        public int Position { get; private set; }

        public int BaseCode { get; private set; } // Save ID = BaseCode + Level
        public int BaseId { get; private set; } // Save ID = BaseId + Level
        public int Type { get; private set; }
        public int Level { get; set; }
        public int Weight { get; set; }
        public int SlotA { get; set; }
        public int SlotB { get; set; }
        public int SlotC { get; set; }

        private Chip()
        {
            Level = 0x00000000;
            SlotA = unchecked((int)0xFFFFFFFF);
            SlotB = unchecked((int)0xFFFFFFFF);
            SlotC = unchecked((int)0xFFFFFFFF);
        }

        public void ChangeType(int type)
        {
            if (Chips.TryGetValue(type, out var newChip))
            {
                Name = newChip.Name;
                HasLevels = newChip.HasLevels;
                BaseCode = newChip.BaseCode;
                BaseId = newChip.BaseId;
                Type = newChip.Type;
            }
        }

        public override string ToString()
        {
            return HasLevels && Level > 0 ? $"{Name}+{Level}" : Name;
        }

        public static Chip Read(BinaryReader reader, int position)
        {
            var chip = (Chip)Empty.MemberwiseClone();

            chip.Position = position;
            chip.BaseCode = reader.ReadInt32();
            chip.BaseId = reader.ReadInt32();
            chip.Type = reader.ReadInt32();
            chip.Level = reader.ReadInt32();
            chip.Weight = reader.ReadInt32();
            chip.SlotA = reader.ReadInt32();
            chip.SlotB = reader.ReadInt32();
            chip.SlotC = reader.ReadInt32();
            for (int i = 0; i < 0x10; i++)
                reader.ReadByte();

            if (Chips.TryGetValue(chip.Type, out var knownChip))
            {
                chip.Name = knownChip.Name;
                chip.BaseCode = knownChip.BaseCode;
                chip.BaseId = knownChip.BaseId;
            }
            else if (chip.Type != Empty.Type)
            {
                chip.Name = "???";
                chip.BaseCode -= chip.Level;
                chip.BaseId -= chip.Level;
            }

            return chip;
        }

        public static void Write(Chip chip, BinaryWriter writer)
        {
            if (chip.Type == Empty.Type)
                chip = Empty;
            if (chip == Empty || !chip.HasLevels)
            {
                writer.Write(chip.BaseCode);
                writer.Write(chip.BaseId);
            }
            else
            {
                writer.Write(chip.BaseCode + chip.Level);
                writer.Write(chip.BaseId + chip.Level);
            }
            writer.Write(chip.Type);
            writer.Write(chip.Level);
            writer.Write(chip.Weight);
            writer.Write(chip.SlotA);
            writer.Write(chip.SlotB);
            writer.Write(chip.SlotC);
            writer.Write(Padding);
        }
    }
}