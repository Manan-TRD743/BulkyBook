﻿// <auto-generated />
using BulkyBookSolution.BulkyBookDataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BulkyBookSolution.BulkyBookDataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BulkyBookModel.ProductModel", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductID"));

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<string>("ProductAuthor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductISBN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductImgUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ProductListPrice")
                        .HasColumnType("float");

                    b.Property<double>("ProductPriceFiftyPlus")
                        .HasColumnType("float");

                    b.Property<double>("ProductPriceHundredPlus")
                        .HasColumnType("float");

                    b.Property<double>("ProductPriceOneToFifty")
                        .HasColumnType("float");

                    b.Property<string>("ProductTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductID");

                    b.HasIndex("CategoryID");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductID = 1,
                            CategoryID = 1,
                            ProductAuthor = "Billy Spark",
                            ProductDescription = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincProductIDunt. ",
                            ProductISBN = "SWD9999001",
                            ProductListPrice = 99.0,
                            ProductPriceFiftyPlus = 85.0,
                            ProductPriceHundredPlus = 80.0,
                            ProductPriceOneToFifty = 90.0,
                            ProductTitle = "Fortune of Time"
                        },
                        new
                        {
                            ProductID = 2,
                            CategoryID = 1,
                            ProductAuthor = "Nancy Hoover",
                            ProductDescription = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincProductIDunt. ",
                            ProductISBN = "CAW777777701",
                            ProductImgUrl = "",
                            ProductListPrice = 40.0,
                            ProductPriceFiftyPlus = 25.0,
                            ProductPriceHundredPlus = 20.0,
                            ProductPriceOneToFifty = 30.0,
                            ProductTitle = "Dark Skies"
                        },
                        new
                        {
                            ProductID = 3,
                            CategoryID = 2,
                            ProductAuthor = "Julian Button",
                            ProductDescription = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincProductIDunt. ",
                            ProductISBN = "RITO5555501",
                            ProductImgUrl = "",
                            ProductListPrice = 55.0,
                            ProductPriceFiftyPlus = 40.0,
                            ProductPriceHundredPlus = 35.0,
                            ProductPriceOneToFifty = 50.0,
                            ProductTitle = "Vanish in the Sunset"
                        },
                        new
                        {
                            ProductID = 4,
                            CategoryID = 3,
                            ProductAuthor = "Abby Muscles",
                            ProductDescription = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincProductIDunt. ",
                            ProductISBN = "WS3333333301",
                            ProductImgUrl = "",
                            ProductListPrice = 70.0,
                            ProductPriceFiftyPlus = 60.0,
                            ProductPriceHundredPlus = 55.0,
                            ProductPriceOneToFifty = 65.0,
                            ProductTitle = "Cotton Candy"
                        },
                        new
                        {
                            ProductID = 5,
                            CategoryID = 2,
                            ProductAuthor = "Ron Parker",
                            ProductDescription = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincProductIDunt. ",
                            ProductISBN = "SOTJ1111111101",
                            ProductImgUrl = "",
                            ProductListPrice = 30.0,
                            ProductPriceFiftyPlus = 25.0,
                            ProductPriceHundredPlus = 20.0,
                            ProductPriceOneToFifty = 27.0,
                            ProductTitle = "Rock in the Ocean"
                        },
                        new
                        {
                            ProductID = 6,
                            CategoryID = 3,
                            ProductAuthor = "Laura Phantom",
                            ProductDescription = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincProductIDunt. ",
                            ProductISBN = "FOT000000001",
                            ProductImgUrl = "",
                            ProductListPrice = 25.0,
                            ProductPriceFiftyPlus = 22.0,
                            ProductPriceHundredPlus = 20.0,
                            ProductPriceOneToFifty = 23.0,
                            ProductTitle = "Leaves and Wonders"
                        });
                });

            modelBuilder.Entity("BulkyBookSolution.BulkyBookModel.Models.CategoryModel", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryID"));

                    b.Property<int>("CategoryDisplayOrder")
                        .HasColumnType("int");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryID");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryID = 1,
                            CategoryDisplayOrder = 1,
                            CategoryName = "Action"
                        },
                        new
                        {
                            CategoryID = 2,
                            CategoryDisplayOrder = 2,
                            CategoryName = "Sci-Fi"
                        },
                        new
                        {
                            CategoryID = 3,
                            CategoryDisplayOrder = 3,
                            CategoryName = "Histroy"
                        });
                });

            modelBuilder.Entity("BulkyBookModel.ProductModel", b =>
                {
                    b.HasOne("BulkyBookSolution.BulkyBookModel.Models.CategoryModel", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });
#pragma warning restore 612, 618
        }
    }
}
