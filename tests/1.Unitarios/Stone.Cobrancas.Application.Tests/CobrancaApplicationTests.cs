using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Moq;
using Stone.Cobrancas.Application.Mapping;
using Stone.Cobrancas.Application.Validation;
using Stone.Cobrancas.Application.ViewModel;
using Stone.Cobrancas.Domain.Models;
using Stone.Cobrancas.Domain.Services;
using Stone.Cobrancas.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Stone.Cobrancas.Application.Tests
{
    public class CobrancaApplicationTests
    {
        private readonly IMapper mapper;
        private readonly Mock<ICobrancaService> service;
        private readonly Mock<CobrancaViewModelValidation> insertValidation;
        private readonly Mock<BuscarCobrancaViewModelValidation> buscaValidation;
        private readonly CobrancaApplication application;

        public CobrancaApplicationTests()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ViewModelToDomainProfile>();
                cfg.AddProfile<DomainToViewModelToProfile>();
            });
            this.mapper = config.CreateMapper();
            this.service = new Mock<ICobrancaService>();
            this.insertValidation = new Mock<CobrancaViewModelValidation>();
            this.buscaValidation = new Mock<BuscarCobrancaViewModelValidation>();

            this.application = new CobrancaApplication(this.mapper, this.service.Object, this.insertValidation.Object, this.buscaValidation.Object);
        }

        [Fact]
        public async Task CobrancaApplication_BuscarAsync_ExecutaComSucessoAsync()
        {
            //Arrange
            var busca = new BuscarCobrancaViewModel()
            {
                CPF = "840.874.441-04",
                Pagina = 1,
                Quantidade = 10
            };
            var cobrancas = new List<Cobranca>()
            {
                new Cobranca(DateTime.Now, "840.874.441-04", 8404.00m),
                new Cobranca(DateTime.Now.AddDays(-7), "840.874.441-04", 123m),
                new Cobranca(DateTime.Now.AddDays(-14), "840.874.441-04", 55m),
            };
            buscaValidation.Setup(e => e.Validate(It.IsAny<ValidationContext<BuscarCobrancaViewModel>>())).Returns(new ValidationResult());
            service.Setup(c => c.BuscaAsync(It.IsAny<BuscarCobrancaValueObject>(), CancellationToken.None))
                                 .ReturnsAsync(cobrancas);
            //Act
            var result = await this.application.BuscarAsync(busca, CancellationToken.None);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(3, result.Count());
        }

        [Fact]
        public async Task CobrancaApplication_BuscarAsync_RetornaErroValidacaoAsync()
        {
            //Arrange
            var busca = new BuscarCobrancaViewModel()
            {
                CPF = "840.874.441-04",
                Pagina = 1,
                Quantidade = 10
            };
            buscaValidation.Setup(e => e.Validate(It.IsAny<ValidationContext<BuscarCobrancaViewModel>>()))
                                   .Returns(new ValidationResult(new List<ValidationFailure>()
                                        {
                                                new ValidationFailure("erro", "erro")
                                        }));

            //Act
            Task result() => application.BuscarAsync(busca, CancellationToken.None);

            //Assert
            await Assert.ThrowsAsync<Stone.Utils.MultiplaValidacaoException>(result);
        }

        [Fact]
        public async Task CobrancaApplication_CriarAsync_ExecutaComSucesso()
        {
            //Arrange
            var novaCobranca = new CobrancaViewModel()
            {
                CPF = "840.874.441-04",
                Data = DateTime.Now,
                Valor = 8404.00m
            };

            insertValidation.Setup(e => e.Validate(It.IsAny<ValidationContext<CobrancaViewModel>>())).Returns(new ValidationResult());
            service.Setup(c => c.CriarAsync(It.IsAny<Cobranca>(), CancellationToken.None))
                              .ReturnsAsync(new Cobranca(novaCobranca.Data, novaCobranca.CPF, novaCobranca.Valor));
            //Act
            var result = await application.CriarAsync(novaCobranca, CancellationToken.None);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(novaCobranca.CPF, result.CPF);
            Assert.Equal(novaCobranca.Valor, result.Valor);
        }


        [Fact]
        public async Task CobrancaApplication_CriarAsync_RetornaErroValidacaoAsync()
        {
            //Arrange
            var novaCobranca = new CobrancaViewModel()
            {
                CPF = "840.874.441-04",
                Data = DateTime.Now,
                Valor = 8404.00m
            };
            insertValidation.Setup(e => e.Validate(It.IsAny<ValidationContext<CobrancaViewModel>>()))
                                   .Returns(new ValidationResult(new List<ValidationFailure>()
                                        {
                                                new ValidationFailure("erro", "erro")
                                        }));

            //Act
            Task result() => application.CriarAsync(novaCobranca, CancellationToken.None);

            //Assert
            await Assert.ThrowsAsync<Stone.Utils.MultiplaValidacaoException>(result);
        }
    }
}
