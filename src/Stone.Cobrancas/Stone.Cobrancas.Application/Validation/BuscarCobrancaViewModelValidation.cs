using FluentValidation;
using Stone.Cobrancas.Application.Resources;
using Stone.Cobrancas.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using static Stone.Utils.CpfExtensions;

namespace Stone.Cobrancas.Application.Validation
{
    public class BuscarCobrancaViewModelValidation : AbstractValidator<BuscarCobrancaViewModel>
    {
        public BuscarCobrancaViewModelValidation()
        {
            RuleFor(v => v.Pagina)
              .GreaterThan(0)
              .WithErrorCode(nameof(Mensagens.BUSCA_INVALIDA_PAGINA))
              .WithMessage(Mensagens.BUSCA_INVALIDA_PAGINA);

            RuleFor(v => v.Quantidade)
              .GreaterThan(0)
              .WithErrorCode(nameof(Mensagens.BUSCA_INVALIDA_QUANTIDADE))
              .WithMessage(Mensagens.BUSCA_INVALIDA_QUANTIDADE);

            RuleFor(v => v.CPF)
              .Must(ValidarCpf)
              .WithErrorCode(nameof(Mensagens.BUSCA_CPF_INVALIDO))
              .WithMessage(Mensagens.BUSCA_CPF_INVALIDO)
              .When(e => !string.IsNullOrWhiteSpace(e.CPF));

            RuleFor(v => v.CPF)
              .NotEmpty()
              .WithErrorCode(nameof(Mensagens.BUSCA_INVALIDA))
              .WithMessage(Mensagens.BUSCA_INVALIDA)
              .When(e => !e.Ano.HasValue && !e.Mes.HasValue);

            RuleFor(v => v.Ano)
              .NotEmpty()
              .WithErrorCode(nameof(Mensagens.BUSCA_INVALIDA))
              .WithMessage(Mensagens.BUSCA_INVALIDA)
              .When(e => string.IsNullOrWhiteSpace(e.CPF));

            RuleFor(v => v.Mes)
              .NotEmpty()
              .WithErrorCode(nameof(Mensagens.BUSCA_INVALIDA))
              .WithMessage(Mensagens.BUSCA_INVALIDA)
              .When(e => string.IsNullOrWhiteSpace(e.CPF));
        }

        private bool ValidarCpf(string cpfStr)
        {
            Cpf cpf = cpfStr;
            return cpf.EhValido;
        }
    }
}
