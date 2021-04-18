using Data.EF;
using Data.Entities;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using Utilities.Constants;
using ViewModels.System.Users;
using WebApp.Controllers;
using ApiSer;
using Application.Catalog.Categorys;
using Application.Catalog.Mangas;
using Application.Catalog.Banners;
using Application.Common;
using Application.System.Users;
using Application.Catalog.Khuyenmais;
using Application.WishLists;
using Microsoft.AspNetCore.Http;
using Application.Cmt;

namespace WebApp
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
                    //setting the login path
                    options.LoginPath = "/Users/Login";
                    options.AccessDeniedPath = "/User/Forbidden/";
                });

            services.AddControllersWithViews()
               .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<LoginRequestValidator>());

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
            });

            services.AddDbContext<MnDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString(SystemConstants.MainConnectionString)));

            services.AddIdentity<AppUser, AppRole>(options =>
            {
                // Password settings.
                options.Password.RequiredLength = 6;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
            })
                .AddEntityFrameworkStores<MnDbContext>()
                .AddDefaultTokenProviders();

            //Declare DI

            //setting the login path
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddTransient<IStorageService, FileStorageService>();

            services.AddTransient<IMangaApiClient, MangaApiClient>();
            services.AddTransient<IMangaService, MangaService>();

            services.AddTransient<UserManager<AppUser>, UserManager<AppUser>>();
            services.AddTransient<SignInManager<AppUser>, SignInManager<AppUser>>();
            services.AddTransient<RoleManager<AppRole>, RoleManager<AppRole>>();
            services.AddTransient<IUserApiClient, UserApiClient>();
            services.AddTransient<OrdersController>();

            services.AddScoped<IUserApiClient, UserApiClient>();
            services.AddScoped<IUserService, UserService>();


            services.AddTransient<IUserApiClient, UserApiClient>();

            services.AddTransient<IBannerApiClient, BannerApiClient>();
            services.AddTransient<IBannerService, BannerService>();

            services.AddTransient<ITheloaiApiClient, TheloaiApiClient>();
            services.AddTransient<ITheloaiService, TheloaiService>();
            services.AddTransient<IKhuyenmaiiService, KhuyenmaiiService>();
            services.AddTransient<IKhuyenmaiApiClient, KhuyenmaiApiClient>();
            services.AddTransient<ITintucApiClient, TintucApiClient>();

            services.AddTransient<IWishListService, WishlistService>();
            services.AddTransient<IWishListApiClient, WishListApiClient>();
            services.AddTransient<ICommentService, CommentService>();
            services.AddTransient<ILocalApiClient, LocalApiClient>();
            services.AddTransient<IPriceAndDestinationApiClient, PriceAndDestinationApiClient>();
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
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();
            app.UseSession();

            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "Detail",
                    pattern: "truyen-tranh/{meta}-{mangaId}", new
                    {
                        controller = "Mangas",
                        action = "GetMangaId"
                    });

                endpoints.MapControllerRoute(
                        name: "tat-ca-san-pham",
                        pattern: "truyen-tranh/{controller=Mangas}/{action=GetAll}/{mangaId?}");

                endpoints.MapControllerRoute(
                    name: "tat-ca-san-pham-theo-the-loai",
                    pattern: "{meta}-{theloaiId}", new
                    {
                        controller = "Mangas",
                        action = "GetbycategoryId"
                    });
                endpoints.MapControllerRoute(
                   name: "dang-nhap",
                   pattern: "dang-nhap/{controller=Users}/{action=Login}");
                endpoints.MapControllerRoute(
                   name: "dang-ky",
                   pattern: "dang-ky/{controller=Users}/{action=Register}");
                endpoints.MapControllerRoute(
                    name: "Add Cart",
                    pattern: "them-vao-gio-hang/{controller=Cart}/{action=AddItem}/{magaId?}");
                endpoints.MapControllerRoute(
                    name: "dat-hang",
                    pattern: "dat-hang/{controller=Orders}/{action=Payment}/{magaId?}");
                endpoints.MapControllerRoute(
                    name: "gio-hang",
                    pattern: "gio-hang/{controller=Cart}/{action=Index}/{id?}");

            });
        }
    }
}