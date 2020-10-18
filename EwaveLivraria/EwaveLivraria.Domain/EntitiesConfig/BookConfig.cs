using EwaveLivraria.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EwaveLivraria.Domain.EntitiesConfig
{
    public class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(c => new { c.Id });
            builder
                .HasIndex(c => c.Isbn)
                .IsUnique();

            builder
               .Property(i => i.Isbn)
               .HasColumnType("varchar(13)")
               .IsRequired(true);

            builder
               .Property(i => i.Author)
               .HasColumnType("varchar(50)")
               .IsRequired(true);

            builder
              .Property(i => i.Genre)
              .HasColumnType("varchar(50)")
              .IsRequired(true);

            builder
              .Property(i => i.Title)
              .HasColumnType("varchar(100)")
              .IsRequired(true);

            builder
              .Property(i => i.CoverUrl)
              .HasColumnType("varchar(200)")
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
