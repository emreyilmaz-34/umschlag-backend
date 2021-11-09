using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Umschlag_Backend.Core;
using Umschlag_Backend.Core.Services;
using Umschlag_Backend.Core.UnitOfWork;

namespace Umschlag_Backend.Service.Services
{
    class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductService(IUnitOfWork unitOfWork)
            => _unitOfWork = unitOfWork;

        public async Task<Product> AddAsync(Product entity)
        {
            await _unitOfWork.Products.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            return entity;
        }
        public async Task<IEnumerable<Product>> AddRangeAsync(IEnumerable<Product> entities)
        {
            await _unitOfWork.Products.AddRangeAsync(entities);
            await _unitOfWork.CommitAsync();
            return entities;
        }
        public async Task<IEnumerable<Product>> Where(Expression<Func<Product, bool>> predicate)
            => await _unitOfWork.Products.Where(predicate);
        public async Task<IEnumerable<Product>> GetAllAsync()
            => await _unitOfWork.Products.GetAllAsync();
        public async Task<Product> GetByIdAsync(int productId)
            => await _unitOfWork.Products.GetByIdAsync(productId);
        public async Task<Product> GetWithCategoryByIdAsync(int productId)
            => await _unitOfWork.Products.GetWithCategoryByIdAsync(productId);
        public void Remove(Product entity)
        {
            _unitOfWork.Products.Remove(entity);
            _unitOfWork.Commit();
        }
        public void RemoveRange(IEnumerable<Product> entities)
        {
            _unitOfWork.Products.RemoveRange(entities);
            _unitOfWork.Commit();
        }
        public async Task<Product> SingleOrDefaultAsync(Expression<Func<Product, bool>> predicate)
            => await _unitOfWork.Products.SingleOrDefaultAsync(predicate);
        public Product Update(Product entity)
        {
            var updateProduct = _unitOfWork.Products.Update(entity);
            _unitOfWork.Commit();
            return updateProduct;
        }
    }
}
