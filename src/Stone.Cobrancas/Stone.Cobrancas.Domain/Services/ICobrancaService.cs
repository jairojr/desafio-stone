using Stone.Cobrancas.Domain.Models;
using Stone.Cobrancas.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Stone.Cobrancas.Domain.Services
{
    public interface ICobrancaService
    {
        public Task<Cobranca> CriarAsync(Cobranca cobranca, CancellationToken cancellationToken);
        public Task<IEnumerable<Cobranca>> BuscaAsync(BuscarCobrancaValueObject busca , CancellationToken cancellationToken);
    }
}