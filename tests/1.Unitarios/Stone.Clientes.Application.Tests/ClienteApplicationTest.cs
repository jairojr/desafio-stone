using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Moq;
using Stone.Clientes.Application.Mapping;
using Stone.Clientes.Application.Validation;
using Stone.Clientes.Application.ViewModel;
using Stone.Clientes.Domain.Models;
using Stone.Clientes.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Stone.Clientes.Application.Tests
{
    public class ClienteApplicationTest
    {
        private IMapper mapper;
        private Mock<IClienteService> clienteServiceMock;
        private ClienteApplication application;
        private Mock<ClienteViewModelValidation> clienteViewModelValidationMock;

        public ClienteApplicationTest()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ViewModelToDomainProfile>();
                cfg.AddProfile<DomainToViewModelToProfile>();
            });
            this.mapper = config.CreateMapper();
            this.clienteServiceMock = new Mock<IClienteService>();
            this.clienteViewModelValidationMock = new Mock<ClienteViewModelValidation>();

            this.application = new ClienteApplication(this.mapper,
                                                      this.clienteServiceMock.Object,
                                                      this.clienteViewModelValidationMock.Object);

        }


        [Fact]
        public async System.Threading.Tasks.Task ClienteApplication_CriarAsync_ExecutaComSucessoAsync()
        {
            //Arrange
            var novoCliente = new ClienteViewModel() { Nome = "Cliente", Estado = "PB", CPF = "081.245.325-59" };
            var clienteInseridoMock = new Cliente(novoCliente.Nome, Domain.Enums.EnumEstado.PB, novoCliente.CPF);
            clienteViewModelValidationMock.Setup(e => e.Validate(It.IsAny<ValidationContext<ClienteViewModel>>())).Returns(new ValidationResult());
            clienteServiceMock.Setup(c => c.CriarAsync(It.IsAny<Cliente>(), CancellationToken.None))
                                 .ReturnsAsync(clienteInseridoMock);

            //Act
            var result = await this.application.CriarAsync(novoCliente, CancellationToken.None);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(clienteInseridoMock.Nome, result.Nome);
            Assert.Equal(clienteInseridoMock.CPF.ObterComMascara(), result.CPF);
        }

        [Fact]
        public async System.Threading.Tasks.Task ClienteApplication_CriarAsync_RetornaErrosDeValidacao()
        {
            //Arrange
            var novoCliente = new ClienteViewModel() { Nome = "Cliente", Estado = "PB", CPF = "081.245.325-59" };
            clienteViewModelValidationMock.Setup(e => e.Validate(It.IsAny<ValidationContext<ClienteViewModel>>()))
                                       .Returns(new ValidationResult(new List<ValidationFailure>()
                                                    {
                                                         new ValidationFailure("erro", "erro")
                                                    }));

            //Act
            Task result() => application.CriarAsync(novoCliente, CancellationToken.None);

            //Assert
            await Assert.ThrowsAsync<Stone.Utils.MultiplaValidacaoException>(result);
        }

        [Fact]
        public async System.Threading.Tasks.Task ClienteApplication_ObterPorCpfAsync_ExecutaComSucesso()
        {
            //Arrange
            var clienteMock = new Cliente("Cliente", Domain.Enums.EnumEstado.CE, "118.131.288-47");
            this.clienteServiceMock.Setup(c => c.ObterPorCpfAsync(It.IsAny<long>(), CancellationToken.None)).ReturnsAsync(clienteMock);

            //Act
            var clienteRetornado = await application.ObterPorCpfAsync(11813128847, CancellationToken.None);

            //Assert
            Assert.NotNull(clienteRetornado);
            Assert.Equal(clienteMock.Nome, clienteRetornado.Nome);
        }

        [Fact]
        public async System.Threading.Tasks.Task ClienteApplication_ObterPorIdAsync_ExecutaComSucesso()
        {
            //Arrange
            var clienteMock = new Cliente(Guid.NewGuid(), "Cliente", Domain.Enums.EnumEstado.CE, "118.131.288-47");
            this.clienteServiceMock.Setup(c => c.ObterPorIdAsync(It.IsAny<Guid>(), CancellationToken.None)).ReturnsAsync(clienteMock);

            //Act
            var clienteRetornado = await application.ObterPorIdAsync(clienteMock.Id, CancellationToken.None);

            //Assert
            Assert.NotNull(clienteRetornado);
            Assert.Equal(clienteMock.Nome, clienteRetornado.Nome);
        }
    }
}