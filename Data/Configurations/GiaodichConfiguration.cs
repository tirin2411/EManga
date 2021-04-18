using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Configurations
{
    public class GiaodichConfiguration : IEntityTypeConfiguration<Giaodich>
    {
        public void Configure(EntityTypeBuilder<Giaodich> builder)
        {
            builder.ToTable("Giaodichs");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.NgayGd).HasDefaultValueSql("getdate()");

            builder.HasOne(x => x.AppUser).WithMany(x => x.Giaodiches).HasForeignKey(x => x.UserId);
        }
    }
}