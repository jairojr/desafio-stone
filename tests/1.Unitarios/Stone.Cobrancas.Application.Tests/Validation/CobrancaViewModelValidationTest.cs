using Stone.Cobrancas.Application.Resources;
using Stone.Cobrancas.Application.Validation;
using Stone.Cobrancas.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Stone.Cobrancas.Application.Tests.Validation
{
    [Trait("Category", "Unit")]
    public class CobrancaViewModelValidationTest
    {
        private readonly CobrancaViewModelValidation validation;

        public CobrancaViewModelValidationTest()
        {
            this.validation = new CobrancaViewModelValidation();
        }

        [Fact]
        public void CobrancaViewModelValidation_Validate_RetornaValido()
        {
            //Arrange
            CobrancaViewModel cobrancaValida = RetornaCobrancaValida();

            //Act
            var result = this.validation.Validate(cobrancaValida);

            //Assert
            Assert.True(result.IsValid);
            Assert.Empty(result.Errors);
        }

        [Fact]
        public void CobrancaViewModelValidation_DataValorMinimo_RetornaInvalido()
        {
            //Arrange
            CobrancaViewModel cobrancaValida = RetornaCobrancaValida();
            cobrancaValida.Data = DateTime.MinValue;

            //Act
            var result = this.validation.Validate(cobrancaValida);

            //Assert
            Assert.False(result.IsValid);
            Assert.All(result.Errors, e => Assert.Equal(nameof(Mensagens.COBRANCA_DATA_OBRIGATORIO), e.ErrorCode));
        }

        [Fact]
        public void CobrancaViewModelValidation_DataMenorQue1900_RetornaInvalido()
        {
            //Arrange
            CobrancaViewModel cobrancaValida = RetornaCobrancaValida();
            cobrancaValida.Data = new DateTime(1880, 1, 1);

            //Act
            var result = this.validation.Validate(cobrancaValida);

            //Assert
            Assert.False(result.IsValid);
            Assert.All(result.Errors, e => Assert.Equal(nameof(Mensagens.COBRANCA_DATA_INVALIDA), e.ErrorCode));
        }

        [Fact]
        public void CobrancaViewModelValidation_DataIgual1900_RetornaInvalido()
        {
            //Arrange
            CobrancaViewModel cobrancaValida = RetornaCobrancaValida();
            cobrancaValida.Data = new DateTime(1900, 1, 1);

            //Act
            var result = this.validation.Validate(cobrancaValida);

            //Assert
            Assert.False(result.IsValid);
            Assert.All(result.Errors, e => Assert.Equal(nameof(Mensagens.COBRANCA_DATA_INVALIDA), e.ErrorCode));
        }

        [Fact]
        public void CobrancaViewModelValidation_CpfVazio_RetornaInvalido()
        {
            //Arrange
            CobrancaViewModel cobrancaValida = RetornaCobrancaValida();
            cobrancaValida.CPF = "";

            //Act
            var result = this.validation.Validate(cobrancaValida);

            //Assert
            Assert.False(result.IsValid);
            Assert.All(result.Errors, e => Assert.Equal(nameof(Mensagens.COBRANCA_CPF_OBRIGATORIO), e.ErrorCode));
        }

        [Fact]
        public void CobrancaViewModelValidation_CpfNull_RetornaInvalido()
        {
            //Arrange
            CobrancaViewModel cobrancaValida = RetornaCobrancaValida();
            cobrancaValida.CPF = null;

            //Act
            var result = this.validation.Validate(cobrancaValida);

            //Assert
            Assert.False(result.IsValid);
            Assert.All(result.Errors, e => Assert.Equal(nameof(Mensagens.COBRANCA_CPF_OBRIGATORIO), e.ErrorCode));
        }

        [Fact]
        public void CobrancaViewModelValidation_CpInvalido_RetornaInvalido()
        {
            //Arrange
            CobrancaViewModel cobrancaValida = RetornaCobrancaValida();
            cobrancaValida.CPF = "515.777.642-55";

            //Act
            var result = this.validation.Validate(cobrancaValida);

            //Assert
            Assert.False(result.IsValid);
            Assert.All(result.Errors, e => Assert.Equal(nameof(Mensagens.COBRANCA_CPF_INVALIDO), e.ErrorCode));
        }

        [Fact]
        public void CobrancaViewModelValidation_ValorZerado_RetornaInvalido()
        {
            //Arrange
            CobrancaViewModel cobrancaValida = RetornaCobrancaValida();
            cobrancaValida.Valor = 0;

            //Act
            var result = this.validation.Validate(cobrancaValida);

            //Assert
            Assert.False(result.IsValid);
            Assert.All(result.Errors, e => Assert.Equal(nameof(Mensagens.COBRANCA_VALOR_OBRIGATORIO), e.ErrorCode));
        }

        [Fact]
        public void CobrancaViewModelValidation_ValorMenorQueZero_RetornaInvalido()
        {
            //Arrange
            CobrancaViewModel cobrancaValida = RetornaCobrancaValida();
            cobrancaValida.Valor = -15;

            //Act
            var result = this.validation.Validate(cobrancaValida);

            //Assert
            Assert.False(result.IsValid);
            Assert.All(result.Errors, e => Assert.Equal(nameof(Mensagens.COBRANCA_VALOR_INVALIDO), e.ErrorCode));
        }

        private static CobrancaViewModel RetornaCobrancaValida()
        {
            return new CobrancaViewModel()
            {
                CPF = "035.405.442-24",
                Data = DateTime.Now,
                Valor = 123m
            };
        }
    }
}
