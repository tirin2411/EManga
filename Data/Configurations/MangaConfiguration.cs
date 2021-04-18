using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Configurations
{
    public class MangaConfiguration : IEntityTypeConfiguration<Manga>
    {
        public void Configure(EntityTypeBuilder<Manga> builder)
        {
            builder.ToTable("Mangas");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Ten).IsRequired();
            builder.Property(x => x.Giagoc).IsRequired();
            builder.Property(x => x.Anhien).HasDefaultValue(true);

            builder.HasOne(x => x.NgonnguMn).WithMany(x => x.Mangas).HasForeignKey(x => x.NgonnguId);
        }
    }
}