namespace DTO
{
    public class ItemLeilaoDTO
    {
        public ItemLeilaoDTO(int idItem, string descricao, double maiorLance, TimeSpan tempoRestante)
        {
            IDItem = idItem;
            Descricao = descricao;
            MaiorLance = maiorLance;
            TempoRestante = tempoRestante;
        }
        public int IDItem { get; set; }
        public string Descricao { get; set; }
        public double MaiorLance { get; set; }
        public TimeSpan TempoRestante { get; set; }
    }
}    