using System;
using System.Collections.Generic;
using System.Text;

namespace EwaveLivraria.Services.Model.Response
{
    public class BookLoanModel
    {
        public int Id { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime? ReturnedDate { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public int LoanStatusId { get; set; }
    }
}
