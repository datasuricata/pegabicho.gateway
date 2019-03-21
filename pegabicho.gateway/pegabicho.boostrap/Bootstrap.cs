using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace pegabicho.boostrap
{
    public static class Bootstrap
    {
        public static void Configure(IServiceCollection services, string conn)
        {
            services.AddDbContext<AppDbContext>(options => options.UseMySql(conn,
                builder => builder.MigrationsAssembly("pegabicho.gateway")));

            //services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));

            //// # repository base {entities}
            ///// <summary>
            ///// use this manipule internal entities from db source
            ///// </summary>
            //services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            //services.AddScoped(typeof(IFormManager), typeof(FormManager));

            //// # render view service
            //services.AddScoped(typeof(IViewRender), typeof(ViewRender));
        }
    }
}
