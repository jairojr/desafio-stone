using AutoMapper;
using Stone.Clientes.Application.Interfaces;
using Stone.Clientes.Application.ViewModel;
using Stone.Clientes.Data.Repositories;
using Stone.Clientes.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Stone.Clientes.Application.Validation;

namespace Stone.Clientes.Application.Services
{
    public class ClienteApplication : IClienteApplication
    {
        private readonly IMapper mapper;
        private readonly IClienteRepository clienteRepository;

        public ClienteApplication(IMapper mapper, IClienteRepository clienteRepository)
        {
            mapper = mapper;
            this.mapper = mapper;
            this.clienteRepository = clienteRepository;
        }


        public async Task<ClienteViewModel> CriarAsync(ClienteViewModel clienteViewModel)
        {
            var validation = new ClienteViewModelValidation();
            validation.Validate(clienteViewModel);

            var cliente = this.mapper.Map<Cliente>(clienteViewModel);

            throw new NotImplementedException();
        }

        public Task<ClienteViewModel> ObterPorCpfAsync(long cpf)
        {
            throw new NotImplementedException();
        }

        public Task<ClienteViewModel> ObterPorIdAsync(Guid idCliente)
        {
            throw new NotImplementedException();
        }
    }
}
