using Microsoft.EntityFrameworkCore;

namespace SolvisoftAPI.Data
{
    public class ProductDbContext(DbContextOptions<ProductDbContext> options) : DbContext(options)
    {
        // creates a table for products
        public DbSet<Product> Products => Set<Product>();
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
            //seeder
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().HasData(
            //DateTime.now gives an error because the value cannot be evaluated at compile time
            new Product { ProductId = 1, Name = "Laptop", Price = 999.99m, Stock = 50, LastUpdated = new DateTime(2025, 8, 14, 0, 0, 0) },
            new Product { ProductId = 2, Name = "Smartphone", Price = 499.99m, Stock = 150, LastUpdated = new DateTime(2025, 8, 14, 0, 0, 0) },
            new Product { ProductId = 3, Name = "Tablet", Price = 399.99m, Stock = 100, LastUpdated = new DateTime(2025, 8, 14, 0, 0, 0) },
            new Product { ProductId = 4, Name = "Computer", Price = 1449.99m, Stock = 5, LastUpdated = new DateTime(2025, 8, 14, 0, 0, 0) },
            new Product { ProductId = 5, Name = "Monitor", Price = 160.00m, Stock = 34, LastUpdated = new DateTime(2025, 8, 14, 0, 0, 0) },
            new Product { ProductId = 6, Name = "Keyboard", Price = 89.99m, Stock = 0, LastUpdated = new DateTime(2025, 8, 14, 0, 0, 0) });

        } }
}
