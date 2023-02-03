using IT_Community.Server.Infrastructure.Exceptions;
using System.Net;
using System.Text.Json;

namespace IT_Community.Server
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (HttpException ex)
            {
                await HandleExceptionAsync(httpContext, ex.Message, ex.StatusCode);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex.Message);
            }
        }

        private async Task HandleExceptionAsync(
            HttpContext context,
            string errorMessage = "Internal Server Error",
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            await context.Response.WriteAsync(JsonSerializer.Serialize(new
            {
                StatusCode = statusCode,
                ErrorMessage = errorMessage
            }));
        }
    }
}
