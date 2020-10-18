using EwaveLivraria.Services.Model.Request;
using EwaveLivraria.Services.Model.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EwaveLivraria.Services.Abstract
{
    public interface IAdministratorService
    {
        Task<ReturnModel> CreateAdministrator(AdministratorRequest request);
        Task<ReturnModel> UpdateAdministrator(AdministratorRequest request);
    }
}
