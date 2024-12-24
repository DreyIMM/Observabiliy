

using System.Diagnostics.CodeAnalysis;

namespace OBSI.Infra.Models
{
    public class Produto
    {
        [NotNull]
        public string Nome { get; set; } = string.Empty;

        [NotNull]
        public string Descricao { get; set; } = string.Empty;

        public double Valor { get; set; }

        [NotNull]
        public Guid Id { get; set; }

        public Guid FornecedorId { get; set; }

        [NotNull]
        public Fornecedor Fornecedor { get; set; } = null!;

    }
}
