using FluentValidation.Results;
using Stone.Cobrancas.Domain.Models;
using Stone.Cobrancas.Domain.Repositories;
using Stone.Cobrancas.Domain.Validation;
using Stone.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Stone.Cobrancas.Domain.Services
{
    public class CobrancaService : ICobrancaService
    {
        private readonly ICobrancaRepository cobrancaRepository;
        private readonly CobrancaInsertValidation validationInsert;

        public CobrancaService(ICobrancaRepository cobrancaRepository, CobrancaInsertValidation validationInsert)
        {
            this.cobrancaRepository = cobrancaRepository;
            this.validationInsert = validationInsert;
        }


        public Task<IEnumerable<Cobranca>> BuscarAsync(long cpf, int Pagina, int Quantidade, CancellationToken cancellationToken)
        {
            return cobrancaRepository.BuscarAsync(cpf, Pagina, Quantidade, cancellationToken);
        }

        public Task<IEnumerable<Cobranca>> BuscarAsync(int ano, int mes, int Pagina, int Quantidade, CancellationToken cancellationToken)
        {
            return cobrancaRepository.BuscarAsync(ano, mes, Pagina, Quantidade, cancellationToken);
        }

        public async Task<Cobranca> CriarAsync(Cobranca cobranca, CancellationToken cancellationToken)
        {
            ValidationResult result = validationInsert.Validate(cobranca);
            if (!result.IsValid)
                result.ThrowErrosValidacao();

            return await cobrancaRepository.CriarAsync(cobranca, cancellationToken);
        }
    }
}
