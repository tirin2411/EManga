using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Configurations
{
    public class BlogConfiguration : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.ToTable("Blogs");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.TuaDe).IsRequired().HasMaxLength(50);
            builder.Property(x => x.HinhAnhblog).HasMaxLength(200).IsRequired(true);
            builder.Property(x => x.NoiDungBlog).IsRequired();
            builder.Property(x => x.NgayCapNhat).HasDefaultValueSql("getdate()");
            builder.Property(x => x.AnHien).HasDefaultValue(true);
        }
    }
}