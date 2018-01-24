﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.AspNetCore.Mvc;
using Titanbot.Web.LoginManagers;
using Titanbot.Web._HardcodedValues;

namespace Titanbot.Web
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            if (env.IsDevelopment())
            {
                builder.AddUserSecrets<Startup>();
            }

            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();

            // Add dependency injection
            services.AddSingleton(new HardcodedCommands());

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddTransient<CookieSignInManager>();
            services.AddTransient<CookieUserManager>();

            // Requies all requests to be HTTPS, and ignores HTTP
            //services.Configure<MvcOptions>(options =>
            //{
            //    options.Filters.Add(new RequireHttpsAttribute());
            //});

            // External login provider
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddDiscord(o => 
                {
                    o.AppId = Configuration["Authentication:Discord:AppId"];
                    o.AppSecret = Configuration["Authentication:Discord:AppSecret"];
                    
                    o.Scope.Add("guilds");
                });

            // Configure the login cookie
            //services.ConfigureApplicationCookie(o =>
            //{
            //    o.ExpireTimeSpan = TimeSpan.FromMinutes(5);
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            // Redirect all Http requests to Https
            app.UseRewriter(new RewriteOptions()
                .Add(context =>
                {
                    context.Logger.LogInformation("-----Heroku logging test-----");
                    context.Logger.LogInformation($"Http method: {context.HttpContext.Request.Method}");
                    context.Logger.LogInformation($"Http path: {context.HttpContext.Request.Path}");
                    context.Logger.LogInformation($"Http pathbase: {context.HttpContext.Request.PathBase}");
                    context.Logger.LogInformation($"Http isHttps: {context.HttpContext.Request.IsHttps}");
                    context.Logger.LogInformation($"Http headers count: {context.HttpContext.Request.Headers.Count}");
                    foreach (var header in context.HttpContext.Request.Headers)
                    {
                        context.Logger.LogInformation($"--- {header.Key} : {header.Value}");
                    }
                }));

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Shared/Error");
            }
            
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvcWithDefaultRoute();
        }
    }
}
