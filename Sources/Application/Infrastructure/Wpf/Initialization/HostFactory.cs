using System;
using Lamar;
using Lamar.Microsoft.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Mmu.WpfGraphApiTool.Infrastructure.Settings.Models;
using NLog.Extensions.Logging;

namespace Mmu.WpfGraphApiTool.Infrastructure.Wpf.Initialization
{
    public static class HostFactory
    {
        public static IHost Create()
        {
            var builder = new HostBuilder()
                .ConfigureAppConfiguration(
                    (_, configBuilder) =>
                    {
                        var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

                        configBuilder
                            .SetBasePath(AppContext.BaseDirectory)
                            .AddJsonFile("appsettings.json", true, false)
                            .AddJsonFile($"appsettings.{environment}.json", true);

                        if (environment == "Development")
                        {
                            configBuilder.AddUserSecrets<AppSettings>();
                        }
                    })
                .ConfigureLogging(
                    loggingBuilder =>
                    {
                        loggingBuilder.AddNLog();
                    })
                .UseServiceProviderFactory<ServiceRegistry>(new LamarServiceProviderFactory())
                .ConfigureServices(
                    (hostContext, services) =>
                    {
                        services.Configure<AppSettings>(hostContext.Configuration.GetSection(AppSettings.SectionKey));
                        services.AddLamar();
                    })
                .ConfigureContainer(
                    (HostBuilderContext context, ServiceRegistry registry) =>
                    {
                        registry.Scan(
                            scanner =>
                            {
                                scanner.AssembliesFromPath(context.HostingEnvironment.ContentRootPath);
                                scanner.LookForRegistries();
                            });
                    });

            return builder.Build();
        }
    }
}