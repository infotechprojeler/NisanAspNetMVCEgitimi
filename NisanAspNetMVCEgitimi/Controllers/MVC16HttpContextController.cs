using Microsoft.AspNetCore.Mvc;

namespace NisanAspNetMVCEgitimi.Controllers
{
    public class MVC16HttpContextController : Controller
    {
        public IActionResult Index()
        {
            var geriDonusAdresi = HttpContext.Request.Query["ReturnUrl"]; // : burada adres çubuğundaki ReturnUrl isimli QueryString nesnesini yakalayıp işleyebiliyoruz. Kullanıcıyı burada yer alan ekrana yönlendirmek için mesela.
            var urunAdi = HttpContext.Request.Query["UrunAdi"]; //: bu şekilde adres çubuğundan gönderilen ürün adını yakalayıp veritabanında eşleşen kayıtları bulup kullanıcıya ilgili ürünleri sunabiliriz.
            return View();
        }
    }
}
