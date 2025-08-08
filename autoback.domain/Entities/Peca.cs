namespace autoback.domain.Entities
{
    public class Peca
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Codigo { get; private set; }
        public int Quantidade { get; private set; }
        public decimal Preco { get; private set; }
        public int CategoriaId { get; private set; }
        public Categoria? Categoria { get; private set; }
        public int FabricanteId { get; private set; }
        public Fabricante? Fabricante { get; private set; }

        // Construtor para criação
        public Peca(string nome, string codigo, int quantidade, decimal preco, int categoriaId, int fabricanteId)
        {
            if (string.IsNullOrWhiteSpace(nome)) throw new ArgumentException("Nome inválido.");
            if (string.IsNullOrWhiteSpace(codigo)) throw new ArgumentException("Código inválido.");
            if (quantidade < 0) throw new ArgumentException("Quantidade não pode ser negativa.");
            if (preco < 0) throw new ArgumentException("Preço não pode ser negativo.");

            Nome = nome;
            Codigo = codigo;
            Quantidade = quantidade;
            Preco = preco;
            CategoriaId = categoriaId;
            FabricanteId = fabricanteId;
        }

        // Construtor para EF
        private Peca() { }

        public void AtualizarPreco(decimal novoPreco)
        {
            if (novoPreco < 0) throw new ArgumentException("Preço não pode ser negativo.");
            Preco = novoPreco;
        }

        public void AdicionarEstoque(int quantidade)
        {
            if (quantidade <= 0) throw new ArgumentException("Quantidade deve ser positiva.");
            Quantidade += quantidade;
        }

        public void RemoverEstoque(int quantidade)
        {
            if (quantidade <= 0) throw new ArgumentException("Quantidade deve ser positiva.");
            if (quantidade > Quantidade) throw new InvalidOperationException("Estoque insuficiente.");
            Quantidade -= quantidade;
        }
    }
}
