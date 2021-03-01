using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Stone.Cobrancas.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Stone.Cobrancas.Data
{
    public class CobrancaContext
    {
        private readonly MongoClient client;
        private readonly IMongoDatabase database;

        public CobrancaContext(IConfiguration configuration)
        {
            var url = new MongoUrl(configuration["ConnectionStrings:MongoDb"]);
            this.client = new MongoClient(url);
            this.database = client.GetDatabase(url.DatabaseName);
        }

        public IMongoCollection<CobrancaEntity> Cobrancas
        {
            get
            {
                return database.GetCollection<CobrancaEntity>("Cobrancas");
            }
        }

        public async Task ConfigureMongoIndex(CancellationToken cancellationToken)
        {
            var indexKeyCpf = Builders<CobrancaEntity>.IndexKeys.Ascending(x => x.CPF);
            var indexDataCobranca = Builders<CobrancaEntity>.IndexKeys.Ascending(x => x.Data);

            var listIndexCobranca = new List<CreateIndexModel<CobrancaEntity>>()
            {
                new CreateIndexModel<CobrancaEntity>(indexKeyCpf),
                new CreateIndexModel<CobrancaEntity>(indexDataCobranca),
            };
            await Cobrancas.Indexes.CreateManyAsync(listIndexCobranca, cancellationToken: cancellationToken);
        }
    }
}