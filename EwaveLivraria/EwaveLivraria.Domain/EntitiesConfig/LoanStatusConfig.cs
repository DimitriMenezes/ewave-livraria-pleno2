using EwaveLivraria.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EwaveLivraria.Domain.EntitiesConfig
{
    public class LoanStatusConfig : IEntityTypeConfiguration<LoanStatus>
    {
        public void Configure(EntityTypeBuilder<LoanStatus> builder)
        {
            builder.HasKey(c => new { c.Id });         

            builder
                 .Property(i => i.Name)
                 .HasColumnType("varchar(30)")
                 .IsRequired(true);
        }
    }
}
