using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Model
{
    public class Comprador
    {
        public Comprador(string nome)
        {
            Nome = nome;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        public int IDComprador { get; set; }
        public string Nome { get; set; }
    }
}