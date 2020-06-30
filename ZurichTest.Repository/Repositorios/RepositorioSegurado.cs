using ZurichTest.Domain.Contratos;
using ZurichTest.Domain.Entidades;
using ZurichTest.Repository.Context;

namespace ZurichTest.Repository.Repositorios
{
    public class RepositorioSegurado : RepositorioBase<Segurado>, IRepositorioSegurado
    {
        public RepositorioSegurado(DatabaseContext databaseContext) : base(databaseContext)
        {
        }
    }
}
