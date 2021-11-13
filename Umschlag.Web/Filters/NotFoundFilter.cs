using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Threading.Tasks;
using Umschlag.Web.DTOs;
using Umschlag_Backend.Core.Services;

namespace Umscghlag.Web.Filters
{
    public class NotFoundFilter:ActionFilterAttribute
    {
        private readonly ICategoryService _categoryService;

        public NotFoundFilter(ICategoryService categoryService)
        {
            // if filter waiting for a DI you had to add as a service that filter (scoped) at Startup.cs
            _categoryService = categoryService;
        }

        public async override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            int id = (int)context.ActionArguments.Values.FirstOrDefault();

            var category = await _categoryService.GetByIdAsync(id);

            if (category != null)
                await next();

            else 
            { 
                ErrorDto errorDto = new();

                errorDto.Errors.Add($"The category with id {id} was not found in the database");
                context.Result = new RedirectToActionResult("Error", "Home", errorDto);
            }
        }
    }
}
