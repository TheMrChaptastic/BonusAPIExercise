using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BonusAPIExercise
{
    public static class SpecializationParser
    {
        public static string GetSpecialization(string prof, string specObjStr)
        {
            var spec = "";
            switch (prof)
            {
                case "Guardian":
                    spec = GuardianSpec(specObjStr);
                    break;
                case "Warrior":
                    spec = WarriorSpec(specObjStr);
                    break;
                case "Revenant":
                    spec = RevenantSpec(specObjStr);
                    break;
                case "Thief":
                    spec = ThiefSpec(specObjStr);
                    break;
                case "Ranger":
                    spec = RangerSpec(specObjStr);
                    break;
                case "Engineer":
                    spec = EngineerSpec(specObjStr);
                    break;
                case "Mesmer":
                    spec = MesmerSpec(specObjStr);
                    break;
                case "Elementalist":
                    spec = ElementalistSpec(specObjStr);
                    break;
                case "Necromancer":
                    spec = NecromancerSpec(specObjStr);
                    break;
            }
            return spec;
        }

        private static string GuardianSpec(string objStr)
        {
            if (objStr.Contains(" 65"))
            {
                return "Willbender";
            }
            else if (objStr.Contains(" 62,"))
            {
                return "Firebrand";
            }
            else if (objStr.Contains(" 27,"))
            {
                return "Dragonhunter";
            }
            return "Core";
        }

        private static string WarriorSpec(string objStr)
        {
            if (objStr.Contains(" 68"))
            {
                return "Bladesworn";
            }
            else if (objStr.Contains(" 61,"))
            {
                return "Spellbreaker";
            }
            else if (objStr.Contains(" 18,"))
            {
                return "Berserker";
            }
            return "Core";
        }
        private static string RevenantSpec(string objStr)
        {
            if (objStr.Contains(" 69"))
            {
                return "Vindicator";
            }
            else if (objStr.Contains(" 52,"))
            {
                return "Herald";
            }
            else if (objStr.Contains(" 63,"))
            {
                return "Renegade";
            }
            return "Core";
        }
        private static string RangerSpec(string objStr)
        {
            if (objStr.Contains(" 72"))
            {
                return "Untamed";
            }
            else if (objStr.Contains(" 55,"))
            {
                return "Soulbeast";
            }
            else if (objStr.Contains(" 5,"))
            {
                return "Druid";
            }
            return "Core";
        }
        private static string EngineerSpec(string objStr)
        {
            if (objStr.Contains(" 70"))
            {
                return "Mechanist";
            }
            else if (objStr.Contains(" 57,"))
            {
                return "Holosmith";
            }
            else if (objStr.Contains(" 43,"))
            {
                return "Scrapper";
            }
            return "Core";
        }
        private static string ThiefSpec(string objStr)
        {
            if (objStr.Contains(" 71"))
            {
                return "Specter";
            }
            else if (objStr.Contains(" 58,"))
            {
                return "Deadeye";
            }
            else if (objStr.Contains(" 7,"))
            {
                return "Daredevil";
            }
            return "Core";
        }
        private static string MesmerSpec(string objStr)
        {
            if (objStr.Contains(" 66"))
            {
                return "Virtuoso";
            }
            else if (objStr.Contains(" 59,"))
            {
                return "Mirage";
            }
            else if (objStr.Contains(" 40,"))
            {
                return "Chronomancer";
            }
            return "Core";
        }
        private static string NecromancerSpec(string objStr)
        {
            if (objStr.Contains(" 64"))
            {
                return "Harbinger";
            }
            else if (objStr.Contains(" 60,"))
            {
                return "Scourge";
            }
            else if (objStr.Contains(" 34,"))
            {
                return "Reaper";
            }
            return "Core";
        }
        private static string ElementalistSpec(string objStr)
        {
            if (objStr.Contains(" 67"))
            {
                return "Catalyst";
            }
            else if (objStr.Contains(" 48,"))
            {
                return "Tempest";
            }
            else if (objStr.Contains(" 56,"))
            {
                return "Weaver";
            }
            return "Core";
        }
    }
}
