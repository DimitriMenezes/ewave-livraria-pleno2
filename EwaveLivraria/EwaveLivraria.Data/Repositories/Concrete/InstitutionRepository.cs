using EwaveLivraria.Data.Repositories.Abstract;
using EwaveLivraria.Domain.Context;
using EwaveLivraria.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace EwaveLivraria.Data.Repositories.Concrete
{
    public class InstitutionRepository : BaseRepository<Institution>, IInstitutionRepository
    {
        public InstitutionRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
