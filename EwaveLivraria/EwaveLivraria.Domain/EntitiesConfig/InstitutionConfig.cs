using System;
using System.Collections.Generic;
using System.Text;
using EwaveLivraria.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EwaveLivraria.Domain.EntitiesConfig
{
    public class InstitutionConfig : IEntityTypeConfiguration<Institution>
    {
        public void Configure(EntityTypeBuilder<Institution> builder)
        {
            builder.HasKey(c => new { c.Id });           
            
            builder
                .Property(i => i.Cnpj)
                .HasColumnType("varchar(14)")
                .IsRequired(true);

            builder
                 .Property(i => i.Name)
                 .HasColumnType("varchar(100)")
                 .IsRequired(true);

            builder
                .Property(i => i.RegisteredAt)
                .HasColumnType("datetime")
                .IsRequired(true);

            builder
                .Property(i => i.IsActive)
                .IsRequired(true);
        }
    }
}
