using System.Configuration;

namespace HelloCentralizedConfiguration
{
    public class Configuration : IConfiguration
    {
        public string RandomPersonGeneratorApiLocation => ConfigurationManager.AppSettings["RandomPersonGeneratorApiLocation"];
        public string NumberOfFriends => ConfigurationManager.AppSettings["NumberOfFriends"];
    }
}