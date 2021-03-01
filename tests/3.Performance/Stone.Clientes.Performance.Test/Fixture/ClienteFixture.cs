using Bogus;
using Stone.Clientes.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Bogus.Extensions.Brazil;
using static Stone.Utils.CpfExtensions;
using Stone.Clientes.Application.Enums;
using Stone.Clientes.Performance.Tests.Models;

namespace Stone.Clientes.Performance.Test.Fixture
{
    public class ClienteFixture
    {
        public ClienteEntity GerarClienteEntity()
        {
            return new Faker<ClienteEntity>("pt_BR")
                            .RuleFor(e => e.Id, (f, u) => Guid.NewGuid())
                            .RuleFor(e => e.Nome, (f, u) => f.Person.FullName)
                            .RuleFor(e => e.CPF, (f, u) =>
                            {
                                Cpf cpf = f.Person.Cpf();
                                return cpf.ObterApenasNumeros();
                            })
                            .RuleFor(e => e.Estado, (f, u) => f.PickRandom<EstadoEnum>().ToString());
        }

        public ClienteDTO GerarClienteDTO()
        {
            return new Faker<ClienteDTO>("pt_BR")
                            .RuleFor(e => e.Nome, (f, u) => f.Person.FullName)
                            .RuleFor(e => e.CPF, (f, u) => f.Person.Cpf())
                            .RuleFor(e => e.Estado, (f, u) => FakerEstado(f));
        }

        private static string FakerEstado(Faker f)
        {
            EstadoEnum estado = EstadoEnum.NaoInformado;

            while (estado == EstadoEnum.NaoInformado)
                estado = f.PickRandom<EstadoEnum>();

            return estado.ToString();
        }
    }
}
