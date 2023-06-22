using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUDCleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CRUDCleanArchitecture.Infrastructure.Persistence.EFConfigurations;
public class PersonasConfiguration : IEntityTypeConfiguration<Persona>
{
    public void Configure(EntityTypeBuilder<Persona> builder)
    {
        builder.Property(t => t.Nombre)
            .HasMaxLength(60)
            .IsRequired();

        builder.Property(t => t.Apellido)
            .HasMaxLength(60)
            .IsRequired();
    }
}
