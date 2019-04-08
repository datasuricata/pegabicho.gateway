﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using pegabicho.api.Startups.Base;
using System.Collections.Generic;
using System.Globalization;

namespace pegabicho.api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // # DI
            //Bootstrap.Configure(services, Configuration.GetConnectionString("DefaultConnection"));

            services.Configure<CookiePolicyOptions>(opt =>
            {
                opt.CheckConsentNeeded = context => true;
                opt.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDistributedMemoryCache();

            services.AddCors();

            services.AddMvc(config =>
            {
                // config.Filters.Add(typeof(CrossCutting.ApiFilter));
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
               //.AddFluentValidation()
               .AddJsonOptions(options =>
               {
                   options.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
                   options.SerializerSettings.DateFormatString = "yyyy-MM-ddTHH:mm:ssZ";
                   options.SerializerSettings.Formatting = Formatting.Indented;
                   options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    //options.SerializerSettings.ContractResolver = new DefaultContractResolver { NamingStrategy = new LowerCaseNamingStrategy() };
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
               });

            // # Jason Web Token
            //var key = Encoding.ASCII.GetBytes(Configuration["SecurityKey"]);
            //services.AddAuthentication(x =>
            //{
            //    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //})
            //    .AddJwtBearer(x =>
            //    {
            //        x.RequireHttpsMetadata = false;
            //        x.SaveToken = true;
            //        x.TokenValidationParameters = new TokenValidationParameters
            //        {
            //            ValidateIssuerSigningKey = true,
            //            IssuerSigningKey = new SymmetricSecurityKey(key),
            //            ValidateIssuer = false,
            //            ValidateAudience = false,
            //        };
            //    });

            // # auto mapper by assembly
            //services.AddAutoMapper(Assembly.GetAssembly(typeof(MapperBase)));


            // # swagger documentation
            //services.AddSwaggerGen(config =>
            //{
            //    config.SwaggerDoc("v1", new Info
            //    {
            //        Title = "PegaBicho.Gateway",
            //        Version = "v1",
            //        Contact = new Contact
            //        {
            //            Name = "Lucas R. Moraes",
            //            Email = "lucas.moraes.dev@gmail.com",
            //            Url = "http://www.datasuricata.com.br"
            //        }
            //    });

            //    config.AddSecurityDefinition("Bearer", new ApiKeyScheme
            //    {
            //        In = "header",
            //        Description = "Please enter into field with: Bearer [Token]",
            //        Name = "Authorization",
            //        Type = "apiKey"
            //    });

            //    config.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>>
            //    {
            //        {"Bearer", Enumerable.Empty<string>()},
            //    });
            //});

            // # signalr
            //services.AddSignalR(hubOptions =>
            //{
            //    hubOptions.EnableDetailedErrors = true;
            //    hubOptions.KeepAliveInterval = TimeSpan.FromMinutes(1);
            //})
            //.AddJsonProtocol(hubOptions =>
            //{
            //    hubOptions.PayloadSerializerSettings.ContractResolver = new DefaultContractResolver();
            //});

            // # hangfire
            //services.AddHangfire(Configuration);

            // # cultures {UseLocalizations}
            services.Configure<RequestLocalizationOptions>(
                options =>
                {
                    var supportedCultures = new List<CultureInfo>
                    {
                        new CultureInfo("pt-BR"),
                        new CultureInfo("en-US"),
                    };

                    options.DefaultRequestCulture = new RequestCulture(culture: "pt-BR", uiCulture: "pt-BR");
                    options.SupportedCultures = supportedCultures;
                    options.SupportedUICultures = supportedCultures;

                    options.RequestCultureProviders.Insert(0, new AcceptLanguageHeaderRequestCultureProvider());
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //// # uow
            //app.Use(async (context, next) =>
            //{
            //    // # request
            //    await next.Invoke();
            //    // # response
            //    var BaseService = (IServiceBase)context.RequestServices.GetService(typeof(IServiceBase));
            //    await BaseService.CommitAsync();
            //});

            #region [ enable log ]

            //loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            //loggerFactory.AddDebug();

            #endregion

            #region [ enviroment ]

            if (env.IsDevelopment())
            {
                app.UseHsts();
                app.UseDefaultFiles(new DefaultFilesOptions { DefaultFileNames = new List<string> { "dev.html" } });
            }
            else if (env.IsStaging())
            {
                app.UseHsts();
                app.UseDefaultFiles(new DefaultFilesOptions { DefaultFileNames = new List<string> { "stag.html" } });
            }
            else if (env.IsProduction())
            {
                app.UseHsts();
                app.UseDefaultFiles(new DefaultFilesOptions { DefaultFileNames = new List<string> { "prod.html" } });
            }
            else
            {
                app.UseDeveloperExceptionPage();
                app.UseDefaultFiles(new DefaultFilesOptions { DefaultFileNames = new List<string> { "local.html" } });
            }

            #endregion

            app.ConfigureExceptionApi();
            app.UseStaticFiles();

            // # use cors {default}
            app.UseCors(server => server
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());
            //app.UseCors("CorsPolicy");

            // localization (aprendendo a utilizar isso aqui)
            //var localization = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            //app.UseRequestLocalization(localization.Value);

            // # https
            app.UseHttpsRedirection();

            // # auth
            app.UseAuthentication();
            

            // # compression gzip
            //app.UseResponseCompression();

            // # signalr
            //app.Map("/signalr", map =>
            //{
            //    map.UseCors("CorsPolicy");
            //    map.UseSignalR(routes => routes.MapHub<NotificationHub>("/notificationHub"));
            //});

            // # sinalr
            //app.UseSignalR(routes =>
            //{
            //    routes.MapHub<NotificationHub>("/notificationHub");
            //});

            // # mvc
            app.UseMvc(routes => { routes.MapRoute(name: "default", template: "api/{controller}/{action}/{id?}"); });

            // # swagger
            //app.UseSwagger();
            //app.UseSwaggerUI(config => { config.SwaggerEndpoint("/swagger/v1/swagger.json", "APIWinde.Build V1"); });

            // # hangfire
            //app.UseHangfire(Configuration, serviceProvider);

            app.UseCookiePolicy();

            // # background jobs
            //app.UseBackgroundJobs(Configuration, serviceProvider);

            app.Run(async (context) => { await context.Response.WriteAsync($"Ops! MVC didn't find anything!"); });
        }
    }
}
