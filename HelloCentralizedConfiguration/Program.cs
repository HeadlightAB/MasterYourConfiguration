using MasterYourConfig.Shared;

namespace HelloCentralizedConfiguration
{
    internal class Program
    {
        static void Main()
        {
            var introducer = new Introducer(new Console(), new Configuration());

            introducer.SayHello();

            System.Console.ReadLine();
        }
    }
}
