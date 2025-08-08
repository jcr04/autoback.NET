using autoback.application.Pecas.DTOs;
using autoback.domain.Entities;
using Mapster;

namespace autoback.application.Common.Mapping
{
    public static class MapsterConfig
    {
        public static void Register()
        {
            TypeAdapterConfig<Peca, PecaDto>
                .NewConfig()
                .Map(dest => dest.CategoriaNome, src => src.Categoria!.Nome)
                .Map(dest => dest.FabricanteNome, src => src.Fabricante!.Nome);
        }
    }
}
