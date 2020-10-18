using System;
using System.Collections.Generic;
using System.Text;
using EwaveLivraria.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EwaveLivraria.Domain.EntitiesConfig
{
    public class AdministratorConfig : IEntityTypeConfiguration<Administrator>
    {
        public void Configure(EntityTypeBuilder<Administrator> builder)
        {
            builder.HasKey(c => new { c.Id });

            builder
                .HasIndex(c => c.Cpf)
                .IsUnique();

            builder
                .Property(i => i.Email)
                .HasColumnType("varchar(50)")
                .IsRequired(true);

            builder
                 .Property(i => i.Name)
                 .HasColumnType("varchar(100)")
                 .IsRequired(true);

            builder
                 .Property(i => i.Password)
                 .HasColumnType("varchar(200)")
                 .IsRequired(true);

            builder
                 .Property(i => i.RegisteredAt)
                 .HasColumnType("datetime")
                 .IsRequired(true);
        }
    }
}
