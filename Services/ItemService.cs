using Model;
using Data;

namespace Service
{
    public class ItemService
    {
        private readonly AppDbContext _context;

        public ItemService(AppDbContext context)
        {
            _context = context;
        }
        
        public void Add(Item item)
        {
            _context.Itens.Add(item);
            _context.SaveChanges();
        }
    }
}
