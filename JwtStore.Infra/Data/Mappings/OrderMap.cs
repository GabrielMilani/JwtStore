using Microsoft.EntityFrameworkCore;

namespace JwtStore.Infra.Data.Mappings;

public class OrderMap : IEntityTypeConfiguration<Order.Entities.Order>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Order.Entities.Order> builder)
    {
        builder.ToTable("Order");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.CreateDate)
            .IsRequired()
            .HasColumnName("CreateDate")
            .HasColumnType("SMALLDATETIME")
            .HasMaxLength(60);

        builder.Property(x => x.Status)
            .IsRequired()
            .HasColumnName("Status")
            .IsRequired(true);

        builder.HasMany(x => x.Items);
        builder.HasMany(x => x.Deliveries);
        builder.HasOne(x => x.Customer);
    }
}