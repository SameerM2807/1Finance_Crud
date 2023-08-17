﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using _1FinanceAssignment_Web_Api_.ContextLayered;

#nullable disable

namespace _1FinanceAssignment_Web_Api_.Migrations
{
    [DbContext(typeof(ProductDbContext))]
    partial class ProductDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("_1FinanceAssignment_Web_Api_.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Category_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Category_name = "Electronics",
                            description = "Product 1 Description"
                        },
                        new
                        {
                            Id = 2,
                            Category_name = "Clothes",
                            description = "Product 2 Description"
                        },
                        new
                        {
                            Id = 3,
                            Category_name = "HomeDeCore",
                            description = "Product 3 Description"
                        });
                });

            modelBuilder.Entity("_1FinanceAssignment_Web_Api_.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"), 1L, 1);

                    b.Property<int>("CatId")
                        .HasColumnType("int");

                    b.Property<string>("ProductName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("price")
                        .HasColumnType("float");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.HasKey("ProductId");

                    b.HasIndex("CatId");

                    b.ToTable("products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            CatId = 1,
                            ProductName = "IPhone14",
                            price = 0.0,
                            quantity = 10
                        },
                        new
                        {
                            ProductId = 2,
                            CatId = 1,
                            ProductName = "IPhone13",
                            price = 0.0,
                            quantity = 20
                        },
                        new
                        {
                            ProductId = 3,
                            CatId = 1,
                            ProductName = "IPhone12",
                            price = 0.0,
                            quantity = 30
                        });
                });

            modelBuilder.Entity("_1FinanceAssignment_Web_Api_.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("user");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "0sameermansuri0@gmail.com",
                            Name = "Sameer",
                            Password = "Mansuri@00"
                        });
                });

            modelBuilder.Entity("_1FinanceAssignment_Web_Api_.Models.Product", b =>
                {
                    b.HasOne("_1FinanceAssignment_Web_Api_.Models.Category", "Category")
                        .WithMany("products")
                        .HasForeignKey("CatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("_1FinanceAssignment_Web_Api_.Models.Category", b =>
                {
                    b.Navigation("products");
                });
#pragma warning restore 612, 618
        }
    }
}
