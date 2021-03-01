using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Stone.Cobrancas.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stone.Cobrancas.Integration.Tests
{
    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureTestServices(services =>
            {
                var context = services.BuildServiceProvider().GetService<CobrancaContext>();
                context.Cobrancas.Database.DropCollection("Cobrancas");
            });

            base.ConfigureWebHost(builder);
        }

        protected override IHostBuilder CreateHostBuilder() =>
           base.CreateHostBuilder().UseEnvironment("IntegrationTests")
               .ConfigureHostConfiguration(
                   config => config.AddEnvironmentVariables("ASPNETCORE"));

    }
}
