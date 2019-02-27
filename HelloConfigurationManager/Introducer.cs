using System.Configuration;
using System.Linq;
using System.Net.Http;
using MasterYourConfig.Shared.Models;

namespace HelloConfigurationManager
{
    public class Introducer
    {
        private readonly IConsole _console;

        public Introducer(IConsole console)
        {
            _console = console;
        }

        public void SayHello()
        {
            _console.Write("Hello, what's your name? ");
            var name = _console.ReadLine();

            var httpClient = new HttpClient();
            var requestUri = ConfigurationManager.AppSettings["RandomPersonGeneratorApiLocation"];
            var numberOfFriends = ConfigurationManager.AppSettings["NumberOfFriends"];

            var result = httpClient.GetStringAsync($"{requestUri}?results={numberOfFriends}").Result;

            var randomPersonResults = Newtonsoft.Json.JsonConvert.DeserializeObject<RandomPersonResults>(result);

            _console.WriteLine($"Hello {name}, my name is {randomPersonResults.Results[0].Name.First}.");
            _console.WriteLine($"I have {randomPersonResults.Results.Length - 1} friends, " +
                              $"{string.Join(", ", randomPersonResults.Results.Skip(1).Select(x => x.Name.First))}");
        }
    }
}
