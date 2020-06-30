using System.Collections.Generic;
using System.Linq;
using ZurichTest.Domain.Contratos;
using ZurichTest.Repository.Context;

namespace ZurichTest.Repository.Repositorios
{
    public class RepositorioBase<TEntity> : IRepositorioBase<TEntity> where TEntity : class
    {
        private DatabaseContext databaseContext;
        public RepositorioBase(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }
        public void Adicionar(TEntity entity)
        {
            databaseContext.Add<TEntity>(entity);
            databaseContext.SaveChanges();
        }

        public void Atualizar(int id, TEntity entity)
        {
            databaseContext.Entry<TEntity>(PesquisarPorId(id)).CurrentValues.SetValues(entity);
            databaseContext.SaveChanges();
        }

        public void Deletar(TEntity entity)
        {
            databaseContext.Remove<TEntity>(entity);
            databaseContext.SaveChanges();
        }

        public void Dispose()
        {
            databaseContext.Dispose();
        }

        public IEnumerable<TEntity> PegarTodos()
        {
            return databaseContext.Set<TEntity>().ToList();
        }

        public TEntity PesquisarPorId(int id)
        {
            return databaseContext.Find<TEntity>(id);
        }
    }
}
