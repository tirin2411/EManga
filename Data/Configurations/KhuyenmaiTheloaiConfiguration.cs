using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Configurations
{
    public class KhuyenmaiTheloaiConfiguration : IEntityTypeConfiguration<KhuyenmaiTheloai>
    {
        public void Configure(EntityTypeBuilder<KhuyenmaiTheloai> builder)
        {
            builder.ToTable("KhuyenmaiTheloais");
            builder.HasKey(t => new { t.KhuyenmaiId, t.TheLoaiId });
            builder.HasOne(t => t.Khuyenmai).WithMany(mt => mt.KhuyenmaiTheloais).HasForeignKey(mt => mt.KhuyenmaiId);
            builder.HasOne(t => t.Theloai).WithMany(mt => mt.KhuyenmaiTheloais).HasForeignKey(mt=>mt.TheLoaiId);
        }
    }
}
