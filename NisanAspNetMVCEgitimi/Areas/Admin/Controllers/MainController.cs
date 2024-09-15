using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NisanAspNetMVCEgitimi.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize] // aşağıdaki controller admin altında çalışsın
    public class MainController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Index");
        }
    }
}
