using OBSI.Infra.Models;
using OBSI.Infra.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBSI.Infra.RepositoryImp
{
    public class FornecedorRepository : Repository<Fornecedor>, IFornecedor
    {
        public FornecedorRepository(ProdutosContext db) : base(db) { }


    }
}
