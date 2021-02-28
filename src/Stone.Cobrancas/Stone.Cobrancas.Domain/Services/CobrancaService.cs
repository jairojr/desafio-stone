using FluentValidation.Results;
using Stone.Cobrancas.Domain.Models;
using Stone.Cobrancas.Domain.Repositories;
using Stone.Cobrancas.Domain.ValueObjects;
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

        public CobrancaService(ICobrancaRepository cobrancaRepository)
        {
            this.cobrancaRepository = cobrancaRepository;
        }

        public Task<IEnumerable<Cobranca>> BuscaAsync(BuscarCobrancaValueObject busca, CancellationToken cancellationToken)
        {
            return cobrancaRepository.BuscaAsync(busca, cancellationToken);
        }

        public async Task<Cobranca> CriarAsync(Cobranca cobranca, CancellationToken cancellationToken)
        {
            return await cobrancaRepository.CriarAsync(cobranca, cancellationToken);
        }
    }
}
