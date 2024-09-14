using Microsoft.AspNetCore.Mvc;

namespace NisanAspNetMVCEgitimi.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UrunlerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
