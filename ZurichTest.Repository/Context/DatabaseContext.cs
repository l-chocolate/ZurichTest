using Microsoft.EntityFrameworkCore;
using ZurichTest.Domain.Entidades;

namespace ZurichTest.Repository.Context
{
    public class DatabaseContext : DbContext
    {
        public virtual DbSet<Segurado> Segurados { get; set; }
        public virtual DbSet<Seguro> Seguros { get; set; }
        public virtual DbSet<Veiculo> Veiculos { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source = (localdb)\MSSQLLocalDB;Initial Catalog=ZurichTestDb; Integrated Security = True")
                .UseLazyLoadingProxies();
        }
    }
}
