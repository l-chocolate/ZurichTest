using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ZurichTest.Domain.Entidades
{
    [Table("Segurado")]
    public class Segurado : Entidade
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public int Idade { get; set; }
        [JsonIgnore]
        public virtual ICollection<Seguro> Seguros { get; set; }
    }
}
