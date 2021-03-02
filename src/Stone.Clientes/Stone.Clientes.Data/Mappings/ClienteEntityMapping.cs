using Microsoft.EntityFrameworkCore;
using Stone.Clientes.Data.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Stone.Clientes.Data.Mappings
{
    [ExcludeFromCodeCoverage]
    internal class ClienteEntityMapping : IEntityTypeConfiguration<ClienteEntity>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<ClienteEntity> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(e => e.Estado).HasMaxLength(2).IsRequired();
            builder.Property(e => e.CPF).HasMaxLength(11).IsRequired();

            builder.HasIndex(c => c.CPF).IsUnique();
        }
    }
}
