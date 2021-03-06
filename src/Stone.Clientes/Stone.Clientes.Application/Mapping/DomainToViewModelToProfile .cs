﻿using AutoMapper;
using Stone.Clientes.Application.ViewModel;
using Stone.Clientes.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stone.Clientes.Application.Mapping
{
    /// <summary>
    /// Automapper Domain -> ViewModel 
    /// </summary>
    public class DomainToViewModelToProfile : Profile
    {
        /// <summary>
        /// 
        /// </summary>
        public DomainToViewModelToProfile()
        {
            CreateMap<Cliente, ClienteViewModel>()
                    .ForMember(v => v.CPF, opt => opt.MapFrom(d => d.CPF.ObterComMascara()));
        }
    }
}
