using OBSI.Infra.Models;

namespace OBSLI.Api.Shared
{
    public static class FornecedorExtensions
    {
        public static Fornecedor ToEntity(this FornecedorDTO fornecedorDto)
        {
            return new Fornecedor
            {
                Id = fornecedorDto.Id,
                Nome = fornecedorDto.Nome,
            };
        }
    }
}
