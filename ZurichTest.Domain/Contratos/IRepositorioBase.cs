using System;
using System.Collections.Generic;

namespace ZurichTest.Domain.Contratos
{
    public interface IRepositorioBase<TEntity> : IDisposable where TEntity : class
    {
        void Adicionar(TEntity entity);
        void Atualizar(int id, TEntity entity);
        void Deletar(TEntity entity);
        TEntity PesquisarPorId(int id);
        IEnumerable<TEntity> PegarTodos();
    }
}
