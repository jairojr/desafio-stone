using FluentValidation.Results;
using Stone.Clientes.Domain.Models;
using Stone.Clientes.Domain.Repositories;
using Stone.Clientes.Domain.Resources;
using Stone.Clientes.Domain.Validation;
using Stone.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Stone.Utils.CpfExtensions;
using static Stone.Utils.ServiceOperation;

namespace Stone.Clientes.Domain.Services
{
    //TODO - Adicionar Testes
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository clienteRepository;
        private readonly ClienteInsertValidation validationInsert;

        public ClienteService(IClienteRepository clienteRepository, ClienteInsertValidation validation)
        {
            this.clienteRepository = clienteRepository;
            this.validationInsert = validation;
        }

        public async Task<Cliente> CriarAsync(Cliente cliente, CancellationToken cancellationToken)
        {
            ValidationResult result = validationInsert.Validate(cliente);
            if (!result.IsValid)
                result.ThrowErrosValidacao();

            return await clienteRepository.CriarAsync(cliente, cancellationToken);
        }

        public async Task<Cliente> ObterPorCpfAsync(long cpfPesquisa, CancellationToken cancellationToken)
        {
            Cpf cpf = cpfPesquisa.ToString();

            if (!cpf.EhValido)
                throw new ValidacaoException(nameof(Mensagens.CLIENTE_CPF_INVALIDO), Mensagens.CLIENTE_CPF_INVALIDO);

            return await clienteRepository.ObterPorCpfAsync(cpfPesquisa, cancellationToken);
        }

        public async Task<Cliente> ObterPorIdAsync(Guid idCliente, CancellationToken cancellationToken)
        {
            return await clienteRepository.ObterPorIdAsync(idCliente, cancellationToken);
        }

        public async Task<IEnumerable<Cliente>> BuscaPaginadaAsync(int pagina, int quantidade, CancellationToken cancellationToken)
        {
            return await clienteRepository.BuscaPaginadaAsync(pagina, quantidade, cancellationToken);
        }
    }
}