using System.Net;
using System.Text.Json;

namespace ProductAPI.API.Middlewares
{
    public class GlobalExceptionMiddleware(RequestDelegate next)
    {
        private readonly RequestDelegate _next = next;

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";
                var errorResponse = new
                {
                    message = "An unexpected error occurred.",
                    detail = ex.Message,
                    exceptionType = ex.GetType().FullName,
                    stackTrace = ex.StackTrace,
                    innerException = ex.InnerException?.ToString(),
                };
                await context.Response.WriteAsync(JsonSerializer.Serialize(errorResponse));
            }
        }
    }
}
