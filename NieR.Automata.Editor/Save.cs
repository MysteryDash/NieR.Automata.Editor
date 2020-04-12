using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NieR.Automata.Editor
{
    class Save
    {
        private const int InventoryItemsCount = 256;
        private const int CorpseInventoryItemsCount = 256;
        private const int ChipsCount = 256;

        public const int SaveSize = 0x399CC;

        private byte[] _save;

        public byte[] HeaderId { get; set; }
        public int InGameTime { get; set; }                 // Start: 0x00024 Length: 4 bytes
        public int Chapter { get; set; }                    // Start: 0x0002C Length: 4 bytes, -1 if not present (due to saving after an ending)
        public string Name { get; set; }                    // Start: 0x00034 Length: 70 bytes maximum, UTF-16 or UCS-2 encoded, null terminated and padded
        public int Money { get; set; }                      // Start: 0x3056C Length: 4 Bytes
        public int Experience { get; set; }                 // Start: 0x3871C Length: 4 Bytes
        public List<Item> Inventory { get; set; }           // Start: 0x30570 Items: 256    Single Item Length: 12 Bytes
        public List<Item> CorpseInventory { get; set; }     // Start: 0x31170 Items: 256    Single Item Length: 12 Bytes
        public List<Weapon> Weapons { get; set; }           // Start: 0x31D70 Items: 39     Single Item Length: 20 Bytes
        public List<Chip> Chips { get; set; }               // Start: 0x324BC Items: 256    Single Item Length: 48 Bytes

        public Save()
        {
            Inventory = new List<Item>(InventoryItemsCount);
            CorpseInventory = new List<Item>(CorpseInventoryItemsCount);
            Weapons = new List<Weapon>(Weapon.Weapons.Count);
            Chips = new List<Chip>(ChipsCount);
        }

        public void Load(byte[] save)
        {
            if (save == null) throw new ArgumentNullException(nameof(save));
            if (save.Length != SaveSize) throw new ArgumentOutOfRangeException(nameof(save.Length));
            
            _save = save;
            using var stream = new MemoryStream(_save);
            using var reader = new BinaryReader(stream, Encoding.Unicode);

            stream.Seek(0x00004, SeekOrigin.Begin);
            HeaderId = reader.ReadBytes(12);

            stream.Seek(0x00024, SeekOrigin.Begin);
            InGameTime = reader.ReadInt32();

            stream.Seek(0x0002C, SeekOrigin.Begin);
            Chapter = reader.ReadInt32();

            stream.Seek(0x00034, SeekOrigin.Begin);
            Name = new string(reader.ReadChars(35)).TrimEnd('\0');

            stream.Seek(0x3056C, SeekOrigin.Begin);
            Money = reader.ReadInt32();

            stream.Seek(0x3871C, SeekOrigin.Begin);
            Experience = reader.ReadInt32();

            stream.Seek(0x30570, SeekOrigin.Begin);
            Inventory.Clear();
            for (int i = 0; i < InventoryItemsCount; i++)
                Inventory.Add(Item.Read(reader, i));

            stream.Seek(0x31170, SeekOrigin.Begin);
            CorpseInventory.Clear();
            for (int i = 0; i < CorpseInventoryItemsCount; i++)
                CorpseInventory.Add(Item.Read(reader, i));

            stream.Seek(0x31D70, SeekOrigin.Begin);
            Weapons.Clear();
            for (int i = 0; i < Weapon.Weapons.Count; i++)
                Weapons.Add(Weapon.Read(reader, i));

            stream.Seek(0x324BC, SeekOrigin.Begin);
            Chips.Clear();
            for (int i = 0; i < ChipsCount; i++)
                Chips.Add(Chip.Read(reader, i));
        }

        public byte[] Write()
        {
            using var stream = new MemoryStream(SaveSize);
            using var writer = new BinaryWriter(stream, Encoding.Unicode);

            writer.Write(_save);

            stream.Seek(0x00004, SeekOrigin.Begin);
            writer.Write(HeaderId);

            stream.Seek(0x00024, SeekOrigin.Begin);
            writer.Write(InGameTime);

            stream.Seek(0x0002C, SeekOrigin.Begin);
            writer.Write(Chapter);

            stream.Seek(0x00034, SeekOrigin.Begin);
            writer.Write(Name.ToCharArray());
            writer.Write('\0');

            stream.Seek(0x3056C, SeekOrigin.Begin);
            writer.Write(Money);

            stream.Seek(0x3871C, SeekOrigin.Begin);
            writer.Write(Experience);

            stream.Seek(0x30570, SeekOrigin.Begin);
            foreach (var item in Inventory)
                Item.Write(item, writer);

            stream.Seek(0x31170, SeekOrigin.Begin);
            foreach (var item in CorpseInventory)
                Item.Write(item, writer);

            stream.Seek(0x31D70, SeekOrigin.Begin);
            foreach (var weapon in Weapons)
                Weapon.Write(weapon, writer);

            stream.Seek(0x324BC, SeekOrigin.Begin);
            foreach (var chip in Chips)
                Chip.Write(chip, writer);

            return stream.ToArray();
        }
    }
}