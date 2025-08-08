namespace autoback.domain.Entities
{
    public class Fabricante
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        private Fabricante() { }
        public Fabricante(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome)) throw new ArgumentException("Nome inválido");
            Nome = nome;
        }
    }
}
