using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Stone.Cobrancas.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stone.Cobrancas.Data
{
    public class CobrancaContext
    {
        private readonly MongoClient client;
        private readonly IMongoDatabase database;

        public CobrancaContext(IConfiguration configuration)
        {
            this.client = new MongoClient(configuration["ConnectionStrings:MongoDb"]);
            this.database = client.GetDatabase("cobranca");
        }

        public IMongoCollection<CobrancaEntity> Cobrancas
        {
            get
            {
                var Paises = database.GetCollection<CobrancaEntity>("Cobrancas");
                return Paises;
            }
        }
    }
}