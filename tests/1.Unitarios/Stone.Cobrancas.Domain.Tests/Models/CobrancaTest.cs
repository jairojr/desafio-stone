using Stone.Cobrancas.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Stone.Cobrancas.Domain.Tests.Models
{
    [Trait("Category", "Unit")]
    public class CobrancaTest
    {


        [Theory]
        [InlineData("566.222.926-04", 5604)]
        [InlineData("537.223.848-85", 5385)]
        [InlineData("110.244.855-95", 1195)]
        [InlineData("91178684598", 9198)]
        [InlineData("77118159727", 7727)]
        [InlineData("60103863494", 6094)]
        public void CriarCobranca_ExecutaComSucesso(string cpf, decimal valorASerCobrado)
        {
            //Arrange & Act
            var cobranca = Cobranca.CriarCobranca(cpf);

            //Assert
            Assert.Equal(valorASerCobrado, cobranca.Valor);
        }


    }
}
