using System.Net;

namespace InsuranceProcess.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            // Log the exception details here using your logging framework

            // Return a generic error message or detailed one based on the environment
            var result = System.Text.Json.JsonSerializer.Serialize(new { error = "An unexpected error has occurred." });
            return context.Response.WriteAsync(result);
        }
    }

}
