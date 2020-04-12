using System;
using System.Collections.Generic;
using System.Linq;

namespace NieR.Automata.Editor
{
    static class Experience
    {
        private static readonly IReadOnlyList<(int Level, int Experience)> ExperienceTable = new List<(int, int)>()
        {
            (1, 0),
            (2, 48),
            (3, 139),
            (4, 294),
            (5, 525),
            (6, 843),
            (7, 1259),
            (8, 1782),
            (9, 2421),
            (10, 3184),
            (11, 4080),
            (12, 5116),
            (13, 6300),
            (14, 7638),
            (15, 9139),
            (16, 10809),
            (17, 12654),
            (18, 14682),
            (19, 16898),
            (20, 19309),
            (21, 21920),
            (22, 24739),
            (23, 27770),
            (24, 31019),
            (25, 34493),
            (26, 38196),
            (27, 42134),
            (28, 46312),
            (29, 50736),
            (30, 55412),
            (31, 60343),
            (32, 65536),
            (33, 70994),
            (34, 76724),
            (35, 82730),
            (36, 89017),
            (37, 95590),
            (38, 102453),
            (39, 109611),
            (40, 117070),
            (41, 124832),
            (42, 132904),
            (43, 141288),
            (44, 149991),
            (45, 159016),
            (46, 168368),
            (47, 178051),
            (48, 188068),
            (49, 198426),
            (50, 209127),
            (51, 220177),
            (52, 231578),
            (53, 243336),
            (54, 255454),
            (55, 267937),
            (56, 280788),
            (57, 294011),
            (58, 307611),
            (59, 321591),
            (60, 335956),
            (61, 350709),
            (62, 365854),
            (63, 381395),
            (64, 397336),
            (65, 413680),
            (66, 430431),
            (67, 447594),
            (68, 465171),
            (69, 483167),
            (70, 501585),
            (71, 520429),
            (72, 539702),
            (73, 559408),
            (74, 579552),
            (75, 600135),
            (76, 621162),
            (77, 642637),
            (78, 664562),
            (79, 686942),
            (80, 709780),
            (81, 733079),
            (82, 756843),
            (83, 781075),
            (84, 805779),
            (85, 830958),
            (86, 856615),
            (87, 882754),
            (88, 909379),
            (89, 936491),
            (90, 964096),
            (91, 992196),
            (92, 1020794),
            (93, 1049894),
            (94, 1079499),
            (95, 1109612),
            (96, 1140237),
            (97, 1171376),
            (98, 1203033),
            (99, 1235211)
        };

        public static int GetLevelFromExperience(int experience)
        {
            if (experience < 0)
                throw new ArgumentOutOfRangeException(nameof(experience), $@"{nameof(experience)} cannot be a negative integer.");

            var maxLevel = ExperienceTable.Last();
            if (experience >= maxLevel.Experience)
                return maxLevel.Level;
            return ExperienceTable.First(m => m.Experience > experience).Level - 1;
        }

        public static int GetExperienceToNextLevel(int experience)
        {
            if (experience < 0)
                throw new ArgumentOutOfRangeException(nameof(experience), $@"{nameof(experience)} cannot be a negative integer.");

            var next = ExperienceTable.SkipWhile(m => m.Experience <= experience).FirstOrDefault();
            if (next == default)
                return 0;
            return next.Experience - experience;
        }
    }
}
