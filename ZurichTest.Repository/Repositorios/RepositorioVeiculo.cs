using ZurichTest.Domain.Contratos;
using ZurichTest.Domain.Entidades;
using ZurichTest.Repository.Context;

namespace ZurichTest.Repository.Repositorios
{
    public class RepositorioVeiculo : RepositorioBase<Veiculo>, IRepositorioVeiculo
    {
        public RepositorioVeiculo(DatabaseContext databaseContext) : base(databaseContext)
        {
        }
    }
}
