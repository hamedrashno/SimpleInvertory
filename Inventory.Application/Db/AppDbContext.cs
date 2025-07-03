
using Microsoft.Data.Sqlite;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Inventory.Application.Db.Entities;

namespace Inventory.Application.Db
{
    public class AppDbContext : DbContext
    {
        public DbSet<ProductEntity> Products => Set<ProductEntity>();
        public DbSet<CategoryEntity> Categories => Set<CategoryEntity>();
        public DbSet<UnitEntity> Units => Set<UnitEntity>();
        public DbSet<WarehouseEntity> Warehouses => Set<WarehouseEntity>();
        public DbSet<TransactionTypeEntity> TransactionTypes => Set<TransactionTypeEntity>();
        public DbSet<InvoiceEntity> Invoices => Set<InvoiceEntity>();
        public DbSet<StockTransactionEntity> StockTransactions => Set<StockTransactionEntity>();
        public DbSet<UserEntity> Users => Set<UserEntity>();

        public string DbPath { get; }

        public AppDbContext()
        {
            var dbFolder = Directory.GetCurrentDirectory();
            if (!Directory.Exists(dbFolder))
            {
                Directory.CreateDirectory(dbFolder);
            }

            DbPath = Path.Combine(dbFolder, "inventory.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }

        public override int SaveChanges()
        {
            SetDefaultValues();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            SetDefaultValues();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void SetDefaultValues()
        {
            var entries = ChangeTracker.Entries()
                .Where(e => e.Entity is BaseEntity && (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entry in entries)
            {
                var entity = (BaseEntity)entry.Entity;
                if (entry.State == EntityState.Added)
                {
                    if (entity.CreatedAt == default)
                        entity.CreatedAt = DateTime.UtcNow;
                    entity.IsActive = true;
                    entity.IsDeleted = false;
                }
            }
        } 
    }

}

// dotnet ef migrations add InitialCreate --output-dir "Db/Migrations"
// dotnet ef database update