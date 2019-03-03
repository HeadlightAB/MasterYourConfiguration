using System;

namespace HelloValidateConfiguration
{
    public class Configuration : IConfiguration
    {
        private readonly Func<string, string> _configurationManager;

        public Configuration(Func<string, string> configurationManager)
        {
            _configurationManager = configurationManager;
        }

        public string RandomPersonGeneratorApiLocation => _configurationManager("RandomPersonGeneratorApiLocation");
        public int NumberOfFriends => Convert.ToInt32(_configurationManager("NumberOfFriends"));
    }
}