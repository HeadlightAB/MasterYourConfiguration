using System;

namespace HelloConfigurationManager
{
    internal class Program
    {
        static void Main()
        {
            var introducer = new Introducer();

            introducer.SayHello();

            Console.ReadLine();
        }
    }
}
