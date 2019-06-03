using Microsoft.AspNetCore.Builder;

namespace pegabicho.api.Startups.Kernel {
    public static class MiddleConfig {
        public static IApplicationBuilder MiddleException(this IApplicationBuilder builder) {
            return builder.UseMiddleware<ApiException>();
        }

        public static IApplicationBuilder UseApiUnitOfWork(this IApplicationBuilder builder) {
            return builder.UseMiddleware<ApiUnitOfWork>();
        }
    }
}
