using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppConfig>().HasData(
                new AppConfig() { Key = "HomeTitle", Value = "This is home page of FMN" },
                new AppConfig() { Key = "HomeKeyword", Value = "This is Keyword of FMN" },
                new AppConfig() { Key = "HomeDescription", Value = "This is Description of FMN" }
                );

            modelBuilder.Entity<NgonnguMn>().HasData(

                new NgonnguMn() { Id = 1, Name = "Vietnamese" },
                new NgonnguMn() { Id = 2, Name = "Japanese" }
                );

            modelBuilder.Entity<Manga>().HasData(
                new Manga()
                {
                    Id = 1,
                    Ten = "OnePice Tap 1",
                    Gia = 50000,
                    Giagoc = 50000,
                    Anhien = true,
                    NgonnguId = 1
                },
                new Manga() { Id = 2, Ten = "Conan Tap 10", Gia = 30000, Giagoc = 30000, Anhien = true, NgonnguId = 1 }
                );

            modelBuilder.Entity<MangaDetail>().HasData(new MangaDetail()
            {
                MangaId = 1,
                SoLuong = Enums.TinhtrangSoluong.Stocking,
                TinhtrangMn = Enums.TinhtrangMn.New,
                Mota = "Hay lam ne hehe",
                Tacgia = "vvv",
                NamXB = "1234",
                Sotrang = 90
            },
            new MangaDetail()
            {
                MangaId = 2,
                SoLuong = Enums.TinhtrangSoluong.Stocking,
                TinhtrangMn = Enums.TinhtrangMn.New,
                Mota = "Hấp dẫn nè",
                Tacgia = "fdsf",
                NamXB = "3452",
                Sotrang = 97
            }
            );

            modelBuilder.Entity<Menu>().HasData(
            new Menu() { Id = 1, TenMenu = "Menu Header",Meta = "menu-header",ThuTu = 1, Anhien = true },
            new Menu() { Id = 2, TenMenu = "Menu Footer", Meta = "menu-footer", ThuTu = 2, Anhien = true }
            );

            modelBuilder.Entity<Theloai>().HasData(new Theloai()
            { Id = 1, TenTL = "Hành Động" },
            new Theloai() { Id = 2, TenTL = "Hài Hước" },
            new Theloai() { Id = 3, TenTL = "Kinh Dị" },
            new Theloai() { Id = 4, TenTL = "Trinh Thám" }
            );

            modelBuilder.Entity<MnTheloai>().HasData(
                new MnTheloai() { MangaId = 1, TheLoaiId = 1 },
                new MnTheloai() { MangaId = 1, TheLoaiId = 2 },
                new MnTheloai() { MangaId = 2, TheLoaiId = 1 }
                );

            // any guid
            var roleId = new Guid("8D04DCE2-969A-435D-BBA4-DF3F325983DC");
            var adminId = new Guid("69BD714F-9576-45BA-B5B7-F00649BE00DE");
            modelBuilder.Entity<AppRole>().HasData(new AppRole
            {
                Id = roleId,
                Name = "admin",
                NormalizedName = "admin",
                Description = "Administrator role"
            });

            var hasher = new PasswordHasher<AppUser>();
            modelBuilder.Entity<AppUser>().HasData(new AppUser
            {
                Id = adminId,
                UserName = "admin",
                NormalizedUserName = "admin",
                Email = "nutrinh@gmail.com",
                NormalizedEmail = "nutrinh@gmail.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "123456@"),
                SecurityStamp = string.Empty,
                Ho = "Lee",
                Ten = "TiRin",
                Dob = new DateTime(2000, 01, 01),
                GioiTinh = Gender.Nữ
            });

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = roleId,
                UserId = adminId
            });
        }
    }
}