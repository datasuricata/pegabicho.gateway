using Microsoft.Extensions.DependencyInjection;

namespace pegabicho.boostrap
{
    public static class Bootstrap
    {
        //public static void Configure(IServiceCollection services, string conn)
        //{
        //    //#region [ context ]

        //    //// # db context strongly typed
        //    //services.AddDbContext<WindeDataContext>(options => options.UseSqlServer(connection));

        //    //#endregion

        //    //#region [ identity ]

        //    ////// # identity aplication user

        //    ////            services.AddIdentity<ApplicationUser, IdentityRole>(config =>
        //    ////                {
        //    ////                    // Password settings
        //    ////                    config.Password.RequireDigit = false;
        //    ////                    config.Password.RequiredLength = 6;
        //    ////                    config.Password.RequireLowercase = false;
        //    ////                    config.Password.RequireNonAlphanumeric = false;
        //    ////                    config.Password.RequireUppercase = false;
        //    ////
        //    ////                    // Lockout settings
        //    ////                    config.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
        //    ////                    config.Lockout.MaxFailedAccessAttempts = 10;
        //    ////                    config.Lockout.AllowedForNewUsers = true;
        //    ////
        //    ////                    // User settings
        //    ////                    config.User.RequireUniqueEmail = true;
        //    ////                }).AddEntityFrameworkStores<AppDbContext>()
        //    ////                .AddDefaultTokenProviders();

        //    ////// # cookies

        //    ////            services.ConfigureApplicationCookie(config =>
        //    ////            {
        //    ////                // Cookie settings
        //    ////                config.Cookie.HttpOnly = true;
        //    ////                config.ExpireTimeSpan = TimeSpan.FromMinutes(30);
        //    ////                // If the LoginPath isn't set, ASP.NET Core defaults 
        //    ////                // the path to /Account/Login.
        //    ////                config.LoginPath = "/Account/Login";
        //    ////                // If the AccessDeniedPath isn't set, ASP.NET Core defaults 
        //    ////                // the path to /Account/AccessDenied.
        //    ////                config.AccessDeniedPath = "/Account/AccessDenied";
        //    ////                config.SlidingExpiration = true;
        //    ////            });

        //    ////// # service identity

        //    ////services.AddScoped(typeof(IAuthentication), typeof(Authentication));
        //    ////services.AddScoped(typeof(IManager), typeof(Manager));

        //    //#endregion

        //    //#region [ kernel ]

        //    //// # unit of work (context)
        //    ///// <summary>
        //    ///// use this to interact with db transactions
        //    ///// </summary>
        //    //services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
        //    //// # service base {events}
        //    ///// <summary>
        //    ///// use this to inject base events into internal service
        //    ///// </summary>
        //    //services.AddScoped(typeof(IServiceBase), typeof(ServiceBase));
        //    //// # repository base {entities}
        //    ///// <summary>
        //    ///// use this manipule internal entities from db source
        //    ///// </summary>
        //    //services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        //    //// # events base {notifications}
        //    ///// <summary>
        //    ///// use this to inject message notifications into internal services application
        //    ///// </summary>
        //    //services.AddScoped(typeof(IEventNotification), typeof(EventNotification));
        //    //// # service base {application}
        //    ///// <summary>
        //    ///// use this to inject db context for internal services applications
        //    ///// </summary>
        //    //services.AddScoped(typeof(IServiceApplication<>), typeof(ServiceApplication<>));

        //    //#endregion

        //    //#region [ core ]

        //    //// # service integration {external application}
        //    ///// <summary>
        //    ///// use this to integrate external services for life cicle application
        //    ///// </summary>
        //    //services.AddScoped(typeof(IServiceIntegration), typeof(ServiceIntegration));

        //    //// # services contract with base {internal events} services
        //    ///// <summary>
        //    ///// use this area to register current internal services events for applications
        //    ///// </summary>
        //    //services.AddScoped(typeof(IServiceReport), typeof(ServiceReport));
        //    //services.AddScoped(typeof(IServiceLocation), typeof(ServiceLocation));
        //    //services.AddScoped(typeof(IServiceConfiguration), typeof(ServiceConfiguration));

        //    //#endregion

        //    //#region [ signalr ]


        //    //#endregion

        //    //#region [ app ]

        //    //// # services contract with base {internal application} services 
        //    ///// <summary>
        //    ///// use this area to register current internal services applications
        //    ///// </summary>
        //    //services.AddScoped(typeof(IUserApplicationService), typeof(UserApplicationService));
        //    //services.AddScoped(typeof(ITicketApplicationService), typeof(TicketApplicationService));
        //    //services.AddScoped(typeof(IWalletApplicationService), typeof(WalletApplicationService));
        //    //services.AddScoped(typeof(IVehicleApplicationService), typeof(VehicleApplicationService));
        //    //services.AddScoped(typeof(IDocumentApplicationService), typeof(DocumentApplicationService));
        //    //services.AddScoped(typeof(ICalcApplicationService), typeof(CalcApplicationService));
        //    //services.AddScoped(typeof(ISurveyApplicationService), typeof(SurveyApplicationService));

        //    //#endregion

        //    //#region [ controller ]

        //    //// # controllers as services
        //    ////services.AddScoped(typeof(ApiFilter));

        //    //#endregion
        //}
    }
}
