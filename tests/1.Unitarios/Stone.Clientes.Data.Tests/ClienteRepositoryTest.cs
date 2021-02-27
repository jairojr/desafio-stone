using Microsoft.EntityFrameworkCore;
using Stone.Clientes.Data.Models;
using Stone.Clientes.Data.Repositories;
using Stone.Clientes.Data.Tests.Fixture;
using Stone.Clientes.Domain.Models;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Stone.Clientes.Data.Tests
{
    public class ClienteRepositoryTest : IClassFixture<ClientesContextFixture>
    {
        private ClientesContext ContextFixture;
        public ClienteRepositoryTest(ClientesContextFixture fixture)
        {
            this.ContextFixture = fixture.Context;
        }

        [Fact]
        public async Task ClienteRepository_CriaCliente_ExecutaComSucessoAsync()
        {
            //Arrange
            var novoCliente = new Cliente("Novo Cliente", Domain.Enums.EstadoEnum.PR, 85648448422);
            var repository = new ClienteRepository(ContextFixture);

            //Act
            var clienteSalvo = await repository.CriarAsync(novoCliente, CancellationToken.None);

            //Assert
            Assert.NotNull(clienteSalvo);
            Assert.NotEqual(Guid.Empty, clienteSalvo.Id);
        }

        [Fact]
        public async Task ClienteRepository_ObterPorCpfAsync_ExecutaComSucessoAsync()
        {
            //Arrange
            var clienteExistente = await ContextFixture.Clientes.FirstAsync();
            var repository = new ClienteRepository(ContextFixture);
            var cpfPesquisa = clienteExistente.CPF;

            //Act
            var cliente = await repository.ObterPorCpfAsync(cpfPesquisa, CancellationToken.None);

            //Assert
            Assert.NotNull(cliente);
            Assert.Equal(cpfPesquisa, cliente.CPF.ObterApenasNumeros());
        }

        [Fact]
        public async Task ClienteRepository_ObterPorIdAsyncComIdExistente_RetornaClienteComSucesso()
        {
            //Arrange
            var clienteExistente = await ContextFixture.Clientes.FirstAsync();
            var repository = new ClienteRepository(ContextFixture);
            var idPesquisa = clienteExistente.Id;

            //Act
            var cliente = await repository.ObterPorIdAsync(idPesquisa, CancellationToken.None);

            //Assert
            Assert.NotNull(cliente);
            Assert.Equal(idPesquisa, cliente.Id);
        }

        [Fact]
        public async Task ClienteRepository_ObterPorIdAsyncComIdExistente_RetornaClienteNullo()
        {
            //Arrange
            var repository = new ClienteRepository(ContextFixture);

            //Act
            var verificaSeClienteExiste = await repository.ObterPorIdAsync(Guid.NewGuid(), CancellationToken.None);

            //Assert
            Assert.Null(verificaSeClienteExiste);
        }


        [Fact]
        public async Task ClienteRepository_VerificaSeClienteExisteAsyncComClienteExistente_RetornaVerdadeiro()
        {
            //Arrange
            var clienteExistente = await ContextFixture.Clientes.FirstAsync();
            var repository = new ClienteRepository(ContextFixture);
            var cpfVerificacao = clienteExistente.CPF;

            //Act
            var clienteExiste = await repository.VerificaSeClienteExisteAsync(cpfVerificacao, CancellationToken.None);

            //Assert
            Assert.True(clienteExiste);
        }

        [Fact]
        public async Task ClienteRepository_VerificaSeClienteExisteAsyncComClienteInexistente_RetornaFalse()
        {
            //Arrange
            var repository = new ClienteRepository(ContextFixture);

            //Act
            var verificaSeClienteExiste = await repository.VerificaSeClienteExisteAsync(0, CancellationToken.None);

            //Assert
            Assert.False(verificaSeClienteExiste);
        }

        [Fact]
        public async Task ClienteRepository_BuscaPaginada_RetornaLista()
        {
            //Arrange
            var repository = new ClienteRepository(ContextFixture);

            //Act
            var verificaSeClienteExiste = await repository.BuscaPaginadaAsync(1, 5, CancellationToken.None);

            //Assert
            Assert.NotEmpty(verificaSeClienteExiste);
        }
    }
}
