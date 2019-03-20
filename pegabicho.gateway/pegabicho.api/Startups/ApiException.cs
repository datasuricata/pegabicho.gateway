using begabicho.shared.Notifications;
using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Threading.Tasks;

namespace pegabicho.api.Startups
{
    public class ApiException
    {
        private readonly RequestDelegate _next;

        public ApiException(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                // #invoke next
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            string ex = exception.InnerException?.InnerException == null ? exception.Message
                : exception.InnerException.InnerException.Message;

            ex += exception.InnerException == null ? ""
                : Environment.NewLine + "Inner Exception: " + Environment.NewLine + exception.InnerException.Message;

            string[] lines;

            if (ex.Contains(Environment.NewLine))
                lines = ex.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            else
                lines = new string[] { ex };

            return context.Response.WriteAsync(new Notification()
            {
                StatusCode = context.Response.StatusCode,
                Value = "Ops! Algo deu errado.",
                Key = "ApiException",
                Exception = lines,
                Call = new string[] {
                    $"Endpoint: {context.Request.Path.ToUriComponent()}",
                    $"StackTrace: {exception.InnerException.StackTrace}"
                },
            }.ToString());
        }
    }
}
