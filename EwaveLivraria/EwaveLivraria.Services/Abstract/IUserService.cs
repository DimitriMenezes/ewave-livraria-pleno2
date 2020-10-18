using EwaveLivraria.Services.Model.Request;
using EwaveLivraria.Services.Model.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EwaveLivraria.Services.Abstract
{
    public interface IUserService
    {
        Task<ReturnModel> CreateUser(UserRequest request);
        Task<ReturnModel> UpdateUser(UserRequest request);
        Task<ReturnModel> GetUser(int id);
        Task<ReturnModel> GetAllUsers();
        Task<ReturnModel> BlockUser(int id);
    }
}
