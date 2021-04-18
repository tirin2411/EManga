using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Configurations
{
    public class WishListItemConfiguration : IEntityTypeConfiguration<WishListItem>
    {
        public void Configure(EntityTypeBuilder<WishListItem> builder)
        {
            builder.ToTable("WishListItems");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.CreatedOn).HasDefaultValueSql("getdate()");
            builder.HasOne(x => x.WishList).WithMany(x => x.WishListItems).HasForeignKey(x => x.WishListId);
            builder.HasOne(x => x.Manga).WithMany(x => x.WishListItems).HasForeignKey(x => x.MangaId);
        }
    }
}
