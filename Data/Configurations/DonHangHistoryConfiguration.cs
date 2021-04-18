using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Configurations
{
    public class DonHangHistoryConfiguration : IEntityTypeConfiguration<DonHangHistory>
    {
        public void Configure(EntityTypeBuilder<DonHangHistory> builder)
        {
            builder.ToTable("DonHangHistories");
            //builder.HasKey(x => x.DonHangDetailId);
            //builder.HasOne(x => x.DonHangDetail).WithMany(x => x.DonHangHistories).HasForeignKey(x => x.DonHangDetailId);
        }
    }
}