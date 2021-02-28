using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Stone.Clientes.API.Controllers;
using Stone.Clientes.Application.Interfaces;
using Stone.Clientes.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using Xunit;

namespace Stone.Clientes.API.Tests
{
    public class ClientesControllerTest
    {
        private readonly Mock<IClienteApplication> application;
        private readonly ClientesController controller;

        public ClientesControllerTest()
        {
            this.application = new Moq.Mock<IClienteApplication>();
            this.controller = new ClientesController(this.application.Object)
            {
                Url = new Mock<IUrlHelper>().Object
            };
        }
        [Fact]
        public async System.Threading.Tasks.Task ClientesController_PostAsync_ExecutaComSucessoAsync()
        {
            //Arrange
            ClienteViewModel novoCliente = new ClienteViewModel()
            {
                CPF = "801.715.539-50",
                Nome = "Analu Fernanda Santos",
                Estado = "MS"
            };
            this.application.Setup(e => e.CriarAsync(novoCliente, CancellationToken.None)).ReturnsAsync(novoCliente);

            //Act
            var result = await this.controller.PostAsync(novoCliente, CancellationToken.None);
            var createdResult = result as CreatedAtActionResult;

            //Assert
            Assert.NotNull(createdResult);
            Assert.Equal((int)HttpStatusCode.Created, createdResult.StatusCode);
        }

        [Fact]
        public async System.Threading.Tasks.Task ClientesController_GetPorCpf_RetornaCliente()
        {
            //Arrange
            ClienteViewModel cliente = new ClienteViewModel()
            {
                CPF = "801.715.539-50",
                Nome = "Analu Fernanda Santos",
                Estado = "MS"
            };
            this.application.Setup(e => e.ObterPorCpfAsync(80171553950, CancellationToken.None)).ReturnsAsync(cliente);

            //Act
            var result = await this.controller.Get(80171553950, CancellationToken.None);
            var okResult = result as OkObjectResult;

            //Assert
            Assert.NotNull(okResult);
            Assert.Equal((int)HttpStatusCode.OK, okResult.StatusCode);
        }

        [Fact]
        public async System.Threading.Tasks.Task ClientesController_GetPorCpfSemCliente_RetornaClienteNull()
        {
            //Arrange
            this.application.Setup(e => e.ObterPorCpfAsync(31555847420, CancellationToken.None)).ReturnsAsync((ClienteViewModel)null);

            //Act
            var result = await this.controller.Get(31555847420, CancellationToken.None);
            var notFoundResult = result as NotFoundResult;

            //Assert
            Assert.NotNull(notFoundResult);
            Assert.Equal((int)HttpStatusCode.NotFound, notFoundResult.StatusCode);
        }



        [Fact]
        public async System.Threading.Tasks.Task ClientesController_GetLista_RetornaListaDeClientes()
        {
            //Arrange
            var listClientes = new List<ClienteViewModel> {
                    new ClienteViewModel()
                    {
                        CPF = "801.715.539-50",
                        Nome = "Analu Fernanda Santos",
                        Estado = "MS"
                    },
                     new ClienteViewModel()
                    {
                        CPF = "803.272.081-20",
                        Nome = "Oliver Emanuel Moreira",
                        Estado = "GO"
                    },
                      new ClienteViewModel()
                    {
                        CPF = "492.177.875-23",
                        Nome = "Joana Elza Beatriz Freitas",
                        Estado = "MT"
                    }
            };
            this.application.Setup(e => e.BuscaPaginadaAsync(1, 5, CancellationToken.None)).ReturnsAsync(listClientes);
            //Act
            var result = await this.controller.GetLista(1, 5, CancellationToken.None);
            var okResult = result as OkObjectResult;

            //Assert
            Assert.NotNull(okResult);
            Assert.Equal((int)HttpStatusCode.OK, okResult.StatusCode);
        }
    }
}
