using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EwaveLivraria.Domain.Model
{
    [Table("BookInventory")]
    public class BookInventory : Base
    {        
        public int BookId { get; set; }
        public Book Book { get; set; }
        public int Quantity { get; set; }
    }
}
