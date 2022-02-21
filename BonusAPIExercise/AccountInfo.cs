using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;

namespace BonusAPIExercise
{
    public class AccountInfo
    {
        public AccountInfo(IConfigurationRoot config)
        {
            string apiKey = config.GetConnectionString("GW2Key");
            if (apiKey == "" || apiKey == null)
            {
                Console.WriteLine("Please enter your GW2 API Key: ");
                apiKey = "?access_token=" + Console.ReadLine().Trim();
            }
            ApiKey = apiKey;
        }
        public string ApiKey { get; set; }
        public void GetCharacterInfo(HttpClient client)
        {
            Console.Clear();
            Console.WriteLine("Enter Your Characters Name: ");
            var userInput = Console.ReadLine();
            //Format it to "Upper Caseing" and only allow 2 words
            //add try catch incase no character exists
            try
            {
                string charConn = "https://api.guildwars2.com/v2/characters/" + userInput.Replace(" ", "%20").Trim() + ApiKey;
                var gw2CharAPI = client.GetStringAsync(charConn).Result;
                var charInfo = JObject.Parse(gw2CharAPI);
                var title = "";
                if (charInfo["title"] != null)
                {
                    var titleId = charInfo["title"].ToString();
                    string titleConn = "https://api.guildwars2.com/v2/titles/" + titleId;
                    var gw2TitleAPI = client.GetStringAsync(titleConn).Result;
                    title = JObject.Parse(gw2TitleAPI).GetValue("name").ToString();
                }
                else
                {
                    title = "\'No Title\'";
                }

                var specializations = charInfo["specializations"]["pve"].ToString();

                var hoursOld = (int.Parse(charInfo["age"].ToString()) / 60 / 60);
                var spec = SpecializationParser.GetSpecialization(charInfo["profession"].ToString(), specializations);

                Console.WriteLine();
                Console.WriteLine($"{charInfo["name"]} - {title}");
                Console.WriteLine($"{charInfo["race"]} {charInfo["gender"]} {spec} {charInfo["profession"]}");
                Console.WriteLine($"Level: {charInfo["level"]} | Deaths so far: {charInfo["deaths"]}");
                Console.WriteLine($"{hoursOld} Hours old.");
                Console.ReadLine();
            }
            catch
            {
                Console.WriteLine("Character doesnt exist in account or API key doesnt have correct permissions.");
                Console.WriteLine("Enter to continue.");
                Console.ReadLine();
            }
        }

    }
}
