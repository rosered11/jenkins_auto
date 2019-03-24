using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DemoApp.DAL
{
    public abstract class ProductAbstact
    {
        [System.ComponentModel.DataAnnotations.Key]
        public string Name {get;set;}
    }
    [Table("Products")]
    public class Products : ProductAbstact{
        public string Size {get;set;}
        public string Color {get;set;}
        public string Price {get;set;}
        public ProductsMachine ProductMachine {get;set;}
    }
    [Table("ProductsMachine")]
    public class ProductsMachine : ProductAbstact
    {
        public int Clock {get;set;}
        public int CostPerClock {get;set;}
        public Products Product {get;set;}
    }
    internal class DatabaseContext : DbContext
    {
        public DbSet<Products> products {get;set;}
        public DbSet<ProductsMachine> productsMachines {get;set;}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=10.0.2.5,31433;Database=demo;User Id=sa;Password=pass@word1;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductsMachine>()
                .HasOne(p => p.Product)
                .WithOne(b => b.ProductMachine)
                .HasForeignKey<Products>(x => x.Name)
                .HasConstraintName("ForeignKey_ProductsMachine_Products");
        }
    }
}