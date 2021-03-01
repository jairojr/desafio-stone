using Microsoft.EntityFrameworkCore;
using Stone.Clientes.Data.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Stone.Clientes.Data.Tests.Fixture
{
    [ExcludeFromCodeCoverage]
    public class ClientesContextFixture : IDisposable
    {
        private static readonly object _lock = new object();
        private static bool _databaseInitialized;
        public ClientesContext Context { get; private set; }

        public ClientesContextFixture()
        {
            this.Context = new ClientesContext(new DbContextOptionsBuilder<ClientesContext>()
                                                         .UseSqlite("Filename=Test.db")
                                                         .Options);
            Seed();
        }

        private void Seed()
        {
            lock (_lock)
            {
                if (!_databaseInitialized)
                {
                    Context.Database.EnsureDeleted();
                    Context.Database.EnsureCreated();

                    var pessoa1 = new ClienteEntity(new Guid("362eaade-162b-47ff-9d7a-6b4b0682a806"),
                                                "Luna Allana Gonçalves",
                                                "RJ",
                                                30632920017);

                    var pessoa2 = new ClienteEntity(new Guid("79fa9d4f-47d0-419c-851e-4fb0cf515710"),
                                                "Carlos Fábio Vicente Monteiro",
                                                "TO",
                                                84371747752);

                    var pessoa3 = new ClienteEntity(new Guid("a05a55d9-ee67-4ebd-af85-872986a3c025"),
                                                "aa7d9d1a-86be-41fc-9f5e-12129b9fcdf9",
                                                "DF",
                                                33952753106);


                    Context.AddRange(pessoa1, pessoa2, pessoa3);
                    Context.SaveChanges();

                    _databaseInitialized = true;
                }
            }
        }

        public void Dispose() => this.Context.Dispose();
    }
}