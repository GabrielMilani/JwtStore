using JwtStore.Stock.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JwtStore.Infra.Data.Mappings;

public class ProductMap : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Product");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Title)
            .IsRequired()
            .HasColumnName("Title")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(100);
        builder.Property(x => x.Description)
            .IsRequired(false)
            .HasColumnName("Description")
            .HasColumnType("VARCHAR")
            .HasMaxLength(2000);
        builder.Property(x => x.Price)
            .IsRequired()
            .HasColumnName("Price")
            .HasColumnType("NUMERIC")
            .HasPrecision(10, 2);
        builder.Property(x => x.QuantityOnHand)
            .IsRequired()
            .HasColumnName("QuantityOnHand")
            .HasColumnType("NUMERIC")
            .HasPrecision(10, 2);
        builder.Property(x => x.CreateDate)
            .IsRequired()
            .HasColumnName("CreateDate")
            .HasColumnType("SMALLDATETIME")
            .HasMaxLength(60);
        builder.Property(x => x.LastUpdateDate)
            .IsRequired()
            .HasColumnName("LastUpdateDate")
            .HasColumnType("SMALLDATETIME")
            .HasMaxLength(60);
        builder
            .HasOne(x => x.Category)
            .WithMany(x => x.Products)
            .HasConstraintName("FK_Products_Category")
            .OnDelete(DeleteBehavior.Cascade);
    }
}