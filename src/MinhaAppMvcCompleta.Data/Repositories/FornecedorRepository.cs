using Microsoft.EntityFrameworkCore;
using MinhaAppMvcCompleta.Business.Interfaces;
using MinhaAppMvcCompleta.Business.Models;
using MinhaAppMvcCompleta.Data.Contexts;

namespace MinhaAppMvcCompleta.Data.Repositories
{
    public class FornecedorRepository : Repository<Fornecedor>, IFornecedorRepository
    {
        public FornecedorRepository(MeuDbContext context) : base(context) { }

        public async Task<Fornecedor> ObterFornecedorEndereco(Guid id)
        {
            return await db.Fornecedores
                .AsNoTracking()
                .Include(e => e.Endereco)
                .FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<Fornecedor> ObterFornecedorEnderecoProdutos(Guid id)
        {
            return await db.Fornecedores
                .AsNoTracking()
                .Include(e => e.Endereco)
                .Include(p => p.Produtos)
                .FirstOrDefaultAsync(f => f.Id == id);                
        }
    }
}
