using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Umschlag_Backend.Core.Services
{
    public interface IProductService:IService<Product>
    {
        // i did the services interface  separately 
        // because i don't want to do anything other 
        // than database operations on the repository interfaces.
        // bool ControlInnerBarcode(int productId);
        Task<Product> GetWithCategoryByIdAsync(int productId); //  retunrn product with category

    }
}