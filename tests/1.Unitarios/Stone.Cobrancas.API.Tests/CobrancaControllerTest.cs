using Microsoft.AspNetCore.Mvc;
using Moq;
using Stone.Cobrancas.API.Controllers;
using Stone.Cobrancas.Application.Interfaces;
using Stone.Cobrancas.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using Xunit;

namespace Stone.Cobrancas.API.Tests
{
    [Trait("Category", "Unit")]
    public class CobrancaControllerTest
    {
        private readonly Mock<ICobrancaApplication> cobrancaApplication;
        private readonly CobrancaController controller;

        public CobrancaControllerTest()
        {
            this.cobrancaApplication = new Mock<ICobrancaApplication>();
            this.controller = new CobrancaController(this.cobrancaApplication.Object)
            {
                Url = new Mock<IUrlHelper>().Object
            };

        }

        [Fact]
        public async System.Threading.Tasks.Task CobrancaController_Post_ExecutaComSucessoAsync()
        {
            //Arrange
            var cobranca = new CobrancaViewModel()
            {
                CPF = "840.874.441-04",
                Data = DateTime.Now,
                Valor = 8404.00m
            };
            this.cobrancaApplication.Setup(e => e.CriarAsync(cobranca, CancellationToken.None)).ReturnsAsync(cobranca);

            //Act
            var result = await this.controller.PostAsync(cobranca, CancellationToken.None);
            var createdResult = result as CreatedAtActionResult;

            //Assert
            Assert.NotNull(createdResult);
            Assert.Equal((int)HttpStatusCode.Created, createdResult.StatusCode);
        }

        [Fact]
        public async System.Threading.Tasks.Task CobrancaController_Get_ExecutaComSucessoAsync()
        {
            //Arrange
            var busca = new BuscarCobrancaViewModel()
            {
                CPF = "840.874.441-04",
                Pagina = 1,
                Quantidade = 10
            };
            var cobranca = new List<CobrancaViewModel>()
            {
                new CobrancaViewModel()
                {
                    CPF = "840.874.441-04",
                    Data = DateTime.Now,
                    Valor = 8404.00m
                }
            };
            this.cobrancaApplication.Setup(e => e.BuscarAsync(busca, CancellationToken.None)).ReturnsAsync(cobranca);

            //Act
            var result = await this.controller.Get(busca, CancellationToken.None);
            var okObjectResult = result as OkObjectResult;

            //Assert
            Assert.NotNull(okObjectResult);
            Assert.Equal((int)HttpStatusCode.OK, okObjectResult.StatusCode);
        }
    }
}
