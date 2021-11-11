using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Umschlag_Backend.Core;
using Umschlag_Backend.Core.Repositories;

namespace Umschlag_Backend.Data.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private AppDbContext _appDbContext { get => _context as AppDbContext; }
        public ProductRepository(AppDbContext context) : base(context)
        {

        }
        public async Task<Product> GetWithCategoryByIdAsync(int productId)
            => await _appDbContext.Products.Include(x=> x.Category).SingleOrDefaultAsync(x=> x.Id == productId);
    }
}