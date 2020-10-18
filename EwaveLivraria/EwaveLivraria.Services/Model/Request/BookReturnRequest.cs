using System;
using System.Collections.Generic;
using System.Text;

namespace EwaveLivraria.Services.Model.Request
{
    public class BookReturnRequest
    {
        public int UserId { get; set; }
        public int BookId { get; set; }
    }
}
