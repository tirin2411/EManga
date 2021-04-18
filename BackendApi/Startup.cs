using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Catalog.Banners;
using Application.Catalog.Cart;
using Application.Catalog.Categorys;
using Application.Catalog.Khuyenmais;
using Application.Catalog.Mangas;
using Application.Catalog.Menus;
using Application.Catalog.Order;
using Application.Catalog.Tintuc;
using Application.Common;
using Application.Shipment;
using Application.System.Locals;
using Application.System.Roles;
using Application.System.Users;
using Application.System.Users.Address;
using Application.Utilities.Contacts;
using Application.WishLists;
using Data.EF;
using Data.Entities;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Utilities.Constants;
using ViewModels.System.Users;

namespace BackendApi
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
            services.AddTransient<IStorageService, FileStorageService>();

            services.AddTransient<IMangaService, MangaService>();
            services.AddTransient<UserManager<AppUser>, UserManager<AppUser>>();
            services.AddTransient<SignInManager<AppUser>, SignInManager<AppUser>>();
            services.AddTransient<RoleManager<AppRole>, RoleManager<AppRole>>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ITheloaiService, TheloaiService>();
            services.AddTransient<IMenuService, MenuService>();
            services.AddTransient<IWishListService, WishlistService>();
            services.AddTransient<IBannerService, BannerService>();
            services.AddTransient<IContactService, ContactService>();
            services.AddTransient<ITintucServer, TintucService>();
            services.AddTransient<IAddressService, AddressService>();
            services.AddTransient<ICartService, CartService>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IKhuyenmaiiService, KhuyenmaiiService>();
            services.AddTransient<ILocalService, LocalService>();
            services.AddTransient<ITableRateShippingService, TableRateShippingService>();

            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<IStatisticService, StatisticService>();

            //services.AddTransient<IValidator<LoginRequest>, LoginRequestValidator>();
            //services.AddTransient<IValidator<RegisterRequest>, RegisterRequestValidator>();

            services.AddControllers()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<LoginRequestValidator>());

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Swagger Ecommerce Solution", Version = "v1" });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                  {
                    {
                      new OpenApiSecurityScheme
                      {
                        Reference = new OpenApiReference
                          {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                          },
                          Scheme = "oauth2",
                          Name = "Bearer",
                          In = ParameterLocation.Header,
                        },
                        new List<string>()
                      }
                });
            });
            string issuer = Configuration.GetValue<string>("Tokens:Issuer");
            string signingKey = Configuration.GetValue<string>("Tokens:Key");
            byte[] signingKeyBytes = System.Text.Encoding.UTF8.GetBytes(signingKey);

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidIssuer = issuer,
                    ValidateAudience = true,
                    ValidAudience = issuer,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ClockSkew = System.TimeSpan.Zero,
                    IssuerSigningKey = new SymmetricSecurityKey(signingKeyBytes)
                };
            });
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

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger AAASolution V1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}