using EwaveLivraria.Services.Model.Request;
using EwaveLivraria.Services.Model.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EwaveLivraria.Services.Abstract
{
    public interface IAuthenticationService
    {
        Task<ReturnModel> AdminLogin(LoginRequest request);
        Task<ReturnModel> UserLogin(LoginRequest request);
    }
}
