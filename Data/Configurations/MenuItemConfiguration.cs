using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Configurations
{
    public class MenuItemConfiguration : IEntityTypeConfiguration<MenuItem>
    {
        public void Configure(EntityTypeBuilder<MenuItem> builder)
        {
            builder.ToTable("MenuItems");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.HasOne(x => x.Menu).WithMany(x => x.MenuItems).HasForeignKey(x => x.MenuId);
            //builder.HasOne(x => x.Menuitem).WithMany(x => x.MenuItems).HasForeignKey(x => x.ParentId);
        }
    }
}
