using JwtStore.Order.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JwtStore.Infra.Data.Mappings;

public class DeliveryMap : IEntityTypeConfiguration<Delivery>
{
    public void Configure(EntityTypeBuilder<Delivery> builder)
    {
        builder.ToTable("Delivery");

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

        builder.Property(x => x.EstimatedDeliveryDate)
            .IsRequired()
            .HasColumnName("EstimatedDate")
            .HasColumnType("SMALLDATETIME")
            .HasMaxLength(60);
    }
}