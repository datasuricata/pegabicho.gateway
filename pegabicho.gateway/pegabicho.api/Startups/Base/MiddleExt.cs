using Microsoft.AspNetCore.Builder;

namespace pegabicho.api.Startups.Base
{
    public static class MiddleExt
    {
        public static IApplicationBuilder MiddleException(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ApiException>();
        }
    }
}
