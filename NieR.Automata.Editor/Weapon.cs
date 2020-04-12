using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NieR.Automata.Editor
{
    class Weapon
    {
        public static Weapon Empty { get; } = new Weapon()
        {
            Id = unchecked((int)0xFFFFFFFF)
        };

        public static IReadOnlyDictionary<int, Weapon> Weapons { get; } = new Dictionary<int, Weapon>()
        {
            [0x000003EB] = new Weapon() { Id = 0x000003EB, Name = "Faith" },
            [0x000003F5] = new Weapon() { Id = 0x000003F5, Name = "Iron Pipe" },
            [0x000003FC] = new Weapon() { Id = 0x000003FC, Name = "Beastbane" },
            [0x00000410] = new Weapon() { Id = 0x00000410, Name = "Phoenix Dagger" },
            [0x00000406] = new Weapon() { Id = 0x00000406, Name = "Ancient Overlord" },
            [0x0000041A] = new Weapon() { Id = 0x0000041A, Name = "Type-40 Sword" },
            [0x00000424] = new Weapon() { Id = 0x00000424, Name = "Type-3 Sword" },
            [0x0000042E] = new Weapon() { Id = 0x0000042E, Name = "Virtuous Contract" },
            [0x0000042F] = new Weapon() { Id = 0x0000042F, Name = "Cruel Oath" },
            [0x00000438] = new Weapon() { Id = 0x00000438, Name = "YoRHa-issue Blade" },
            [0x00000442] = new Weapon() { Id = 0x00000442, Name = "Machine Sword" },
            [0x000004B3] = new Weapon() { Id = 0x000004B3, Name = "Iron Will" },
            [0x000004BD] = new Weapon() { Id = 0x000004BD, Name = "Fang of the Twins" },
            [0x000004C4] = new Weapon() { Id = 0x000004C4, Name = "Beastlord" },
            [0x000004CE] = new Weapon() { Id = 0x000004CE, Name = "Phoenix Sword" },
            [0x000004D8] = new Weapon() { Id = 0x000004D8, Name = "Type-40 Blade" },
            [0x000004E2] = new Weapon() { Id = 0x000004E2, Name = "Type-3 Blade" },
            [0x000004EC] = new Weapon() { Id = 0x000004EC, Name = "Virtuous Treaty" },
            [0x000004ED] = new Weapon() { Id = 0x000004ED, Name = "Cruel Blood Oath" },
            [0x000004F6] = new Weapon() { Id = 0x000004F6, Name = "Machine Axe" },
            [0x00000578] = new Weapon() { Id = 0x00000578, Name = "Phoenix Lance" },
            [0x0000058C] = new Weapon() { Id = 0x0000058C, Name = "Beastcurse" },
            [0x00000596] = new Weapon() { Id = 0x00000596, Name = "Dragoon Lance" },
            [0x000005A0] = new Weapon() { Id = 0x000005A0, Name = "Spear of the Usurper" },
            [0x000005AA] = new Weapon() { Id = 0x000005AA, Name = "Type-40 Lance" },
            [0x000005B4] = new Weapon() { Id = 0x000005B4, Name = "Type-3 Lance" },
            [0x000005BE] = new Weapon() { Id = 0x000005BE, Name = "Virtuous Dignity" },
            [0x000005BF] = new Weapon() { Id = 0x000005BF, Name = "Cruel Arrogance" },
            [0x000005C8] = new Weapon() { Id = 0x000005C8, Name = "Machine Spear" },
            [0x00000668] = new Weapon() { Id = 0x00000668, Name = "Angel's Folly" },
            [0x0000065E] = new Weapon() { Id = 0x0000065E, Name = "Demon's Cry" },
            [0x0000064A] = new Weapon() { Id = 0x0000064A, Name = "Type-40 Fists" },
            [0x00000640] = new Weapon() { Id = 0x00000640, Name = "Type-3 Fists" },
            [0x00000654] = new Weapon() { Id = 0x00000654, Name = "Virtuous Grief" },
            [0x00000655] = new Weapon() { Id = 0x00000655, Name = "Cruel Lament" },
            [0x00000672] = new Weapon() { Id = 0x00000672, Name = "Machine Heads" },
            [0x00000753] = new Weapon() { Id = 0x00000753, Name = "Engine Blade" },
            [0x00000754] = new Weapon() { Id = 0x00000754, Name = "Cypress Stick" },
            [0x00000755] = new Weapon() { Id = 0x00000755, Name = "Emil Heads" }
        };

        public string Name { get; private set; }
        public bool Obtained { get; set; }
        public int Position { get; private set; }

        public int Id { get; private set; }
        public int Level { get; set; }
        public int NewItem { get; set; }
        public int NewStory { get; set; }
        public int EnemiesDefeated { get; set; }

        private Weapon()
        {
            Level = 0x00000001;
            NewItem = 0x00000001;
            NewStory = 0x00000001;
            EnemiesDefeated = 0x00000000;
        }

        public static Weapon Read(BinaryReader reader, int position)
        {
            var weapon = (Weapon)Empty.MemberwiseClone();
            weapon.Id = reader.ReadInt32();
            weapon.Level = reader.ReadInt32();
            weapon.NewItem = reader.ReadInt32();
            weapon.NewStory = reader.ReadInt32();
            weapon.EnemiesDefeated = reader.ReadInt32();

            if (position >= 0 && position < Weapons.Count)
            {
                if (!Weapons.TryGetValue(weapon.Id, out var originalWeapon))
                {
                    originalWeapon = Weapons.Values.ElementAt(position);
                }

                if (weapon.Id == originalWeapon.Id)
                    weapon.Obtained = true;
                else
                    weapon = (Weapon)originalWeapon.MemberwiseClone();

                weapon.Name = originalWeapon.Name;
            }
            else
            {
                weapon.Name = "???";
            }

            weapon.Position = position;
            return weapon;
        }

        public static void Write(Weapon weapon, BinaryWriter writer)
        {
            if (!weapon.Obtained)
                weapon = Empty;
            writer.Write(weapon.Id);
            writer.Write(weapon.Level);
            writer.Write(weapon.NewItem);
            writer.Write(weapon.NewStory);
            writer.Write(weapon.EnemiesDefeated);
        }
    }
}