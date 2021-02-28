using FluentValidation;
using Stone.Clientes.Application.Enums;
using Stone.Clientes.Application.Resources;
using Stone.Clientes.Application.ViewModel;
using Stone.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using static Stone.Utils.CpfExtensions;

namespace Stone.Clientes.Application.Validation
{
    /// <summary>
    /// Validação de inserção de cliente
    /// </summary>
    public class ClienteViewModelValidation : AbstractValidator<ClienteViewModel>
    {
        /// <summary>
        /// Construtor com as definições de validação
        /// </summary>
        public ClienteViewModelValidation()
        {
            RuleFor(v => v.Nome)
                .NotEmpty()
                .WithErrorCode(nameof(Mensagens.CLIENTE_NOME_OBRIGATORIO))
                .WithMessage(Mensagens.CLIENTE_NOME_OBRIGATORIO);

            RuleFor(v => v.CPF)
                .NotEmpty()
                .WithErrorCode(nameof(Mensagens.CLIENTE_CPF_OBRIGATORIO))
                .WithMessage(Mensagens.CLIENTE_CPF_OBRIGATORIO);

            RuleFor(v => v.CPF)
              .Must(c => Cpf.ValidarCPF(c))
              .WithErrorCode(nameof(Mensagens.CLIENTE_CPF_INVALIDO))
              .WithMessage(Mensagens.CLIENTE_CPF_INVALIDO)
              .When(c => !string.IsNullOrEmpty(c.CPF));

            RuleFor(v => v.Estado)
               .NotEmpty()
               .WithErrorCode(nameof(Mensagens.CLIENTE_ESTADO_OBRIGATORIO))
               .WithMessage(Mensagens.CLIENTE_ESTADO_OBRIGATORIO);

            RuleFor(d => d.Estado)
             .Must(EstadoValido)
             .WithErrorCode(nameof(Mensagens.CLIENTE_ESTADO_INVALIDO))
             .WithMessage(Mensagens.CLIENTE_ESTADO_INVALIDO)
             .When(c => !string.IsNullOrWhiteSpace(c.Estado));
        }

        private bool EstadoValido(string strEstado)
        {
            var estado = EnumExtension.ObterEnum<EstadoEnum>(strEstado);

            if (estado == EstadoEnum.NaoInformado)
                return false;

            return true;
        }
    }
}
