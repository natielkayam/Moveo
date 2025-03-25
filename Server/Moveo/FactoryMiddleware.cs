
using System.Net;
using System.Text.Json;

namespace Moveo
{
    public class FactoryMiddleware
    {
        private readonly RequestDelegate _next;

        public FactoryMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                context.Response.ContentType = "application/json";

                var errorResponse = new
                {
                    IsSuccess = false,
                    Message = "An unexpected error occurred.",
                };

                var jsonResponse = JsonSerializer.Serialize(errorResponse);

                await context.Response.WriteAsync(jsonResponse);
            }
        }
    }
}
