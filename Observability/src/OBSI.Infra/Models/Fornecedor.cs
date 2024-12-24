using System.Diagnostics.CodeAnalysis;


namespace OBSI.Infra.Models
{
    public class Fornecedor
    {
        [NotNull]
        public Guid Id { get; set; } = Guid.NewGuid();

        [NotNull]
        public string Nome { get; set; } = string.Empty;

        public ICollection<Produto> Produtos { get; set; } = new List<Produto>();

    }
}
