using AutoMapper;
using Stone.Cobrancas.Application.ViewModel;
using Stone.Cobrancas.Domain.Models;
using Stone.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stone.Cobrancas.Application.Mapping
{
    public class ViewModelToDomainProfile : Profile
    {
        public ViewModelToDomainProfile()
        {
            CreateMap<CobrancaViewModel, Cobranca>();
        }
    }
}
