using Microsoft.AspNetCore.Mvc;

namespace NisanAspNetMVCEgitimi.Areas.Admin.Controllers
{
    public class MainController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
