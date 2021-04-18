using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Configurations
{
    public class MangaDetailConfiguration : IEntityTypeConfiguration<MangaDetail>
    {
        public void Configure(EntityTypeBuilder<MangaDetail> builder)
        {
            builder.ToTable("MangaDetails");
            builder.HasKey(x => x.MangaId);
            builder.HasOne(x => x.Manga).WithMany(x => x.MangaDetails).HasForeignKey(x => x.MangaId);
        }
    }
}
