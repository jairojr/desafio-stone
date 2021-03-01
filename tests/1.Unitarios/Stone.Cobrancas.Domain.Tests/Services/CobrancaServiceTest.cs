using FluentValidation;
using FluentValidation.Results;
using Moq;
using Stone.Cobrancas.Domain.Models;
using Stone.Cobrancas.Domain.Repositories;
using Stone.Cobrancas.Domain.Services;
using Stone.Cobrancas.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Stone.Cobrancas.Domain.Tests.Services
{
    [Trait("Category", "Unit")]
    public class CobrancaServiceTest
    {
        private readonly  Mock<ICobrancaRepository> repositoryMock;
        private readonly CobrancaService cobrancaService;

        public CobrancaServiceTest()
        {
            this.repositoryMock = new Moq.Mock<ICobrancaRepository>();
            this.cobrancaService = new CobrancaService(repositoryMock.Object);
        }

        [Fact]
        public async Task CobrancaServices_BuscarPorCpfAsync_ExecutaComSucessoAsync()
        {
            //Arrange
            var cobranca1 = Cobranca.CriarCobranca("815.768.817-50", DateTime.Now);
            var cobranca2 = Cobranca.CriarCobranca("815.768.817-50", DateTime.Now.AddDays(-1));
            var cobranca3 = Cobranca.CriarCobranca("815.768.817-50", DateTime.Now.AddDays(-2));
            var busca = new BuscarCobrancaValueObject(1, 5, CPF: "81576881750");
            repositoryMock.Setup(c => c.BuscaAsync(busca, CancellationToken.None))
                                 .ReturnsAsync(new List<Cobranca>()
                                 {
                                     cobranca1,cobranca2, cobranca3
                                 });

            //Act
            var buscarCobrancas = await this.cobrancaService.BuscaAsync(busca, CancellationToken.None);

            //Assert
            Assert.NotEmpty(buscarCobrancas);
            Assert.Equal(3, buscarCobrancas.Count());
        }

        [Fact]
        public async Task CobrancaServices_BuscarPorMesAsync_ExecutaComSucessoAsync()
        {
            //Arrange
            var cobranca1 = Cobranca.CriarCobranca("815.768.817-50", DateTime.Now);
            var cobranca2 = Cobranca.CriarCobranca("728.636.577-04", DateTime.Now.AddDays(-1));
            var cobranca3 = Cobranca.CriarCobranca("625.472.483-95", DateTime.Now.AddDays(-2));
            var busca = new BuscarCobrancaValueObject(1, 5, Ano: DateTime.Now.Year, Mes: DateTime.Now.Month);
            repositoryMock.Setup(c => c.BuscaAsync(busca, CancellationToken.None))
                                 .ReturnsAsync(new List<Cobranca>()
                                 {
                                     cobranca1,cobranca2, cobranca3
                                 });

            //Act
            var buscarCobrancas = await this.cobrancaService.BuscaAsync(busca, CancellationToken.None);

            //Assert
            Assert.NotEmpty(buscarCobrancas);
            Assert.Equal(3, buscarCobrancas.Count());
        }

        [Fact]
        public async Task CobrancaServices_CriarAsync_ExecutaComSucesso()
        {
            //Arrange
            var novoCobrancaMock = Cobranca.CriarCobranca("704.598.366-25");
            repositoryMock.Setup(c => c.CriarAsync(It.IsAny<Cobranca>(), CancellationToken.None))
                                 .ReturnsAsync(novoCobrancaMock);

            //Act
            var CobrancaInserido = await cobrancaService.CriarAsync(novoCobrancaMock, CancellationToken.None);

            //Assert
            Assert.Equal(novoCobrancaMock.Id, CobrancaInserido.Id);
            Assert.Equal(novoCobrancaMock.CPF, CobrancaInserido.CPF);
            Assert.Equal(novoCobrancaMock.Valor, CobrancaInserido.Valor);
        }
    }
}
