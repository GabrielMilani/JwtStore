using JwtStore.Account.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JwtStore.Infra.Data.Mappings;

public class AddressMap : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.ToTable("Address");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Street)
            .IsRequired()
            .HasColumnName("Street")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(150);

        builder.Property(x => x.Number)
            .IsRequired()
            .HasColumnName("Number")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(10);

        builder.Property(x => x.Neighborhood)
            .IsRequired()
            .HasColumnName("Neighborhood")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(100);

        builder.Property(x => x.City)
            .IsRequired()
            .HasColumnName("City")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(100);

        builder.Property(x => x.State)
            .IsRequired()
            .HasColumnName("State")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(100);

        builder.Property(x => x.Country)
            .IsRequired()
            .HasColumnName("Country")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(100);

        builder.Property(x => x.ZipCode)
            .IsRequired()
            .HasColumnName("ZipCode")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(8);

        builder.Property(x => x.Street)
            .IsRequired()
            .HasColumnName("Title")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(100);

        builder
            .HasOne(x => x.User)
            .WithMany(x => x.Addresses)
            .HasConstraintName("FK_Address_User")
            .OnDelete(DeleteBehavior.Cascade);
    }
}