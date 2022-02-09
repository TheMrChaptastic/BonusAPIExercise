using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;

namespace BonusAPIExercise
{
    public static class Professions
    {
        public static void GetProfessions(HttpClient client)
        {
            string conn = "https://api.guildwars2.com/v2/professions";
            var gw2API = client.GetStringAsync(conn).Result;
            var succ = true;
            var uInput = "";
            var classes = new string[9] { "Guardian", "Warrior", "Engineer", "Ranger", "Thief", "Elementalist", "Mesmer", "Necromancer", "Revenant" };
            do
            {
                Console.Clear();
                foreach (var c in classes)
                {
                    Console.WriteLine(c);
                }
                Console.WriteLine();

                Console.Write("Choose a Class: ");
                uInput = Console.ReadLine();

                switch (uInput.ToLower())
                {
                    case "guardian":
                        conn = "https://api.guildwars2.com/v2/professions/Guardian";
                        break;
                    case "warrior":
                        conn = "https://api.guildwars2.com/v2/professions/Warrior";
                        break;
                    case "engineer":
                        conn = "https://api.guildwars2.com/v2/professions/Engineer";
                        break;
                    case "ranger":
                        conn = "https://api.guildwars2.com/v2/professions/Ranger";
                        break;
                    case "thief":
                        conn = "https://api.guildwars2.com/v2/professions/Thief";
                        break;
                    case "elementalist":
                        conn = "https://api.guildwars2.com/v2/professions/Elementalist";
                        break;
                    case "mesmer":
                        conn = "https://api.guildwars2.com/v2/professions/Mesmer";
                        break;
                    case "necromancer":
                        conn = "https://api.guildwars2.com/v2/professions/Necromancer";
                        break;
                    case "revenant":
                        conn = "https://api.guildwars2.com/v2/professions/Revenant";
                        break;
                    default:
                        succ = false;
                        break;
                }

                if (succ)
                {
                    gw2API = client.GetStringAsync(conn).Result;

                    var name = JObject.Parse(gw2API).GetValue("name");
                    var weps = JObject.Parse(gw2API).GetValue("weapons");

                    var weapons = WeaponParse.GetWeapons(weps);
                    
                    Console.WriteLine($"Class: {name}\nWeapons:");
                    foreach (var weapon in weapons)
                    {
                        Console.WriteLine(weapon);
                    }

                    Console.WriteLine();
                    Console.WriteLine("type \"back\" to go to menu. Enter to restart.");
                    uInput = Console.ReadLine().ToLower();
                }
            } while (uInput.ToLower() != "back") ;
        }
    }
}
