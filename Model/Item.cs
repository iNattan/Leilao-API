using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Model
{
    public class Item
    {
        public Item() {}
        public Item(string descricao, double lanceInicial, double duracaoLeilao)
        {
            Descricao = descricao;
            Lance_Inicial = lanceInicial;            
            Duracao_Leilao = duracaoLeilao;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        public int IDItem { get; set; }
        public string Descricao { get; set; }
        public double Lance_Inicial { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        public DateTime Data_Hora_Cadastro { get; set; }
        public double Duracao_Leilao { get; set; }
    }
}