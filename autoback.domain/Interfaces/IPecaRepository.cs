using autoback.domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autoback.domain.Interfaces;

    public interface IPecaRepository
{
    Task<Peca?> GetByIdAsync(int id, CancellationToken ct);
    Task<Peca?> GetByCodigoAsync(string codigo, CancellationToken ct);
    Task<List<Peca>> GetAllAsync(CancellationToken ct);
    Task AddAsync(Peca peca, CancellationToken ct);
    Task UpdateAsync(Peca peca, CancellationToken ct);
    Task DeleteAsync(Peca peca, CancellationToken ct);
    Task<bool> SaveChangesAsync(CancellationToken ct);
}


