using System;

namespace HelloLooselyCoupledConfiguration
{
    public class Configuration : IConfiguration
    {
        private readonly Func<string, string> _configurationManager;

        public Configuration(Func<string, string> configurationManager)
        {
            _configurationManager = configurationManager;
        }

        public string RandomPersonGeneratorApiLocation => _configurationManager("RandomPersonGeneratorApiLocation");
        public string NumberOfFriends => _configurationManager("NumberOfFriends");
    }
}