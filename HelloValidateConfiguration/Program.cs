using System;
using Microsoft.Extensions.DependencyInjection;

namespace HelloValidateConfiguration
{
    internal class Program
    {
        static void Main()
        {
            var serviceProvider = ServiceProviderConfiguration.CreateProvider();

            var introducer = serviceProvider.GetService<Introducer>();
            introducer.SayHello();

            Console.ReadLine();
        }
    }
}
