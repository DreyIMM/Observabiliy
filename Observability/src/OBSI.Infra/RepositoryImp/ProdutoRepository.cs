

using OBSI.Infra.Models;
using OBSI.Infra.Repository;

namespace OBSI.Infra.RepositoryImp
{
    public class ProdutoRepository : Repository<Produto>, IProduto
    {
        public ProdutoRepository(ProdutosContext context) : base(context) { }
    }
}
