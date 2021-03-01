using AutoMapper;
using Stone.Cobrancas.Application.Mapping;
using Stone.Cobrancas.Application.ViewModel;
using Stone.Cobrancas.Domain.Models;
using Stone.Cobrancas.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Stone.Cobrancas.Application.Tests.Mapping
{
    [Trait("Category", "Unit")]
    public class AutomappersTests
    {
        private IMapper mapper;

        public AutomappersTests()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ViewModelToDomainProfile>();
                cfg.AddProfile<DomainToViewModelToProfile>();
            }); ;
            this.mapper = config.CreateMapper();
        }

        [Fact]
        public void Automappers_MappperCobrancaViewModel_CobrancaDomain()
        {
            //Arrange
            var cobrancaViewModel = new CobrancaViewModel()
            {
                CPF = "282.490.822-06",
                Data = DateTime.Now,
                Valor = 123m
            };

            //Act
            var cobrancaDomain = this.mapper.Map<Cobranca>(cobrancaViewModel);

            //Assert
            Assert.Equal(cobrancaViewModel.CPF, cobrancaDomain.CPF.ObterComMascara());
            Assert.Equal(cobrancaViewModel.Data, cobrancaDomain.Data);
            Assert.Equal(cobrancaViewModel.Valor, cobrancaDomain.Valor);
        }

        [Fact]
        public void Automappers_MappperCobrancaDomain_CobrancaViewModel()
        {
            //Arrange
            var cobrancaDomain = new Cobranca(DateTime.Now, "282.490.822-06", 123m);
            //Act
            var cobrancaViewModel = this.mapper.Map<CobrancaViewModel>(cobrancaDomain);

            //Assert
            Assert.Equal(cobrancaDomain.CPF.ObterComMascara(), cobrancaViewModel.CPF);
            Assert.Equal(cobrancaDomain.Data, cobrancaViewModel.Data);
            Assert.Equal(cobrancaDomain.Valor, cobrancaViewModel.Valor);
        }

        [Fact]
        public void Automappers_MappperBuscarCobrancaViewModel_BuscarCobrancaValueObject()
        {
            //Arrange
            var buscaViewModel = new BuscarCobrancaViewModel()
            {
                Pagina = 1,
                Quantidade = 10,
                CPF = "035.405.442-24",
                Ano = 2021,
                Mes = 5
            };

            //Act
            var buscaDomain = this.mapper.Map<BuscarCobrancaValueObject>(buscaViewModel);

            //Assert
            Assert.Equal(buscaViewModel.CPF, buscaDomain.CPF.Value.ObterComMascara());
            Assert.Equal(buscaViewModel.Ano, buscaDomain.Ano);
            Assert.Equal(buscaViewModel.Mes, buscaDomain.Mes);
            Assert.Equal(buscaViewModel.Pagina, buscaDomain.Pagina);
            Assert.Equal(buscaViewModel.Quantidade, buscaDomain.Quantidade);
        }
    }
}
