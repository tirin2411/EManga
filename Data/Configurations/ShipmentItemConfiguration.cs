using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Configurations
{
    public class ShipmentItemConfiguration : IEntityTypeConfiguration<ShipmentItem>
    {
        public void Configure(EntityTypeBuilder<ShipmentItem> builder)
        {
            builder.ToTable("ShipmentItems");
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Shipment).WithMany(x => x.ShipmentItems).HasForeignKey(x => x.ShipmentId);
            //builder.HasOne(x => x.DonHangDetail).WithMany(x => x.ShipmentItems).HasForeignKey(x => x.OrderItemId);
            builder.HasOne(x => x.Manga).WithMany(x => x.ShipmentItems).HasForeignKey(x => x.MangaId);

        }
    }
}
