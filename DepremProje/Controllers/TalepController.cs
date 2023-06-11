using DepremProje.Models;
using DepremProje.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DepremProje.Controllers
{
    public class TalepController : Controller
    {

		TalepRepository talepRepository;
        Context c;
		public TalepController(TalepRepository _talepRepository,Context _c)
		{
			talepRepository = _talepRepository;
            c = _c;
		}
		public IActionResult Index()
        {
            return View(talepRepository.TList());
        }
        [HttpGet]
        public IActionResult TalepEkle()
        {
            List<SelectListItem> values1 = (from x in c.Sehirs.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.SehirAdi,
                                               Value = x.SehirId.ToString()
                                           }).ToList();

            ViewBag.v1 = values1;

            List<SelectListItem> values2 = (from y in c.Ilces.ToList()
                                            select new SelectListItem
                                            {
                                                Text = y.IlceAdi,
                                                Value = y.IlceId.ToString()
                                            }).ToList();

            ViewBag.v2 = values2;

            List<SelectListItem> values3 = (from z in c.Malzemes.ToList()
                                            select new SelectListItem
                                            {
                                                Text = z.MalzemeAdi,
                                                Value = z.MalzemeId.ToString()
                                            }).ToList();

            ViewBag.v3 = values3;
            return View();
        }

        [HttpPost]
        public IActionResult TalepEkle(Talep t)
        {

            talepRepository.TAdd(t);
            return RedirectToAction("Index");
        }


        public IActionResult TalepGet(int id)
        {
            var x = talepRepository.TGet(id);
            List<SelectListItem> values1 = (from a in c.Sehirs.ToList()
                                            select new SelectListItem
                                            {
                                                Text = a.SehirAdi,
                                                Value = a.SehirId.ToString()
                                            }).ToList();

            ViewBag.v1 = values1;

            List<SelectListItem> values2 = (from y in c.Ilces.ToList()
                                            select new SelectListItem
                                            {
                                                Text = y.IlceAdi,
                                                Value = y.IlceId.ToString()
                                            }).ToList();

            ViewBag.v2 = values2;

            List<SelectListItem> values3 = (from z in c.Malzemes.ToList()
                                            select new SelectListItem
                                            {
                                                Text = z.MalzemeAdi,
                                                Value = z.MalzemeId.ToString()
                                            }).ToList();

            ViewBag.v3 = values3;
            Talep t = new Talep
            {
                TalepId = x.TalepId,
                KisiAdi = x.KisiAdi,
                KisiSoyadi = x.KisiSoyadi,
                KisiTC = x.KisiTC,
                KisiDogumTarihi = x.KisiDogumTarihi,
                SehirId = x.SehirId,
                IlceId = x.IlceId,
                TalepAcikAdresi = x.TalepAcikAdresi,
                MalzemeId = x.MalzemeId

            };
            return View("TalepGet", t);
        }

        [HttpPost]
        public IActionResult TalepGuncelle(Talep t)
        {
            var x = talepRepository.TGet(t.TalepId);
            x.TalepId = t.TalepId;
            x.KisiAdi = t.KisiAdi;
            x.KisiSoyadi=t.KisiSoyadi;
            x.KisiTC = t.KisiTC;
            x.KisiDogumTarihi = t.KisiDogumTarihi;
            x.SehirId = t.SehirId;
            x.IlceId = t.IlceId;
            x.TalepAcikAdresi=t.TalepAcikAdresi;
            x.MalzemeId = t.MalzemeId;
            x.Status = true;
            talepRepository.TUpdate(x);

            return RedirectToAction("Index");
        }

        public IActionResult TalepSil(int id)
        {
           // talepRepository.TDelete(new Talep { TalepId = id });
            var x = talepRepository.TGet(id);
            x.Status = false;
            talepRepository.TUpdate(x);
            return RedirectToAction("Index");
        }
    }
}
