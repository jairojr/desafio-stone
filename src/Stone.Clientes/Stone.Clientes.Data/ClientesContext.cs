using Microsoft.EntityFrameworkCore;
using Stone.Clientes.Data.Mappings;
using Stone.Clientes.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stone.Clientes.Data
{
    public class ClientesContext : DbContext
    {

        public ClientesContext()
        {
        }

        public ClientesContext(DbContextOptions<ClientesContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public DbSet<ClienteEntity> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ClientesContext).Assembly);
        }
    }
}
