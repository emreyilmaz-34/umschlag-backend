using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Umschlag_Backend.Core;
using Umschlag_Backend.Core.Repositories;

namespace Umschlag_Backend.Data.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private AppDbContext _appDbContext { get => _context as AppDbContext; }
        public CategoryRepository(AppDbContext context) : base(context)
        {

        }
        public async Task<Category> GetWithProductByIdAsync(int categoryId)
            => await _appDbContext.Categories.Include(x=> x.Products).SingleOrDefaultAsync(x=> x.Id == categoryId);
    }
}