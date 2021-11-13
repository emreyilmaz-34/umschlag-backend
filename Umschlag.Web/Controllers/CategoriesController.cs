using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Umscghlag.Web.Filters;
using Umschlag.Web.DTOs;
using Umschlag_Backend.Core;
using Umschlag_Backend.Core.Services;

namespace Umschlag.Web.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
            => View(_mapper.Map<IEnumerable<CategoryDto>>(await _categoryService.GetAllAsync()));

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryDto categoryDto)
        {
            await _categoryService.AddAsync(_mapper.Map<Category>(categoryDto));
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
            => View(_mapper.Map<CategoryDto>(await _categoryService.GetByIdAsync(id)));

        [HttpPost]
        public IActionResult Update(CategoryDto categoryDto)
        {
            _categoryService.Update(_mapper.Map<Category>(categoryDto));
            return RedirectToAction("Index");
        }
        
        [ServiceFilter(typeof(NotFoundFilter))]
        public IActionResult Delete(int id)
        {
            _categoryService.Remove(_mapper.Map<Category>(_categoryService.GetByIdAsync(id).Result));
            return RedirectToAction("Index");
        }
    }
}
