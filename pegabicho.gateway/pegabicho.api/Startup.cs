using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using pegabicho.api.Startups.Kernel;
using pegabicho.boostrap;

namespace pegabicho.api {
    public class Startup {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services) {
            // # DI
            Bootstrap.Configure(services, Configuration.GetConnectionString("DefaultConnection"));

            services.Configure<CookiePolicyOptions>(opt => {
                opt.CheckConsentNeeded = context => true;
                opt.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDistributedMemoryCache();
            services.AddCustomMvc();
            services.AddJWTService(Configuration);
            services.AddCustomSwagger();
            services.AddSignalR();
            services.AddLocalizations();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env) {


             app.UseApiUnitOfWork();
            //app.Use(async (context, next) => {
            //    await next.Invoke();
            //    var core = (IServiceBase)context.RequestServices.GetService(typeof(IServiceBase));
            //    await core.Commit();
            //});

            app.UserDevExceptionIfDebug(env);
            app.UseStaticFiles();
            app.MiddleException();
            app.UserCustomCors();
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseSwaggerDocs();
            app.UserNotifyHub();
            app.UseCookiePolicy();

            app.UseMvc();
        }
    }
}