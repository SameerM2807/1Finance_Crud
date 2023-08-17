using _1FinanceAssignment_Web_Api_.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace _1FinanceAssignment_Web_Api_.ContextLayered
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> context) : base(context)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Category_name = "Electronics",
                    description = "Product 1 Description"

                },
                new Category
                {
                    Id = 2,
                    Category_name = "Clothes",
                    description = "Product 2 Description"

                },
                new Category
                {
                    Id = 3,
                    Category_name = "HomeDeCore",
                    description = "Product 3 Description"

                }

                );
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ProductId = 1,
                    ProductName = "IPhone14",
                    quantity = 10,
                    CatId = 1
                },
                new Product
                {
                    ProductId = 2,
                    ProductName = "IPhone13",
                    quantity = 20,
                    CatId = 1
                },
                new Product
                {
                    ProductId = 3,
                    ProductName = "IPhone12",
                    quantity = 30,
                    CatId = 1
                }




                );

            modelBuilder.Entity<Product>()
                 .HasOne(p => p.Category)
                 .WithMany(c => c.products)
                 .HasForeignKey(p => p.CatId)
                 .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id=1,
                    Name="Sameer",
                    Email="0sameermansuri0@gmail.com",
                    Password="Mansuri@00"
                }
                );


        }


        //create table

        public DbSet<Product> products { get; set; }

        public DbSet<Category> categories { get; set; }
        public DbSet<User> user { get; set; }
    }
}
