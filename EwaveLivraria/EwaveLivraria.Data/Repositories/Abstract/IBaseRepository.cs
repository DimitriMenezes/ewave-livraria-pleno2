using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EwaveLivraria.Data.Repositories.Abstract
{
    public interface IBaseRepository<TEntity>
    {
        Task<TEntity> GetById(int id);
        Task<List<TEntity>> GetAll();
        Task<TEntity> Insert(TEntity entity);
        Task<TEntity> Update(TEntity entity);
        Task Delete(int id);
        IQueryable<TEntity> Include();
    }
}
