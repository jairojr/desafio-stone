using System;
using Xunit;
using static Stone.Utils.CpfExtensions;

namespace Stone.Utils.Tests
{
    public class CpfExtensionsTests
    {
        [Theory]
        [InlineData("0")]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        [InlineData("00000000000")]
        [InlineData("11111111111")]
        [InlineData("22222222222")]
        [InlineData("33333333333")]
        [InlineData("44444444444")]
        [InlineData("55555555555")]
        [InlineData("66666666666")]
        [InlineData("77777777777")]
        [InlineData("88888888888")]
        [InlineData("99999999999")]
        [InlineData("123456789123456")]
        [InlineData("123")]
        [InlineData("ABCD")]
        [InlineData("ABCD1234567")]
        [InlineData("924.312.330-01")]
        [InlineData("539.402.190-15")]
        [InlineData("714.419.120-03")]
        [InlineData("254.361.690-06")]
        [InlineData("183.377.680-61")]
        [InlineData("18052414042")]
        [InlineData("28519096169")]
        [InlineData("02035513090")]
        [InlineData("91046545051")]
        [InlineData("66454856120")]

        public void CpfExtensions_CpfsInvalidos_RetornaInvalido(string cpfInvalido)
        {
            //Act & Act
            Cpf cpf = cpfInvalido;

            //Assert
            Assert.False(cpf.EhValido);
        }


        [Theory]
        [InlineData("08504412008")]
        [InlineData("98042753098")]
        [InlineData("10052677079")]
        [InlineData("15203071012")]
        [InlineData("55569809007")]
        [InlineData("731.547.010-79")]
        [InlineData("223.985.200-30")]
        [InlineData("318.116.470-49")]
        [InlineData("508.607.310-30")]
        [InlineData("617.653.510-73")]
        public void CpfExtensions_CpfsValidos_RetornaValido(string cpfValido)
        {
            //Act & Act
            Cpf cpf = cpfValido;

            //Assert
            Assert.True(cpf.EhValido);
        }


        [Theory]
        [InlineData("08504412008", 08504412008)]
        [InlineData("98042753098", 98042753098)]
        [InlineData("10052677079", 10052677079)]
        [InlineData("15203071012", 15203071012)]
        [InlineData("55569809007", 55569809007)]
        [InlineData("731.547.010-79", 73154701079)]
        [InlineData("223.985.200-30", 22398520030)]
        [InlineData("318.116.470-49", 31811647049)]
        [InlineData("508.607.310-30", 50860731030)]
        [InlineData("617.653.510-73", 61765351073)]
        public void CpfExtensions_CpfsValidos_RetornaOsNumeros(string cpfValido, long numerosCpf)
        {
            //Act & Act
            Cpf cpf = cpfValido;

            //Assert
            Assert.Equal(numerosCpf, cpf.ObterApenasNumeros());
        }

        [Theory]
        [InlineData("08504412008", "085.044.120-08")]
        [InlineData("98042753098", "980.427.530-98")]
        [InlineData("10052677079", "100.526.770-79")]
        [InlineData("15203071012", "152.030.710-12")]
        [InlineData("55569809007", "555.698.090-07")]
        [InlineData("731.547.010-79", "731.547.010-79")]
        [InlineData("223.985.200-30", "223.985.200-30")]
        [InlineData("318.116.470-49", "318.116.470-49")]
        [InlineData("508.607.310-30", "508.607.310-30")]
        [InlineData("617.653.510-73", "617.653.510-73")]
        public void CpfExtensions_CpfsValidos_RetornaCpfComMascara(string cpfValido, string cpfComMascara)
        {
            //Act & Act
            Cpf cpf = cpfValido;

            //Assert
            Assert.Equal(cpfComMascara, cpf.ObterComMascara());
        }
    }
}
