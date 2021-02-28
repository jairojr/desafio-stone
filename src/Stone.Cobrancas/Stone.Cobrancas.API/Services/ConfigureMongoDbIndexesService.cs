using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Stone.Cobrancas.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Stone.Cobrancas.API.Services
{
    /// <summary>
    /// Serviço utilizado para criação de index dentro do mongo db ao iniciar a aplicação
    /// </summary>
    public class ConfigureMongoDbIndexesService : IHostedService
    {
        private readonly CobrancaContext cobrancaContext;
        private readonly ILogger<ConfigureMongoDbIndexesService> logger;

        /// <summary>
        /// Construtor padrão
        /// </summary>
        /// <param name="cobrancaContext"></param>
        /// <param name="logger"></param>
        public ConfigureMongoDbIndexesService(CobrancaContext cobrancaContext, ILogger<ConfigureMongoDbIndexesService> logger)
        {
            this.cobrancaContext = cobrancaContext;
            this.logger = logger;
        }

        /// <summary>
        /// Start criação de index
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            logger.LogInformation("MongoDb - Criando indexes");
            await cobrancaContext.ConfigureMongoIndex(cancellationToken);
            logger.LogInformation("MongoDb - Index criados");
        }


        public Task StopAsync(CancellationToken cancellationToken)
            => Task.CompletedTask;
    }
}