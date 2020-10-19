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
    public class InstitutionRepository : BaseRepository<Institution>, IInstitutionRepository
    {
        public InstitutionRepository(ApplicationContext context) : base(context)
        {
        }
        public override IQueryable<Institution> Include()
        {
            return _dbSet.Include(i => i.Address);
        }

        public async Task<Institution> GetByCnpj(string cnpj)
        {
            return await Include().FirstOrDefaultAsync(i => i.Cnpj == cnpj);
        }
    }
}
