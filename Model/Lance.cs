using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Model
{
    public class Lance
    {
        public Lance() {}
        public Lance(int idComprador, int idItem, double valor)
        {
            IDComprador = idComprador;
            IDItem = idItem;
            Valor = valor;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        public int IDLance { get; set; }
        public int IDComprador { get; set; }
        public int IDItem { get; set; }
        public double Valor { get; set; }
    }
}