using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ZurichTest.Domain.Entidades
{
    [Table("Veiculo")]
    public class Veiculo : Entidade
    {
        public int Id { get; set; }
        public double Valor { get; set; }
        public string Modelo { get; set; }
        [JsonIgnore]
        public virtual ICollection<Seguro> Seguros { get; set; }
    }
}
