using AutoMapper;
using Stone.Clientes.Application.Enums;
using Stone.Clientes.Application.ViewModel;
using Stone.Clientes.Domain.Enums;
using Stone.Clientes.Domain.Models;
using Stone.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stone.Clientes.Application.Mapping
{
    /// <summary>
    /// Automapper ViewModel -> Domain
    /// </summary>
    public class ViewModelToDomainProfile : Profile
    {
        /// <summary>
        /// 
        /// </summary>
        public ViewModelToDomainProfile()
        {
            CreateMap<ClienteViewModel, Cliente>()
                   .ForCtorParam("estado", opt => opt.MapFrom(src => EnumExtension.ObterEnum<Enums.EstadoEnum>(src.Estado)))
                ;
        }
    }
}
