namespace API.Models
{
    public class Produto
    {
        public Produto()
        {
            Id = Guid.NewGuid().ToString();
            CriadoEm = DateTime.Now; // Corrigido para 'DateTime'
        }

        public string? Id { get; set; }

        public string? Nome { get; set; }

        public double Preco { get; set; }

        public int Quantidade { get; set; }

        public DateTime CriadoEm { get; set; }
    }
}
