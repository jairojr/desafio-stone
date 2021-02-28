using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Stone.Cobrancas.Worker.Services;
using Stone.Cobrancas.Domain.Models;
using Stone.Cobrancas.Worker.Models;
using System.Linq;
using System.Collections.Generic;
using Stone.Utils;
using System.Collections.Concurrent;
using Microsoft.Extensions.Configuration;

namespace Stone.Cobrancas.Worker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly ClienteService clienteService;
        private readonly CobrancaService cobrancaService;
        private readonly int intervaloEntreCobrancasEmMinutos;
        private readonly int clientesQuantidadeBusca;
        private readonly int delayInicioEmSegundos;

        public Worker(ILogger<Worker> logger,
                      ClienteService clienteService,
                      CobrancaService cobrancaService,
                      IConfiguration configuration)
        {
            _logger = logger;
            this.clienteService = clienteService;
            this.cobrancaService = cobrancaService;

            this.intervaloEntreCobrancasEmMinutos = configuration.GetValue<int>("IntervaloEntreCobrancasEmMinutos");
            this.clientesQuantidadeBusca = configuration.GetValue<int>("StoneApiClientes:Paginacao.QuantidadeBusca");
            this.delayInicioEmSegundos = configuration.GetValue<int>("DelayInicioEmSegundos");
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Worker cobran�a - Aguardando {delay}s para iniciar", delayInicioEmSegundos);
            await Task.Delay(TimeSpan.FromSeconds(delayInicioEmSegundos));
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker cobran�a - executando: {time}", DateTimeOffset.Now);

                ConcurrentBag<Task> insercoesCobranca = new ConcurrentBag<Task>();
                ResultadoPaginado<ClienteViewModel> listaCpfs = new ResultadoPaginado<ClienteViewModel>();
                int pagina = 1;
                do
                {
                    _logger.LogInformation("Worker cobran�a - Realizando busca de clientes. Pagina: {pagina}", pagina);
                    listaCpfs = await clienteService.GetClientes(pagina, clientesQuantidadeBusca, stoppingToken);
                    foreach (var cliente in listaCpfs.Data)
                    {
                        var task = EnviarCobrancaParaCliente(cliente, stoppingToken);
                        insercoesCobranca.Add(task);
                    }
                    pagina++;
                }
                while (listaCpfs.Next != null);

                await Task.WhenAll(insercoesCobranca);
                _logger.LogInformation("Worker cobran�a - Foram Inseridos {cobrancas} cobran�as", insercoesCobranca.Count);
                _logger.LogInformation("Worker cobran�a - Aguardando {intervaloEntreCobrancasEmMinutos} min para inserir novas cobran�as", intervaloEntreCobrancasEmMinutos);
                await Task.Delay(TimeSpan.FromMinutes(intervaloEntreCobrancasEmMinutos));
            }
        }

        private async Task EnviarCobrancaParaCliente(ClienteViewModel cliente, CancellationToken cancellationToken)
        {
            var cobranca = Cobranca.CriarCobranca(cliente.CPF);

            var cobrancaInserir = new CobrancaViewModel()
            {
                CPF = cobranca.CPF.ObterComMascara(),
                Data = cobranca.Data,
                Valor = cobranca.Valor,
            };

            _logger.LogInformation("Worker cobran�a - Inserindo cobran�a para cpf: {cpf}", cliente.CPF, cobranca.Valor);

            var cobrancaInserida = await this.cobrancaService.InserirCobranca(cobrancaInserir, cancellationToken);


            if (cobrancaInserida)
                _logger.LogInformation("Worker cobran�a - Cobranca inserida para cpf: {cpf} valor: {valor}", cliente.CPF, cobranca.Valor);
            else
                _logger.LogError("Worker cobran�a - Erro ao inserir cobran�a para o cpf: {cpf}", cliente.CPF);


        }
    }
}
