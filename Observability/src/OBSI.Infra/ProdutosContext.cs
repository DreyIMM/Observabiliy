using Microsoft.EntityFrameworkCore;
using OBSI.Infra.Models;

namespace OBSI.Infra
{
    public class ProdutosContext : DbContext
    {
        public ProdutosContext() : base() { }
        public ProdutosContext(DbContextOptions<ProdutosContext> options) : base(options) { }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Fornecedor> Fornecedors { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        => modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProdutosContext).Assembly);

    }
}
