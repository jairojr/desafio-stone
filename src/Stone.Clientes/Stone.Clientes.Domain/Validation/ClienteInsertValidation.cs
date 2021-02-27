using FluentValidation;
using Stone.Clientes.Domain.Models;
using Stone.Clientes.Domain.Repositories;
using Stone.Clientes.Domain.Resources;
using Stone.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Stone.Clientes.Domain.Validation
{
    public class ClienteInsertValidation : AbstractValidator<Cliente>
    {
        private readonly IClienteRepository clienteRepository;

        public ClienteInsertValidation(IClienteRepository clienteRepository)
        {
            this.clienteRepository = clienteRepository;

            RuleFor(d => d.CPF)
             .Must(d => d.EhValido)
             .WithErrorCode(nameof(Mensagens.CLIENTE_CPF_INVALIDO))
             .WithMessage(Mensagens.CLIENTE_CPF_INVALIDO);

            RuleFor(d => d.CPF)
                .MustAsync(ValidaSeCpfJaExiste)
                .WithErrorCode(nameof(Mensagens.CLIENTE_JA_EXISTENTE))
                .WithMessage(Mensagens.CLIENTE_JA_EXISTENTE);
        }

        private async Task<bool> ValidaSeCpfJaExiste(CpfExtensions.Cpf cpf, CancellationToken cancellationToken)
        {
            return !(await clienteRepository.VerificaSeClienteExisteAsync(cpf.ObterApenasNumeros(), cancellationToken));
        }
    }
}