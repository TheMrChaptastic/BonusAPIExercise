using System;
using System.IO;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;

namespace BonusAPIExercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();
            var config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            var uInput = "";
            AccountInfo accInfo;
            do
            {
                Console.Clear();
                Console.WriteLine("Character = Character Information(!Requires API Key with Permissions!) \nProfession = Professions Info" +
                    "\nDaily = Dailies Today \nBoss = World Bosses");
                Console.WriteLine("\nChoose an Option!");
                uInput = Console.ReadLine();
                switch (uInput.ToLower())
                {
                    case "character":
                    case "characters":
                        accInfo = new AccountInfo(config);
                        accInfo.GetCharacterInfo(client);
                        break;
                    case "profession":
                    case "professions":
                        Professions.GetProfessions(client);
                        break;
                    case "daily":
                    case "dailies":
                        Console.WriteLine("Not implemented yet.");
                        Console.ReadLine();
                        //Daily.GetDailies(client);
                        break;
                    case "boss":
                    case "bosses":
                        Console.WriteLine("Not implemented yet.");
                        Console.ReadLine();
                        //Boss.GetBosses(client);
                        break;
                    case "exit":
                        Console.WriteLine("Hope you enjoyed!");
                        break;
                    default:
                        Console.WriteLine("Input not Recognized.");
                        break;
                }
            } while (uInput.ToLower() != "exit");
        }
    }
}
