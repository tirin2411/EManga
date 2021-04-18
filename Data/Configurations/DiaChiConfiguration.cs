using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Configurations
{
    public class DiaChiConfiguration : IEntityTypeConfiguration<DiaChi>
    {
        public void Configure(EntityTypeBuilder<DiaChi> builder)
        {
            builder.ToTable("DiaChis");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Diachi).IsRequired();
            builder.HasOne(x => x.AppUser).WithMany(x => x.DiaChis).HasForeignKey(x => x.UserId);
        }
    }
}