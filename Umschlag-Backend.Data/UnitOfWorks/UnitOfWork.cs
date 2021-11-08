using System.Threading.Tasks;
using Umschlag_Backend.Core.Repositories;
using Umschlag_Backend.Core.UnitOfWork;
using Umschlag_Backend.Data.Repositories;

namespace Umschlag_Backend.Data.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private ProductRepository _productRepository;
        private CategoryRepository _categoryRepository;

        public UnitOfWork(AppDbContext appDbContext)
            => _context = appDbContext;
        public IProductRepository Products => _productRepository = _productRepository ?? new ProductRepository(_context); 
        public ICategoryRepository Categories => _categoryRepository = _categoryRepository ?? new CategoryRepository(_context);
        public void Commit()
            => _context.SaveChanges();
        public async Task CommitAsync()
            => await _context.SaveChangesAsync();
    }
}