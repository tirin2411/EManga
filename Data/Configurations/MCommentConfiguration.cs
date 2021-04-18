using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Configurations
{
    public class MCommentConfiguration : IEntityTypeConfiguration<MComment>
    {
        public void Configure(EntityTypeBuilder<MComment> builder)
        {
            builder.ToTable("MComments");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.NoiDung).IsRequired();
            builder.Property(x => x.NgayComment).HasDefaultValueSql("getdate()");
            builder.HasOne(x => x.Manga).WithMany(x => x.MComments).HasForeignKey(x => x.MangaId);
            builder.HasOne(x => x.AppUser).WithMany(x => x.MComments).HasForeignKey(x => x.UserId);
        }
    }
}