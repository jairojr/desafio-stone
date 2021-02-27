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
using Stone.Clientes.Domain.Repositories;
using FluentValidation.Results;
using Stone.Utils;
using System.Threading;
using Stone.Clientes.Domain.Services;
using Stone.Clientes.Application.Resources;

namespace Stone.Clientes.Application
{
    public class ClienteApplication : IClienteApplication
    {
        private readonly IMapper mapper;
        private readonly IClienteService clienteService;
        private readonly ClienteViewModelValidation validation;

        public ClienteApplication(IMapper mapper,
                                  IClienteService clienteService,
                                  ClienteViewModelValidation validation)
        {
            this.mapper = mapper;
            this.clienteService = clienteService;
            this.validation = validation;
        }


        public async Task<ClienteViewModel> CriarAsync(ClienteViewModel clienteViewModel, CancellationToken cancellationToken)
        {
            ValidationResult result = this.validation.Validate(clienteViewModel);

            if (!result.IsValid)
                result.ThrowErrosValidacao();

            var clienteInserido = await clienteService.CriarAsync(this.mapper.Map<Cliente>(clienteViewModel), cancellationToken);

            return this.mapper.Map<ClienteViewModel>(clienteInserido);
        }

        public async Task<ClienteViewModel> ObterPorCpfAsync(long cpf, CancellationToken cancellationToken)
        {
            var cliente = await clienteService.ObterPorCpfAsync(cpf, cancellationToken);

            return this.mapper.Map<ClienteViewModel>(cliente);
        }

        public async Task<ClienteViewModel> ObterPorIdAsync(Guid idCliente, CancellationToken cancellationToken)
        {
            var cliente = await clienteService.ObterPorIdAsync(idCliente, cancellationToken);

            return this.mapper.Map<ClienteViewModel>(cliente);
        }

        public async Task<IEnumerable<ClienteViewModel>> BuscaPaginadaAsync(int pagina, int tamanho, CancellationToken cancellationToken)
        {
            if (pagina < 0 || tamanho <= 0)
                throw new ValidacaoException(nameof(Mensagens.BUSCA_INVALIDA), Mensagens.BUSCA_INVALIDA);

            var result = await this.clienteService.BuscaPaginadaAsync(pagina, tamanho, cancellationToken);

            return this.mapper.Map<IEnumerable<ClienteViewModel>>(result);
        }
    }
}
