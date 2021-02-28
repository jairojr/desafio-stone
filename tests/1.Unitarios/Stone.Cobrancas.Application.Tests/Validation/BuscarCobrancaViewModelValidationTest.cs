using Stone.Cobrancas.Application.Resources;
using Stone.Cobrancas.Application.Validation;
using Stone.Cobrancas.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Stone.Cobrancas.Application.Tests.Validation
{
    public class BuscarCobrancaViewModelValidationTest
    {
        private readonly BuscarCobrancaViewModelValidation validation;

        public BuscarCobrancaViewModelValidationTest()
        {
            this.validation = new BuscarCobrancaViewModelValidation();
        }

        [Fact]
        public void BuscarCobrancaViewModelValidation_ValidatePorCpf_RetornaValido()
        {
            //Arrange
            BuscarCobrancaViewModel buscaValida = RetornaBuscaPorCpfValida();
            //Act
            var result = this.validation.Validate(buscaValida);

            //Assert
            Assert.True(result.IsValid);
            Assert.Empty(result.Errors);
        }

        [Fact]
        public void BuscarCobrancaViewModelValidation_ValidatePorAnoMes_RetornaValido()
        {
            //Arrange
            BuscarCobrancaViewModel buscaValida = RetornaBuscaPorAnoMesValida();
            //Act
            var result = this.validation.Validate(buscaValida);

            //Assert
            Assert.True(result.IsValid);
            Assert.Empty(result.Errors);
        }

        [Fact]
        public void BuscarCobrancaViewModelValidation_PaginaIgualZero_RetornaInvalido()
        {
            //Arrange
            BuscarCobrancaViewModel buscaValida = RetornaBuscaPorCpfValida();
            buscaValida.Pagina = 0;
            //Act
            var result = this.validation.Validate(buscaValida);

            //Assert
            Assert.False(result.IsValid);
            Assert.All(result.Errors, e => Assert.Equal(nameof(Mensagens.BUSCA_INVALIDA_PAGINA), e.ErrorCode));
        }

        [Fact]
        public void BuscarCobrancaViewModelValidation_PaginaMenorQueZero_RetornaInvalido()
        {
            //Arrange
            BuscarCobrancaViewModel buscaValida = RetornaBuscaPorCpfValida();
            buscaValida.Pagina = -10;
            //Act
            var result = this.validation.Validate(buscaValida);

            //Assert
            Assert.False(result.IsValid);
            Assert.All(result.Errors, e => Assert.Equal(nameof(Mensagens.BUSCA_INVALIDA_PAGINA), e.ErrorCode));
        }

        [Fact]
        public void BuscarCobrancaViewModelValidation_QuantidadeIgualZero_RetornaInvalido()
        {
            //Arrange
            BuscarCobrancaViewModel buscaValida = RetornaBuscaPorCpfValida();
            buscaValida.Quantidade = 0;
            //Act
            var result = this.validation.Validate(buscaValida);

            //Assert
            Assert.False(result.IsValid);
            Assert.All(result.Errors, e => Assert.Equal(nameof(Mensagens.BUSCA_INVALIDA_QUANTIDADE), e.ErrorCode));
        }

        [Fact]
        public void BuscarCobrancaViewModelValidation_QuantidadeMenorQueZero_RetornaInvalido()
        {
            //Arrange
            BuscarCobrancaViewModel buscaValida = RetornaBuscaPorCpfValida();
            buscaValida.Quantidade = -10;
            //Act
            var result = this.validation.Validate(buscaValida);

            //Assert
            Assert.False(result.IsValid);
            Assert.All(result.Errors, e => Assert.Equal(nameof(Mensagens.BUSCA_INVALIDA_QUANTIDADE), e.ErrorCode));
        }

        [Fact]
        public void BuscarCobrancaViewModelValidation_CpfInvalidoQuandoBuscaPorCpf_RetornaInvalido()
        {
            //Arrange
            BuscarCobrancaViewModel buscaValida = RetornaBuscaPorCpfValida();
            buscaValida.CPF = "888.405.442-27";
            //Act
            var result = this.validation.Validate(buscaValida);

            //Assert
            Assert.False(result.IsValid);
            Assert.All(result.Errors, e => Assert.Equal(nameof(Mensagens.BUSCA_CPF_INVALIDO), e.ErrorCode));
        }

        [Fact]
        public void BuscarCobrancaViewModelValidation_CpfVazioQuandoBuscaPorCpf_RetornaInvalido()
        {
            //Arrange
            BuscarCobrancaViewModel buscaValida = RetornaBuscaPorCpfValida();
            buscaValida.CPF = "";
            //Act
            var result = this.validation.Validate(buscaValida);

            //Assert
            Assert.False(result.IsValid);
            Assert.All(result.Errors, e => Assert.Equal(nameof(Mensagens.BUSCA_CPF_INVALIDO), e.ErrorCode));
        }

        [Fact]
        public void BuscarCobrancaViewModelValidation_CpfNullQuandoBuscaPorCpf_RetornaInvalido()
        {
            //Arrange
            BuscarCobrancaViewModel buscaValida = RetornaBuscaPorCpfValida();
            buscaValida.CPF = null;
            //Act
            var result = this.validation.Validate(buscaValida);

            //Assert
            Assert.False(result.IsValid);
            Assert.All(result.Errors, e => Assert.Equal(nameof(Mensagens.BUSCA_INVALIDA), e.ErrorCode));
        }

        [Fact]
        public void BuscarCobrancaViewModelValidation_AnoVazioQuandoBuscaPorAno_RetornaInvalido()
        {
            //Arrange
            BuscarCobrancaViewModel buscaValida = RetornaBuscaPorAnoMesValida();
            buscaValida.Ano = 0;
            //Act
            var result = this.validation.Validate(buscaValida);

            //Assert
            Assert.False(result.IsValid);
            Assert.All(result.Errors, e => Assert.Equal(nameof(Mensagens.BUSCA_INVALIDA_ANO), e.ErrorCode));
        }

        [Fact]
        public void BuscarCobrancaViewModelValidation_AnoMenorQue1900QuandoBuscaPorAno_RetornaInvalido()
        {
            //Arrange
            BuscarCobrancaViewModel buscaValida = RetornaBuscaPorAnoMesValida();
            buscaValida.Ano = 1880;
            //Act
            var result = this.validation.Validate(buscaValida);

            //Assert
            Assert.False(result.IsValid);
            Assert.All(result.Errors, e => Assert.Equal(nameof(Mensagens.BUSCA_INVALIDA_ANO), e.ErrorCode));
        }

        [Fact]
        public void BuscarCobrancaViewModelValidation_AnoIgual1900QuandoBuscaPorAno_RetornaInvalido()
        {
            //Arrange
            BuscarCobrancaViewModel buscaValida = RetornaBuscaPorAnoMesValida();
            buscaValida.Ano = 1900;
            //Act
            var result = this.validation.Validate(buscaValida);

            //Assert
            Assert.False(result.IsValid);
            Assert.All(result.Errors, e => Assert.Equal(nameof(Mensagens.BUSCA_INVALIDA_ANO), e.ErrorCode));
        }

        [Fact]
        public void BuscarCobrancaViewModelValidation_MesMenorQue1QuandoBuscaPorAno_RetornaInvalido()
        {
            //Arrange
            BuscarCobrancaViewModel buscaValida = RetornaBuscaPorAnoMesValida();
            buscaValida.Mes = 0;
            //Act
            var result = this.validation.Validate(buscaValida);

            //Assert
            Assert.False(result.IsValid);
            Assert.All(result.Errors, e => Assert.Equal(nameof(Mensagens.BUSCA_INVALIDA_MES), e.ErrorCode));
        }

        [Fact]
        public void BuscarCobrancaViewModelValidation_MesMaiorQue12QuandoBuscaPorAno_RetornaInvalido()
        {
            //Arrange
            BuscarCobrancaViewModel buscaValida = RetornaBuscaPorAnoMesValida();
            buscaValida.Mes = 13;
            //Act
            var result = this.validation.Validate(buscaValida);

            //Assert
            Assert.False(result.IsValid);
            Assert.All(result.Errors, e => Assert.Equal(nameof(Mensagens.BUSCA_INVALIDA_MES), e.ErrorCode));
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        [InlineData(7)]
        [InlineData(8)]
        [InlineData(9)]
        [InlineData(10)]
        [InlineData(11)]
        [InlineData(12)]
        public void BuscarCobrancaViewModelValidation_MesValidoBuscaPorAno_RetornaValido(int mes)
        {
            //Arrange
            BuscarCobrancaViewModel buscaValida = RetornaBuscaPorAnoMesValida();
            buscaValida.Mes = mes;
            //Act
            var result = this.validation.Validate(buscaValida);

            //Assert
            Assert.True(result.IsValid);
            Assert.Empty(result.Errors);
        }

        private static BuscarCobrancaViewModel RetornaBuscaPorCpfValida()
        {
            return new BuscarCobrancaViewModel()
            {
                Pagina = 1,
                Quantidade = 10,
                CPF = "035.405.442-24"
            };
        }

        private static BuscarCobrancaViewModel RetornaBuscaPorAnoMesValida()
        {
            return new BuscarCobrancaViewModel()
            {
                Pagina = 1,
                Quantidade = 10,
                Ano = 2021,
                Mes = 2,
            };
        }
    }
}
