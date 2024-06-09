using Model;
using Data;

namespace Service
{
    public class CompradorService
    {
        private readonly AppDbContext _context;

        public CompradorService(AppDbContext context)
        {
            _context = context;
        }
        
        public void Add(Comprador comprador)
        {
            _context.Compradores.Add(comprador);
            _context.SaveChanges();
        }
    }
}
