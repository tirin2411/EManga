using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Configurations
{
    public class KhuyenmaiLichsuSudungConfiguration : IEntityTypeConfiguration<KhuyenmaiLichsuSudung>
    {
        public void Configure(EntityTypeBuilder<KhuyenmaiLichsuSudung> builder)
        {
            builder.ToTable("KhuyenmaiLichsuSudungs");
            builder.HasKey(x => x.Id);
            builder.HasOne(t => t.Khuyenmai).WithMany(mt => mt.KhuyenmaiLichsuSudungs).HasForeignKey(mt => mt.KhuyenmaiId);
            builder.HasOne(t => t.DonHang).WithMany(mt => mt.KhuyenmaiLichsuSudungs).HasForeignKey(mt=>mt.DonHangId);
            builder.Property(t=>t.NgayTao).HasDefaultValueSql("getdate()");
        }
    }
}
