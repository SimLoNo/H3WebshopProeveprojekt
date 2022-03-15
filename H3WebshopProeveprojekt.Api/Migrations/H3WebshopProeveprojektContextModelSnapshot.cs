﻿// <auto-generated />
using System;
using H3WebshopProeveprojekt.Api.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace H3WebshopProeveprojekt.Api.Migrations
{
    [DbContext(typeof(H3WebshopProeveprojektContext))]
    partial class H3WebshopProeveprojektContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.14")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("H3WebshopProeveprojekt.Api.Database.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Category");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryName = "Trousers"
                        },
                        new
                        {
                            Id = 2,
                            CategoryName = "Shirts"
                        });
                });

            modelBuilder.Entity("H3WebshopProeveprojekt.Api.Database.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<short>("CategoryId")
                        .HasColumnType("smallint");

                    b.Property<int?>("CategoryId1")
                        .HasColumnType("int");

                    b.Property<byte>("DiscountPercentage")
                        .HasColumnType("tinyint");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(30)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId1");

                    b.ToTable("Product");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = (short)1,
                            DiscountPercentage = (byte)0,
                            Name = "Jeans",
                            Price = 400.0
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = (short)1,
                            DiscountPercentage = (byte)0,
                            Name = "Woolies",
                            Price = 300.0
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = (short)2,
                            DiscountPercentage = (byte)0,
                            Name = "Serena shirt",
                            Price = 600.0
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = (short)2,
                            DiscountPercentage = (byte)0,
                            Name = "Tshirt",
                            Price = 200.0
                        });
                });

            modelBuilder.Entity("H3WebshopProeveprojekt.Api.Database.Entities.Product", b =>
                {
                    b.HasOne("H3WebshopProeveprojekt.Api.Database.Entities.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId1");

                    b.Navigation("Category");
                });
#pragma warning restore 612, 618
        }
    }
}
