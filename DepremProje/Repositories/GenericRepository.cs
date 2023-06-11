using DepremProje.Models;
using Microsoft.EntityFrameworkCore;

namespace DepremProje.Repositories
{
    public class GenericRepository<T> where T : class , new()
    {
        private Context c;
        public GenericRepository(Context _context)
        {
            c = _context;
        }


        public List<T> TList()
        {
            return c.Set<T>().ToList();
        }

        public void TAdd(T entity)
        {
            c.Set<T>().Add(entity);
            c.SaveChanges();
        }

        public void TDelete(T entity)
        {
            c.Set<T>().Remove(entity);
            c.SaveChanges();
        }

        public void TUpdate(T entity)
        {
            c.Set<T>().Update(entity);
            c.SaveChanges();
        }

        public T TGet(int id)
        {
            return c.Set<T>().Find(id);
        }

        public List<T> TList(string p)
        {
            return c.Set<T>().Include(p).ToList();
        }
    }
}
