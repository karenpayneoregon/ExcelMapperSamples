﻿using Microsoft.Extensions.DependencyInjection;
using SampleApp4.Models.Configuration;


namespace SampleApp4.Classes.Configuration;
internal class ApplicationConfiguration
{
    /// <summary>
    /// Sets up the services for connection string and should mock data be used
    /// </summary>
    /// <returns>ServiceCollection</returns>
    public static ServiceCollection ConfigureServices()
    {
        static void ConfigureService(IServiceCollection services)
        {

            services.Configure<ConnectionStrings>(Config.Configuration.JsonRoot()
                .GetSection(nameof(ConnectionStrings)));

            services.Configure<EntityConfiguration>(Config.Configuration.JsonRoot()
                .GetSection(nameof(EntityConfiguration)));

            services.AddTransient<SetupServices>();
        }

        var services = new ServiceCollection();
        ConfigureService(services);

        return services;

    }
}


