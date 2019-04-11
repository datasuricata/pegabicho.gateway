using Microsoft.AspNetCore.Builder;
using pegabicho.api.Kernel.Middlewares;
 
namespace pegabicho.api.Kernel.Handlers
{
    public static class MiddleHandlers
    {
        public static IApplicationBuilder ConfigureExceptionApi(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ApiException>();
        }
    }
}
