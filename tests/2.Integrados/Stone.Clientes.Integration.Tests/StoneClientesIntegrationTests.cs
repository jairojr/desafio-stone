using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Stone.Clientes.Data;
using Stone.Clientes.Integration.Tests.Models;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using Xunit;

namespace Stone.Clientes.Integration.Tests
{
    [Trait("Category", "Integration")]
    public class StoneClientesIntegrationTests : IClassFixture<CustomWebApplicationFactory<API.Startup>>
    {
        private readonly HttpClient _api;
        private readonly CustomWebApplicationFactory<Stone.Clientes.API.Startup>
            _factory;

        public StoneClientesIntegrationTests(CustomWebApplicationFactory<API.Startup> factory)
        {
            _factory = factory;
            _api = factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false
            });
        }

        [Fact]
        public async System.Threading.Tasks.Task StoneClientes_InserirNovoClienteAsync_CriaNovoCLienteEConsultaComSucesso()
        {
            //Arrange
            var NovoCliente = new ClienteDTO()
            {
                Nome = "Guilherme Fábio Barros",
                CPF = "003.017.796-00",
                Estado = "BA"
            };

            //Act
            var response = await _api.PostAsJsonAsync("/api/Clientes", NovoCliente);

            //Assert
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            var urlClienteInserido = response.Headers.Location.LocalPath;
            var responseConsultaNovoCliente = await _api.GetFromJsonAsync<ClienteDTO>(urlClienteInserido);

            Assert.NotNull(responseConsultaNovoCliente);
            Assert.Equal(NovoCliente.CPF, responseConsultaNovoCliente.CPF);
        }

        [Fact]
        public async System.Threading.Tasks.Task StoneClientes_ConsultaListagemDeClientes_ExecutaComSucesso()
        {
            //Arrange
            using (var scope = _factory.Server.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ClientesContext>();

                dbContext.Clientes.Add(new Data.Models.ClienteEntity(Guid.NewGuid(), "Cecília Catarina Melo", "MS", 48599495100));
                dbContext.Clientes.Add(new Data.Models.ClienteEntity(Guid.NewGuid(), "Severino Julio dos Santos", "RN", 22796251993));
                dbContext.Clientes.Add(new Data.Models.ClienteEntity(Guid.NewGuid(), "Vinicius Lucca Costa", "RJ", 60570267803));
                dbContext.SaveChanges();
            }

            //Act
            var response = await _api.GetFromJsonAsync<BuscaClienteDTO>("/api/Clientes?page=1&size=10");

            //Assert
            Assert.NotNull(response);
            Assert.NotEmpty(response.Data);
        }
    }
}
