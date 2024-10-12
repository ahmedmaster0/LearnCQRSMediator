using Application.Contract;
using Microsoft.EntityFrameworkCore;


namespace Presistence.Repositories
{
    public class BaseAsyncRepository<T> : IBaseAyncRepository<T> where T : class
    {
        protected ApplicationContext _context;
        public BaseAsyncRepository(ApplicationContext context) 
        {
            _context = context;
        }

        public async Task<T> AddAsync(T entity)
        {
            var addedEntity  =  await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return addedEntity.Entity;
        }

        public async Task<bool> DeleteByIdAsync(T entity)
        {
             _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
           return  await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _context.Set<T>().FindAsync(id); ;
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
