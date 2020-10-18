using EwaveLivraria.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EwaveLivraria.Data.Repositories.Abstract
{
    public interface IBookInventoryRepository : IBaseRepository<BookInventory>
    {
        Task<BookInventory> GetByBookId(int bookId);
    }
}
