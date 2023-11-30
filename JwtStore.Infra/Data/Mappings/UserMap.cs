using JwtStore.Account.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JwtStore.Infra.Data.Mappings;

public class UserMap : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("User");

        builder.Property<Guid>("Id")
            .ValueGeneratedOnAdd()
            .HasColumnType("uniqueidentifier");

        builder.HasKey("Id");

        builder.Property(x => x.Name)
            .HasColumnName("Name")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(120)
            .IsRequired(true);

        builder.OwnsOne(x => x.Email)
            .Property(x => x.Address)
            .HasColumnName("Email")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(120)
            .IsRequired(true);

        builder.OwnsOne(x => x.Email)
            .Property(x => x.ResetCode)
            .HasColumnName("EmailResetCode")
            .IsRequired();

        builder.OwnsOne(x => x.Password)
            .Property(x => x.Hash)
            .HasColumnName("Password")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(120)
            .IsRequired();

        builder.OwnsOne(x => x.Password)
            .Property(x => x.ResetCode)
            .HasColumnName("PasswordResetCode")
            .IsRequired();

        builder.HasMany(x => x.Roles)
            .WithMany(x => x.Users)
            .UsingEntity<Dictionary<string, object>>(
                "UserRole",
                role => role
                    .HasOne<Role>()
                    .WithMany()
                    .HasForeignKey("RoleId")
                    .OnDelete(DeleteBehavior.Cascade),
                user => user
                    .HasOne<User>()
                    .WithMany()
                    .HasForeignKey("UserId")
                    .OnDelete(DeleteBehavior.Cascade));
    }
}