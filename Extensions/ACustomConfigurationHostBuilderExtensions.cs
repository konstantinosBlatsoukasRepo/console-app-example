using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Hosting;

namespace MyGenericHost.Extensions
{
    public static class ACustomConfigurationHostBuilderExtensions
    {
        public static IHostBuilder ConfigureMyCustomOptions(this IHostBuilder hostBuilder)
        {
            Console.WriteLine("Here are some awesome configuration options");
            return hostBuilder;
        }
    }

}
