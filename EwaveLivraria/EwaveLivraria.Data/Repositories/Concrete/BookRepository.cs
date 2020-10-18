using EwaveLivraria.Data.Repositories.Abstract;
using EwaveLivraria.Domain.Context;
using EwaveLivraria.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EwaveLivraria.Data.Repositories.Concrete
{
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        public BookRepository(ApplicationContext context) : base(context)
        {
        }

        public Task<Book> GetByIsbn(string isbn)
        {
            return _dbSet.FirstOrDefaultAsync(i=> i.Isbn == isbn);
        }

        public Task<List<Book>> GetWithFilter(string isbn, string author, string title, string genre)
        {
            var query = _dbSet.AsQueryable();
            if (!string.IsNullOrEmpty(isbn))
                query = query.Where(i => i.Isbn == isbn);
            if (!string.IsNullOrEmpty(author))
                query = query.Where(i => i.Author.Contains(author));
            if (!string.IsNullOrEmpty(title))
                query = query.Where(i => i.Title.Contains(title));
            if (!string.IsNullOrEmpty(genre))
                query = query.Where(i => i.Genre.Contains(genre));
            return query.ToListAsync();
        }
    }
}
