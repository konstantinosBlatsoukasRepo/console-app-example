using System;
using Autofac;
using Microsoft.Extensions.Hosting;
using MyGenericHost.Extensions;
using MyGenericHost.Services;
using System.Threading.Tasks;
using MyGenericHost.DependencyInjenction;


namespace MyGenericHost
{
    public static class Program
    {
        public static Task Main(string[] args)
        {
            var hostBuilder = new HostBuilder().ConfigureHostBuilder(args);
            return hostBuilder.RunConsoleAsync();
        }

        private static IHostBuilder ConfigureHostBuilder(this IHostBuilder hostBuilder, string[] args)
        {
            // Host & Application Configuration setup

            // reads/loads configuration values regarding the host
            // those values are usually are in environmental variables with a specific prefix
            // and command line args
            Console.WriteLine("ConfigureDefaultHostConfiguration");
            hostBuilder.ConfigureDefaultHostConfiguration();

            // reads/loads configuration values regarding the app
            // those configurations usually are included in json files (i.e. appsettings.json)
            // or command line args or environmental vars
            Console.WriteLine("ConfigureDefaultAppConfiguration");
            hostBuilder.ConfigureDefaultAppConfiguration();

            // logging setup
            hostBuilder.ConfigureDefaultLogging();

            // Dependency Injection Setup
            Console.WriteLine("Dependency Injection Setup");
            hostBuilder.UseAutofacServiceProvider();
            hostBuilder.ConfigureContainer<ContainerBuilder>(ConfigureAutofacContainer);
            hostBuilder.ConfigureContainer<ContainerBuilder>(ConfigureHostedServices);

            return hostBuilder;
        }

        private static void ConfigureAutofacContainer(HostBuilderContext context, ContainerBuilder containerBuilder)
        {
            // why we are doing that?
            containerBuilder.AddAutofac();

            // Application Modules Registration
            containerBuilder.RegisterType<ComplexBusinessLogic>().As<IComplexBusinessLogic>();
        }

        /// <summary>
        /// Configures the <see cref="IHostedService"/>s to run on application start.
        /// Note: The order of the registrations is important.
        /// </summary>
        /// <param name="context">The host builder context.</param>
        /// <param name="containerBuilder">The container builder to configure the hosted services.</param>
        private static void ConfigureHostedServices(HostBuilderContext context, ContainerBuilder containerBuilder)
        {
            containerBuilder.AddHostedService<MyHostedService>();
        }

    }
}
