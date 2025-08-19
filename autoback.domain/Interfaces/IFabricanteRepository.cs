using autoback.domain.Entities;

namespace autoback.domain.Interfaces
{
    public interface IFabricanteRepository
    {
        Task<List<Fabricante>> GetAllAsync(CancellationToken ct);
        Task<Fabricante?> GetByNomeAsync(string nome, CancellationToken ct);
        Task AddAsync(Fabricante fabricante, CancellationToken ct);
        Task<bool> SaveChangesAsync(CancellationToken ct);
    }
}
