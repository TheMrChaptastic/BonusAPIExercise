using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BonusAPIExercise
{
    public static class WeaponParse
    {
        public static string GetWeapons(JToken conn)
        {
            var tempS = "";
            var rList = new List<string>();
            var weaponsCheckList = new List<string>() { "Axe", "Dagger", "Mace", "Pistol", "Sword", "Scepter", "Focus", "Shield", 
                "Torch", "Warhorn", "Greatsword", "Hammer", "Longbow", "Rifle", "Shortbow", "Staff" };

            foreach(var w in weaponsCheckList)
            {
                tempS = "";
                if (conn[$"{w}"] != null)
                {
                    tempS += w;
                    tempS += GetFlags(conn[$"{w}"]);
                    rList.Add(tempS);
                }
            }
            var wepsString = "";
            foreach (var weapon in rList)
            {
                wepsString += weapon + ", ";
            }

            return wepsString;
        }

        public static string GetFlags(JToken wep)
        {
            var rVal = "";
            if (wep["flags"].ToString().Contains("Mainhand"))
            {
                rVal += "(MH)";
            }
            if (wep["flags"].ToString().Contains("Offhand"))
            {
                rVal += "(OH)";
            }
            if (wep["flags"].ToString().Contains("TwoHand"))
            {
                rVal += "(2H)";
            }
            return rVal;
        }
    }
}
