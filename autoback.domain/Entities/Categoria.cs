namespace autoback.domain.Entities
{
    public class Categoria
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        private Categoria() { }
        public Categoria(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome)) throw new ArgumentException("Nome inválido");
            Nome = nome;
        }
    }
}
