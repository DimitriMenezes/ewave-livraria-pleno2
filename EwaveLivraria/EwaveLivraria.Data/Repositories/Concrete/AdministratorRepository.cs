using EwaveLivraria.Data.Repositories.Abstract;
using EwaveLivraria.Domain.Context;
using EwaveLivraria.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EwaveLivraria.Data.Repositories.Concrete
{
    public class AdministratorRepository : BaseRepository<Administrator>, IAdministratorRepository
    {
        public AdministratorRepository(ApplicationContext context) : base(context)
        {
            
        }
        public async Task<Administrator> GetByCpf(string cpf)
        {
            return await _dbSet.FirstOrDefaultAsync(i => i.Cpf == cpf);
        }

        public async Task<Administrator> GetByEmail(string email)
        {
            return await _dbSet.FirstOrDefaultAsync(i => i.Email == email);
        }
    }
}
