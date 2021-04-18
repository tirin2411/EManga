using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Configurations
{
    public class KhuyenmaiConfiguration : IEntityTypeConfiguration<Khuyenmai>
    {
        public void Configure(EntityTypeBuilder<Khuyenmai> builder)
        {
            builder.ToTable("Khuyenmais");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.FromDate).HasDefaultValueSql("getdate()");
            builder.Property(x => x.ToDate).HasDefaultValueSql("getdate()");
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.CouponCode).IsRequired();
        }
    }
}