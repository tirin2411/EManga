using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Configurations
{
    public class ShippingTableRateConfiguration : IEntityTypeConfiguration<ShippingTableRate>
    {
        public void Configure(EntityTypeBuilder<ShippingTableRate> builder)
        {
            builder.ToTable("ShipmentTableRates");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ShippingPrice).HasDefaultValue(0);

        }
    }
}
