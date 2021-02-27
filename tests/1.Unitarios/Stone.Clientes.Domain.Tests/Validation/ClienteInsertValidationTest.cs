using Moq;
using Stone.Clientes.Domain.Models;
using Stone.Clientes.Domain.Repositories;
using Stone.Clientes.Domain.Resources;
using Stone.Clientes.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xunit;

namespace Stone.Clientes.Domain.Tests.Validation
{
    public class ClienteInsertValidationTest
    {
        private Mock<IClienteRepository> clienteRepositoryMock;

        public ClienteInsertValidation Validation { get; }

        public ClienteInsertValidationTest()
        {

            this.clienteRepositoryMock = new Mock<IClienteRepository>();
            this.Validation = new ClienteInsertValidation(clienteRepositoryMock.Object);
        }

        [Fact]
        public void ClienteInsertValidation_Valida_ExecutaComSucesso()
        {
            //Arrange
            var cliente = new Cliente(Guid.NewGuid(), "Cliente", Enums.EnumEstado.GO, "153.565.213-67");

            //Act
            var result = this.Validation.Validate(cliente);

            //Assert
            Assert.True(result.IsValid);
        }

        [Fact]
        public void ClienteInsertValidation_ValidaCpf_RetornaErroAsync()
        {
            //Arrange
            var cliente = new Cliente(Guid.NewGuid(), "Cliente", Enums.EnumEstado.GO, "111.565.222-67");
            var validation = new ClienteInsertValidation(clienteRepositoryMock.Object);

            //Act
            var result = validation.Validate(cliente);

            //Assert
            Assert.False(result.IsValid);
            Assert.All(result.Errors, e => Assert.Equal(nameof(Mensagens.CLIENTE_CPF_INVALIDO), e.ErrorCode));
        }

        [Fact]
        public async System.Threading.Tasks.Task ClienteInsertValidation_ValidaCpfDuplicado_RetornaErroAsync()
        {
            //Arrange
            this.clienteRepositoryMock.Setup(e => e.VerificaSeClienteExisteAsync(It.IsAny<long>(), CancellationToken.None)).ReturnsAsync(true);
            var cliente = new Cliente(Guid.NewGuid(), "Cliente", Enums.EnumEstado.GO, "642.056.422-02");
            var validation = new ClienteInsertValidation(clienteRepositoryMock.Object);

            //Act
            var result = await validation.ValidateAsync(cliente, CancellationToken.None);

            //Assert
            Assert.False(result.IsValid);
            Assert.All(result.Errors, e => Assert.Equal(nameof(Mensagens.CLIENTE_JA_EXISTENTE), e.ErrorCode));
        }
    }
}
