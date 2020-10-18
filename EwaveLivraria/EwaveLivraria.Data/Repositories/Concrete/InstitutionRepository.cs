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
    public class InstitutionRepository : BaseRepository<Institution>, IInstitutionRepository
    {
        public InstitutionRepository(ApplicationContext context) : base(context)
        {
        }

        public async Task<Institution> GetByCnpj(string cnpj)
        {
            return await _dbSet.FirstOrDefaultAsync(i => i.Cnpj == cnpj);
        }
    }
}
