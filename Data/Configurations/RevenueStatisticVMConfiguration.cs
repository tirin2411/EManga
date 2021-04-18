using Data.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Configurations
{
    public class RevenueStatisticVMConfiguration : IEntityTypeConfiguration<RevenueStatisticViewModel>
    {
        public void Configure(EntityTypeBuilder<RevenueStatisticViewModel> builder)
        {
            //builder.ToTable("GetRevenueStatistic");
            builder.HasNoKey();
        }
    }
}
