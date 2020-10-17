using EwaveLivraria.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EwaveLivraria.Domain.EntitiesConfig
{
    public class BookLoanConfig : IEntityTypeConfiguration<BookLoan>
    {
        public void Configure(EntityTypeBuilder<BookLoan> builder)
        {
            builder.HasKey(c => new { c.Id });

            builder
                .HasOne(i => i.User)
                .WithMany(i => i.BookLoan)
                .HasForeignKey(i => i.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(i => i.Book)
                .WithMany(i => i.BookLoan)
                .HasForeignKey(i => i.BookId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .Property(i => i.BeginDate)
                .HasColumnType("datetime")
                .IsRequired(true);

            builder
                .Property(i => i.EndDate)
                .HasColumnType("datetime")
                .IsRequired(true);
        }
    }
}
