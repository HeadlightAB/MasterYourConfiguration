using System.Configuration;
using MasterYourConfig.Shared;

namespace HelloLooselyCoupledConfiguration
{
    class Program
    {
        static void Main()
        {
            var introducer = new Introducer(
                new Console(),
                new Configuration(key => ConfigurationManager.AppSettings[key]));

            introducer.SayHello();

            System.Console.ReadLine();
        }
    }
}