using Microsoft.AspNetCore.Mvc;
using NisanAspNetMVCEgitimi.Models; // UyeContext namespace

namespace NisanAspNetMVCEgitimi.Controllers
{
    public class MVC12SessionController : Controller
    {
        private readonly UyeContext _context;

        public MVC12SessionController(UyeContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SessionOlustur(string kullaniciAdi, string sifre)
        {
            var kullanici = _context.Uyeler.FirstOrDefault(u => u.KullaniciAdi == kullaniciAdi && u.Sifre == sifre);
            if (kullanici != null)
            {
                HttpContext.Session.SetString("kullanici", kullaniciAdi); // sessionda SetString metoduyla string tipinde veri saklayabiliriz.
                HttpContext.Session.SetString("sifre", sifre);
                HttpContext.Session.SetInt32("IsLoggedIn", 1);// sessionda SetInt32 metoduyla int tipinde veri saklayabiliriz.
                HttpContext.Session.SetString("userguid", Guid.NewGuid().ToString());
                return RedirectToAction("SessionOku"); // işlem başarılıysa SessionOku sayfasına git
            }
            else
                TempData["Mesaj"] = @"<div class='alert alert-danger'>
                    Giriş Başarısız!
                </div>";
            return View("Index");
        }
        public IActionResult SessionOku()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SessionSil()
        {
            HttpContext.Session.Remove("userguid"); // userguid isimli session ı sil
            HttpContext.Session.Clear(); // tüm sessionları sil
            return RedirectToAction("Index");
        }
    }
}
