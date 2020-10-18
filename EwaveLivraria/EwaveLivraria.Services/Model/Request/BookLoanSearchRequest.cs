using System;
using System.Collections.Generic;
using System.Text;

namespace EwaveLivraria.Services.Model.Request
{
    public class BookLoanSearchRequest
    {
        public string UserCpf { get; set; }
        public string BookTitle { get; set; }
        public int StatusId { get; set; }
    }
}
