using Microsoft.AspNetCore.Mvc;
using NisanAspNetMVCEgitimi.Models;

namespace NisanAspNetMVCEgitimi.Controllers
{
    public class MVC09ViewResultsController : Controller
    {
        private readonly UyeContext _context;

        public MVC09ViewResultsController(UyeContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult FarkliViewDondur()
        {
            return View("Index");
        }
        public IActionResult Yonlendir(string kelime)
        {
            // Bir action içerisinde farklı bir sayfaya yönlendirme yapabiliriz
            // return Redirect("/Home");
            // return Redirect($"/Home/Index?kelime={arananDeger}"); // ?kelime=telefon kısmı QueryString olarak geçer ve gittiği sayfada adres çubuğu üzerinden bu veriye ulaşıp sorgulama yapabiliriz.
            return Redirect("https://www.google.com.tr/"); // Redirect metoduyla başka bir siteye de yönlendirme yapabiliriz.
        }
        public IActionResult ActionaYonlendir()
        {
            // return RedirectToAction("Index");// metot çalıştığında aynı controllerdaki bir actiona yönlendirmemizi sağlar
            return RedirectToAction("Index", "Home"); // metot çalıştığında farklı bir controller daki actiona bu şekilde yönlendirebiliriz
        }
        public RedirectToRouteResult RouteYonlendir()
        {
            return RedirectToRoute("Default", new { controller = "Home", action = "Index", id = 18 });
        }
        public PartialViewResult KategorileriGetirPartial()
        {
            return PartialView("_KategorilerPartial");
        }
        public JsonResult JsonDondur()
        {
            var kullanicilar = _context.Uyeler.ToList(); // veritabanındaki üye listesini çek
            return Json(kullanicilar); // kullanıcıya json formatında döndür
        }
        public ContentResult XmlContentResult()
        {
            var kullanicilar = _context.Uyeler.ToList();
            var xml = "<kullanicilar>";
            foreach (var item in kullanicilar)
            {
                xml += $@"<kullanici>
                        <Id>{item.Id}</Id>
                        <Ad>{item.Ad}</Ad>
                        <Soyad>{item.Soyad}</Soyad>
                        <KullaniciAdi>{item.TcKimlikNo}</KullaniciAdi>
                        <Email>{item.DogumTarihi}</Email>
                    </kullanici>";
            }
            xml += "</kullanicilar>";
            return Content(xml, "application/xml");
        }
    }
}
