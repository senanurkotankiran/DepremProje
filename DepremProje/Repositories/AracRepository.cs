using DepremProje.Models;

namespace DepremProje.Repositories
{
    public class AracRepository : GenericRepository<Arac>
    {
        public AracRepository(Context _context) : base(_context)
        {
        }
    }
}
