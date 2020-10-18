using System;
using System.Collections.Generic;
using System.Text;

namespace EwaveLivraria.Services.Model.Response
{
    public class BookModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Author { get; set; }
        public string CoverUrl { get; set; }
    }
}
