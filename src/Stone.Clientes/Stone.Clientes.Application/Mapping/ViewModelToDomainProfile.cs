using AutoMapper;
using Stone.Clientes.Application.ViewModel;
using Stone.Clientes.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stone.Clientes.Application.Mapping
{
    public class ViewModelToDomainProfile : Profile
    {
        public ViewModelToDomainProfile()
        {
            CreateMap<ClienteViewModel, Cliente>();
        }
    }
}
