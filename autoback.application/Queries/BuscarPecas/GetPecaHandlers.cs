using autoback.application.Pecas.Queries;
using autoback.domain.Entities;
using autoback.domain.Interfaces;
using MediatR;

namespace autoback.application.Pecas.Handlers
{
    public class GetPecaByIdHandler : IRequestHandler<GetPecaByIdQuery, Peca?>
    {
        private readonly IPecaRepository _repo;
        public GetPecaByIdHandler(IPecaRepository repo) => _repo = repo;
        public Task<Peca?> Handle(GetPecaByIdQuery request, CancellationToken ct) =>
            _repo.GetByIdAsync(request.Id, ct);
    }

    public class GetPecasHandler : IRequestHandler<GetPecasQuery, List<Peca>>
    {
        private readonly IPecaRepository _repo;
        public GetPecasHandler(IPecaRepository repo) => _repo = repo;
        public Task<List<Peca>> Handle(GetPecasQuery request, CancellationToken ct) =>
            _repo.GetAllAsync(ct);
    }
}
