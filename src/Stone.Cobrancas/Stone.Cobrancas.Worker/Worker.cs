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

namespace Stone.Cobrancas.Worker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly ClienteService clienteService;
        private readonly CobrancaService cobrancaService;

        public Worker(ILogger<Worker> logger, ClienteService clienteService, CobrancaService cobrancaService)
        {
            _logger = logger;
            this.clienteService = clienteService;
            this.cobrancaService = cobrancaService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Worker cobrança - Aguardando 10s para iniciar");
            await Task.Delay(1000 * 3);
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker cobrança - executando: {time}", DateTimeOffset.Now);

                ConcurrentBag<Task> insercoesCobranca = new ConcurrentBag<Task>();
                ResultadoPaginado<ClienteViewModel> listaCpfs = new ResultadoPaginado<ClienteViewModel>();
                int pagina = 1;
                do
                {
                    _logger.LogInformation("Worker cobrança - Realizando busca de clientes. Pagina: {pagina}", pagina);
                    listaCpfs = await clienteService.GetClientes(pagina, 5, stoppingToken);
                    foreach (var cliente in listaCpfs.Data)
                    {
                        var task = EnviarCobrancaParaCliente(cliente, stoppingToken);
                        insercoesCobranca.Add(task);
                    }
                    pagina++;
                }
                while (listaCpfs.Next != null);

                await Task.WhenAll(insercoesCobranca);
                _logger.LogInformation("Worker cobrança - Foram Inseridos {cobrancas} cobranças", insercoesCobranca.Count);

                await Task.Delay(1000 * 3 * 60, stoppingToken);
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

            _logger.LogInformation("Worker cobrança - Inserindo cobrança para cpf: {cpf}", cliente.CPF, cobranca.Valor);

            var cobrancaInserida = await this.cobrancaService.InserirCobranca(cobrancaInserir, cancellationToken);


            if (cobrancaInserida)
                _logger.LogInformation("Worker cobrança - Cobranca inserida para cpf: {cpf} valor: {valor}", cliente.CPF, cobranca.Valor);
            else
                _logger.LogError("Worker cobrança - Erro ao inserir cobrança para o cpf: {cpf}", cliente.CPF);


        }
    }
}
