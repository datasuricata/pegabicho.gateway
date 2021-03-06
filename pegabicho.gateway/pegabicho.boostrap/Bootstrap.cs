﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using pegabicho.domain.Interfaces.Repositories.Base;
using pegabicho.domain.Interfaces.Services.Base;
using pegabicho.domain.Interfaces.Services.Core;
using pegabicho.domain.Interfaces.Services.Events;
using pegabicho.infra.ORM;
using pegabicho.infra.Persistence.Repositories.Base;
using pegabicho.infra.Transaction;
using pegabicho.service.Events;
using pegabicho.service.Services.Base;
using pegabicho.service.Services.Core;

namespace pegabicho.boostrap
{
    public static class Bootstrap
    {
        public static void Configure(IServiceCollection services, string conn)
        {
            #region [ context ]

            // # db context strongly typed
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(conn));

            #endregion

            #region [ kernel ]

            // # unit of work (context)
            /// <summary>
            /// use this to interact with db transactions
            /// </summary>
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
            // # service base {events}
            /// <summary>
            /// use this to inject base events into internal service
            /// </summary>
            services.AddScoped(typeof(IServiceBase), typeof(ServiceBase));
            // # repository base {entities}
            /// <summary>
            /// use this manipule internal entities from db source
            /// </summary>
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            // # events base {notifications}
            /// <summary>
            /// use this to inject message notifications into internal services application
            /// </summary>
            services.AddScoped(typeof(IEventNotifier), typeof(EventNotifier));
            // # service base {application}
            /// <summary>
            /// use this to inject db context for internal services applications
            /// </summary>
            services.AddScoped(typeof(IServiceApp<>), typeof(ServiceApp<>));

            #endregion

            #region [ core ]

            // # services contract with base {internal events} services
            services.AddScoped(typeof(IServicePet), typeof(ServicePet));
            services.AddScoped(typeof(IServiceUser), typeof(ServiceUser));
            services.AddScoped(typeof(IServiceOrder), typeof(ServiceOrder));
            services.AddScoped(typeof(IServiceTravel), typeof(ServiceTravel));
            services.AddScoped(typeof(IServiceSurvey), typeof(ServiceSurvey));

            #endregion
        }
    }
}
