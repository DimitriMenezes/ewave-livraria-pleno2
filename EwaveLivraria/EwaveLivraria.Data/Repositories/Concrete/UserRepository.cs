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
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationContext context) : base(context)
        {
        }

        public override IQueryable<User> Include()
        {
            return _dbSet
               .Include(c => c.Institution);
        }

        public async Task<User> GetByCpf(string cpf)
        {
            return await Include().FirstOrDefaultAsync(i => i.Cpf == cpf);
        }

        public async Task<User> GetByEmail(string email)
        {
            return await _dbSet.FirstOrDefaultAsync(i => i.Email == email);
        }
    }
}
