using Microsoft.AspNetCore.Http;
using pegabicho.domain.Interfaces.Services.Base;
using System.Threading.Tasks;

namespace pegabicho.api.Startups {

    public class ApiUnitOfWork {
        private readonly RequestDelegate _next;

        public ApiUnitOfWork(RequestDelegate next) {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext) {
            await _next(httpContext);
            var core = (IServiceBase)httpContext.RequestServices.GetService(typeof(IServiceBase));
            await core.Commit();
        }
    }
}
