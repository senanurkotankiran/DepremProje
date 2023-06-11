using DepremProje.Models;
using DepremProje.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DepremProje.Controllers
{
    public class AracController : Controller
    {
        AracRepository aracRepository;
        Context context;

        public AracController(AracRepository _aracRepository, Context _context)
        {
            aracRepository = _aracRepository;
            context = _context;
        }

        public IActionResult Index()
        {
            return View(aracRepository.TList());
        }

        [HttpGet]
        public IActionResult AracEkle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AracEkle(Arac a)
        {
            aracRepository.TAdd(a);
            return RedirectToAction("Index");
        }

        public IActionResult AracGet(int id)
        {
            var x = aracRepository.TGet(id);
            return View("AracGet",x);
        }

        [HttpPost]
        public IActionResult AracGuncelle(Arac a)
        {
            var x = aracRepository.TGet(a.AracId);
            x.AracId = a.AracId;
            x.AracPlaka = a.AracPlaka;
            x.AracOzellikleri = a.AracOzellikleri;
            aracRepository.TUpdate(x);
            return RedirectToAction("Index");
        }

        public IActionResult AracSil(int id)
        {
            aracRepository.TDelete(new Arac { AracId = id });
            return RedirectToAction("Index");
        }
    }
}
