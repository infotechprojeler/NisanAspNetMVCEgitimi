using Microsoft.AspNetCore.Mvc;

namespace NisanAspNetMVCEgitimi.Controllers
{
    public class AnasayfaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Hakkimizda() // 1 controller da 1 den fazla action tanımlayabiliyoruz
        {
            return View(); // Burada Views Altında Hakkimizda adında bir view bekler
        }
        public IActionResult Ders12OrnekTasarim()
        {
            return View();
        }
    }
}
