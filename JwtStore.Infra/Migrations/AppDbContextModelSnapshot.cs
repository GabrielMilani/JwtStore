﻿// <auto-generated />
using System;
using JwtStore.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JwtStore.Infra.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("JwtStore.Account.Entities.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("City");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Country");

                    b.Property<string>("Neighborhood")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Neighborhood");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Number");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("State");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Title");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("ZipCode");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Address", (string)null);
                });

            modelBuilder.Entity("JwtStore.Account.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Title");

                    b.HasKey("Id");

                    b.ToTable("Role", (string)null);
                });

            modelBuilder.Entity("JwtStore.Account.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("JwtStore.Order.Entities.Delivery", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasMaxLength(60)
                        .HasColumnType("SMALLDATETIME")
                        .HasColumnName("CreateDate");

                    b.Property<DateTime>("EstimatedDeliveryDate")
                        .HasMaxLength(60)
                        .HasColumnType("SMALLDATETIME")
                        .HasColumnName("EstimatedDate");

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int")
                        .HasColumnName("Status");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("Delivery", (string)null);
                });

            modelBuilder.Entity("JwtStore.Order.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasMaxLength(60)
                        .HasColumnType("SMALLDATETIME")
                        .HasColumnName("CreateDate");

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int")
                        .HasColumnName("Status");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Order", (string)null);
                });

            modelBuilder.Entity("JwtStore.Order.Entities.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.Property<decimal?>("Price")
                        .IsRequired()
                        .HasPrecision(10, 2)
                        .HasColumnType("NUMERIC")
                        .HasColumnName("Price");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<decimal?>("Quantity")
                        .IsRequired()
                        .HasPrecision(10, 2)
                        .HasColumnType("NUMERIC")
                        .HasColumnName("Quantity");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderItem", (string)null);
                });

            modelBuilder.Entity("JwtStore.Stock.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Title");

                    b.HasKey("Id");

                    b.ToTable("Category", (string)null);
                });

            modelBuilder.Entity("JwtStore.Stock.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasMaxLength(60)
                        .HasColumnType("SMALLDATETIME")
                        .HasColumnName("CreateDate");

                    b.Property<string>("Description")
                        .HasMaxLength(2000)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("Description");

                    b.Property<DateTime>("LastUpdateDate")
                        .HasMaxLength(60)
                        .HasColumnType("SMALLDATETIME")
                        .HasColumnName("LastUpdateDate");

                    b.Property<decimal>("Price")
                        .HasPrecision(10, 2)
                        .HasColumnType("NUMERIC")
                        .HasColumnName("Price");

                    b.Property<decimal>("QuantityOnHand")
                        .HasPrecision(10, 2)
                        .HasColumnType("NUMERIC")
                        .HasColumnName("QuantityOnHand");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Title");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Product", (string)null);
                });

            modelBuilder.Entity("UserRole", b =>
                {
                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("RoleId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRole");
                });

            modelBuilder.Entity("JwtStore.Account.Entities.Address", b =>
                {
                    b.HasOne("JwtStore.Account.Entities.User", "User")
                        .WithMany("Addresses")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK_Address_User");

                    b.Navigation("User");
                });

            modelBuilder.Entity("JwtStore.Account.Entities.User", b =>
                {
                    b.OwnsOne("JwtStore.Account.ValueObjects.Document", "Document", b1 =>
                        {
                            b1.Property<int>("UserId")
                                .HasColumnType("int");

                            b1.Property<string>("Number")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Document");

                            b1.Property<int>("Type")
                                .HasColumnType("int")
                                .HasColumnName("DocumentType");

                            b1.HasKey("UserId");

                            b1.ToTable("User");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("JwtStore.Account.ValueObjects.Email", "Email", b1 =>
                        {
                            b1.Property<int>("UserId")
                                .HasColumnType("int");

                            b1.Property<string>("Address")
                                .IsRequired()
                                .HasMaxLength(120)
                                .HasColumnType("NVARCHAR")
                                .HasColumnName("Email");

                            b1.Property<string>("ResetCode")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("EmailResetCode");

                            b1.HasKey("UserId");

                            b1.ToTable("User");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("JwtStore.Account.ValueObjects.Password", "Password", b1 =>
                        {
                            b1.Property<int>("UserId")
                                .HasColumnType("int");

                            b1.Property<string>("Hash")
                                .IsRequired()
                                .HasMaxLength(120)
                                .HasColumnType("NVARCHAR")
                                .HasColumnName("Password");

                            b1.Property<string>("ResetCode")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("PasswordResetCode");

                            b1.HasKey("UserId");

                            b1.ToTable("User");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.Navigation("Document")
                        .IsRequired();

                    b.Navigation("Email")
                        .IsRequired();

                    b.Navigation("Password")
                        .IsRequired();
                });

            modelBuilder.Entity("JwtStore.Order.Entities.Delivery", b =>
                {
                    b.HasOne("JwtStore.Order.Entities.Order", null)
                        .WithMany("Deliveries")
                        .HasForeignKey("OrderId");
                });

            modelBuilder.Entity("JwtStore.Order.Entities.Order", b =>
                {
                    b.HasOne("JwtStore.Account.Entities.User", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("JwtStore.Order.Entities.OrderItem", b =>
                {
                    b.HasOne("JwtStore.Order.Entities.Order", null)
                        .WithMany("Items")
                        .HasForeignKey("OrderId");

                    b.HasOne("JwtStore.Stock.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("JwtStore.Stock.Entities.Product", b =>
                {
                    b.HasOne("JwtStore.Stock.Entities.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Products_Category");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("UserRole", b =>
                {
                    b.HasOne("JwtStore.Account.Entities.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JwtStore.Account.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("JwtStore.Account.Entities.User", b =>
                {
                    b.Navigation("Addresses");
                });

            modelBuilder.Entity("JwtStore.Order.Entities.Order", b =>
                {
                    b.Navigation("Deliveries");

                    b.Navigation("Items");
                });

            modelBuilder.Entity("JwtStore.Stock.Entities.Category", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
