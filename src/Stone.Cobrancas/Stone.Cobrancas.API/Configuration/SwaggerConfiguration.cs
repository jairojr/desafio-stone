using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

namespace Stone.Cobrancas.API.Configuration
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
                        Title = "Stone.Cobrancas",
                        Description = "API que registra uma cobrança para um determinado clien.",
                        Version = "v1"
                    });

                var pasta = AppContext.BaseDirectory;
                c.IncludeXmlComments(Path.Combine(pasta, "Stone.Cobrancas.API.xml"));
                c.IncludeXmlComments(Path.Combine(pasta, "Stone.Clientes.Application.xml"));
                c.IncludeXmlComments(Path.Combine(pasta, "Stone.Utils.xml"));
            });

            return services;
        }

        internal static IApplicationBuilder UseSwaggerStone(this IApplicationBuilder app)
        {
            SwaggerBuilderExtensions.UseSwagger(app)
               .UseSwaggerUI(setup =>
               {
                   setup.SwaggerEndpoint("/swagger/v1/swagger.json", "Stone.Cobrancas");
               });

            return app;
        }
    }
}
