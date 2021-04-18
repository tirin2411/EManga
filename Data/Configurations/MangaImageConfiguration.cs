using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Configurations
{
    public class MangaImageConfiguration : IEntityTypeConfiguration<MangaImage>
    {
        public void Configure(EntityTypeBuilder<MangaImage> builder)
        {
            builder.ToTable("MangaImages");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.LinkAnh).HasMaxLength(200).IsRequired(true);
            builder.Property(x => x.ChuThich).HasMaxLength(200);
            builder.HasOne(x => x.Manga).WithMany(x => x.MangaImages).HasForeignKey(x => x.MangaId);
        }
    }
}
