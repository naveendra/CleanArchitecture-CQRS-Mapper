using Application.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Application.API.Filters
{
    public class ApiResponseFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Result is ObjectResult result)
            {
                var response = new ApiResponse<object>
                {
                    Success = true,
                    Data = result.Value
                };

                context.Result = new ObjectResult(response)
                {
                    StatusCode = result.StatusCode
                };
            }
        }

        public void OnActionExecuting(ActionExecutingContext context) { }
    }
}
