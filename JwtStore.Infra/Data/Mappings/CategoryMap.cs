using JwtStore.Stock.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JwtStore.Infra.Data.Mappings;

public class CategoryMap : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Category");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Title)
            .HasColumnName("Title")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(120)
            .IsRequired(true);
    }
}