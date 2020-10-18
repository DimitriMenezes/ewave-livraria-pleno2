using EwaveLivraria.Data.Repositories.Abstract;
using EwaveLivraria.Domain.Context;
using EwaveLivraria.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace EwaveLivraria.Data.Repositories.Concrete
{
    public class BookInventoryRepository : BaseRepository<BookInventory>, IBookInventoryRepository
    {
        public BookInventoryRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
