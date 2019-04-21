﻿using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using pegabicho.api.Startups.Base;
using pegabicho.boostrap;
using pegabicho.domain.Interfaces.Services.Base;
using Swashbuckle.AspNetCore.Swagger;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

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

            services.AddCors();

            services.AddMvc(config => {
                // config.Filters.Add(typeof(CrossCutting.ApiFilter));
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
               .AddFluentValidation()
               .AddJsonOptions(options => {
                   options.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
                   options.SerializerSettings.DateFormatString = "yyyy-MM-ddTHH:mm:ssZ";
                   options.SerializerSettings.Formatting = Formatting.Indented;
                   options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                   options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
               });

            // # JWToken
            var key = Encoding.ASCII.GetBytes(Configuration["SecurityKey"]);
            services.AddAuthentication(x => {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(x => {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                    };
                });

            // # swagger documentation
            services.AddSwaggerGen(config => {
                config.SwaggerDoc("v1", new Info {
                    Title = "PegaBicho.Gateway",
                    Version = "v1",
                    Contact = new Contact {
                        Name = "Lucas Rocha de Moraes",
                        Email = "lucas.moraes.dev@gmail.com",
                        Url = "http://www.datasuricata.com.br"
                    }
                });

                config.AddSecurityDefinition("Bearer", new ApiKeyScheme {
                    In = "header",
                    Description = "Please enter into field with: Bearer [Token]",
                    Name = "Authorization",
                    Type = "apiKey"
                });

                config.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>>
                {
                    {"Bearer", Enumerable.Empty<string>()},
                });
            });

            // # cultures {UseLocalizations}
            services.Configure<RequestLocalizationOptions>(
                options => {
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
        public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
            // todo pass to middleware extension class
            app.Use(async (context, next) => {
                await next.Invoke();
                var core = (IServiceBase)context.RequestServices.GetService(typeof(IServiceBase));
                await core.Commit();
            });

            #region [ enable log ]

            //loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            //loggerFactory.AddDebug();

            #endregion

            #region [ enviroment ]

            var index = new DefaultFilesOptions { DefaultFileNames = new List<string> { "index.html" } };

            if (env.IsDevelopment()) {
                app.UseHsts();
                app.UseDefaultFiles(index);
            } else {
                app.UseDeveloperExceptionPage();
                app.UseDefaultFiles(index);
            }

            #endregion

            app.MiddleException();
            app.UseStaticFiles();

            app.UseCors(server => server.AllowAnyOrigin()
                .AllowAnyMethod()
                    .AllowAnyHeader()
                        .AllowCredentials());

            app.UseHttpsRedirection();
            app.UseAuthentication();

            app.UseMvc(routes => {
                routes.MapRoute(name: "default", template: "api/{controller}/{action}/{id?}");
            });

            app.UseSwagger();
            app.UseSwaggerUI(config => {
                config.SwaggerEndpoint("/swagger/v1/swagger.json", "APIWinde.Build V1");
            });

            app.UseCookiePolicy();

            //app.Run(async (context) => {
            //    await context.Response.WriteAsync($"Ops! MVC didn't find anything!");
            //});
        }
    }
}