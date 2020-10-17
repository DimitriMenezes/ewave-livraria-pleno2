using EwaveLivraria.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EwaveLivraria.Domain.EntitiesConfig
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(c => new { c.Id });

            builder
                .HasOne(i => i.Institution)
                .WithMany(i => i.User)
                .HasForeignKey(i => i.InstitutionId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .Property(i => i.Email)
                .HasColumnType("varchar(50)")
                .IsRequired(true);

            builder
                .Property(i => i.Phone)
                .HasColumnType("varchar(15)")
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
                .Property(i => i.Cpf)
                .HasColumnType("varchar(11)")
                .IsRequired(true);

            builder
                 .Property(i => i.IsActive)
                 .IsRequired(true);

            builder
                 .Property(i => i.RegisteredAt)
                 .HasColumnType("datetime")
                 .IsRequired(true);

            builder
                .Property(i => i.BlockedUntil)
                .HasColumnType("datetime")
                .IsRequired(false);
        }
    }
}
