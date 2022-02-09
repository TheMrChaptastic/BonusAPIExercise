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
            Console.WriteLine();
            Console.WriteLine("Enter Your Characters Name: ");
            var userInput = Console.ReadLine();
            //Format it to "Upper Caseing" and only allow 2 words

            string conn = "https://api.guildwars2.com/v2/characters/" + userInput.Replace(" ","%20").Trim() + ApiKey;

            var gw2API = client.GetStringAsync(conn).Result;

            var charInfo = JObject.Parse(gw2API);
            var hoursOld = (int.Parse(charInfo["age"].ToString()) / 60 / 60);

            Console.WriteLine();
            Console.WriteLine($"{charInfo["name"]}: {charInfo["race"]} {charInfo["gender"]} {charInfo["profession"]}");
            Console.WriteLine($"Level: {charInfo["level"]} | Deaths so far: {charInfo["deaths"]}");
            Console.WriteLine($"{hoursOld} Hours old.");
            Console.ReadLine();
        }
        

    }
}
