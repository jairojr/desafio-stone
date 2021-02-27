using FluentValidation.Results;
using Moq;
using Stone.Clientes.Domain.Models;
using Stone.Clientes.Domain.Repositories;
using Stone.Clientes.Domain.Services;
using Stone.Clientes.Domain.Validation;
using Stone.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using FluentValidation.TestHelper;
using FluentValidation;

namespace Stone.Clientes.Domain.Tests.Services
{
    public class ClienteServiceTests
    {
        private readonly Mock<IClienteRepository> clienteRepositoryMock;
        private readonly Mock<ClienteInsertValidation> clienteInsertValidationMock;
        private readonly ClienteService clienteService;

        public ClienteServiceTests()
        {
            this.clienteRepositoryMock = new Mock<IClienteRepository>();
            this.clienteInsertValidationMock = new Mock<ClienteInsertValidation>(clienteRepositoryMock.Object);
            this.clienteService = new ClienteService(clienteRepositoryMock.Object, clienteInsertValidationMock.Object);
        }

        [Fact]
        public async Task ClienteServices_CriarAsync_ExecutaComSucesso()
        {
            //Arrange
            clienteRepositoryMock.Setup(e => e.VerificaSeClienteExisteAsync(It.IsAny<long>(), CancellationToken.None)).ReturnsAsync(false);
            var novoClienteMock = new Cliente(Guid.NewGuid(), "Cliente", Enums.EstadoEnum.PB, "081.245.325-59");
            clienteInsertValidationMock.Setup(e => e.Validate(It.IsAny<ValidationContext<Cliente>>())).Returns(new ValidationResult());
            clienteRepositoryMock.Setup(c => c.CriarAsync(It.IsAny<Cliente>(), CancellationToken.None))
                                 .ReturnsAsync(novoClienteMock);

            //Act
            var clienteInserido = await clienteService.CriarAsync(novoClienteMock, CancellationToken.None);

            //Assert
            Assert.Equal(novoClienteMock.Id, clienteInserido.Id);
            Assert.Equal(novoClienteMock.Nome, clienteInserido.Nome);
            Assert.Equal(novoClienteMock.CPF, clienteInserido.CPF);
        }

        [Fact]
        public async Task ClienteServices_ObterPorCpfAsync_RetornaErrosDeValidacao()
        {
            //Arrange
            clienteRepositoryMock.Setup(e => e.VerificaSeClienteExisteAsync(It.IsAny<long>(), CancellationToken.None)).ReturnsAsync(false);
            var novoClienteMock = new Cliente(Guid.NewGuid(), "Cliente", Enums.EstadoEnum.PB, "081.245.325-59");
            clienteInsertValidationMock.Setup(e => e.Validate(It.IsAny<ValidationContext<Cliente>>()))
                                        .Returns(new ValidationResult(new List<ValidationFailure>()
                                                     {
                                                         new ValidationFailure("erro", "erro")
                                                     }));

            //Act
            Task result() => clienteService.CriarAsync(novoClienteMock, CancellationToken.None);

            //Assert
            await Assert.ThrowsAsync<Stone.Utils.MultiplaValidacaoException>(result);
        }


        [Fact]
        public async Task ClienteServices_ObterPorCpfAsync_ExecutaComSucessoAsync()
        {
            //Arrange
            var clienteMock = new Cliente(Guid.NewGuid(), "Cliente", Enums.EstadoEnum.PB, "081.245.325-59");
            clienteRepositoryMock.Setup(c => c.ObterPorCpfAsync(It.IsAny<long>(), CancellationToken.None))
                                 .ReturnsAsync(clienteMock);

            //Act
            var clienteBusca = await clienteService.ObterPorCpfAsync(08124532559, CancellationToken.None);

            //Assert
            Assert.Equal(clienteMock.Id, clienteBusca.Id);
            Assert.Equal(clienteMock.Nome, clienteBusca.Nome);
            Assert.Equal(clienteMock.CPF, clienteBusca.CPF);

        }

        [Fact]
        public async Task ClienteServices_ObterPorCpfAsync_RetornaCpfInvalido()
        {
            //Act
            Task result() => clienteService.ObterPorCpfAsync(12345678912, CancellationToken.None);

            //Assert
            await Assert.ThrowsAsync<Stone.Utils.ValidacaoException>(result);
        }

        [Fact]
        public async Task ClienteServices_ObterPorIdAsync_ExecutaComSucessoAsync()
        {
            //Arrange
            var clienteMock = new Cliente(Guid.NewGuid(), "Cliente", Enums.EstadoEnum.AC, "815.768.817-50");
            clienteRepositoryMock.Setup(c => c.ObterPorIdAsync(It.IsAny<Guid>(), CancellationToken.None))
                                 .ReturnsAsync(clienteMock);


            //Act
            var clienteBusca = await clienteService.ObterPorIdAsync(clienteMock.Id, CancellationToken.None);

            //Assert
            Assert.Equal(clienteMock.Id, clienteBusca.Id);
            Assert.Equal(clienteMock.Nome, clienteBusca.Nome);
            Assert.Equal(clienteMock.CPF, clienteBusca.CPF);

        }
    }
}
