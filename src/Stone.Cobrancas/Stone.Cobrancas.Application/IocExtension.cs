using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Stone.Cobrancas.Application.Interfaces;
using Stone.Cobrancas.Application.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stone.Cobrancas.Application
{
    public static class IocExtension
    {
        public static IServiceCollection ConfigurarIoc(this IServiceCollection service)
        {
            service.AddSingleton(p => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ViewModelToDomainProfile>();
                cfg.AddProfile<DomainToViewModelToProfile>();
            }).CreateMapper());

            service.AddScoped<ICobrancaApplication, CobrancaApplication>();
            ///TODO - Ajustar
            //service.AddScoped<ICobrancaService, CobrancaService>();
            //service.AddScoped<ICobrancaRepository, CobrancaRepository>();

            //service.AddScoped<CobrancaInsertValidation>();
            //service.AddScoped<CobrancaViewModelValidation>();

            return service;
        }
    }
}
