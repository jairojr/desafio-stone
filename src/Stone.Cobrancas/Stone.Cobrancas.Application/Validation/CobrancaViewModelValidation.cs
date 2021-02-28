using FluentValidation;
using Stone.Cobrancas.Application.Resources;
using Stone.Cobrancas.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using static Stone.Utils.CpfExtensions;

namespace Stone.Cobrancas.Application.Validation
{
    /// <summary>
    /// Validação de inserção de cobrança
    /// </summary>
    public class CobrancaViewModelValidation : AbstractValidator<CobrancaViewModel>
    {
        /// <summary>
        /// Construtor com as definições de validação
        /// </summary>
        public CobrancaViewModelValidation()
        {
            RuleFor(v => v.Data)
                .NotEmpty()
                .WithErrorCode(nameof(Mensagens.COBRANCA_DATA_OBRIGATORIO))
                .WithMessage(Mensagens.COBRANCA_DATA_OBRIGATORIO);

            RuleFor(v => v.Data.Year)
              .GreaterThan(1900)
              .WithErrorCode(nameof(Mensagens.COBRANCA_DATA_INVALIDA))
              .WithMessage(Mensagens.COBRANCA_DATA_INVALIDA)
              .When(c => c.Data != DateTime.MinValue);

            RuleFor(v => v.CPF)
                .NotEmpty()
                .WithErrorCode(nameof(Mensagens.COBRANCA_CPF_OBRIGATORIO))
                .WithMessage(Mensagens.COBRANCA_CPF_OBRIGATORIO);

            RuleFor(v => v.CPF)
                .Must(c => Cpf.ValidarCPF(c))
                .WithErrorCode(nameof(Mensagens.COBRANCA_CPF_INVALIDO))
                .WithMessage(Mensagens.COBRANCA_CPF_INVALIDO)
                .When(c => !string.IsNullOrEmpty(c.CPF));

            RuleFor(v => v.Valor)
               .NotEmpty()
               .WithErrorCode(nameof(Mensagens.COBRANCA_VALOR_OBRIGATORIO))
               .WithMessage(Mensagens.COBRANCA_VALOR_OBRIGATORIO);

            RuleFor(v => v.Valor)
               .GreaterThan(0)
               .WithErrorCode(nameof(Mensagens.COBRANCA_VALOR_INVALIDO))
               .WithMessage(Mensagens.COBRANCA_VALOR_INVALIDO)
               .When(c => c.Valor != 0);

        }
    }
}