using Microsoft.EntityFrameworkCore;
using MinhaAppMvcCompleta.Business.Interfaces;
using MinhaAppMvcCompleta.Business.Models;
using MinhaAppMvcCompleta.Data.Contexts;

namespace MinhaAppMvcCompleta.Data.Repositories
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(MeuDbContext context) : base (context) { }

        public async Task<Produto> ObterProdutoFornecedor(Guid id)
        {
            return await db.Produtos
                .AsNoTracking()
                .Include(f => f.Fornecedor)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Produto>> ObterProdutosFornecedor(Guid fornecedorId)
        {
            return await Buscar(p => p.FornecedorId == fornecedorId);
        }

        public async Task<IEnumerable<Produto>> ObterProdutosFornecedores()
        {            
            return await db.Produtos
                .AsNoTracking()
                .Include(f => f.Fornecedor)
                .OrderBy(p => p.Nome).ToListAsync();
        }
    }
}
