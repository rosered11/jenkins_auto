﻿// <auto-generated />
using DemoApp.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DemoApp.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("25620428083409_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DemoApp.DAL.Products", b =>
                {
                    b.Property<string>("Name")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Color");

                    b.Property<string>("Price");

                    b.Property<string>("Size");

                    b.HasKey("Name");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("DemoApp.DAL.ProductsMachine", b =>
                {
                    b.Property<string>("Name");

                    b.Property<int>("Clock");

                    b.Property<int>("CostPerClock");

                    b.HasKey("Name");

                    b.ToTable("ProductsMachine");
                });

            modelBuilder.Entity("DemoApp.DAL.ProductsMachine", b =>
                {
                    b.HasOne("DemoApp.DAL.Products", "Product")
                        .WithMany("ProductMachines")
                        .HasForeignKey("Name")
                        .HasConstraintName("ForeignKey_ProductsMachine_Products")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}