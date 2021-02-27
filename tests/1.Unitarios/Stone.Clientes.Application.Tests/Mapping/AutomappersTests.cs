using AutoMapper;
using Stone.Clientes.Application.Mapping;
using Stone.Clientes.Application.ViewModel;
using Stone.Clientes.Domain.Enums;
using Stone.Clientes.Domain.Models;
using Xunit;

namespace Stone.Clientes.Application.Tests.Mapping
{
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
        public void Automappers_MappperClienteViewModel_ClienteDomain()
        {
            //Arrange
            var clienteViewModel = new ClienteViewModel
            {
                Nome = "Novo Cliente",
                CPF = "282.490.822-06",
                Estado = "PR"
            };

            //Act
            var clienteDomain = this.mapper.Map<Cliente>(clienteViewModel);

            //Assert
            Assert.Equal(clienteViewModel.Nome, clienteDomain.Nome);
            Assert.Equal(clienteViewModel.CPF, clienteDomain.CPF.ObterComMascara());
            Assert.Equal(clienteViewModel.Estado, clienteDomain.Estado.ToString());
        }

        [Fact]
        public void Automappers_MappperClienteViewModelComEstadoCompleto_ClienteDomain()
        {
            //Arrange
            var clienteViewModel = new ClienteViewModel
            {
                Nome = "Novo Cliente",
                CPF = "282.490.822-06",
                Estado = "Paraná"
            };

            //Act
            var clienteDomain = this.mapper.Map<ClienteViewModel, Cliente>(clienteViewModel);

            //Assert
            Assert.Equal(clienteViewModel.Nome, clienteDomain.Nome);
            Assert.Equal(clienteViewModel.CPF, clienteDomain.CPF.ObterComMascara());
            Assert.Equal(EstadoEnum.PR.ToString(), clienteDomain.Estado.ToString());
        }

        [Fact]
        public void Automappers_MappperClienteDomainComCpfComMascara_ClienteViewModel()
        {
            //Arrange
            var clienteDomain = new Cliente("Nome Cliente", Domain.Enums.EstadoEnum.AM, "190.161.779-30");

            //Act
            var clienteViewModel = this.mapper.Map<ClienteViewModel>(clienteDomain);

            //Assert
            Assert.Equal(clienteDomain.Nome, clienteViewModel.Nome);
            Assert.Equal(clienteDomain.CPF.ObterComMascara(), clienteViewModel.CPF);
            Assert.Equal(clienteDomain.Estado.ToString(), clienteViewModel.Estado.ToString());
        }

        [Fact]
        public void Automappers_MappperClienteDomainSemCpfComMascara_ClienteViewModel()
        {
            //Arrange
            var clienteDomain = new Cliente("Nome Cliente", Domain.Enums.EstadoEnum.AM, "47938659096");

            //Act
            var clienteViewModel = this.mapper.Map<ClienteViewModel>(clienteDomain);

            //Assert
            Assert.Equal(clienteDomain.Nome, clienteViewModel.Nome);
            Assert.Equal(clienteDomain.CPF.ObterComMascara(), clienteViewModel.CPF);
            Assert.Equal(clienteDomain.Estado.ToString(), clienteViewModel.Estado);
        }
    }
}
