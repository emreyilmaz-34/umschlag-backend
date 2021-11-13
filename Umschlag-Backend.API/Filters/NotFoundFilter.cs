using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Umschlag_Backend.Core.Services;
using Umschlag_Backend.Exception.DTOs;

namespace Umschlag_Backend.API.Filters
{
    public class NotFoundFilter:ActionFilterAttribute
    {
        private readonly IProductService _productService;

        public NotFoundFilter(IProductService productService)
        {
            // if filter waiting for a DI you had to add as a service that filter (scoped) at Startup.cs
            _productService = productService;
        }

        public async override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            int id = (int)context.ActionArguments.Values.FirstOrDefault();

            var product = await _productService.GetByIdAsync(id);

            if (product != null)
                await next();

            else 
            { 
                ErrorDto errorDto = new();
                errorDto.Status = 404;

                errorDto.Errors.Add($"The product with id {id} was not found in the database");
                context.Result = new NotFoundObjectResult(errorDto);
            }
        }
    }
}
