using SnapShop.Products.API.Models;
using Microsoft.EntityFrameworkCore;

namespace SnapShop.Products.API.Data
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Product configuration
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Description).HasMaxLength(500);
                entity.Property(e => e.Price).IsRequired().HasColumnType("decimal(18,2)");
                entity.Property(e => e.Stock).IsRequired();
                entity.Property(e => e.ImageUrl).HasMaxLength(255);
                entity.Property(e => e.CreatedAt).IsRequired();

                entity.HasOne(e => e.Category)
                      .WithMany(c => c.Products)
                      .HasForeignKey(e => e.CategoryId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasIndex(e => e.Name);
                entity.HasIndex(e => e.CategoryId);
            });

            // Category configuration
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Description).HasMaxLength(200);

                entity.HasIndex(e => e.Name).IsUnique();
            });

            // Seed data
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Electronics", Description = "Electronic devices and gadgets" },
                new Category { Id = 2, Name = "Clothing", Description = "Clothing and fashion items" },
                new Category { Id = 3, Name = "Books", Description = "Books and educational materials" },
                new Category { Id = 4, Name = "Home & Garden", Description = "Home improvement and garden items" }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "iPhone 15", Description = "Latest iPhone", Price = 999.99m, Stock = 50, CategoryId = 1, IsActive = true, CreatedAt = DateTime.UtcNow },
                new Product { Id = 2, Name = "Samsung Galaxy S24", Description = "Android smartphone", Price = 899.99m, Stock = 30, CategoryId = 1, IsActive = true, CreatedAt = DateTime.UtcNow },
                new Product { Id = 3, Name = "T-Shirt", Description = "Cotton t-shirt", Price = 19.99m, Stock = 100, CategoryId = 2, IsActive = true, CreatedAt = DateTime.UtcNow }
            );
        }
    }
}