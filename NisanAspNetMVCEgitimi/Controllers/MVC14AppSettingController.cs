using Microsoft.AspNetCore.Mvc;

namespace NisanAspNetMVCEgitimi.Controllers
{
    public class MVC14AppSettingController : Controller
    {
        private readonly IConfiguration _configuration; // appsettings.json dosyasına erişebilmek için gerekli nesne

        public MVC14AppSettingController(IConfiguration configuration)
        {
            _configuration = configuration; // yukardaki boş nesne burada dolduruluyor
        }
        public IActionResult Index()
        {
            ViewBag.MailinGidecegiAdres = _configuration["Email"];
            ViewBag.MailSunucu = _configuration["MailSunucu"];
            ViewBag.KullaniciAdi = _configuration["MailKullanici:Username"]; // iç içe verilere ulaşma yöntemi
            // ViewBag.Sifre = _configuration["MailKullanici:Password"]; // 1.yöntem
            ViewBag.Sifre = _configuration.GetSection("MailKullanici:Password").Value; // 2. yöntem
            return View();
        }
    }
}
