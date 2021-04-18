using Data.Entities;
using Data.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Configurations
{
    public class DonHangConfiguration : IEntityTypeConfiguration<DonHang>
    {
        public void Configure(EntityTypeBuilder<DonHang> builder)
        {
            builder.ToTable("DonHangs");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.NgayDat).HasDefaultValueSql("getdate()");
            builder.Property(x => x.NguoiNhan).IsRequired();
            builder.Property(x => x.DiaChiNhan).IsRequired().HasMaxLength(500);
            builder.Property(x => x.SDT).IsRequired();
            builder.Property(x => x.Tinhtrang).HasDefaultValue(OrderStatus.InProgress);
            builder.Property(x => x.TinhtrangThanhtoan).HasDefaultValue(TinhtrangThanhtoan.Unpaid);
            builder.HasOne(x => x.AppUser).WithMany(x => x.DonHangs).HasForeignKey(x => x.UserId);
        }
    }
}