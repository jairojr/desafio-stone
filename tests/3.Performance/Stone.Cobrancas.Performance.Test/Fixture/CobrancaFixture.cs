using Bogus;
using Stone.Cobrancas.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Bogus.Extensions.Brazil;
using static Stone.Utils.CpfExtensions;
using Stone.Cobrancas.Performance.Tests.Models;

namespace Stone.Cobrancas.Performance.Test.Fixture
{
    public class CobrancaFixture
    {
        public CobrancaEntity GerarCobrancaEntity()
        {
            return new Faker<CobrancaEntity>("pt_BR")
                            .RuleFor(e => e.Id, (f, u) => Guid.NewGuid())
                            .RuleFor(e => e.CPF, (f, u) =>
                            {
                                Cpf cpf = f.Person.Cpf();
                                return cpf.ObterApenasNumeros();
                            })
                            .RuleFor(e => e.Valor, (f, u) => f.Random.Decimal(0.1m, 1000m))
                            .RuleFor(e => e.Data, (f, u) => f.Date.Between(new DateTime(2012, 1, 1), new DateTime(2025, 12, 31)));
        }

        public CobrancaDTO GerarCobrancaDTO()
        {
            return new Faker<CobrancaDTO>("pt_BR")
                            .RuleFor(e => e.CPF, (f, u) => f.Person.Cpf())
                            .RuleFor(e => e.Valor, (f, u) => f.Random.Decimal(0.1m, 1000m))
                            .RuleFor(e => e.Data, (f, u) => f.Date.Between(new DateTime(2012, 1, 1), new DateTime(2025, 12, 31)));

        }
    }
}
