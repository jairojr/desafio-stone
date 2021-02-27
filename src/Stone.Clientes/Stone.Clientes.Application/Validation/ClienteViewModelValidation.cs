using FluentValidation;
using Stone.Clientes.Application.Enums;
using Stone.Clientes.Application.Resources;
using Stone.Clientes.Application.ViewModel;
using Stone.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stone.Clientes.Application.Validation
{
    public class ClienteViewModelValidation : AbstractValidator<ClienteViewModel>
    {
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

            RuleFor(v => v.Estado)
               .NotEmpty()
               .WithErrorCode(nameof(Mensagens.CLIENTE_ESTADO_OBRIGATORIO))
               .WithMessage(Mensagens.CLIENTE_ESTADO_OBRIGATORIO);

            RuleFor(d => d.Estado)
             .Must(EstadoValido)
             .WithErrorCode(nameof(Mensagens.CLIENTE_ESTADO_INVALIDO))
             .WithMessage(Mensagens.CLIENTE_ESTADO_INVALIDO);
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
