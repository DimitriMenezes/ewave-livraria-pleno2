using EwaveLivraria.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EwaveLivraria.Data.Repositories.Abstract
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetByCpf(string cpf);
        Task<User> GetByEmail(string email);
        Task<List<User>> GetBlockedUsers();
    }
}
