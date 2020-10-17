using EwaveLivraria.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;


namespace EwaveLivraria.Domain.EntitiesConfig
{
    public class AddressConfig : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(i => i.Number)
              .HasColumnType("varchar(10)")
              .IsRequired(true);

            builder.Property(i => i.Street)
                .HasColumnType("varchar(100)")
                .IsRequired(true);

            builder.Property(i => i.City)
                .HasColumnType("varchar(100)")
                .IsRequired(true);

            builder.Property(i => i.State)
                .HasColumnType("varchar(2)")
                .IsRequired(true);

            builder.Property(i => i.ZipCode)
                .HasColumnType("varchar(8)")
                .IsRequired(true);

            builder.Property(i => i.Neighborhood)
                .HasColumnType("varchar(100)")
                .IsRequired(true);

            builder.Property(i => i.Complement)
                .HasColumnType("varchar(100)");          
        }      
    }
}