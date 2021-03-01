using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Stone.Cobrancas.Data;
using Stone.Cobrancas.Integration.Tests.Models;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using Xunit;

namespace Stone.Cobrancas.Integration.Tests
{
    [Trait("Category", "Integration")]
    public class StoneCobrancasIntegrationTests : IClassFixture<CustomWebApplicationFactory<API.Startup>>
    {
        private readonly HttpClient _api;
        private readonly CustomWebApplicationFactory<Stone.Cobrancas.API.Startup>
            _factory;

        public StoneCobrancasIntegrationTests(CustomWebApplicationFactory<API.Startup> factory)
        {
            _factory = factory;
            _api = factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false
            });
        }

        [Fact]
        public async System.Threading.Tasks.Task StoneCobrancas_InserirNovoCobrancaAsync_CriaNovoCobrancaEConsultaComSucesso()
        {
            //Arrange
            var NovoCobranca = new CobrancaDTO()
            {
                CPF = "109.646.388-19",
                Data = DateTime.Now,
                Valor = 1019m
            };

            //Act
            var response = await _api.PostAsJsonAsync("/api/Cobranca", NovoCobranca);

            //Assert
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            var urlCobrancaInserido = response.Headers.Location.PathAndQuery;
            var responseConsultaNovoCobranca = await _api.GetFromJsonAsync<BuscaCobrancasDTO>(urlCobrancaInserido);

            Assert.NotNull(responseConsultaNovoCobranca);
        }

        [Fact]
        public async System.Threading.Tasks.Task StoneCobrancas_ConsultaListagemDeCobrancas_ExecutaComSucesso()
        {
            //Arrange
            using (var scope = _factory.Server.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<CobrancaContext>();

                dbContext.Cobrancas.InsertMany(
                    new Data.Models.CobrancaEntity[] {
                        new Data.Models.CobrancaEntity(Guid.NewGuid(), DateTime.Now, 10964638819, 1019),
                        new Data.Models.CobrancaEntity(Guid.NewGuid(), DateTime.Now, 65854843633, 6533),
                        new Data.Models.CobrancaEntity(Guid.NewGuid(), DateTime.Now, 90782895549, 9049)
                    });
            }

            //Act
            var response = await _api.GetFromJsonAsync<BuscaCobrancasDTO>($"api/Cobranca?Pagina=1&Quantidade=10&Ano={DateTime.Now.Year}&Mes={DateTime.Now.Month}");

            //Assert
            Assert.NotNull(response);
            Assert.NotEmpty(response.Data);
        }
    }
}
