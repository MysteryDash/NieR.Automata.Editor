using System.Collections.Generic;
using System.IO;

namespace NieR.Automata.Editor
{
    class Item
    {
        public static Item Empty { get; } = new Item
        {
            Id = unchecked((int)0xFFFFFFFF),
            Status = ItemStatus.Inactive,
            Quantity = 0,
            Name = "Empty"
        };

        public static IReadOnlyDictionary<int, Item> Items { get; } = new Dictionary<int, Item>()
        {
            [0x00000000] = new Item() { Id = 0x00000000, Status = ItemStatus.Active, Quantity = 1, Name = "Small Recovery" },
            [0x00000001] = new Item() { Id = 0x00000001, Status = ItemStatus.Active, Quantity = 1, Name = "Medium Recovery" },
            [0x00000002] = new Item() { Id = 0x00000002, Status = ItemStatus.Active, Quantity = 1, Name = "Large Recovery" },
            [0x00000003] = new Item() { Id = 0x00000003, Status = ItemStatus.Active, Quantity = 1, Name = "Full Recovery" },
            [0x0000003C] = new Item() { Id = 0x0000003C, Status = ItemStatus.Active, Quantity = 1, Name = "Visual Cure" },
            [0x00000046] = new Item() { Id = 0x00000046, Status = ItemStatus.Active, Quantity = 1, Name = "Aural Cure" },
            [0x0000004B] = new Item() { Id = 0x0000004B, Status = ItemStatus.Active, Quantity = 1, Name = "Cure Manipulation" },
            [0x00000050] = new Item() { Id = 0x00000050, Status = ItemStatus.Active, Quantity = 1, Name = "Cure All Status" },
            [0x0000005A] = new Item() { Id = 0x0000005A, Status = ItemStatus.Active, Quantity = 1, Name = "Cure All + Heal All" },
            [0x00000032] = new Item() { Id = 0x00000032, Status = ItemStatus.Active, Quantity = 1, Name = "Volt-Proof Salve" },
            [0x00000064] = new Item() { Id = 0x00000064, Status = ItemStatus.Active, Quantity = 1, Name = "Melee Attack Up (S)" },
            [0x00000066] = new Item() { Id = 0x00000066, Status = ItemStatus.Active, Quantity = 1, Name = "Melee Attack Up (L)" },
            [0x0000006E] = new Item() { Id = 0x0000006E, Status = ItemStatus.Active, Quantity = 1, Name = "Ranged Attack Up (S)" },
            [0x00000070] = new Item() { Id = 0x00000070, Status = ItemStatus.Active, Quantity = 1, Name = "Ranged Attack Up (L)" },
            [0x00000078] = new Item() { Id = 0x00000078, Status = ItemStatus.Active, Quantity = 1, Name = "Melee Defense Up (S)" },
            [0x0000007A] = new Item() { Id = 0x0000007A, Status = ItemStatus.Active, Quantity = 1, Name = "Melee Defense Up (L)" },
            [0x00000082] = new Item() { Id = 0x00000082, Status = ItemStatus.Active, Quantity = 1, Name = "Ranged Defense Up (S)" },
            [0x00000084] = new Item() { Id = 0x00000084, Status = ItemStatus.Active, Quantity = 1, Name = "Ranged Defense Up (L)" },
            [0x0000008C] = new Item() { Id = 0x0000008C, Status = ItemStatus.Active, Quantity = 1, Name = "Skill Salve (S)" },
            [0x0000008E] = new Item() { Id = 0x0000008E, Status = ItemStatus.Active, Quantity = 1, Name = "Skill Salve (L)" },
            [0x00000096] = new Item() { Id = 0x00000096, Status = ItemStatus.Active, Quantity = 1, Name = "Impact Bracer (S)" },
            [0x00000098] = new Item() { Id = 0x00000098, Status = ItemStatus.Active, Quantity = 1, Name = "Impact Bracer (L)" },
            [0x000000A0] = new Item() { Id = 0x000000A0, Status = ItemStatus.Active, Quantity = 1, Name = "Speed Salve (S)" },
            [0x000000A2] = new Item() { Id = 0x000000A2, Status = ItemStatus.Active, Quantity = 1, Name = "Speed Salve (L)" },
            [0x000000AA] = new Item() { Id = 0x000000AA, Status = ItemStatus.Active, Quantity = 1, Name = "Popola's Booze" },
            [0x0000012C] = new Item() { Id = 0x0000012C, Status = ItemStatus.Active, Quantity = 1, Name = "Animal Bait" },
            [0x0000014A] = new Item() { Id = 0x0000014A, Status = ItemStatus.Active, Quantity = 1, Name = "Small G Luck+" },
            [0x0000014C] = new Item() { Id = 0x0000014C, Status = ItemStatus.Active, Quantity = 1, Name = "Large G Luck+" },
            [0x00000190] = new Item() { Id = 0x00000190, Status = ItemStatus.Active, Quantity = 1, Name = "E-Drug" },
            [0x0000019A] = new Item() { Id = 0x0000019A, Status = ItemStatus.Active, Quantity = 1, Name = "Forbidden Fruit" },
            [0x00000258] = new Item() { Id = 0x00000258, Status = ItemStatus.Active, Quantity = 1, Name = "Copper Ore" },
            [0x00000259] = new Item() { Id = 0x00000259, Status = ItemStatus.Active, Quantity = 1, Name = "Iron Ore" },
            [0x0000025A] = new Item() { Id = 0x0000025A, Status = ItemStatus.Active, Quantity = 1, Name = "Silver Ore" },
            [0x0000025B] = new Item() { Id = 0x0000025B, Status = ItemStatus.Active, Quantity = 1, Name = "Gold Ore" },
            [0x00000212] = new Item() { Id = 0x00000212, Status = ItemStatus.Active, Quantity = 1, Name = "Rusted Clump" },
            [0x00000262] = new Item() { Id = 0x00000262, Status = ItemStatus.Active, Quantity = 1, Name = "Dented Plate" },
            [0x00000217] = new Item() { Id = 0x00000217, Status = ItemStatus.Active, Quantity = 1, Name = "Titanium Alloy" },
            [0x00000218] = new Item() { Id = 0x00000218, Status = ItemStatus.Active, Quantity = 1, Name = "Memory Alloy" },
            [0x000001FE] = new Item() { Id = 0x000001FE, Status = ItemStatus.Active, Quantity = 1, Name = "Beast Hide" },
            [0x0000021C] = new Item() { Id = 0x0000021C, Status = ItemStatus.Active, Quantity = 1, Name = "Broken Key" },
            [0x00000283] = new Item() { Id = 0x00000283, Status = ItemStatus.Active, Quantity = 1, Name = "Warped Wire" },
            [0x00000284] = new Item() { Id = 0x00000284, Status = ItemStatus.Active, Quantity = 1, Name = "Stretched Coil" },
            [0x00000286] = new Item() { Id = 0x00000286, Status = ItemStatus.Active, Quantity = 1, Name = "Broken Circuit" },
            [0x00000208] = new Item() { Id = 0x00000208, Status = ItemStatus.Active, Quantity = 1, Name = "Stripped Screw" },
            [0x00000209] = new Item() { Id = 0x00000209, Status = ItemStatus.Active, Quantity = 1, Name = "Pristine Screw" },
            [0x0000020D] = new Item() { Id = 0x0000020D, Status = ItemStatus.Active, Quantity = 1, Name = "Small Gear" },
            [0x0000020E] = new Item() { Id = 0x0000020E, Status = ItemStatus.Active, Quantity = 1, Name = "Large Gear" },
            [0x0000027B] = new Item() { Id = 0x0000027B, Status = ItemStatus.Active, Quantity = 1, Name = "Rusty Bolt" },
            [0x0000022B] = new Item() { Id = 0x0000022B, Status = ItemStatus.Active, Quantity = 1, Name = "New Bolt" },
            [0x0000027C] = new Item() { Id = 0x0000027C, Status = ItemStatus.Active, Quantity = 1, Name = "Crushed Nut" },
            [0x00000230] = new Item() { Id = 0x00000230, Status = ItemStatus.Active, Quantity = 1, Name = "Clean Nut" },
            [0x00000285] = new Item() { Id = 0x00000285, Status = ItemStatus.Active, Quantity = 1, Name = "Dented Socket" },
            [0x00000282] = new Item() { Id = 0x00000282, Status = ItemStatus.Active, Quantity = 1, Name = "Sturdy Socket" },
            [0x00000226] = new Item() { Id = 0x00000226, Status = ItemStatus.Active, Quantity = 1, Name = "Severed Cable" },
            [0x00000227] = new Item() { Id = 0x00000227, Status = ItemStatus.Active, Quantity = 1, Name = "Pristine Cable" },
            [0x00000221] = new Item() { Id = 0x00000221, Status = ItemStatus.Active, Quantity = 1, Name = "Broken Battery" },
            [0x00000222] = new Item() { Id = 0x00000222, Status = ItemStatus.Active, Quantity = 1, Name = "Large Battery" },
            [0x0000023A] = new Item() { Id = 0x0000023A, Status = ItemStatus.Active, Quantity = 1, Name = "Machine Arm" },
            [0x0000023B] = new Item() { Id = 0x0000023B, Status = ItemStatus.Active, Quantity = 1, Name = "Machine Leg" },
            [0x0000023C] = new Item() { Id = 0x0000023C, Status = ItemStatus.Active, Quantity = 1, Name = "Machine Torso" },
            [0x0000023D] = new Item() { Id = 0x0000023D, Status = ItemStatus.Active, Quantity = 1, Name = "Machine Head" },
            [0x000002A8] = new Item() { Id = 0x000002A8, Status = ItemStatus.Active, Quantity = 1, Name = "Crystal" },
            [0x000002AE] = new Item() { Id = 0x000002AE, Status = ItemStatus.Active, Quantity = 1, Name = "Pearl" },
            [0x0000027F] = new Item() { Id = 0x0000027F, Status = ItemStatus.Active, Quantity = 1, Name = "Black Pearl" },
            [0x00000278] = new Item() { Id = 0x00000278, Status = ItemStatus.Active, Quantity = 1, Name = "Pyrite" },
            [0x00000279] = new Item() { Id = 0x00000279, Status = ItemStatus.Active, Quantity = 1, Name = "Amber" },
            [0x000002AF] = new Item() { Id = 0x000002AF, Status = ItemStatus.Active, Quantity = 1, Name = "Moldavite" },
            [0x000002B0] = new Item() { Id = 0x000002B0, Status = ItemStatus.Active, Quantity = 1, Name = "Meteorite" },
            [0x00000213] = new Item() { Id = 0x00000213, Status = ItemStatus.Active, Quantity = 1, Name = "Meteorite Shard" },
            [0x00000244] = new Item() { Id = 0x00000244, Status = ItemStatus.Active, Quantity = 1, Name = "Simple Gadget" },
            [0x00000245] = new Item() { Id = 0x00000245, Status = ItemStatus.Active, Quantity = 1, Name = "Elaborate Gadget" },
            [0x00000246] = new Item() { Id = 0x00000246, Status = ItemStatus.Active, Quantity = 1, Name = "Complex Gadget" },
            [0x00000247] = new Item() { Id = 0x00000247, Status = ItemStatus.Active, Quantity = 1, Name = "Powerup Part S" },
            [0x00000248] = new Item() { Id = 0x00000248, Status = ItemStatus.Active, Quantity = 1, Name = "Powerup Part M" },
            [0x00000249] = new Item() { Id = 0x00000249, Status = ItemStatus.Active, Quantity = 1, Name = "Powerup Part L" },
            [0x00000270] = new Item() { Id = 0x00000270, Status = ItemStatus.Active, Quantity = 1, Name = "Tree Seed" },
            [0x0000026D] = new Item() { Id = 0x0000026D, Status = ItemStatus.Active, Quantity = 1, Name = "Plant Seed" },
            [0x0000026E] = new Item() { Id = 0x0000026E, Status = ItemStatus.Active, Quantity = 1, Name = "Tree Sap" },
            [0x00000272] = new Item() { Id = 0x00000272, Status = ItemStatus.Active, Quantity = 1, Name = "Mushroom" },
            [0x0000027E] = new Item() { Id = 0x0000027E, Status = ItemStatus.Active, Quantity = 1, Name = "Eagle Eggs" },
            [0x0000027D] = new Item() { Id = 0x0000027D, Status = ItemStatus.Active, Quantity = 1, Name = "Giant Egg" },
            [0x00000273] = new Item() { Id = 0x00000273, Status = ItemStatus.Active, Quantity = 1, Name = "Torn Book" },
            [0x000002AC] = new Item() { Id = 0x000002AC, Status = ItemStatus.Active, Quantity = 1, Name = "Tech Manual" },
            [0x000002AD] = new Item() { Id = 0x000002AD, Status = ItemStatus.Active, Quantity = 1, Name = "Thick Dictionary" },
            [0x0000026F] = new Item() { Id = 0x0000026F, Status = ItemStatus.Active, Quantity = 1, Name = "Pure Water" },
            [0x00000275] = new Item() { Id = 0x00000275, Status = ItemStatus.Active, Quantity = 1, Name = "Tanning Agent" },
            [0x00000277] = new Item() { Id = 0x00000277, Status = ItemStatus.Active, Quantity = 1, Name = "Dye" },
            [0x0000027A] = new Item() { Id = 0x0000027A, Status = ItemStatus.Active, Quantity = 1, Name = "Natural Rubber" },
            [0x00000274] = new Item() { Id = 0x00000274, Status = ItemStatus.Active, Quantity = 1, Name = "Machine Oil" },
            [0x00000276] = new Item() { Id = 0x00000276, Status = ItemStatus.Active, Quantity = 1, Name = "Filler Metal" },
            [0x00000204] = new Item() { Id = 0x00000204, Status = ItemStatus.Active, Quantity = 1, Name = "Moose Meat" },
            [0x00000203] = new Item() { Id = 0x00000203, Status = ItemStatus.Active, Quantity = 1, Name = "Boar Meat" },
            [0x00000206] = new Item() { Id = 0x00000206, Status = ItemStatus.Active, Quantity = 1, Name = "W. Moose Meat" },
            [0x00000205] = new Item() { Id = 0x00000205, Status = ItemStatus.Active, Quantity = 1, Name = "W. Boar Meat" },
            [0x00000280] = new Item() { Id = 0x00000280, Status = ItemStatus.Active, Quantity = 1, Name = "Shattered Earring" },
            [0x00000281] = new Item() { Id = 0x00000281, Status = ItemStatus.Active, Quantity = 1, Name = "Drab Bracelet" },
            [0x000002A9] = new Item() { Id = 0x000002A9, Status = ItemStatus.Active, Quantity = 1, Name = "Lovely Choker" },
            [0x000002AB] = new Item() { Id = 0x000002AB, Status = ItemStatus.Active, Quantity = 1, Name = "Precious Earrings" },
            [0x00000271] = new Item() { Id = 0x00000271, Status = ItemStatus.Active, Quantity = 1, Name = "Desert Rose" },
            [0x000002AA] = new Item() { Id = 0x000002AA, Status = ItemStatus.Active, Quantity = 1, Name = "Ancient Mask" },
            [0x000002B2] = new Item() { Id = 0x000002B2, Status = ItemStatus.Active, Quantity = 1, Name = "Machine Core" },
            [0x000002B3] = new Item() { Id = 0x000002B3, Status = ItemStatus.Active, Quantity = 1, Name = "Pascal's Core" },
            [0x000002B4] = new Item() { Id = 0x000002B4, Status = ItemStatus.Active, Quantity = 1, Name = "Children's Cores" },
            [0x000002B5] = new Item() { Id = 0x000002B5, Status = ItemStatus.Active, Quantity = 1, Name = "Pascal's Book" },
            [0x0000034D] = new Item() { Id = 0x0000034D, Status = ItemStatus.Active, Quantity = 1, Name = "Elevator Key" },
            [0x00000352] = new Item() { Id = 0x00000352, Status = ItemStatus.Active, Quantity = 1, Name = "Book: \"Pensées\"" },
            [0x00000353] = new Item() { Id = 0x00000353, Status = ItemStatus.Active, Quantity = 1, Name = "Fuel Filter" },
            [0x00000354] = new Item() { Id = 0x00000354, Status = ItemStatus.Active, Quantity = 1, Name = "Viscous Oil" },
            [0x00000334] = new Item() { Id = 0x00000334, Status = ItemStatus.Active, Quantity = 1, Name = "Forest Access Key" },
            [0x00000335] = new Item() { Id = 0x00000335, Status = ItemStatus.Active, Quantity = 1, Name = "Ocean Access Key" },
            [0x00000336] = new Item() { Id = 0x00000336, Status = ItemStatus.Active, Quantity = 1, Name = "Park Access Key" },
            [0x000002EE] = new Item() { Id = 0x000002EE, Status = ItemStatus.Active, Quantity = 1, Name = "Rusty Music Box" },
            [0x000002BC] = new Item() { Id = 0x000002BC, Status = ItemStatus.Active, Quantity = 1, Name = "Letter for Sartre" },
            [0x000002BD] = new Item() { Id = 0x000002BD, Status = ItemStatus.Active, Quantity = 1, Name = "Beautiful Glass" },
            [0x000002BE] = new Item() { Id = 0x000002BE, Status = ItemStatus.Active, Quantity = 1, Name = "Machine Fossil" },
            [0x000002BF] = new Item() { Id = 0x000002BF, Status = ItemStatus.Active, Quantity = 1, Name = "Sartre's Letter" },
            [0x000002CB] = new Item() { Id = 0x000002CB, Status = ItemStatus.Active, Quantity = 1, Name = "Memory Chip" },
            [0x000002CC] = new Item() { Id = 0x000002CC, Status = ItemStatus.Active, Quantity = 1, Name = "Man's Journal" },
            [0x000002D0] = new Item() { Id = 0x000002D0, Status = ItemStatus.Active, Quantity = 1, Name = "Data Chip A" },
            [0x000002D1] = new Item() { Id = 0x000002D1, Status = ItemStatus.Active, Quantity = 1, Name = "Data Chip B" },
            [0x000002D2] = new Item() { Id = 0x000002D2, Status = ItemStatus.Active, Quantity = 1, Name = "Data Chip C" },
            [0x000002D3] = new Item() { Id = 0x000002D3, Status = ItemStatus.Active, Quantity = 1, Name = "Data Chip D" },
            [0x000002D4] = new Item() { Id = 0x000002D4, Status = ItemStatus.Active, Quantity = 1, Name = "Data Chip E" },
            [0x000002F8] = new Item() { Id = 0x000002F8, Status = ItemStatus.Active, Quantity = 1, Name = "Desert Photo" },
            [0x000002F9] = new Item() { Id = 0x000002F9, Status = ItemStatus.Active, Quantity = 1, Name = "Amusement Park Photo" },
            [0x000002FA] = new Item() { Id = 0x000002FA, Status = ItemStatus.Active, Quantity = 1, Name = "Forest Photo" },
            [0x00000307] = new Item() { Id = 0x00000307, Status = ItemStatus.Active, Quantity = 1, Name = "Package" },
            [0x0000030C] = new Item() { Id = 0x0000030C, Status = ItemStatus.Active, Quantity = 1, Name = "Broken Toy" },
            [0x0000030D] = new Item() { Id = 0x0000030D, Status = ItemStatus.Active, Quantity = 1, Name = "Accounting Book" },
            [0x0000030E] = new Item() { Id = 0x0000030E, Status = ItemStatus.Active, Quantity = 1, Name = "Small Shoe" },
            [0x00000316] = new Item() { Id = 0x00000316, Status = ItemStatus.Active, Quantity = 1, Name = "Tri-color Cable" },
            [0x00000317] = new Item() { Id = 0x00000317, Status = ItemStatus.Active, Quantity = 1, Name = "Four-color Cable" },
            [0x00000318] = new Item() { Id = 0x00000318, Status = ItemStatus.Active, Quantity = 1, Name = "Five-color Cable" },
            [0x00000319] = new Item() { Id = 0x00000319, Status = ItemStatus.Active, Quantity = 1, Name = "Toothbrush" },
            [0x0000031A] = new Item() { Id = 0x0000031A, Status = ItemStatus.Active, Quantity = 1, Name = "Cosmetics" },
            [0x0000031B] = new Item() { Id = 0x0000031B, Status = ItemStatus.Active, Quantity = 1, Name = "Dietary Goods" },
            [0x0000031C] = new Item() { Id = 0x0000031C, Status = ItemStatus.Active, Quantity = 1, Name = "Writing Implement" },
            [0x0000031D] = new Item() { Id = 0x0000031D, Status = ItemStatus.Active, Quantity = 1, Name = "Medical Journal" },
            [0x00000340] = new Item() { Id = 0x00000340, Status = ItemStatus.Active, Quantity = 1, Name = "Machine Part" },
            [0x00000341] = new Item() { Id = 0x00000341, Status = ItemStatus.Active, Quantity = 1, Name = "Stamp" },
            [0x00000342] = new Item() { Id = 0x00000342, Status = ItemStatus.Active, Quantity = 1, Name = "Stamp Card" },
            [0x00000343] = new Item() { Id = 0x00000343, Status = ItemStatus.Active, Quantity = 1, Name = "Aged Stick" },
            [0x00000344] = new Item() { Id = 0x00000344, Status = ItemStatus.Active, Quantity = 1, Name = "Commandment Slab" },
            [0x00000345] = new Item() { Id = 0x00000345, Status = ItemStatus.Active, Quantity = 1, Name = "Filthy Mask" },
            [0x00000346] = new Item() { Id = 0x00000346, Status = ItemStatus.Active, Quantity = 1, Name = "Statue of a Girl" },
            [0x0000034A] = new Item() { Id = 0x0000034A, Status = ItemStatus.Active, Quantity = 1, Name = "Rigid Tree Bark" },
            [0x00000347] = new Item() { Id = 0x00000347, Status = ItemStatus.Active, Quantity = 1, Name = "Toy Material" },
            [0x00000348] = new Item() { Id = 0x00000348, Status = ItemStatus.Active, Quantity = 1, Name = "Storage Element" },
            [0x00000349] = new Item() { Id = 0x00000349, Status = ItemStatus.Active, Quantity = 1, Name = "Plug-in Chip" },
            [0x000002E4] = new Item() { Id = 0x000002E4, Status = ItemStatus.Active, Quantity = 1, Name = "Rusty Dog Tag" },
            [0x000002E5] = new Item() { Id = 0x000002E5, Status = ItemStatus.Active, Quantity = 1, Name = "Dirty Dog Tag" },
            [0x000002E6] = new Item() { Id = 0x000002E6, Status = ItemStatus.Active, Quantity = 1, Name = "Damaged Dog Tag" },
            [0x000002E7] = new Item() { Id = 0x000002E7, Status = ItemStatus.Active, Quantity = 1, Name = "Bloody Dog Tag" },
            [0x0000034B] = new Item() { Id = 0x0000034B, Status = ItemStatus.Active, Quantity = 1, Name = "Membership Card" },
            [0x0000034C] = new Item() { Id = 0x0000034C, Status = ItemStatus.Active, Quantity = 1, Name = "Dirty Bag" },
            [0x00000398] = new Item() { Id = 0x00000398, Status = ItemStatus.Active, Quantity = 1, Name = "Sachet" },
            [0x00000399] = new Item() { Id = 0x00000399, Status = ItemStatus.Active, Quantity = 1, Name = "Quality Sachet" },
            [0x0000039A] = new Item() { Id = 0x0000039A, Status = ItemStatus.Active, Quantity = 1, Name = "Choice Sachet" },
            [0x000003A2] = new Item() { Id = 0x000003A2, Status = ItemStatus.Active, Quantity = 1, Name = "Sound Data 1" },
            [0x000003A3] = new Item() { Id = 0x000003A3, Status = ItemStatus.Active, Quantity = 1, Name = "Sound Data 2" },
            [0x000003A4] = new Item() { Id = 0x000003A4, Status = ItemStatus.Active, Quantity = 1, Name = "Sound Data 3" },
            [0x000003A5] = new Item() { Id = 0x000003A5, Status = ItemStatus.Active, Quantity = 1, Name = "Sound Data 4" },
            [0x000003A6] = new Item() { Id = 0x000003A6, Status = ItemStatus.Active, Quantity = 1, Name = "Sound Data 5" },
            [0x000003A7] = new Item() { Id = 0x000003A7, Status = ItemStatus.Active, Quantity = 1, Name = "Record: 3C3C1D119440927" },
            [0x000003A8] = new Item() { Id = 0x000003A8, Status = ItemStatus.Active, Quantity = 1, Name = "Record: CEO" },
            [0x000003B6] = new Item() { Id = 0x000003B6, Status = ItemStatus.Active, Quantity = 1, Name = "Play System Pod" },
            [0x000003B7] = new Item() { Id = 0x000003B7, Status = ItemStatus.Active, Quantity = 1, Name = "Grimoire Weiss" },
            [0x000003B8] = new Item() { Id = 0x000003B8, Status = ItemStatus.Active, Quantity = 1, Name = "Cardboard Pod" },
            [0x000003B9] = new Item() { Id = 0x000003B9, Status = ItemStatus.Active, Quantity = 1, Name = "Blue Stripes Pod" },
            [0x000003BA] = new Item() { Id = 0x000003BA, Status = ItemStatus.Active, Quantity = 1, Name = "Retro Red Pod" },
            [0x000003BB] = new Item() { Id = 0x000003BB, Status = ItemStatus.Active, Quantity = 1, Name = "Retro White Pod" },
            [0x000003BC] = new Item() { Id = 0x000003BC, Status = ItemStatus.Active, Quantity = 1, Name = "Retro Black Pod" },
            [0x000003BD] = new Item() { Id = 0x000003BD, Status = ItemStatus.Active, Quantity = 1, Name = "Retro Grey Pod" },
            [0x000003BE] = new Item() { Id = 0x000003BE, Status = ItemStatus.Active, Quantity = 1, Name = "Retro Purple Pod" },
            [0x000003BF] = new Item() { Id = 0x000003BF, Status = ItemStatus.Active, Quantity = 1, Name = "amazarashi Head" },
            [0x000003C0] = new Item() { Id = 0x000003C0, Status = ItemStatus.Active, Quantity = 1, Name = "Emil Bullets" },
            [0x000003C1] = new Item() { Id = 0x000003C1, Status = ItemStatus.Active, Quantity = 1, Name = "CEO Bullets" },
            [0x000003D4] = new Item() { Id = 0x000003D4, Status = ItemStatus.Active, Quantity = 1, Name = "Dress Module" },
            [0x000003D5] = new Item() { Id = 0x000003D5, Status = ItemStatus.Active, Quantity = 1, Name = "Heavy Armor A" },
            [0x000003D6] = new Item() { Id = 0x000003D6, Status = ItemStatus.Active, Quantity = 1, Name = "Heavy Armor B" },
            [0x000003D7] = new Item() { Id = 0x000003D7, Status = ItemStatus.Active, Quantity = 1, Name = "Revealing Outfit" },
            [0x000003D8] = new Item() { Id = 0x000003D8, Status = ItemStatus.Active, Quantity = 1, Name = "Young Man's Outfit" },
            [0x000003D9] = new Item() { Id = 0x000003D9, Status = ItemStatus.Active, Quantity = 1, Name = "Destroyer Outfit" },
            [0x00000369] = new Item() { Id = 0x00000369, Status = ItemStatus.Active, Quantity = 1, Name = "Pink Ribbon" },
            [0x0000036A] = new Item() { Id = 0x0000036A, Status = ItemStatus.Active, Quantity = 1, Name = "Blue Ribbon" },
            [0x000003DE] = new Item() { Id = 0x000003DE, Status = ItemStatus.Active, Quantity = 1, Name = "Machine Mask" },
            [0x000003DF] = new Item() { Id = 0x000003DF, Status = ItemStatus.Active, Quantity = 1, Name = "Emil's Head" },
            [0x000003E1] = new Item() { Id = 0x000003E1, Status = ItemStatus.Active, Quantity = 1, Name = "Emil Mask" },
            [0x000003E0] = new Item() { Id = 0x000003E0, Status = ItemStatus.Active, Quantity = 1, Name = "Lunar Tear" },
            [0x000003E3] = new Item() { Id = 0x000003E3, Status = ItemStatus.Active, Quantity = 1, Name = "Adam's Glasses" },
            [0x000003E4] = new Item() { Id = 0x000003E4, Status = ItemStatus.Active, Quantity = 1, Name = "Alien Mask" },
            [0x00000367] = new Item() { Id = 0x00000367, Status = ItemStatus.Active, Quantity = 1, Name = "Camouflage Goggles" },
            [0x00000368] = new Item() { Id = 0x00000368, Status = ItemStatus.Active, Quantity = 1, Name = "A2 Wig" },
            [0x000003E2] = new Item() { Id = 0x000003E2, Status = ItemStatus.Active, Quantity = 1, Name = "Sand Mask" },
            [0x000003E5] = new Item() { Id = 0x000003E5, Status = ItemStatus.Active, Quantity = 1, Name = "Valve: Left Eye" },
            [0x000003E6] = new Item() { Id = 0x000003E6, Status = ItemStatus.Active, Quantity = 1, Name = "Valve: Right Eye" },
            [0x000003E7] = new Item() { Id = 0x000003E7, Status = ItemStatus.Active, Quantity = 1, Name = "Valve: Both Eyes" },
            [0x00000366] = new Item() { Id = 0x00000366, Status = ItemStatus.Active, Quantity = 1, Name = "Valve: Head" },
            [0x0000036B] = new Item() { Id = 0x0000036B, Status = ItemStatus.Active, Quantity = 1, Name = "Proof of Oath" },
            [0x0000036C] = new Item() { Id = 0x0000036C, Status = ItemStatus.Active, Quantity = 1, Name = "Masamune Mask" },
            [0x0000036D] = new Item() { Id = 0x0000036D, Status = ItemStatus.Active, Quantity = 1, Name = "Matsuda Mask" },
            [0x0000036E] = new Item() { Id = 0x0000036E, Status = ItemStatus.Active, Quantity = 1, Name = "Sato Mask" },
            [0x00000370] = new Item() { Id = 0x00000370, Status = ItemStatus.Active, Quantity = 1, Name = "White Hair" },
            [0x00000371] = new Item() { Id = 0x00000371, Status = ItemStatus.Active, Quantity = 1, Name = "Black Hair" },
            [0x00000372] = new Item() { Id = 0x00000372, Status = ItemStatus.Active, Quantity = 1, Name = "Brown Hair" },
            [0x00000373] = new Item() { Id = 0x00000373, Status = ItemStatus.Active, Quantity = 1, Name = "Red Hair" },
            [0x00000374] = new Item() { Id = 0x00000374, Status = ItemStatus.Active, Quantity = 1, Name = "Blue Hair" },
            [0x00000375] = new Item() { Id = 0x00000375, Status = ItemStatus.Active, Quantity = 1, Name = "Green Hair" },
            [0x00000376] = new Item() { Id = 0x00000376, Status = ItemStatus.Active, Quantity = 1, Name = "Purple Hair" },
            [0x00000377] = new Item() { Id = 0x00000377, Status = ItemStatus.Active, Quantity = 1, Name = "Ash Grey Hair" },
            [0x00000378] = new Item() { Id = 0x00000378, Status = ItemStatus.Active, Quantity = 1, Name = "Golden Hair" },
            [0x00000379] = new Item() { Id = 0x00000379, Status = ItemStatus.Active, Quantity = 1, Name = "Pastel Pink Hair" },
            [0x0000037A] = new Item() { Id = 0x0000037A, Status = ItemStatus.Active, Quantity = 1, Name = "Light Blue Hair" },
            [0x0000037B] = new Item() { Id = 0x0000037B, Status = ItemStatus.Active, Quantity = 1, Name = "Lime Green Hair" },
            [0x0000037C] = new Item() { Id = 0x0000037C, Status = ItemStatus.Active, Quantity = 1, Name = "Light Purple Hair" },
            [0x0000037D] = new Item() { Id = 0x0000037D, Status = ItemStatus.Active, Quantity = 1, Name = "Neon White Hair" },
            [0x0000037E] = new Item() { Id = 0x0000037E, Status = ItemStatus.Active, Quantity = 1, Name = "Neon Yellow Hair" },
            [0x0000037F] = new Item() { Id = 0x0000037F, Status = ItemStatus.Active, Quantity = 1, Name = "Neon Pink Hair" },
            [0x00000380] = new Item() { Id = 0x00000380, Status = ItemStatus.Active, Quantity = 1, Name = "Neon Blue Hair" },
            [0x00000381] = new Item() { Id = 0x00000381, Status = ItemStatus.Active, Quantity = 1, Name = "Neon Green Hair" },
            [0x00000382] = new Item() { Id = 0x00000382, Status = ItemStatus.Active, Quantity = 1, Name = "Neon Purple Hair" },
            [Empty.Id] = Empty
        };

