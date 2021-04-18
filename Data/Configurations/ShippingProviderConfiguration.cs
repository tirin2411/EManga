using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Configurations
{
    public class ShippingProviderConfiguration : IEntityTypeConfiguration<ShippingProvider>
    {
        public void Configure(EntityTypeBuilder<ShippingProvider> builder)
        {
            builder.ToTable("ShipmentProviders");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.IsEnabled).HasDefaultValue(1);

        }
    }
}
