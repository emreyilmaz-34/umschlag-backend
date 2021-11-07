using Umschlag_Backend.Core.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Umschlag_Backend.Core.Repositories
{
    interface IProductRepository : IRepository<Product>
    {
        Task<Product> GetWithCategoryByIdAsync(int productId); //  retunrn product with category
    }
}