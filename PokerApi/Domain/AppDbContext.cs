using Microsoft.EntityFrameworkCore;
using PokerApi.Model.Entities;

namespace PokerApi.Data
{
    public class AppDbContext : DbContext
    {
        public virtual DbSet<PlayerEntity> Players { get; set; }
        public virtual DbSet<PlaceEntity> Places { get; set; }
        public virtual DbSet<FinancialEntity> Financial { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlayerEntity>(entity => {
                entity.HasKey(e => new { e.Id });
                entity.Property(p => p.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<PlaceEntity>(entity => { 
                entity.HasKey(e => new { e.Id });
                entity.Property(p => p.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<FinancialEntity>(entity => { 
                entity.HasKey(e => new { e.PlaceId, e.PlayerId });
                entity.HasOne<PlayerEntity>().WithMany().HasForeignKey(fk => fk.PlayerId);
                entity.HasOne<PlaceEntity>().WithMany().HasForeignKey(fk => fk.PlaceId);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
