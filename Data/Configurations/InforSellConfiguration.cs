using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Configurations
{
    public class InforSellConfiguration : IEntityTypeConfiguration<InforSell>
    {
        public void Configure(EntityTypeBuilder<InforSell> builder)
        {
            builder.ToTable("InforSells");
            builder.HasKey(x => new { x.MangaId, x.UserId });

            builder.HasOne(x => x.Manga).WithMany(mt => mt.InforSells).HasForeignKey(mt => mt.MangaId);
            builder.HasOne(x => x.AppUser).WithMany(mt=>mt.InforSells).HasForeignKey(mt=>mt.UserId);
        }
    }
}
