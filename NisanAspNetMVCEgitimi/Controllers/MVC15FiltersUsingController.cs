using Microsoft.AspNetCore.Authentication; // Oturum açmak için gerekli
using Microsoft.AspNetCore.Authorization; // Authorize attribute ünü kullanabilmek için
using Microsoft.AspNetCore.Mvc;
using NisanAspNetMVCEgitimi.Filters; // yazdığımız filtrenin usingi
using NisanAspNetMVCEgitimi.Models;
using System.Security.Claims;

namespace NisanAspNetMVCEgitimi.Controllers
{
    public class MVC15FiltersUsingController : Controller
    {
        private readonly UyeContext _context;

        public MVC15FiltersUsingController(UyeContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [UserControl] // FiltreKullanimi action ı çalıştığında usercontrol çalışır
        public IActionResult FiltreKullanimi()
        {
            return View();
        }
        [Authorize] // Authorize attribute ü altındaki action ı oturum açılmamışsa korur ve ekranın açılmasını engeller.
        public IActionResult UyeGuncelle(int? id)
        {
            if (id == null) // eğer adres çubuğundan id gönderilmezse
            {
                return BadRequest(); // geriye geçersiz istek hatası döndür.
            }
            Uye uye = _context.Uyeler.Find(id); // gönderilen id ye göre veritabanında arama yap
            if (uye == null) // eğer db de kayıt bulamazsan
                return NotFound(); // geriye not found - kayıt bulunamadı ekranı göster
            return View(uye);
        }
        [HttpPost]
        [Authorize]
        public IActionResult UyeGuncelle(int? id, Uye uye)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Uyeler.Update(uye);
                    _context.SaveChanges();
                }
                catch (Exception hata)
                {
                    ModelState.AddModelError("","Hata Oluştu!" + hata.Message);
                }
            }
            return View(uye);
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LoginAsync(Uye uye)
        {
            try
            {
                Uye admin = _context.Uyeler.FirstOrDefault(u => u.Email == uye.Email && u.Sifre == uye.Sifre); // 1.yöntem
                if (admin is not null)
                {
                    // Kullanıcıya giriş için vermek istediğimiz hakları tanımlıyoruz
                    var haklar = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Email, admin.Email),
                        new Claim(ClaimTypes.Role, "Admin")
                    };
                    // kullanıcıya kimlik tanımlıyoruz
                    var kullaniciKimligi = new ClaimsIdentity(haklar, "Login"); // kullanıcıya tanıdığımız hakları kimliğe işliyoruz
                    // kullanıcıya verdiğimiz kimlik ile tanımlı kurallardan oluşan nesne oluşturuyoruz
                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(kullaniciKimligi);
                    // Yetkilendirme ile sisteme girişi yapıyoruz
                    await HttpContext.SignInAsync(claimsPrincipal);
                    // Giriş sonrası tarayıcıda returnurl varsa 
                    if (!string.IsNullOrEmpty(HttpContext.Request.Query["ReturnUrl"]))
                    {
                        return Redirect(HttpContext.Request.Query["ReturnUrl"]); // kullanıcıyı ReturnUrl deki gitmek istediği adrese yönlendir
                    }
                    return RedirectToAction("Index"); // ReturnUrl yoksa anasayfaya yönlendir
                }
            }
            catch (Exception hata)
            {
                ModelState.AddModelError("", "Hata Oluştu!" + hata.Message);
            }
            ModelState.AddModelError("", "Giriş Başarısız!");
            return View(uye);
        }
        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Index");
        }
    }
}
