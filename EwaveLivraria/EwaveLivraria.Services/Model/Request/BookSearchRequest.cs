using System;
using System.Collections.Generic;
using System.Text;

namespace EwaveLivraria.Services.Model.Request
{
    public class BookSearchRequest
    {
        public string Isbn { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
    }
}
