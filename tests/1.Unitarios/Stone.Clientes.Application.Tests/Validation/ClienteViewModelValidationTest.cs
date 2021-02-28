using Stone.Clientes.Application.Resources;
using Stone.Clientes.Application.Validation;
using Stone.Clientes.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Stone.Clientes.Application.Tests.Validation
{
    public class ClienteViewModelValidationTest
    {
        private readonly ClienteViewModelValidation validation;

        public ClienteViewModelValidationTest()
        {
            this.validation = new ClienteViewModelValidation();
        }

        [Fact]
        public void ClienteViewModelValidation_Validate_ExecutaComSucesso()
        {
            //Arrange
            var clienteValido = ObterClienteValido();

            //Act
            var result = this.validation.Validate(clienteValido);

            //Assert
            Assert.True(result.IsValid);
            Assert.Empty(result.Errors);
        }

        [Fact]
        public void ClienteViewModelValidation_NomeVazio_RetornaInvalido()
        {
            //Arrange
            var clienteValido = ObterClienteValido();
            clienteValido.Nome = "";

            //Act
            var result = this.validation.Validate(clienteValido);

            //Assert
            Assert.False(result.IsValid);
            Assert.All(result.Errors, e => Assert.Equal(nameof(Mensagens.CLIENTE_NOME_OBRIGATORIO), e.ErrorCode));
        }

        [Fact]
        public void ClienteViewModelValidation_NomeNull_RetornaInvalido()
        {
            //Arrange
            var clienteValido = ObterClienteValido();
            clienteValido.Nome = null;

            //Act
            var result = this.validation.Validate(clienteValido);

            //Assert
            Assert.False(result.IsValid);
            Assert.All(result.Errors, e => Assert.Equal(nameof(Mensagens.CLIENTE_NOME_OBRIGATORIO), e.ErrorCode));
        }

        [Fact]
        public void ClienteViewModelValidation_CpfVazio_RetornaInvalido()
        {
            //Arrange
            var clienteValido = ObterClienteValido();
            clienteValido.CPF = "";

            //Act
            var result = this.validation.Validate(clienteValido);

            //Assert
            Assert.False(result.IsValid);
            Assert.All(result.Errors, e => Assert.Equal(nameof(Mensagens.CLIENTE_CPF_OBRIGATORIO), e.ErrorCode));
        }

        [Fact]
        public void ClienteViewModelValidation_CpfNull_RetornaInvalido()
        {
            //Arrange
            var clienteValido = ObterClienteValido();
            clienteValido.CPF = null;

            //Act
            var result = this.validation.Validate(clienteValido);

            //Assert
            Assert.False(result.IsValid);
            Assert.All(result.Errors, e => Assert.Equal(nameof(Mensagens.CLIENTE_CPF_OBRIGATORIO), e.ErrorCode));
        }

        [Fact]
        public void ClienteViewModelValidation_CpfInvalido_RetornaInvalido()
        {
            //Arrange
            var clienteValido = ObterClienteValido();
            clienteValido.CPF = "999.922.362-41";

            //Act
            var result = this.validation.Validate(clienteValido);

            //Assert
            Assert.False(result.IsValid);
            Assert.All(result.Errors, e => Assert.Equal(nameof(Mensagens.CLIENTE_CPF_INVALIDO), e.ErrorCode));
        }

        [Fact]
        public void ClienteViewModelValidation_EstadoVazio_RetornaInvalido()
        {
            //Arrange
            var clienteValido = ObterClienteValido();
            clienteValido.Estado = "";

            //Act
            var result = this.validation.Validate(clienteValido);

            //Assert
            Assert.False(result.IsValid);
            Assert.All(result.Errors, e => Assert.Equal(nameof(Mensagens.CLIENTE_ESTADO_OBRIGATORIO), e.ErrorCode));
        }

        [Fact]
        public void ClienteViewModelValidation_EstadoNull_RetornaInvalido()
        {
            //Arrange
            var clienteValido = ObterClienteValido();
            clienteValido.Estado = null;

            //Act
            var result = this.validation.Validate(clienteValido);

            //Assert
            Assert.False(result.IsValid);
            Assert.All(result.Errors, e => Assert.Equal(nameof(Mensagens.CLIENTE_ESTADO_OBRIGATORIO), e.ErrorCode));
        }

        [Fact]
        public void ClienteViewModelValidation_EstadoInvalido_RetornaInvalido()
        {
            //Arrange
            var clienteValido = ObterClienteValido();
            clienteValido.Estado = "Oregon";

            //Act
            var result = this.validation.Validate(clienteValido);

            //Assert
            Assert.False(result.IsValid);
            Assert.All(result.Errors, e => Assert.Equal(nameof(Mensagens.CLIENTE_ESTADO_INVALIDO), e.ErrorCode));
        }

        [Theory]
        [MemberData(nameof(estadosValidos))]
        public void ClienteViewModelValidation_ClienteValidoEEstadosValido_RetornaValido(string estado)
        {
            //Arrange
            var clienteValido = ObterClienteValido();
            clienteValido.Estado = estado;

            //Act
            var result = this.validation.Validate(clienteValido);

            //Assert
            Assert.True(result.IsValid);
            Assert.Empty(result.Errors);
        }


        #region EstadosValidos
        public static IEnumerable<object[]> estadosValidos =>
                        new List<object[]>
       {
            new object[] { "Acre" },
            new object[] { "AC" },
            new object[] { "Alagoas" },
            new object[] { "AL" },
            new object[] { "Amapá" },
            new object[] { "AP" },
            new object[] { "Amazonas" },
            new object[] { "AM" },
            new object[] { "Bahia" },
            new object[] { "BA" },
            new object[] { "Ceará" },
            new object[] { "CE" },
            new object[] { "Distrito Federal" },
            new object[] { "DF" },
            new object[] { "Espirito Santo" },
            new object[] { "ES" },
            new object[] { "Goiás" },
            new object[] { "GO" },
            new object[] { "Maranhão" },
            new object[] { "MA" },
            new object[] { "Mato Grosso" },
            new object[] { "MT" },
            new object[] { "Mato Grosso do Sul" },
            new object[] { "MS" },
            new object[] { "Minas Gerais" },
            new object[] { "MG" },
            new object[] { "Pará" },
            new object[] { "PA" },
            new object[] { "Paraiba" },
            new object[] { "PB" },
            new object[] { "Paraná" },
            new object[] { "PR" },
            new object[] { "Pernambuco" },
            new object[] { "PE" },
            new object[] { "Piauí" },
            new object[] { "PI" },
            new object[] { "Rio de Janeiro" },
            new object[] { "RJ" },
            new object[] { "Rio Grande do Norte" },
            new object[] { "RN" },
            new object[] { "Rio Grande do Sul" },
            new object[] { "RS" },
            new object[] { "Rondônia" },
            new object[] { "RO" },
            new object[] { "Roraima" },
            new object[] { "RR" },
            new object[] { "Santa Catarina" },
            new object[] { "SC" },
            new object[] { "São Paulo" },
            new object[] { "SP" },
            new object[] { "Sergipe" },
            new object[] { "SE" },
            new object[] { "Tocantis" },
            new object[] { "TO" }

       };

        #endregion

        private ClienteViewModel ObterClienteValido()
        {
            return new ClienteViewModel()
            {
                CPF = "280.397.936-53",
                Nome = "Aurora Larissa Corte Real",
                Estado = "RN",
            };
        }
    }
}
