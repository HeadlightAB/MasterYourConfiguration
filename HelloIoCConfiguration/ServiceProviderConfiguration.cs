using System.Configuration;
using MasterYourConfig.Shared;
using Microsoft.Extensions.DependencyInjection;

namespace HelloIoCConfiguration
{
    public class ServiceProviderConfiguration
    {
        public static ServiceProvider CreateProvider()
        {
            var services = new ServiceCollection()
                .AddSingleton<IConfiguration>(service => new Configuration(key => ConfigurationManager.AppSettings[key]))
                .AddSingleton<IConsole, Console>()
                .AddScoped<Introducer>();

            return services.BuildServiceProvider();
        } 
    }
}