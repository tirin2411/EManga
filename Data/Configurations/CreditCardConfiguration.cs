using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Configurations
{
    public class CreditCardConfiguration : IEntityTypeConfiguration<CreditCard>
    {
        public void Configure(EntityTypeBuilder<CreditCard> builder)
        {
            builder.ToTable("CreditCards");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.HasOne(x => x.DiaChi).WithMany(x => x.CreditCards).HasForeignKey(x => x.DiaChiId);
        }
    }
}