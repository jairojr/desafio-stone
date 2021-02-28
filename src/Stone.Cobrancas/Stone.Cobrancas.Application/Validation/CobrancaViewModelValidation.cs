using FluentValidation;
using Stone.Cobrancas.Application.Resources;
using Stone.Cobrancas.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

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

            RuleFor(v => v.CPF)
                .NotEmpty()
                .WithErrorCode(nameof(Mensagens.COBRANCA_CPF_OBRIGATORIO))
                .WithMessage(Mensagens.COBRANCA_CPF_OBRIGATORIO);

            RuleFor(v => v.Valor)
               .NotEmpty()
               .WithErrorCode(nameof(Mensagens.COBRANCA_VALOR_OBRIGATORIO))
               .WithMessage(Mensagens.COBRANCA_VALOR_OBRIGATORIO);
        }
    }
}