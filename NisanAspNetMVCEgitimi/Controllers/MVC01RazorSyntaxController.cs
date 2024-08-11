using Microsoft.AspNetCore.Mvc;

namespace NisanAspNetMVCEgitimi.Controllers
{
    public class MVC01RazorSyntaxController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
