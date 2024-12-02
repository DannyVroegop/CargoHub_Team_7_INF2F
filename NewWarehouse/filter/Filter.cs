// using Microsoft.AspNetCore.Mvc.Filters;
// using Microsoft.Extensions.Options;

// namespace Filters
// {
//     public class APIkeyfilter : Attribute, IAsyncActionFilter{
//         public async Task OnActionExecutionAsync(ActionExecutingContext actioncontext, ActionExecutionDelegate next)
//         {
//             var context = actioncontext.HttpContext;
//             Console.WriteLine("TEST");
//             var ApiTokens = context.RequestServices.GetService<IOptions<ApiOption>>()?.Value.ApiToken;

//             if (!context.Request.Headers.ContainsKey("API_KEY"))
//             {
//                 context.Response.StatusCode = 401;
//                 return;
//             }
//             bool found = false;
//             foreach (var token in ApiTokens){
//                 if (ApiTokens == context.Request.Headers["API_KEY"])
//                 {
//                     found = true;
//                 }
//             }
//             if (!found){ context.Response.StatusCode = 401; return; }
//             await next();
//         }
//     }

    public class ApiOption{
        public string User1 { get; set;}=null!;
    }
