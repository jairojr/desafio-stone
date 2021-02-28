using AutoMapper;
using Stone.Cobrancas.Application.ViewModel;
using Stone.Cobrancas.Domain.Models;
using Stone.Cobrancas.Domain.ValueObjects;
using Stone.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stone.Cobrancas.Application.Mapping
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
            CreateMap<CobrancaViewModel, Cobranca>();
            CreateMap<BuscarCobrancaViewModel, BuscarCobrancaValueObject>();


        }
    }
}
