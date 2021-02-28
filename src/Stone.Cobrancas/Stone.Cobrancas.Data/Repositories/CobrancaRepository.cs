using MongoDB.Driver;
using Stone.Cobrancas.Data.Models;
using Stone.Cobrancas.Domain.Models;
using Stone.Cobrancas.Domain.Repositories;
using Stone.Cobrancas.Domain.ValueObjects;
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

        public async Task<IEnumerable<Cobranca>> BuscaAsync(BuscarCobrancaValueObject busca, CancellationToken cancellationToken)
        {
            int skip = (busca.Pagina - 1) * busca.Quantidade;


            List<FilterDefinition<CobrancaEntity>> filtros = new List<FilterDefinition<CobrancaEntity>>();

            if (busca.CPF.HasValue)
            {
                var cpf = busca.CPF.Value.ObterApenasNumeros();
                filtros.Add(Builders<CobrancaEntity>.Filter.Eq(x => x.CPF, cpf));
            }

            if (busca.Ano.HasValue)
            {
                var dataInicial = new DateTime(busca.Ano.Value, busca.Mes.Value, 1);
                var dataFinal = dataInicial.AddMonths(1).AddMilliseconds(-1);
                filtros.Add(Builders<CobrancaEntity>.Filter.Gte(x => x.Data, dataInicial));
                filtros.Add(Builders<CobrancaEntity>.Filter.Lte(x => x.Data, dataFinal));
            }


            var result = await this.cobrancaDb.Find(Builders<CobrancaEntity>.Filter.And(filtros))
                                        .Skip(skip)
                                        .Limit(busca.Quantidade)
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
