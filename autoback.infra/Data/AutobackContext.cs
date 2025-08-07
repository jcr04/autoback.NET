using autoback.domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace autoback.infra.Data
{
    public class AutobackContext : DbContext
    {
        public AutobackContext(DbContextOptions<AutobackContext> options) : base(options) { }
        public DbSet<Peca> Pecas => Set<Peca>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Peca>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Nome).IsRequired().HasMaxLength(120);
                entity.Property(p => p.Codigo).IsRequired().HasMaxLength(60);
                entity.HasIndex(p => p.Codigo).IsUnique();
                entity.Property(p => p.Preco).HasPrecision(10, 2);
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
