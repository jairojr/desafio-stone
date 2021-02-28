using AutoMapper;
using Stone.Cobrancas.Application.ViewModel;
using Stone.Cobrancas.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stone.Cobrancas.Application.Mapping
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
            CreateMap<Cobranca, CobrancaViewModel>()
                .ForMember(v => v.CPF, opt => opt.MapFrom(d => d.CPF.ObterComMascara()));
        }
    }
}
