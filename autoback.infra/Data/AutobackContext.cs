using autoback.domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace autoback.infra.Data
{
    public class AutobackContext : DbContext
    {
        public AutobackContext(DbContextOptions<AutobackContext> options) : base(options) { }
        public DbSet<Peca> Pecas => Set<Peca>();
        public DbSet<Categoria> Categorias => Set<Categoria>();
        public DbSet<Fabricante> Fabricantes => Set<Fabricante>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(x => x.Nome).IsRequired().HasMaxLength(80);
            });

            modelBuilder.Entity<Fabricante>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(x => x.Nome).IsRequired().HasMaxLength(80);
            });

            modelBuilder.Entity<Peca>(e =>
            {
                e.HasKey(p => p.Id);
                e.Property(p => p.Nome).IsRequired().HasMaxLength(120);
                e.Property(p => p.Codigo).IsRequired().HasMaxLength(60);
                e.HasIndex(p => p.Codigo).IsUnique();
                e.Property(p => p.Preco).HasPrecision(10, 2);

                e.HasOne(p => p.Categoria)
                 .WithMany()
                 .HasForeignKey(p => p.CategoriaId)
                 .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(p => p.Fabricante)
                 .WithMany()
                 .HasForeignKey(p => p.FabricanteId)
                 .OnDelete(DeleteBehavior.Restrict);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}