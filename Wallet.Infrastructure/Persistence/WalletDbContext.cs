using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities = Wallet.Domain.Entities;

namespace Wallet.Infrastructure.Persistence
{
    public class WalletDbContext : DbContext
    {
        public WalletDbContext(DbContextOptions<WalletDbContext> options) : base(options)
        {
        }

        public DbSet<Entities.Wallet> Wallets => Set<Entities.Wallet>();
        public DbSet<Entities.Movement> Movements => Set<Entities.Movement>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración opcional con Fluent API
            modelBuilder.Entity<Entities.Wallet>(entity =>
            {
                entity.HasKey(w => w.Id);
                entity.Property(w => w.Name).IsRequired().HasMaxLength(100);
                entity.Property(w => w.DocumentId).IsRequired().HasMaxLength(50);
                entity.Property(w => w.Balance).HasColumnType("decimal(18,2)");
            });

            modelBuilder.Entity<Entities.Movement>(entity =>
            {
                entity.HasKey(m => m.Id);
                entity.Property(m => m.Amount).HasColumnType("decimal(18,2)");
                entity.HasOne(m => m.Wallet)
                      .WithMany(w => w.Movements)
                      .HasForeignKey(m => m.WalletId);
            });
        }
    }
}
