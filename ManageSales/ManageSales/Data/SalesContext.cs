using ManageSales.Models;
using Microsoft.EntityFrameworkCore;

namespace ManageSales.Data
{
    public class SalesContext: DbContext
    {
        public SalesContext(DbContextOptions<SalesContext> options) : base(options){
            
        }
		
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<OrderPriority> OrderPriorities { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
        public virtual DbSet<ProductContainer> ProductContainers { get; set; }
        public virtual DbSet<ProductSubCategory> ProductSubCategories { get; set; }
        public virtual DbSet<Province> Provinces { get; set; }
        public virtual DbSet<Region> Regions { get; set; }
        public virtual DbSet<Segment> Segments { get; set; }
        public virtual DbSet<ShipMode> ShipModes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().ToTable("Customer");
            modelBuilder.Entity<OrderPriority>().ToTable("OrderPriority");
            modelBuilder.Entity<Orders>().ToTable("Orders");
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<ProductCategory>().ToTable("ProductCategory");
            modelBuilder.Entity<ProductContainer>().ToTable("ProductContainer");
            modelBuilder.Entity<ProductSubCategory>().ToTable("ProductSubCategory");
            modelBuilder.Entity<Province>().ToTable("Province");
            modelBuilder.Entity<Region>().ToTable("Region");
            modelBuilder.Entity<Segment>().ToTable("Segment");
            modelBuilder.Entity<ShipMode>().ToTable("ShipMode");
        }

    }
}
