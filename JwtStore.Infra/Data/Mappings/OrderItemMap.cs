using JwtStore.Order.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JwtStore.Infra.Data.Mappings;

public class OrderItemMap : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.ToTable("OrderItem");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Price)
            .IsRequired()
            .HasColumnName("Price")
            .HasColumnType("NUMERIC")
            .HasPrecision(10, 2);

        builder.Property(x => x.Quantity)
            .IsRequired()
            .HasColumnName("Quantity")
            .HasColumnType("NUMERIC")
            .HasPrecision(10, 2);

        builder.HasOne(x => x.Product);

    }
}