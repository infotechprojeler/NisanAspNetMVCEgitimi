using Microsoft.AspNetCore.Mvc;
using NisanAspNetMVCEgitimi.Models;

namespace NisanAspNetMVCEgitimi.Controllers
{
    public class MVC04ModelBindingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult KullaniciDetay()
        {
            Kullanici kullanici = new Kullanici() // sayfada kullanacağımız model nesnemiz
            {
                Ad = "Murat",
                Soyad = "Yılmaz",
                Email = "info@yoneciti.com",
                KullaniciAdi = "murat",
                Sifre = "123456"
            };
            return View(kullanici); // sayfada model kullanıyorsak bu şekilde model nesnesini sayfaya gönderiyoruz.
        }
        [HttpPost]
        public IActionResult KullaniciDetay(Kullanici kullanici)// Burada belirttiğimiz kullanici nesnesi view sayfasındaki model kullanan form içerisindeki verileri model binding yöntemiyle yakalıyor.
        {
            // burada istersek ekrandan gelen kullanıcıyı veritabanına kaydedebiliriz.
            return View(kullanici); // Post işleminden sonra metoda parametreyle gelen kullanici nesnesini tekrar ekrana gönder
        }
        public IActionResult AdresDetay()
        {
            var model = new Adres { Ilce = "Suşehri", Sehir = "Sivas", AcikAdres = "Menekşe Sokak No:18" };
            return View(model);
        }
        [HttpPost]
        public IActionResult AdresDetay(Adres model) // burada önemli olan Adres sınıfını kullanmak, sonrasındaki isim değişken ismi, dolayısıyla model, adres, vb kullanabiliriz.
        {
            // burada gönderilen adresi kaydedebiliriz.
            return View(model);
        }
        public IActionResult UyeSayfasi()
        {
            Kullanici kullanici = new Kullanici() // sayfada kullanacağımız model nesnemiz
            {
                Ad = "Murat",
                Soyad = "Yılmaz",
                Email = "info@yoneciti.com",
                KullaniciAdi = "murat",
                Sifre = "123456"
            };
            var adres = new Adres { Ilce = "Suşehri", Sehir = "Sivas", AcikAdres = "Menekşe Sokak No:18" };
            var model = new UyeSayfasiViewModel()
            {
                Adres = adres,
                Kullanici = kullanici
            };
            return View(model);
        }
    }
}
