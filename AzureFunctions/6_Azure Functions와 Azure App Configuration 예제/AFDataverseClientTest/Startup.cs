using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.IO;

[assembly: FunctionsStartup(typeof(AFDataverseClientTest.Startup))]

namespace AFDataverseClientTest
{
    internal class Startup : FunctionsStartup
    {
        public override void ConfigureAppConfiguration(IFunctionsConfigurationBuilder builder)
        {
            string cs = Environment.GetEnvironmentVariable("ACCS");
            
            builder.ConfigurationBuilder
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("local.settings.json", optional: false, reloadOnChange: false)
                .AddEnvironmentVariables()
                .Build();

            builder.ConfigurationBuilder.AddAzureAppConfiguration(cs);
            
        }

        public override void Configure(IFunctionsHostBuilder builder)
        {
            
        }
    }
}
