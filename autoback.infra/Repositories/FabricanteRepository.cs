using autoback.domain.Entities;
using autoback.domain.Interfaces;
using autoback.infra.Data;
using Microsoft.EntityFrameworkCore;

namespace autoback.infra.Repositories
{
    public class FabricanteRepository : IFabricanteRepository
    {
        private readonly AutobackContext _ctx;
        public FabricanteRepository(AutobackContext ctx) => _ctx = ctx;

        public Task<List<Fabricante>> GetAllAsync(CancellationToken ct) =>
            _ctx.Fabricantes.AsNoTracking().OrderBy(f => f.Nome).ToListAsync(ct);

        public Task<Fabricante?> GetByNomeAsync(string nome, CancellationToken ct) =>
            _ctx.Fabricantes.AsNoTracking().FirstOrDefaultAsync(f => f.Nome == nome, ct);

        public async Task AddAsync(Fabricante fabricante, CancellationToken ct) =>
            await _ctx.Fabricantes.AddAsync(fabricante, ct);

        public async Task<bool> SaveChangesAsync(CancellationToken ct) =>
            (await _ctx.SaveChangesAsync(ct)) > 0;
    }
}
