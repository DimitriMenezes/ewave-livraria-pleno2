using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EwaveLivraria.Services.Model.Request
{
    public class BookLoanRequest
    {
        public int UserId { get; set; }
        public int BookId { get; set; }
        public DateTime LoanUntil { get; set; }
    }
}
