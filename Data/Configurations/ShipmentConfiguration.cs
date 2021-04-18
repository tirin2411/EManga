using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Configurations
{
    public class ShipmentConfiguration : IEntityTypeConfiguration<Shipment>
    {
        public void Configure(EntityTypeBuilder<Shipment> builder)
        {
            builder.ToTable("Shipments");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CreateOn).HasDefaultValueSql("getdate()");
            builder.HasOne(x => x.DonHang).WithMany(x => x.Shipments).HasForeignKey(x => x.OrderId);
        }
    }
}
