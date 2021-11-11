using System.Threading.Tasks;
using Umschlag_Backend.Core;
using Umschlag_Backend.Core.Repositories;
using Umschlag_Backend.Core.Services;
using Umschlag_Backend.Core.UnitOfWork;

namespace Umschlag_Backend.Service.Services
{
    public class CategoryService : Service<Category>, ICategoryService
    {
        public CategoryService(IUnitOfWork unitOfWork, IRepository<Category> repository) : base(unitOfWork, repository)
        {
        }
        public async Task<Category> GetWithProductByIdAsync(int categoryId)
            => await _unitOfWork.Categories.GetWithProductByIdAsync(categoryId);
    }
}
