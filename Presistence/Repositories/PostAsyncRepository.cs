using Application.Contract;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presistence.Repositories
{
    public class PostAsyncRepository : BaseAsyncRepository<Post>, IPostAsyncRepository
    {
        public PostAsyncRepository(ApplicationContext context):base(context) 
        {
        }
        public async Task<IReadOnlyList<Post>> GetAllPostsAsync(bool IncludeCategory)
        {
            if (IncludeCategory)
            {
                return await _context.Posts.Include(m => m.Category).ToListAsync();    
            }
            return await _context.Posts.ToListAsync();
        }

        public async Task<Post> GetPostByIdAsync(Guid id, bool IncludeCategory)
        {
            if (IncludeCategory) 
            {
                return await _context.Posts.Include(m => m.Category).FirstOrDefaultAsync(m => m.Id.Equals(id));
            }
            return await _context.Posts.FirstOrDefaultAsync(m => m.Id.Equals(id));
        }
    }
}
