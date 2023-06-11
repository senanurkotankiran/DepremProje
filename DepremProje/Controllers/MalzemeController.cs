using DepremProje.Models;
using DepremProje.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DepremProje.Controllers
{
    public class MalzemeController : Controller
    {
        MalzemeRepository malzemeRepository;
        Context c;

        public MalzemeController(MalzemeRepository _malzemeRepository, Context _c)
        {
            malzemeRepository = _malzemeRepository;
            c = _c; 
        }

        public IActionResult Index()
        {
            return View(malzemeRepository.TList());
        }

        [HttpGet]
        public IActionResult MalzemeEkle()
        {
            List<SelectListItem> values = (from x in c.Kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KategoriAdi,
                                               Value = x.KategoriId.ToString()
                                           }).ToList();

            ViewBag.v1 = values;
            return View();
        }

        [HttpPost]
        public IActionResult MalzemeEkle(Malzeme m)
        {
            
            malzemeRepository.TAdd(m);
            return RedirectToAction("Index");
        }
        public IActionResult MalzemeGet(int id)
        {
            var x = malzemeRepository.TGet(id);
            List<SelectListItem> values = (from y in c.Kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = y.KategoriAdi,
                                               Value = y.KategoriId.ToString()
                                           }).ToList();

            ViewBag.v1 = values;
            Malzeme m = new Malzeme
            {
                MalzemeId = x.MalzemeId,
                MalzemeAdi = x.MalzemeAdi,
                KategoriId = x.KategoriId,
                MalzemeStokAdedi = x.MalzemeStokAdedi,
                MalzemeAciklamasi = x.MalzemeAciklamasi
            };
            return View("MalzemeGet", m);
        }

        [HttpPost]
        public IActionResult MalzemeGuncelle(Malzeme m)
        {
            var x = malzemeRepository.TGet(m.MalzemeId);
            x.MalzemeAdi = m.MalzemeAdi;
            x.KategoriId = m.KategoriId;
            x.MalzemeStokAdedi = m.MalzemeStokAdedi;
            x.MalzemeAciklamasi = m.MalzemeAciklamasi;
            malzemeRepository.TUpdate(x);

            return RedirectToAction("Index");
        }

        public IActionResult MalzemeSil(int id)
        {
            malzemeRepository.TDelete(new Malzeme { MalzemeId = id });
            return RedirectToAction("Index");
        }

    }
}
