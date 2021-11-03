using Microsoft.EntityFrameworkCore;
using MinhaAppMvcCompleta.Business.Interfaces;
using MinhaAppMvcCompleta.Business.Models;
using MinhaAppMvcCompleta.Data.Contexts;
using System.Linq.Expressions;

namespace MinhaAppMvcCompleta.Data.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly MeuDbContext db;
        protected readonly DbSet<TEntity> dbSet;

        public Repository(MeuDbContext context)
        {
            db = context;
            dbSet = db.Set<TEntity>();
        }

        public virtual async Task<TEntity> ObterId(Guid id)
        {
            return await dbSet.FindAsync(id);
        }

        public virtual async Task<IEnumerable<TEntity>> ObterTodos()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return await dbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task Adicionar(TEntity entity)
        {
            dbSet.Add(entity);
            await SaveChanges();
        }

        public virtual async Task Atualizar(TEntity entity)
        {
            dbSet.Update(entity);
            await SaveChanges();
        }

        public virtual async Task Remover(Guid id)
        {            
            dbSet.Remove(new TEntity { Id = id });
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await db.SaveChangesAsync();
        }

        public void Dispose()
        {
            db?.Dispose();
        }
    }
}
