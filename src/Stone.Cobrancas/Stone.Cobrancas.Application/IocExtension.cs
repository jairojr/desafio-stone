using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Stone.Cobrancas.Application.Interfaces;
using Stone.Cobrancas.Application.Mapping;
using Stone.Cobrancas.Application.Validation;
using Stone.Cobrancas.Data;
using Stone.Cobrancas.Data.Repositories;
using Stone.Cobrancas.Domain.Repositories;
using Stone.Cobrancas.Domain.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Stone.Cobrancas.Application
{
    /// <summary>
    /// Extensão para IoC
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class IocExtension
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        public static IServiceCollection ConfigurarIoc(this IServiceCollection service)
        {
            service.AddSingleton(p => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ViewModelToDomainProfile>();
                cfg.AddProfile<DomainToViewModelToProfile>();
            }).CreateMapper());

            service.AddScoped<ICobrancaApplication, CobrancaApplication>();
            service.AddScoped<ICobrancaService, CobrancaService>();
            service.AddScoped<ICobrancaRepository, CobrancaRepository>();

            service.AddScoped<CobrancaViewModelValidation>();
            service.AddScoped<BuscarCobrancaViewModelValidation>();
            
            service.AddSingleton<CobrancaContext>();

            return service;
        }
    }
}
