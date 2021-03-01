using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Stone.Cobrancas.Data;
using Stone.Cobrancas.Performance.Test.Fixture;
using Stone.Cobrancas.Performance.Tests.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using Xunit;

namespace Stone.Cobrancas.Performance.Tests
{
    public class StoneCobrancasPerformanceTests : IClassFixture<CustomWebApplicationFactory<API.Startup>>, IClassFixture<CobrancaFixture>
    {
        private readonly HttpClient _api;
        private readonly CustomWebApplicationFactory<Stone.Cobrancas.API.Startup>
            _factory;
        private readonly CobrancaFixture cobrancaFixture;

        public StoneCobrancasPerformanceTests(CustomWebApplicationFactory<API.Startup> factory, CobrancaFixture cobrancaFixture)
        {
            _factory = factory;
            this.cobrancaFixture = cobrancaFixture;
            _api = factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false
            });
        }

        [Fact(DisplayName = "Insere 10.000 Cobranças e valida que o tempo de cada requisição durou menos que 50ms")]
        public async System.Threading.Tasks.Task StoneCobrancas_InsereBatchDeCobrancas_ExecutaComSucesso()
        {
            int totalIteracoes = 10000;
            var erros = 0;
            Stopwatch watcher = new Stopwatch();
            for (int i = 0; i < totalIteracoes; i++)
            {
                var novaCobranca = cobrancaFixture.GerarCobrancaDTO();
                watcher.Start();
                var response = await _api.PostAsJsonAsync("/api/Cobranca", novaCobranca);
                watcher.Stop();

                if (response.StatusCode != HttpStatusCode.Created)
                    erros++;
            }

            Assert.Equal(0, erros);
            var duracaoCadaRequest = (watcher.ElapsedMilliseconds / (decimal)totalIteracoes);
            Assert.True(duracaoCadaRequest < 50);
        }
    }
}