        public string Name { get; private set; }
        public int Position { get; private set; }
        public int Id { get; set; }
        public ItemStatus Status { get; set; }
        public int Quantity { get; set; }

        public void ChangeType(int id)
        {
            if (Items.TryGetValue(id, out var newItem))
            {
                Id = id;
                Name = newItem.Name;
                if (Id == Empty.Id)
                {
                    Status = ItemStatus.Inactive;
                    Quantity = 0;
                }
                else
                {
                    Status = ItemStatus.Active;
                    Quantity = 1;
                }
            }
        }

        public override string ToString()
        {
            return Name;
        }

        public enum ItemStatus : int
        {
            Active = 0x00070000,
            Inactive = -1
        }

        public static Item Read(BinaryReader reader, int position)
        {
            var item = (Item)Empty.MemberwiseClone();
            item.Position = position;
            item.Id = reader.ReadInt32();
            item.Status = (ItemStatus)reader.ReadInt32();
            item.Quantity = reader.ReadInt32();
            item.Name = Items.TryGetValue(item.Id, out var knownItem) ? knownItem.Name : "???";
            return item;
        }

        public static void Write(Item item, BinaryWriter writer)
        {
            writer.Write(item.Id);
            writer.Write((int)item.Status);
            writer.Write(item.Quantity);
        }
    }
}