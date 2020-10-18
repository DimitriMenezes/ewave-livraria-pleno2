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
    public class BookInventoryRepository : BaseRepository<BookInventory>, IBookInventoryRepository
    {
        public BookInventoryRepository(ApplicationContext context) : base(context)
        {
        }


        public override IQueryable<BookInventory> Include()
        {
            return _dbSet
                .Include(c => c.Book);
        }

        public async Task<BookInventory> GetByBookId(int bookId)
        {
            return Include().FirstOrDefault(i => i.BookId == bookId);
        }
    }
}
