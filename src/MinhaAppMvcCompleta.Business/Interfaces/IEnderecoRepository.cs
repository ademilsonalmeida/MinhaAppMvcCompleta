using MinhaAppMvcCompleta.Business.Models;

namespace MinhaAppMvcCompleta.Business.Interfaces
{
    public interface IEnderecoRepository : IRepository<Endereco>
    {
        Task<Endereco> ObterEnderecoFornecedor(Guid forneceorId);
    }
}
