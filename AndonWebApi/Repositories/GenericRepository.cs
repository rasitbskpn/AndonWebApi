using AndonWebApi.Context;
using AndonWebApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace AndonWebApi.Repositories
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly AppDbContext _dbContext;
        public GenericRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>().AsNoTracking();
        }
        public async Task Add(TEntity entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            TEntity entity = await GetById(id);
            _dbContext.Set<TEntity>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _dbContext.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task Update(TEntity entity)
        {

            _dbContext.Set<TEntity>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
