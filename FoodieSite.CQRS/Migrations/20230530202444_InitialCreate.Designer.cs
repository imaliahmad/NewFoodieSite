﻿// <auto-generated />
using System;
using FoodieSite.CQRS.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FoodieSite.CQRS.Migrations
{
    [DbContext(typeof(EFCoreDbContext))]
    [Migration("20230530202444_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FoodieSite.CQRS.Models.CategoryMaster", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("description");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<Guid?>("ModifiedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("name");

                    b.Property<Guid>("StoreId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("store_id");

                    b.HasKey("Id");

                    b.HasIndex("StoreId");

                    b.ToTable("CategoryMaster");
                });

            modelBuilder.Entity("FoodieSite.CQRS.Models.CustomerMaster", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(350)")
                        .HasColumnName("address");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("city");

                    b.Property<string>("ContactNumber1")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("contact_number_1");

                    b.Property<string>("ContactNumber2")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("contact_number_2");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<Guid?>("ModifiedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("CustomerMaster");
                });

            modelBuilder.Entity("FoodieSite.CQRS.Models.ItemMaster", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("category_id");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("description");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<Guid?>("ModifiedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("name");

                    b.Property<decimal>("SalePrice")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("sale_price");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("ItemMaster");
                });

            modelBuilder.Entity("FoodieSite.CQRS.Models.OrderDetails", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<Guid>("ItemId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("item_id");

                    b.Property<Guid?>("ModifiedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("order_id");

                    b.Property<int>("Quantity")
                        .HasColumnType("int")
                        .HasColumnName("quantity");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("FoodieSite.CQRS.Models.OrderMaster", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("customer_id");

                    b.Property<string>("InvoiceNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("invoice_no");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<Guid?>("ModifiedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("StoreId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("store_id");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("StoreId");

                    b.ToTable("OrderMaster");
                });

            modelBuilder.Entity("FoodieSite.CQRS.Models.OrderStatus", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<Guid?>("ModifiedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("order_id");

                    b.Property<int>("Status")
                        .HasColumnType("int")
                        .HasColumnName("status");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderStatus");
                });

            modelBuilder.Entity("FoodieSite.CQRS.Models.PaymentMaster", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<Guid?>("ModifiedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("order_id");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("type");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("PaymentMaster");
                });

            modelBuilder.Entity("FoodieSite.CQRS.Models.RestaurantMaster", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("address");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("city");

                    b.Property<string>("ContactNumber1")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("contact_number_1");

                    b.Property<string>("ContactNumber2")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("contact_number_2");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("email");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<Guid?>("ModifiedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.Property<string>("RestaurantCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(350)")
                        .HasColumnName("restaurant_code");

                    b.HasKey("Id");

                    b.ToTable("RestaurantMaster");
                });

            modelBuilder.Entity("FoodieSite.CQRS.Models.StoreMaster", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("address");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("city");

                    b.Property<string>("ContactNumber1")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("contact_number_1");

                    b.Property<string>("ContactNumber2")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("contact_number_2");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<Guid?>("ModifiedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.Property<Guid>("RestaurantId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("restaurant_id");

                    b.HasKey("Id");

                    b.HasIndex("RestaurantId");

                    b.ToTable("StoreMaster");
                });

            modelBuilder.Entity("FoodieSite.CQRS.Models.CategoryMaster", b =>
                {
                    b.HasOne("FoodieSite.CQRS.Models.StoreMaster", "StoreMaster")
                        .WithMany("CategoryMaster")
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("StoreMaster");
                });

            modelBuilder.Entity("FoodieSite.CQRS.Models.ItemMaster", b =>
                {
                    b.HasOne("FoodieSite.CQRS.Models.CategoryMaster", "CategoryMaster")
                        .WithMany("ItemMaster")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("CategoryMaster");
                });

            modelBuilder.Entity("FoodieSite.CQRS.Models.OrderDetails", b =>
                {
                    b.HasOne("FoodieSite.CQRS.Models.ItemMaster", "ItemMaster")
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("FoodieSite.CQRS.Models.OrderMaster", "OrderMaster")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ItemMaster");

                    b.Navigation("OrderMaster");
                });

            modelBuilder.Entity("FoodieSite.CQRS.Models.OrderMaster", b =>
                {
                    b.HasOne("FoodieSite.CQRS.Models.CustomerMaster", "CustomerMaster")
                        .WithMany("OrderMaster")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("FoodieSite.CQRS.Models.StoreMaster", "StoreMaster")
                        .WithMany("OrderMaster")
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("CustomerMaster");

                    b.Navigation("StoreMaster");
                });

            modelBuilder.Entity("FoodieSite.CQRS.Models.OrderStatus", b =>
                {
                    b.HasOne("FoodieSite.CQRS.Models.OrderMaster", "OrderMaster")
                        .WithMany("OrderStatus")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("OrderMaster");
                });

            modelBuilder.Entity("FoodieSite.CQRS.Models.PaymentMaster", b =>
                {
                    b.HasOne("FoodieSite.CQRS.Models.OrderMaster", "OrderMaster")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("OrderMaster");
                });

            modelBuilder.Entity("FoodieSite.CQRS.Models.StoreMaster", b =>
                {
                    b.HasOne("FoodieSite.CQRS.Models.RestaurantMaster", "RestaurantMaster")
                        .WithMany("StoreMaster")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("RestaurantMaster");
                });

            modelBuilder.Entity("FoodieSite.CQRS.Models.CategoryMaster", b =>
                {
                    b.Navigation("ItemMaster");
                });

            modelBuilder.Entity("FoodieSite.CQRS.Models.CustomerMaster", b =>
                {
                    b.Navigation("OrderMaster");
                });

            modelBuilder.Entity("FoodieSite.CQRS.Models.OrderMaster", b =>
                {
                    b.Navigation("OrderStatus");
                });

            modelBuilder.Entity("FoodieSite.CQRS.Models.RestaurantMaster", b =>
                {
                    b.Navigation("StoreMaster");
                });

            modelBuilder.Entity("FoodieSite.CQRS.Models.StoreMaster", b =>
                {
                    b.Navigation("CategoryMaster");

                    b.Navigation("OrderMaster");
                });
#pragma warning restore 612, 618
        }
    }
}