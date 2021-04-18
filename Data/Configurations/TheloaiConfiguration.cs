using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Configurations
{
    public class TheloaiConfiguration : IEntityTypeConfiguration<Theloai>
    {
        public void Configure(EntityTypeBuilder<Theloai> builder)
        {
            builder.ToTable("Theloais");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.TenTL).IsRequired();
            builder.Property(x => x.Anhien).HasDefaultValue(true);
        }
    }
}
