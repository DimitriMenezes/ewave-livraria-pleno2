using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EwaveLivraria.Domain.Model
{
    [Table("BookLoan")]
    public class BookLoan : Base
    {        
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime? ReturnedDate { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public int LoanStatusId { get; set; }
        public User User { get; set; }
        public Book Book { get; set; }
        public LoanStatus LoanStatus { get; set; }
    }
}
