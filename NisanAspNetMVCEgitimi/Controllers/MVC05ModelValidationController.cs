using Microsoft.AspNetCore.Mvc;
using NisanAspNetMVCEgitimi.Models; // Models klasöründeki classları kullanabilmek için bu satır gerekli!!!

namespace NisanAspNetMVCEgitimi.Controllers
{
    public class MVC05ModelValidationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult YeniUye()
        {
            return View();
        }
        [HttpPost]
        public IActionResult YeniUye(Uye uye)
        {
            if (ModelState.IsValid) // Eğer modeldeki validasyon kurallarına uyulmuşsa, tersi için !ModelState.IsValid
            {
                // burada gelen uye nesnesini veritabanına kaydedebiliriz.
            }
            else
            {
                ModelState.AddModelError("", "Lütfen Zorunlu Alanları Doldurunuz!");
            }
            return View(uye);
        }
    }
}
