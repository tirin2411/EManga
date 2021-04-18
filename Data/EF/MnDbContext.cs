using Data.Configurations;
using Data.Entities;
using Data.Extensions;
using Data.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.EF
{
    public class MnDbContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public MnDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configure using Fluent API
            modelBuilder.ApplyConfiguration(new AppConfigConfiguration());
            modelBuilder.ApplyConfiguration(new MangaConfiguration());
            modelBuilder.ApplyConfiguration(new TheloaiConfiguration());
            modelBuilder.ApplyConfiguration(new MnTheloaiConfiguration());
            modelBuilder.ApplyConfiguration(new BannerConfiguration());
            modelBuilder.ApplyConfiguration(new BlogConfiguration());
            modelBuilder.ApplyConfiguration(new CreditCardConfiguration());
            modelBuilder.ApplyConfiguration(new HoaDonConfiguration());
            modelBuilder.ApplyConfiguration(new HoaDonHistoryConfiguration());
            modelBuilder.ApplyConfiguration(new InforSellConfiguration());
            modelBuilder.ApplyConfiguration(new DiaChiConfiguration());
            modelBuilder.ApplyConfiguration(new DonHangConfiguration());
            modelBuilder.ApplyConfiguration(new DonHangDetailConfiguration());
            //modelBuilder.ApplyConfiguration(new DonHangHistoryConfiguration());
            modelBuilder.ApplyConfiguration(new GioHangConfiguration());
            modelBuilder.ApplyConfiguration(new GioHangDetailConfiguration());
            modelBuilder.ApplyConfiguration(new LienHeConfiguration());
            modelBuilder.ApplyConfiguration(new MangaDetailConfiguration());
            modelBuilder.ApplyConfiguration(new MangaImageConfiguration());
            modelBuilder.ApplyConfiguration(new MCommentConfiguration());
            modelBuilder.ApplyConfiguration(new MenuConfiguration());
            modelBuilder.ApplyConfiguration(new MenuItemConfiguration());

            modelBuilder.ApplyConfiguration(new ShipmentConfiguration());
            modelBuilder.ApplyConfiguration(new ShipmentItemConfiguration());
            modelBuilder.ApplyConfiguration(new ShippingProviderConfiguration());
            modelBuilder.ApplyConfiguration(new ShippingTableRateConfiguration());

            modelBuilder.ApplyConfiguration(new ProvinceConfiguration());
            modelBuilder.ApplyConfiguration(new DistrictConfiguration());
            modelBuilder.ApplyConfiguration(new WardConfiguration());


            modelBuilder.ApplyConfiguration(new SoluottruycapConfiguration());
            modelBuilder.ApplyConfiguration(new TacGiaConfiguration());
            modelBuilder.ApplyConfiguration(new PaymentConfiguration());
            modelBuilder.ApplyConfiguration(new TinTucConfiguration());
            modelBuilder.ApplyConfiguration(new GiaodichConfiguration());
            modelBuilder.ApplyConfiguration(new KhuyenmaiConfiguration());
            modelBuilder.ApplyConfiguration(new KhuyenmaiMangaConfiguration());
            modelBuilder.ApplyConfiguration(new KhuyenmaiTheloaiConfiguration());
            modelBuilder.ApplyConfiguration(new KhuyenmaiLichsuSudungConfiguration());
            modelBuilder.ApplyConfiguration(new WishListConfiguration());
            modelBuilder.ApplyConfiguration(new WishListItemConfiguration());

            modelBuilder.ApplyConfiguration(new NgonnguMnConfiguration());

            modelBuilder.ApplyConfiguration(new AppUserConfiguration());
            modelBuilder.ApplyConfiguration(new AppRoleConfiguration());

            modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("AppUserClaims");
            modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("AppUserRoles").HasKey(x => new { x.UserId, x.RoleId });
            modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("AppUserLogins").HasKey(x => x.UserId);
            modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("AppRoleClaims");
            modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("AppUserTokens").HasKey(x => x.UserId);

            modelBuilder.ApplyConfiguration(new RevenueStatisticVMConfiguration());

            //data seeding
            modelBuilder.Seed();
            //base.OnModelCreating(modelBuilder);
        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Manga> Mangas { get; set; }
        public DbSet<AppConfig> AppConfigs { get; set; }
        public DbSet<Theloai> Theloais { get; set; }
        public DbSet<InforSell> InforSells { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<CreditCard> CreditCards { get; set; }
        public DbSet<DiaChi> DiaChis { get; set; }
        public DbSet<DonHang> DonHangs { get; set; }
        public DbSet<DonHangDetail> DonHangDetails { get; set; }

        //public DbSet<DonHangHtr> DonHangHtrs { get; set; }
        public DbSet<DonHangHistory> DonHangHistories { get; set; }

        public DbSet<GioHang> GioHangs { get; set; }
        public DbSet<GioHangDetail> GioHangDetails { get; set; }
        public DbSet<HoaDon> HoaDons { get; set; }
        public DbSet<HoaDonHistory> HoaDonHistories { get; set; }
        public DbSet<LienHe> LienHes { get; set; }
        public DbSet<MangaDetail> MangaDetails { get; set; }
        public DbSet<MangaImage> MangaImages { get; set; }
        public DbSet<MComment> MComments { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }

        public DbSet<MnTheloai> MnTheloais { get; set; }
        public DbSet<Shipment> Shipments { get; set; }
        public DbSet<ShipmentItem> ShipmentItems { get; set; }
        public DbSet<ShippingProvider> ShippingProviders { get; set; }
        public DbSet<ShippingTableRate> ShippingTableRates { get; set; }

        public DbSet<Province> Provinces { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Ward> Wards { get; set; }

        public DbSet<Soluottruycap> Soluottruycaps { get; set; }
        public DbSet<TacGia> TacGias { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<TinTuc> TinTucs { get; set; }
        public DbSet<NgonnguMn> NgonnguMns { get; set; }
        public DbSet<Giaodich> Giaodiches { get; set; }
        public DbSet<Khuyenmai> Khuyenmais { get; set; }
        public DbSet<KhuyenmaiManga> KhuyenmaiMangas { get; set; }
        public DbSet<KhuyenmaiTheloai> KhuyenmaiTheloais { get; set; }
        public DbSet<KhuyenmaiLichsuSudung> KhuyenmaiLichsuSudungs { get; set; }
        public DbSet<WishList> WishLists { get; set; }
        public DbSet<WishListItem> WishListItems { get; set; }
        public DbSet<RevenueStatisticViewModel> RevenueStatisticViewModels { get; set; }
    }
}