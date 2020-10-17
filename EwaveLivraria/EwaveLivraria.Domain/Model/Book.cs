using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EwaveLivraria.Domain.Model
{
    [Table("Book")]
    public class Book : Base
    {        
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Author { get; set; }
        public string CoverUrl { get; set; }
        public DateTime RegisteredAt { get; set; } 
        public bool IsActive { get; set; }
        public ICollection<BookLoan> BookLoan { get; set; }
        
        public Book()
        {
            BookLoan = new Collection<BookLoan>();
        }
    }
}
