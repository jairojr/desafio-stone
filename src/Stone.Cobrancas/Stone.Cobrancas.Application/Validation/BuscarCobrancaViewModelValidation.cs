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
    /// Validação de busca
    /// </summary>
    public class BuscarCobrancaViewModelValidation : AbstractValidator<BuscarCobrancaViewModel>
    {
        /// <summary>
        /// Construtor padrão
        /// </summary>
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
              .When(BuscaPorCpf);

            RuleFor(v => v)
              .Must(ValidarBusca)
              .WithErrorCode(nameof(Mensagens.BUSCA_INVALIDA))
              .WithMessage(Mensagens.BUSCA_INVALIDA);

            RuleFor(v => v.Ano)
               .GreaterThan(1900)
               .WithErrorCode(nameof(Mensagens.BUSCA_INVALIDA_ANO))
               .WithMessage(Mensagens.BUSCA_INVALIDA_ANO)
              .When(BuscaPorAnoMes);

            RuleFor(v => v.Mes)
              .InclusiveBetween(1, 12)
              .WithErrorCode(nameof(Mensagens.BUSCA_INVALIDA_MES))
              .WithMessage(Mensagens.BUSCA_INVALIDA_MES)
              .When(ValidarBusca);
        }

        private bool ValidarBusca(BuscarCobrancaViewModel busca)
        {
            return BuscaPorCpf(busca) || BuscaPorAnoMes(busca);
        }
        private bool BuscaPorCpf(BuscarCobrancaViewModel busca)
        {
            return busca.CPF != null;
        }
        
        private bool BuscaPorAnoMes(BuscarCobrancaViewModel busca)
        {
            return (busca.Ano.HasValue && busca.Mes.HasValue);
        }

        private bool ValidarCpf(string cpfStr)
        {
            Cpf cpf = cpfStr;
            return cpf.EhValido;
        }
    }
}
