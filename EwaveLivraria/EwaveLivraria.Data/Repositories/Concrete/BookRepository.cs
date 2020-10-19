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

        public Task<List<Book>> GetWithFilter(string filter)
        {
            var query = _dbSet.AsQueryable();
            if (!string.IsNullOrEmpty(filter))
                query = query.Where(i => i.Isbn.Contains(filter) 
                    || i.Author.Contains(filter)
                    || i.Title.Contains(filter)
                    || i.Genre.Contains(filter)
                    ) ;            
            
            return query.ToListAsync();
        }
    }
}
