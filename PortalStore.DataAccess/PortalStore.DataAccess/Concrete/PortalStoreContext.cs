using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PortalStore.Entity.Concrete.Entities;

namespace PortalStore.DataAccess.Concrete
{
    public class PortalStoreContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<SKU> Skus { get; set; }

        public PortalStoreContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("PortalStoreConnectionString"));
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries<BaseEntity>();

            foreach (var entry in entries)
            {
                _ = entry.State switch
                {
                    EntityState.Added => entry.Entity.CreatedDate = DateTime.Now,
                    EntityState.Modified => entry.Entity.ModifiedDate = DateTime.Now,
                    
                };
            }
           
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(a =>
            {
                a.ToTable("Addresses").HasKey(x => x.Id);
                a.Property(x => x.Id).HasColumnName("Id");
                a.Property(x => x.AddressLine).HasColumnName("AddressLine").HasColumnType("nvarchar").HasMaxLength(250);
                a.Property(x => x.Country).HasColumnName("Country").HasColumnType("nvarchar").HasMaxLength(30);
                a.Property(x => x.City).HasColumnName("City").HasColumnType("nvarchar").HasMaxLength(30);
                a.Property(x => x.District).HasColumnName("District").HasColumnType("nvarchar").HasMaxLength(30);
                a.Property(x => x.ZipCode).HasColumnName("ZipCode").HasColumnType("int");
                a.Property(x => x.CustomerId).HasColumnName("CustomerId");
                a.Property(x => x.Status).HasColumnName("Status").HasColumnType("bit");
                a.Property(x => x.CreatedDate).HasColumnName("CreatedDate").HasColumnType("datetime");
                a.Property(x => x.ModifiedDate).HasColumnName("ModifiedDate").HasColumnType("datetime");
                a.HasOne(x => x.Customer).WithMany(x => x.Addresses).OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Category>(a =>
            {
                a.ToTable("Categories").HasKey(x => x.Id);
                a.Property(x => x.Id).HasColumnName("Id");
                a.Property(x => x.Name).HasColumnName("Name").HasColumnType("nvarchar").HasMaxLength(50);
                a.Property(x => x.Status).HasColumnName("Status").HasColumnType("bit");
                a.Property(x => x.CreatedDate).HasColumnName("CreatedDate").HasColumnType("datetime");
                a.Property(x => x.ModifiedDate).HasColumnName("ModifiedDate").HasColumnType("datetime");
                a.HasMany(x => x.Skus);
            });

            modelBuilder.Entity<Customer>(a =>
            {
                a.ToTable("Customers").HasKey(x => x.Id);
                a.Property(x => x.Id).HasColumnName("Id");
                a.Property(x => x.FirstName).HasColumnName("FirstName").HasColumnType("nvarchar").HasMaxLength(50);
                a.Property(x => x.LastName).HasColumnName("LastName").HasColumnType("nvarchar").HasMaxLength(50);
                a.Property(x => x.Email).HasColumnName("Email").HasColumnType("nvarchar").HasMaxLength(150);
                a.Property(x => x.TCID).HasColumnName("TCID").HasColumnType("bigint").HasMaxLength(50);
                a.Property(x => x.Status).HasColumnName("Status").HasColumnType("bit");
                a.Property(x => x.BirthDate).HasColumnName("BirthDate").HasColumnType("datetime");
                a.Property(x => x.GSM).HasColumnName("GSM").HasColumnType("nvarchar").HasMaxLength(20);
                a.Property(x => x.CreatedDate).HasColumnName("CreatedDate").HasColumnType("datetime");
                a.Property(x => x.ModifiedDate).HasColumnName("ModifiedDate").HasColumnType("datetime");
                a.HasMany(x => x.Addresses).WithOne(x => x.Customer);
            });

            modelBuilder.Entity<Order>(a =>
            {
                a.ToTable("Orders").HasKey(x => x.Id);
                a.Property(x => x.Id).HasColumnName("Id");
                a.Property(x => x.CustomerId).HasColumnName("CustomerId");
                a.Property(x => x.AddressId).HasColumnName("AddressId");
                a.Property(x => x.TotalPrice).HasColumnName("TotalPrice").HasColumnType("decimal(16,2)");
                a.Property(x => x.Status).HasColumnName("Status").HasColumnType("bit");
                a.Property(x => x.CreatedDate).HasColumnName("CreatedDate").HasColumnType("datetime");
                a.Property(x => x.ModifiedDate).HasColumnName("ModifiedDate").HasColumnType("datetime");
                a.HasOne(x => x.Address).WithMany().OnDelete(DeleteBehavior.Cascade);
                a.HasOne(x => x.Customer).WithMany().OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<OrderItem>(a =>
            {
                a.ToTable("OrderItems").HasKey(x => x.Id);
                a.Property(x => x.Id).HasColumnName("Id");
                a.Property(x => x.SkuId).HasColumnName("SkuId");
                a.Property(x => x.OrderId).HasColumnName("OrderId");
                a.Property(x => x.UnitPrice).HasColumnName("UnitPrice").HasColumnType("decimal(16,2)");
                a.Property(x => x.Quantity).HasColumnName("Quantity");
                a.Property(x => x.Status).HasColumnName("Status").HasColumnType("bit");
                a.Property(x => x.CreatedDate).HasColumnName("CreatedDate").HasColumnType("datetime");
                a.Property(x => x.ModifiedDate).HasColumnName("ModifiedDate").HasColumnType("datetime");
                a.HasOne(x => x.Sku).WithOne().OnDelete(DeleteBehavior.Cascade);
                a.HasOne(x => x.Order).WithMany().OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<SKU>(a =>
            {
                a.ToTable("Skus").HasKey(x => x.Id);
                a.Property(x => x.Id).HasColumnName("Id");
                a.Property(x => x.Name).HasColumnName("Name").HasColumnType("nvarchar").HasMaxLength(50);
                a.Property(x => x.Description).HasColumnName("Description").HasColumnType("nvarchar").HasMaxLength(250);
                a.Property(x => x.OldPrice).HasColumnName("OldPrice").HasColumnType("decimal(16,2)");
                a.Property(x => x.Price).HasColumnName("Price").HasColumnType("decimal(16,2)");
                a.Property(x => x.CategoryId).HasColumnName("CategoryId");
                a.Property(x => x.Status).HasColumnName("Status").HasColumnType("bit");
                a.Property(x => x.CreatedDate).HasColumnName("CreatedDate").HasColumnType("datetime");
                a.Property(x => x.ModifiedDate).HasColumnName("ModifiedDate").HasColumnType("datetime");
                a.HasOne(x => x.Category).WithMany(x => x.Skus).OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}