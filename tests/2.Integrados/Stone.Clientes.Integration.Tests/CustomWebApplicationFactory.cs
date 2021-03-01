using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Stone.Clientes.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stone.Clientes.Integration.Tests
{
    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureTestServices(services =>
            {
                var context = services.BuildServiceProvider().GetService<ClientesContext>();
                context.Database.EnsureDeleted();
            });

            base.ConfigureWebHost(builder);
        }

        protected override IHostBuilder CreateHostBuilder() =>
           base.CreateHostBuilder().UseEnvironment("IntegrationTests")
               .ConfigureHostConfiguration(
                   config => config.AddEnvironmentVariables("ASPNETCORE"));

    }
}
