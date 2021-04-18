using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Configurations
{
    public class HoaDonHistoryConfiguration : IEntityTypeConfiguration<HoaDonHistory>
    {
        public void Configure(EntityTypeBuilder<HoaDonHistory> builder)
        {
            builder.ToTable("HoaDonHistories");
            builder.HasKey(x => x.HoaDonId);
            builder.HasOne(x => x.HoaDon).WithMany(x => x.HoaDonHistories).HasForeignKey(x => x.HoaDonId);
        }
    }
}