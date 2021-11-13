using System.Threading.Tasks;
using Umschlag_Backend.Core;
using Umschlag_Backend.Core.Repositories;
using Umschlag_Backend.Core.Services;
using Umschlag_Backend.Core.UnitOfWork;

namespace Umschlag_Backend.Service.Services
{
    public class ProductService:Service<Product>, IProductService
    {
        public ProductService(IUnitOfWork unitOfWork, IRepository<Product> repository) : base(unitOfWork, repository)
        {
        }
        public async Task<Product> GetWithCategoryByIdAsync(int productId)
            => await _unitOfWork.Products.GetWithCategoryByIdAsync(productId);

    }
}
