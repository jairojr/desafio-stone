using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Stone.Clientes.Application.Interfaces;
using Stone.Clientes.Application.Mapping;
using Stone.Clientes.Application.Validation;
using Stone.Clientes.Data.Repositories;
using Stone.Clientes.Domain.Repositories;
using Stone.Clientes.Domain.Services;
using Stone.Clientes.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stone.Clientes.Application
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

            service.AddScoped<IClienteApplication, ClienteApplication>();
            service.AddScoped<IClienteService, ClienteService>();
            service.AddScoped<IClienteRepository, ClienteRepository>();

            service.AddScoped<ClienteInsertValidation>();
            service.AddScoped<ClienteViewModelValidation>();

            return service;
        }
    }
}
