using MongoDB.Driver;
using Stone.Cobrancas.Data.Models;
using Stone.Cobrancas.Domain.Models;
using Stone.Cobrancas.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Stone.Cobrancas.Data.Repositories
{
    public class CobrancaRepository : ICobrancaRepository
    {
        private IMongoCollection<CobrancaEntity> cobrancaDb;

        public CobrancaRepository(CobrancaContext context)
        {
            this.cobrancaDb = context.Cobrancas;
        }

        public CobrancaContext Context { get; }

        public async Task<IEnumerable<Cobranca>> BuscarPorCpfAsync(long cpf, int Pagina, int Quantidade, CancellationToken cancellationToken)
        {
            int skip = (Pagina - 1) * Quantidade;
            var result = await this.cobrancaDb.Find(e => e.CPF == cpf)
                                        .Skip(skip)
                                        .Limit(Quantidade)
                                        .ToListAsync(cancellationToken);

            return result.Select(RetornaCobrancaDomain);
        }

        public async Task<IEnumerable<Cobranca>> BuscarPorMesAsync(int ano, int mes, int Pagina, int Quantidade, CancellationToken cancellationToken)
        {
            int skip = (Pagina - 1) * Quantidade;
            var result = await this.cobrancaDb.Find(e => e.Data.Month == mes && e.Data.Year == ano)
                                        .Skip(skip)
                                        .Limit(Quantidade)
                                        .ToListAsync(cancellationToken);

            return result.Select(RetornaCobrancaDomain);
        }

        private static Cobranca RetornaCobrancaDomain(CobrancaEntity CobrancaDb)
        {
            if (CobrancaDb == null)
                return null;

            return new Cobranca(CobrancaDb.Id, CobrancaDb.Data, CobrancaDb.CPF.ToString(), CobrancaDb.Valor);
        }

        public async Task<Cobranca> CriarAsync(Cobranca cobranca, CancellationToken cancellationToken)
        {
            var cobrancaDb = new CobrancaEntity(cobranca.Id, cobranca.Data, cobranca.CPF.ObterApenasNumeros(), cobranca.Valor);
            await this.cobrancaDb.InsertOneAsync(cobrancaDb, null, cancellationToken);
            return cobranca;
        }
    }
}
