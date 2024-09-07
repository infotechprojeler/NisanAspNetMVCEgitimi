using Microsoft.AspNetCore.Mvc;
using NisanAspNetMVCEgitimi.Models;

namespace NisanAspNetMVCEgitimi.Controllers
{
    public class MVC11CookieController : Controller
    {
        private readonly UyeContext _context;

        public MVC11CookieController(UyeContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CookieOlustur(string kullaniciAdi, string sifre)
        {
            var kullanici = _context.Uyeler.FirstOrDefault(u => u.KullaniciAdi == kullaniciAdi && u.Sifre == sifre);
            if (kullanici != null)
            {
                // tarayıcıda 1 cookie oluştur
                CookieOptions cookieOptions = new() // oluşacak cookie ayarlarını yapılandırmak istersek bunu kullanıyoruz
                {
                    Expires = DateTime.Now.AddMinutes(1),
                };
                Response.Cookies.Append("kullaniciAdi", kullaniciAdi, cookieOptions); // çerezi kaydet
                Response.Cookies.Append("sifre", sifre, cookieOptions); // çerezi kaydet
                HttpContext.Response.Cookies.Append("userguid", Guid.NewGuid().ToString()); // userguid isminde 1 çerez daha oluştur ve içinde o kullanıcıya özel şifreli bir değer sakla
                return RedirectToAction("CookieOku");
            }
            return View();
        }
    }
}
