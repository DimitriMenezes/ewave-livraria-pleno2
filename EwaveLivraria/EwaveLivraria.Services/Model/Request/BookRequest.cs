using System;
using System.Collections.Generic;
using System.Text;

namespace EwaveLivraria.Services.Model.Request
{
    public class BookRequest
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Author { get; set; }
        public string CoverUrl { get; set; }
        public int Quantity { get; set; }
    }
}
