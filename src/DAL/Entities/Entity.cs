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
        public List<ProductsMachine> ProductMachines {get;set;}
    }
    [Table("ProductsMachine")]
    public class ProductsMachine : ProductAbstact
    {
        public int Clock {get;set;}
        public int CostPerClock {get;set;}
        public Products Product {get;set;}
    }
    public class DatabaseContext : DbContext
    {
        private readonly string connection;
        public DatabaseContext(){
            this.connection = "Server=127.0.0.1,31433;Database=demo;User Id=sa;Password=pass@word1;";
        }
        public DatabaseContext(DbContextOptions<DatabaseContext> options):base(options)
        {
        }
        public DbSet<Products> products {get;set;}
        public DbSet<ProductsMachine> productsMachines {get;set;}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warni To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                //optionsBuilder.UseSqlServer(connection);
                optionsBuilder.UseSqlServer("Server=127.0.0.1,31433;Database=demo;User Id=sa;Password=pass@word1;");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // modelBuilder.Entity<ProductsMachine>()
            //     .HasOne(p => p.Product)
            //     .WithMany(b => b.ProductMachine)
            //     .HasForeignKey<Products>(x => x.Name)
            //     .HasConstraintName("ForeignKey_ProductsMachine_Products");
            modelBuilder.Entity<Products>()
                    .HasMany(p=>p.ProductMachines)
                    .WithOne(b=>b.Product)
                    .HasForeignKey(x=>x.Name)
                    .HasConstraintName("ForeignKey_ProductsMachine_Products");
        }
    }
}