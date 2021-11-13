using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Umschlag_Backend.API.DTOs;
using Umschlag_Backend.API.Filters;
using Umschlag_Backend.Core;
using Umschlag_Backend.Core.Services;

namespace Umschlag_Backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
            => Ok(_mapper.Map<IEnumerable<ProductDto>>(await _productService.GetAllAsync()));

        [ServiceFilter(typeof(NotFoundFilter))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
            => Ok(_mapper.Map<ProductDto>(await _productService.GetByIdAsync(id)));

        [HttpPost]
        public async Task<IActionResult> Save(ProductDto productDto)
            => Created(string.Empty, _mapper.Map<ProductDto>(await _productService.AddAsync(_mapper.Map<Product>(productDto))));

        [ServiceFilter(typeof(NotFoundFilter))]
        [HttpGet("{id}/category")]
        public async Task<IActionResult> GetWithCategoryByIdAsync(int id)
            => Ok(_mapper.Map<ProductWithCategoryDto>(await _productService.GetWithCategoryByIdAsync(id)));

        [HttpPut]
        public IActionResult Update(ProductDto productDto)
        {
            _productService.Update(_mapper.Map<Product>(productDto));
            return NoContent();
        }

        [ServiceFilter(typeof(NotFoundFilter))]
        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var product = _productService.GetByIdAsync(id).Result;
            _productService.Remove(product);
            return NoContent();
        }
    }
}
