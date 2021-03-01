using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Stone.Clientes.Data;
using Stone.Clientes.Performance.Test.Fixture;
using Stone.Clientes.Performance.Tests.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using Xunit;

namespace Stone.Clientes.Performance.Tests
{
    [Trait("Category", "Performance")]
    public class StoneClientesPerformanceTests : IClassFixture<CustomWebApplicationFactory<API.Startup>>, IClassFixture<ClienteFixture>
    {
        private readonly HttpClient _api;
        private readonly CustomWebApplicationFactory<Stone.Clientes.API.Startup>
            _factory;
        private readonly ClienteFixture clienteFixture;

        public StoneClientesPerformanceTests(CustomWebApplicationFactory<API.Startup> factory, ClienteFixture clienteFixture)
        {
            _factory = factory;
            this.clienteFixture = clienteFixture;
            _api = factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false
            });
        }

        [Fact(DisplayName = "Insere 10.000 clientes e valida que o tempo de cada requisição durou menos que 50ms")]
        public async System.Threading.Tasks.Task StoneClientes_InsereBatchDeClientes_ExecutaComSucesso()
        {
            int totalIteracoes = 10000;
            var erros = 0;
            Stopwatch watcher = new Stopwatch();
            for (int i = 0; i < totalIteracoes; i++)
            {
                var NovoCliente = clienteFixture.GerarClienteDTO();
                watcher.Start();
                var response = await _api.PostAsJsonAsync("/api/Clientes", NovoCliente);
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
