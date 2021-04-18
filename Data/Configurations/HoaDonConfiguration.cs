using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Configurations
{
    public class HoaDonConfiguration : IEntityTypeConfiguration<HoaDon>
    {
        public void Configure(EntityTypeBuilder<HoaDon> builder)
        {
            builder.ToTable("HoaDons");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Creation_date).HasDefaultValueSql("getdate()");
            builder.HasOne(x => x.CreditCard).WithMany(x => x.HoaDons).HasForeignKey(x => x.CreditCardId);
        }
    }
}