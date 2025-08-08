namespace autoback.application.Pecas.DTOs
{
    public record PecaDto(int Id, string Nome, string Codigo, int Quantidade, decimal Preco,
                          string? CategoriaNome, string? FabricanteNome);
}
