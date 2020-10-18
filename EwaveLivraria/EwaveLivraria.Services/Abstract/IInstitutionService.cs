using EwaveLivraria.Services.Model.Request;
using EwaveLivraria.Services.Model.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EwaveLivraria.Services.Abstract
{
    public interface IInstitutionService
    {
        Task<ReturnModel> CreateInstitution(InstitutionRequest request);
        Task<ReturnModel> UpdateInstitution(InstitutionRequest request);
        Task<ReturnModel> BlockInstitution(int id);
        Task<ReturnModel> GetInstitution(int id);
        Task<ReturnModel> GetAllInstitutions();        
    }
}
