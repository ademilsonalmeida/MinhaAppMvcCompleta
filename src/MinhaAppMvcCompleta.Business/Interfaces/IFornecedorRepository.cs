using MinhaAppMvcCompleta.Business.Models;

namespace MinhaAppMvcCompleta.Business.Interfaces
{
    public interface IFornecedorRepository : IRepository<Fornecedor>
    {
        Task<Fornecedor> ObterFornecedorEndereco(Guid id);
        Task<Fornecedor> ObterFornecedorEnderecoProdutos(Guid id);
    }
}
