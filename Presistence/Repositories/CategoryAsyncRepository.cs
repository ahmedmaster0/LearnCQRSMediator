
using Application.Contract;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Presistence.Repositories
{
    public class CategoryAsyncRepository : BaseAsyncRepository<Category>, ICategoryAsyncRepository
    {
        public CategoryAsyncRepository(ApplicationContext context) : base(context)
        {
        }

        public async Task<IReadOnlyCollection<Category>> GetAllCategoriesAsync(bool IncludePosts)
        {
            if (IncludePosts)
            {
                return  await _context.Categories.Include(m => m.Posts)
                    .AsNoTrackingWithIdentityResolution().ToListAsync();
            }
            else
            {
                return await _context.Categories.AsNoTracking().ToListAsync();
            }
        }

       public async Task<Category> GetCategoryByIdsAsync(Guid id, bool IncludePosts)
        {
            if (IncludePosts)
            {
                return await _context.Categories
                    .AsNoTracking()
                    .Include(m => m.Posts)
                    .FirstOrDefaultAsync(m => m.Id.Equals(id));
            }
            else
            {
                return await _context.Categories
                    .AsNoTracking()
                    .FirstOrDefaultAsync(m => m.Id.Equals(id));
            }
        }

       
    }
}
