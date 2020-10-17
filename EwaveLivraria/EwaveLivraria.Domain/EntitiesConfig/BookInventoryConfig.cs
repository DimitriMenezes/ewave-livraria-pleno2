using EwaveLivraria.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EwaveLivraria.Domain.EntitiesConfig
{
    public class BookInventoryConfig : IEntityTypeConfiguration<BookInventory>
    {
        public void Configure(EntityTypeBuilder<BookInventory> builder)
        {
            builder.HasKey(c => new { c.Id });

            builder
              .Property(i => i.Quantity)              
              .IsRequired(true);       
        }
    }
}
