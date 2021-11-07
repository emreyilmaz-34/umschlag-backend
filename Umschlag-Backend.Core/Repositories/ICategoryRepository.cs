using Umschlag_Backend.Core.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Umschlag_Backend.Core.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<Category> GetWithProductByIdAsync(int productId); // retunrn category with product
    }
}