using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Configurations
{
    public class WishListConfiguration : IEntityTypeConfiguration<WishList>
    {
        public void Configure(EntityTypeBuilder<WishList> builder)
        {
            builder.ToTable("WishLists");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.CreatedOn).HasDefaultValueSql("getdate()");
            builder.HasOne(x => x.AppUser).WithMany(x => x.WishLists).HasForeignKey(x => x.UserId);
        }
    }
}
