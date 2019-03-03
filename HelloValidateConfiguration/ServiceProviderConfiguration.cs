using System.Configuration;
using MasterYourConfig.Shared;
using Microsoft.Extensions.DependencyInjection;

namespace HelloValidateConfiguration
{
    public class ServiceProviderConfiguration
    {
        public static ServiceProvider CreateProvider()
        {
            var configuration = new Configuration(key => ConfigurationManager.AppSettings[key]);
            configuration.Validate();

            var services = new ServiceCollection()
                .AddSingleton<IConfiguration>(service => configuration)
                .AddSingleton<IConsole, Console>()
                .AddScoped<Introducer>();

            return services.BuildServiceProvider();
        } 
    }
}