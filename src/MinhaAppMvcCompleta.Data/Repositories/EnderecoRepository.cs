using Microsoft.EntityFrameworkCore;
using MinhaAppMvcCompleta.Business.Interfaces;
using MinhaAppMvcCompleta.Business.Models;
using MinhaAppMvcCompleta.Data.Contexts;

namespace MinhaAppMvcCompleta.Data.Repositories
{
    public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(MeuDbContext context) : base(context) { }

        public async Task<Endereco> ObterEnderecoFornecedor(Guid forneceorId)
        {
            return await db.Enderecos
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.FornecedorId == forneceorId);
        }
    }
}
