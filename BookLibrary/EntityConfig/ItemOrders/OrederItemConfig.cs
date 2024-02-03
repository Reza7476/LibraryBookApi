using BookLibrary.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookLibrary.EntityConfig.ItemOrders;

public class OrederItemConfig : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
  
    }
}
