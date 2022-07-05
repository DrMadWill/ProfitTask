using Microsoft.EntityFrameworkCore;
using RESTAPI.DataAccess.Abstract;
using RESTAPI.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTAPI.DataAccess.Concrete.MsSql
{
    public class BaseRepository<TEntity, TContext> : IBaseRepository<TEntity>
        where TEntity : class
        where TContext : DbContext
    {

        private readonly PostDbContext _dbContext;
        public BaseRepository(PostDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> CreateByAddRange(List<TEntity> entity)
        {
            try
            {
                await _dbContext.Set<TEntity>().AddRangeAsync(entity);
                await _dbContext.SaveChangesAsync();
            }
            catch 
            {
                return false;
            }

            return true;
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await _dbContext.Set<TEntity>().ToListAsync();
        }

        public IQueryable<TEntity> GetAllQuery()
        {
            return _dbContext.Set<TEntity>().AsNoTracking();
        }

        public async Task<int> GetCount()
        {
            return await _dbContext.Set<TEntity>().CountAsync();
        }
    }
}
