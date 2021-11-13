﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Threading.Tasks;
using Umschlag.Web.ApiService;
using Umschlag.Web.DTOs;

namespace Umscghlag.Web.Filters
{
    public class NotFoundFilter:ActionFilterAttribute
    {
        private readonly CategoryApiService _categoryApiService;

        public NotFoundFilter(CategoryApiService categoryApiService)
        {
            _categoryApiService = categoryApiService;
        }

        public async override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            int id = (int)context.ActionArguments.Values.FirstOrDefault();

            var category = await _categoryApiService.GetByIdAsync(id);

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
