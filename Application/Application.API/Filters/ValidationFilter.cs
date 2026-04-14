using Application.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Application.API.Filters
{
    public class ValidationFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState
                    .Where(x => x.Value.Errors.Count > 0)
                    .Select(x => new
                    {
                        Field = x.Key,
                        Errors = x.Value.Errors.Select(e => e.ErrorMessage)
                    });

                context.Result = new BadRequestObjectResult(new ApiResponse<object>
                {
                    Success = false,
                    Message = "Validation failed",
                    Errors = errors
                });
            }
        }

        public void OnActionExecuted(ActionExecutedContext context) { }
    }
}
