using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ordering.Domain.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ordering.Infrastructure.EntityConfigurations
{
    class OrderDetailEntityTypeConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> orderItemConfiguration)
        {
            orderItemConfiguration.HasKey(o => o.Id);

            orderItemConfiguration.Property(o => o.OrderId).IsRequired();
        }
    }
}
