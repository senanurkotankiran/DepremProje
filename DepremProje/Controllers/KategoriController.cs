using DepremProje.Models;
using DepremProje.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DepremProje.Controllers
{
    public class KategoriController : Controller
    {
        KategoriRepository kategoriRepository;
        public KategoriController(KategoriRepository _kategoriRepository)
        {
            kategoriRepository = _kategoriRepository;
        }
        public IActionResult Index()
        {
            return View(kategoriRepository.TList());
        }

        [HttpGet]
        public IActionResult KategoriEkle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult KategoriEkle(Kategori k)
        {
            if (!ModelState.IsValid)
            {
                return View("KategoriEkle");
            }
            kategoriRepository.TAdd(k);
            return RedirectToAction("Index");
        }

        public IActionResult KategoriGet(int id)
        {
            var x = kategoriRepository.TGet(id);
            
            return View("KategoriGet", x);
        }

        [HttpPost]
        public IActionResult KategoriGuncelle(Kategori k)
        {
            var x = kategoriRepository.TGet(k.KategoriId);
            x.KategoriAdi = k.KategoriAdi;
            x.KategoriAciklamasi = k.KategoriAciklamasi;
            kategoriRepository.TUpdate(x);
            
            return RedirectToAction("Index");
        }



    }
}
