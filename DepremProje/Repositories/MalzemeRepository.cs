using DepremProje.Models;

namespace DepremProje.Repositories
{
    public class MalzemeRepository : GenericRepository<Malzeme>
    {
        public MalzemeRepository(Context _context) : base(_context)
        {
        }
    }
}
