using System;
using System.Linq;
using System.Net.Http;
using MasterYourConfig.Shared.Models;

namespace HelloLooselyCoupledConfiguration
{
    public class Introducer
    {
        private readonly IConfiguration _configuration;

        public Introducer(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void SayHello()
        {
            Console.Write("Hello, what's your name? ");
            var name = Console.ReadLine();

            var httpClient = new HttpClient();
            var requestUri = _configuration.RandomPersonGeneratorApiLocation;
            var numberOfFriends = _configuration.NumberOfFriends;

            var result = httpClient.GetStringAsync($"{requestUri}?results={numberOfFriends}").Result;

            var randomPersonResults = Newtonsoft.Json.JsonConvert.DeserializeObject<RandomPersonResults>(result);

            Console.WriteLine($"Hello {name}, my name is {randomPersonResults.Results[0].Name.First}.");
            Console.WriteLine($"I have {randomPersonResults.Results.Length - 1} friends, " +
                              $"{string.Join(", ", randomPersonResults.Results.Select(x => x.Name.First))}");
        }
    }
}