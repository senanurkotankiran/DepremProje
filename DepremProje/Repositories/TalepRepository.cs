using DepremProje.Models;

namespace DepremProje.Repositories
{
    public class TalepRepository : GenericRepository<Talep>
    {
        public TalepRepository(Context _context) : base(_context)
        {
        }
    }
}
