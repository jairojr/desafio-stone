using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Stone.Clientes.API.Configuration
{
    internal static class SwaggerConfiguration
    {
        internal static IServiceCollection AddSwagger(this IServiceCollection services, IWebHostEnvironment env)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new Microsoft.OpenApi.Models.OpenApiInfo()
                    {
                        Title = "Stone.Clientes",
                        Description = "API que permite cadastro e consulta de clientes.",
                        Version = "v1"
                    });

                var pasta = AppContext.BaseDirectory;
                var caminhoXml = Path.Combine(pasta, $"{env.ApplicationName}.xml");

                c.IncludeXmlComments(caminhoXml);
            });

            return services;
        }

        internal static IApplicationBuilder UseSwaggerStone(this IApplicationBuilder app)
        {
            SwaggerBuilderExtensions.UseSwagger(app)
               .UseSwaggerUI(setup =>
                {
                    setup.SwaggerEndpoint("/swagger/v1/swagger.json", "Stone.Clientes");
                });

            return app;
        }
    }
}
