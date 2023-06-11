using DepremProje.Models;

namespace DepremProje.Repositories
{
    public class KategoriRepository : GenericRepository<Kategori>
    {
        public KategoriRepository(Context _context) : base(_context)
        {
        }
    }
}
