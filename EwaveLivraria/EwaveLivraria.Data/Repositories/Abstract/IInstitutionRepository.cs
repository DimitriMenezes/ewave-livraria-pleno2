using EwaveLivraria.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EwaveLivraria.Data.Repositories.Abstract
{
    public interface IInstitutionRepository : IBaseRepository<Institution>
    {
        Task<Institution> GetByCnpj(string cnpj);
    }
}
