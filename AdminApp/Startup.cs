using System;
using System.IO;
using ApiSer;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using ViewModels.System.Users;

namespace AdminApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/Login/Index";
                    options.AccessDeniedPath = "/User/Forbidden/";
                });

            services.AddControllersWithViews()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<LoginRequestValidator>());

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
            });

            //Declare DI

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddTransient<IUserApiClient, UserApiClient>();
            services.AddTransient<IMangaApiClient, MangaApiClient>();
            services.AddTransient<IRoleApiClient, RoleApiClient>();
            services.AddTransient<IOrderApiClient, OrderApiClient>();
            services.AddTransient<ITheloaiApiClient, TheloaiApiClient>();
            services.AddTransient<IMenuApiClient, MenuApiClient>();
            services.AddTransient<ITintucApiClient, TintucApiClient>();
            services.AddTransient<IBannerApiClient, BannerApiClient>();
            services.AddTransient<IKhuyenmaiApiClient, KhuyenmaiApiClient>();
            services.AddTransient<IStatisticApiClient, StatisticApiClient>();
            services.AddTransient<IPriceAndDestinationApiClient, PriceAndDestinationApiClient>();
            services.AddTransient<ILocalApiClient, LocalApiClient>();
            

            IMvcBuilder builder = services.AddRazorPages();
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

#if DEBUG
            if (environment == Environments.Development)
            {
                builder.AddRazorRuntimeCompilation();
            }
#endif
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            // For wwwroot directory
            app.UseStaticFiles();
            //// Add support for node_modules but only during development **temporary**
            //if (env.IsDevelopment())
            //{
            //    app.UseStaticFiles(new StaticFileOptions()
            //    {
            //        FileProvider = new PhysicalFileProvider(
            //          Path.Combine(Directory.GetCurrentDirectory(), @"node_modules")),
            //        RequestPath = new PathString("wwwroot/lib")
            //    });
            //}
            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();
            app.UseSession();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}