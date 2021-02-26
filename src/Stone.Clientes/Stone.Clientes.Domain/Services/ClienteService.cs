using Stone.Clientes.Domain.Models;
using Stone.Clientes.Domain.Repositories;
using Stone.Clientes.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Stone.Clientes.Domain.Services
{
    //TODO - Adicionar Testes
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            this.clienteRepository = clienteRepository;
        }

        public async Task<Cliente> CriarAsync(Cliente cliente, CancellationToken cancellationToken)
        {
            var validation = new ClienteInsertValidation();
            validation.Validate(cliente);

            return await clienteRepository.CriarAsync(cliente, cancellationToken);
        }

        //TODO - Validar CPF
        public async Task<Cliente> ObterPorCpfAsync(long cpf, CancellationToken cancellationToken)
        {
            return await clienteRepository.ObterPorCpfAsync(cpf, cancellationToken);
        }

        public Task<Cliente> ObterPorIdAsync(Guid idCliente, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
