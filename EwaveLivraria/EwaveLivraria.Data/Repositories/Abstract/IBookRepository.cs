using EwaveLivraria.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EwaveLivraria.Data.Repositories.Abstract
{
    public interface IBookRepository : IBaseRepository<Book>
    {
        Task<Book> GetByIsbn(string isbn);
        Task<List<Book>> GetWithFilter(string isbn, string author, string title, string genre);
    }
}
