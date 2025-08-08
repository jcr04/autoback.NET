namespace autoback.application.Pecas.DTOs
{
    public record CreatePecaRequest(string Nome, string Codigo, int Quantidade, decimal Preco, int CategoriaId, int FabricanteId);
}
