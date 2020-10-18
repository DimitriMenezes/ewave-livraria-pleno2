using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using EwaveLivraria.Data.Repositories.Abstract;
using EwaveLivraria.Domain.Context;
using EwaveLivraria.Domain.Model;

namespace EwaveLivraria.Data.Repositories.Concrete
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : Base
    {
        internal readonly ApplicationContext _context;
        internal DbSet<TEntity> _dbSet;

        protected BaseRepository(ApplicationContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public virtual async Task<List<TEntity>> GetAll()
        {
            return await Include().ToListAsync();
        }

        public virtual async Task<TEntity> GetById(int id)
        {
            return await Include().FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<TEntity> Insert(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(int id)
        {
            var entity = _dbSet.Find(id);
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public virtual IQueryable<TEntity> Include()
        {
            return _dbSet;
        }
    }
}
