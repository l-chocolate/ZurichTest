using System.Collections.Generic;
using System.Linq;
using ZurichTest.Domain.Contratos;
using ZurichTest.Domain.Entidades;
using ZurichTest.Repository.Context;

namespace ZurichTest.Repository.Repositorios
{
    public class RepositorioSeguro : RepositorioBase<Seguro>, IRepositorioSeguro
    {
        public RepositorioSeguro(DatabaseContext databaseContext) : base(databaseContext)
        {
             
        }
        public IEnumerable<object> PegarTodosOsSeguros()
        {
            return this.PegarTodos().Select(seguro => new
            {
                seguro,
                Taxa_de_Risco = seguro.TaxaDeRisco(),
                Premio_de_Risco = seguro.PremioDeRisco(),
                Premio_Puro = seguro.PremioPuro(),
                Valor_do_Seguro = seguro.PremioComercial()
            });
        }
        public object PesquisarSeguroPorId(int id)
        {
            Seguro seguro = this.PesquisarPorId(id);
            return new { 
                seguro, 
                Taxa_de_Risco = seguro.TaxaDeRisco(),
                Premio_de_Risco = seguro.PremioDeRisco(),
                Premio_Puro = seguro.PremioPuro(),
                Valor_do_Seguro = seguro.PremioComercial() 
            };
        }
        public object RetornarMediaDosSeguros()
        {
            List<Seguro> seguros = this.PegarTodos().ToList();
            return new
            {
                Taxa_de_Risco = seguros.Average(a => a.TaxaDeRisco()),
                Premio_de_Risco = seguros.Average(a => a.PremioDeRisco()),
                Premio_Puro = seguros.Average(a => a.PremioPuro()),
                Valor_do_Seguro = seguros.Average(a => a.PremioComercial()),
            };
        }
    }
}
