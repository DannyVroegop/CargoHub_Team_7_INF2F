using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;

namespace Filters
{
    public class APIkeyfilter : Attribute, IAsyncActionFilter{
        public async Task OnActionExecutionAsync(ActionExecutingContext actioncontext, ActionExecutionDelegate next)
        {
            var context = actioncontext.HttpContext;
            var ApiTokens = context.RequestServices.GetService<IOptions<ApiOption>>()?.Value.ApiToken;

            if (!context.Request.Headers.ContainsKey("API_KEY"))
            {
                context.Response.StatusCode = 401;
                return;
            }
            
        }
    }
}