using DepremProje.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DepremProje.Controllers
{
    public class LoginController : Controller
    {
        private Context c;
        public LoginController(Context _context)
        {
            c = _context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

		[HttpPost]
		public async Task<IActionResult> Index(Admin a)
		{
			var dataValue = c.Admins.FirstOrDefault(x => x.Kullanici ==
							a.Kullanici && x.Sifre == a.Sifre);
			if (dataValue != null)
			{
				var claims = new List<Claim>
				{
					new Claim(ClaimTypes.Name, a.Kullanici)
				};
				var useridentity = new ClaimsIdentity(claims, "Login");
				ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
				await HttpContext.SignInAsync(principal);
				return RedirectToAction("Index", "Talep");
			}
			return View();
		}

	}
}
