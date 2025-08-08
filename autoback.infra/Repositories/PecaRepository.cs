
using autoback.domain.Entities;
using autoback.domain.Interfaces;
using autoback.infra.Data;
using Microsoft.EntityFrameworkCore;

namespace autoback.infra.Repositories
{
    public class PecaRepository : IPecaRepository
    {
        private readonly AutobackContext _ctx;
        public PecaRepository(AutobackContext ctx) => _ctx = ctx;

        public Task<Peca?> GetByIdAsync(int id, CancellationToken ct) =>
            _ctx.Pecas.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id, ct);

        public Task<Peca?> GetByCodigoAsync(string codigo, CancellationToken ct) =>
            _ctx.Pecas.AsNoTracking().FirstOrDefaultAsync(p => p.Codigo == codigo, ct);

        public Task<List<Peca>> GetAllAsync(CancellationToken ct) =>
            _ctx.Pecas.AsNoTracking().OrderBy(p => p.Nome).ToListAsync(ct);

        public async Task AddAsync(Peca peca, CancellationToken ct) =>
            await _ctx.Pecas.AddAsync(peca, ct);

        public Task UpdateAsync(Peca peca, CancellationToken ct)
        {
            _ctx.Pecas.Update(peca);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(Peca peca, CancellationToken ct)
        {
            _ctx.Pecas.Remove(peca);
            return Task.CompletedTask;
        }

        public async Task<bool> SaveChangesAsync(CancellationToken ct) =>
            (await _ctx.SaveChangesAsync(ct)) > 0;

        public Task<List<Peca>> GetAllPagedAsync(int page, int pageSize, CancellationToken ct) =>
    _ctx.Pecas.AsNoTracking()
        .Include(p => p.Categoria)
        .Include(p => p.Fabricante)
        .OrderBy(p => p.Nome)
        .Skip((page - 1) * pageSize)
        .Take(pageSize)
        .ToListAsync(ct);

        public Task<int> CountAsync(CancellationToken ct) =>
            _ctx.Pecas.AsNoTracking().CountAsync(ct);

        public Task<Peca?> GetByIdWithRefsAsync(int id, CancellationToken ct) =>
            _ctx.Pecas.AsNoTracking()
                .Include(p => p.Categoria)
                .Include(p => p.Fabricante)
                .FirstOrDefaultAsync(p => p.Id == id, ct);
    }
}
