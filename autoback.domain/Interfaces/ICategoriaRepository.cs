using autoback.domain.Entities;

namespace autoback.domain.Interfaces
{
    public interface ICategoriaRepository
    {
        Task<List<Categoria>> GetAllAsync(CancellationToken ct);
        Task<Categoria?> GetByNomeAsync(string nome, CancellationToken ct);
        Task AddAsync(Categoria categoria, CancellationToken ct);
        Task<bool> SaveChangesAsync(CancellationToken ct);
    }
}
