using DepremProje.Models;
using DepremProje.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace DepremProje.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        Context c;
        TalepRepository talepRepository;

        public HomeController(ILogger<HomeController> logger, Context _c, TalepRepository _talepRepository)
        {
            _logger = logger;
            c = _c;
            talepRepository = _talepRepository;
        }

        //public JsonResult Ilce_Gosterim(int id)
        //{
        //    var state = context.Ilces.Where(w=>w.SehirId == id);
        //    return Json(new SelectList(state,"IlceId","IlceAdi"));
        //}
        public IActionResult Index()
        {
            //ViewBag.Sehir = new SelectList(context.Sehirs.ToList(), "SehirId", "SehirAdi");

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
			return View();
        }


		[HttpPost]
		public IActionResult TalepEkle(Talep t)
		{
            talepRepository.TAdd(t);
			return RedirectToAction("Index");
		}

		//public JsonResult ilcegetir(int p)
		//{
		//    var ilceler = (from x in context.Ilces
		//                   join y in context.Sehirs on x.SehirId equals y.SehirId
		//                   where x.SehirId == p
		//                   select new
		//                   {
		//                       Text = x.IlceAdi,
		//                       Value = x.IlceId
		//                   }).ToList();
		//    return Json(ilceler, new Newtonsoft.Json.JsonSerializerSettings());
		//}
		public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}