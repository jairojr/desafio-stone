using FluentValidation;
using Stone.Cobrancas.Domain.Models;
using Stone.Cobrancas.Domain.Resources;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Stone.Cobrancas.Domain.Validation
{
    public class CobrancaInsertValidation : AbstractValidator<Cobranca>
    {
        public CobrancaInsertValidation()
        {
            RuleFor(d => d.CPF)
             .Must(d => d.EhValido)
             .WithErrorCode(nameof(Mensagens.CPF_INVALIDO))
             .WithMessage(Mensagens.CPF_INVALIDO);

        }
    }
}
