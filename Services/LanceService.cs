using Model;
using Data;
using DTO;

namespace Service
{
    public class LanceService
    {
        private readonly AppDbContext _context;

        public LanceService(AppDbContext context)
        {
            _context = context;
        }
        
        public void Add(Lance lance)
        {
            var comprador = _context.Compradores.Find(lance.IDComprador);
            if (comprador == null)
                throw new Exception("Comprador não encontrado.");            

            var item = _context.Itens.Find(lance.IDItem);
            if (item == null)            
                throw new Exception("Item não encontrado.");            

            DateTime dataHoraCadastro = item.Data_Hora_Cadastro;
            double duracaoLeilaoHoras = item.Duracao_Leilao;
            DateTime dataFimLeilao = dataHoraCadastro.AddHours(duracaoLeilaoHoras);

            if (DateTime.Now > dataFimLeilao)        
                throw new Exception("O prazo do leilão expirou.");
            
            var ultimoLance = _context.Lances
                .Where(l => l.IDItem == lance.IDItem)
                .OrderByDescending(l => l.IDLance)
                .FirstOrDefault();

            if (ultimoLance == null )
            {
                if (lance.Valor <= item.Lance_Inicial)
                    throw new Exception("O valor do primeiro lance deve ser maior que o lance inicial do item.");
            }
            else
            {
                if (lance.Valor <= ultimoLance.Valor)
                    throw new Exception("O valor do lance deve ser maior que o lance anterior.");    
            }        
        
            _context.Lances.Add(lance);
            _context.SaveChanges();
        }

        public List<ItemLeilaoDTO> ListarItensEmLeilao()
        {
            var itensEmLeilao = _context.Itens
                .Where(item => DateTime.Now < item.Data_Hora_Cadastro.AddHours(item.Duracao_Leilao))
                .ToList();

            var resultado = new List<ItemLeilaoDTO>();

            foreach (var item in itensEmLeilao)
            {
                var maiorLance = _context.Lances
                    .Where(l => l.IDItem == item.IDItem)
                    .OrderByDescending(l => l.Valor)
                    .FirstOrDefault();

                var dataFimLeilao = item.Data_Hora_Cadastro.AddHours(item.Duracao_Leilao);
                var tempoRestante = dataFimLeilao - DateTime.Now;
                var ultimoLance = _context.Lances
                    .Where(l => l.IDItem == item.IDItem)
                    .OrderByDescending(l => l.IDLance)
                    .FirstOrDefault();                
                double maiorLanceValor = ultimoLance?.Valor ?? 0;
                Console.WriteLine("AAAAAAAAAAAAAAAAAAAAAAA", maiorLanceValor);

                var itemLeilaoDTO = new ItemLeilaoDTO(item.IDItem, item.Descricao, maiorLanceValor, tempoRestante);
                resultado.Add(itemLeilaoDTO);
            }

            return resultado;
        }
    }
}
