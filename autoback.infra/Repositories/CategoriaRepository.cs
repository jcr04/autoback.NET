using autoback.domain.Entities;
using autoback.domain.Interfaces;
using autoback.infra.Data;
using Microsoft.EntityFrameworkCore;

namespace autoback.infra.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AutobackContext _ctx;
        public CategoriaRepository(AutobackContext ctx) => _ctx = ctx;

        public Task<List<Categoria>> GetAllAsync(CancellationToken ct) =>
            _ctx.Categorias.AsNoTracking().OrderBy(c => c.Nome).ToListAsync(ct);

        public Task<Categoria?> GetByNomeAsync(string nome, CancellationToken ct) =>
            _ctx.Categorias.AsNoTracking().FirstOrDefaultAsync(c => c.Nome == nome, ct);

        public async Task AddAsync(Categoria categoria, CancellationToken ct) =>
            await _ctx.Categorias.AddAsync(categoria, ct);

        public async Task<bool> SaveChangesAsync(CancellationToken ct) =>
            (await _ctx.SaveChangesAsync(ct)) > 0;
    }
}
