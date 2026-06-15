using Microsoft.EntityFrameworkCore;
using Refrigeracion.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Refrigeracion.DataAccess
{
    public class RefrigeracionDbContext : DbContext
    {
        public RefrigeracionDbContext(DbContextOptions<RefrigeracionDbContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<PendingJob> PendingJobs { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<SupplierPayment> SupplierPayments { get; set; }
        public DbSet<TaskItem> TaskItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasPrecision(18, 2);

            modelBuilder.Entity<SupplierPayment>()
                .Property(s => s.Amount)
                .HasPrecision(18, 2);

            modelBuilder.Entity<PendingJob>()
                .Property(p => p.Amount)
                .HasPrecision(18, 2);
        }
    }
}
