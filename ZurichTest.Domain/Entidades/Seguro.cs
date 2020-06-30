using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ZurichTest.Domain.Entidades
{
    [Table("Seguro")]
    public class Seguro : Entidade
    {
        public int Id { get; set; }
        public int IdSegurado { get; set; }
        public int IdVeiculo { get; set; }
        [ForeignKey("IdSegurado")]
        public virtual Segurado Segurado { get; set; }
        [ForeignKey("IdVeiculo")]
        public virtual Veiculo Veiculo { get; set; }
        [NotMapped()]
        private static double MargemSeguranca = 0.03;
        [NotMapped()]
        private static double Lucro = 0.05;
        public double TaxaDeRisco()
        {
            return ((Veiculo.Valor * 5) / (2 * Veiculo.Valor))/100;
        }
        public double PremioDeRisco()
        {
            return TaxaDeRisco() * Veiculo.Valor;
        }
        public double PremioPuro()
        {
            return PremioDeRisco() * (1 + MargemSeguranca);
        }
        public double PremioComercial()
        {
            double ValorDePremioPuro = PremioPuro();
            return (Lucro * ValorDePremioPuro) + ValorDePremioPuro;
        }
    }
}
