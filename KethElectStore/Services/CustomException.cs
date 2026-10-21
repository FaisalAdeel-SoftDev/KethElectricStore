using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace KethElectStore.Services
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class CustomException
    {
        private readonly RequestDelegate _next;

        public CustomException(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try 
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
              httpContext.Response.Redirect("/Home/CustomError");
            }
            
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    //public static class CustomExceptionExtensions
    //{
    //    public static IApplicationBuilder UseCustomException(this IApplicationBuilder builder)
    //    {
    //        return builder.UseMiddleware<CustomException>();
    //    }
    //}
}
