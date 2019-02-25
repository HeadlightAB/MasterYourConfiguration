using System;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using MasterYourConfig.Shared.Models;

namespace HelloConfigurationManager
{
    public class Introducer
    {
        public void SayHello()
        {
            Console.Write("Hello, what's your name? ");
            var name = Console.ReadLine();

            var httpClient = new HttpClient();
            var requestUri = ConfigurationManager.AppSettings["RandomPersonGeneratorApiLocation"];
            var numberOfFriends = ConfigurationManager.AppSettings["NumberOfFriends"];

            var result = httpClient.GetStringAsync($"{requestUri}?results={numberOfFriends}").Result;

            var randomPersonResults = Newtonsoft.Json.JsonConvert.DeserializeObject<RandomPersonResults>(result);

            Console.WriteLine($"Hello {name}, my name is {randomPersonResults.Results[0].Name.First}.");
            Console.WriteLine($"I have {randomPersonResults.Results.Length - 1} friends, " +
                              $"{string.Join(", ", randomPersonResults.Results.Select(x => x.Name.First))}");
        }
    }
}
