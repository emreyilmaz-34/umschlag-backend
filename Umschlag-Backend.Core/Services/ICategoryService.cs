using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Umschlag_Backend.Core.Services
{
    public interface ICategoryService:IService<Category>
    {
        Task<Category> GetWithProductByIdAsync(int productId); // retunrn category with product
        
    }
}