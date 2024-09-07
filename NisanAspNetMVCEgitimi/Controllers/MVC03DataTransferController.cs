using Microsoft.AspNetCore.Mvc;
using NisanAspNetMVCEgitimi.Models;

namespace NisanAspNetMVCEgitimi.Controllers
{
    public class MVC03DataTransferController : Controller
    {
        public IActionResult Index(string txtAra) // Index metodunun varsayılan özelliği GET dir.
        {//Mvc de txtAra değişkeni get metduyla gönderilen veriyi yakalamamızı sağlar.
            // MVC de temel olarak 3 türde view a veri yollama yapısı var
            // Örneğin veritabanından ürün bilgisini çekip ekrana  yollamak için

            // 1- ViewBag : Tek Kullanımlık Ömrü Var
            ViewBag.UrunKategorisi = "Bilgisayar";
            // 2-Viewdata : Tek Kullanımlık Ömrü Var
            IList<Urun> urunListesi = new List<Urun>
            {
                new Urun() { Adi = "Oyun Bilgisayarı", Fiyati = 49000, Stok = 5 },
                new Urun() { Adi = "Laptop", Fiyati = 29000, Stok = 7 },
                new Urun() { Adi = "İş İstasyonu", Fiyati = 99000, Stok = 3 }
            };
            ViewData["Urunler"] = urunListesi;
            // 3-TempData : 2 Kullanımlık Ömrü Var
            TempData["UrunBilgi"] = "Toplam " + urunListesi.Count + " Ürün Bulundu..";

            ViewBag.GetVerisi = txtAra;
            return View();
        }
        [HttpPost] // Aşağıdaki metot sayfa post olduğunda çalışsın, get de çalışmasın.
        public IActionResult Index(string text1, string ddlListe, bool cbOnay, IFormCollection formCollection)
        {
            IList<Urun> urunListesi = new List<Urun>
            {
                new Urun() { Adi = "Oyun Bilgisayarı", Fiyati = 49000, Stok = 5 },
                new Urun() { Adi = "Laptop", Fiyati = 29000, Stok = 7 },
                new Urun() { Adi = "İş İstasyonu", Fiyati = 99000, Stok = 3 }
            };
            ViewData["Urunler"] = urunListesi;
            // 3-TempData : 2 Kullanımlık Ömrü Var
            TempData["UrunBilgi"] = "Toplam " + urunListesi.Count + " Ürün Bulundu..";

            ViewBag.Baslik1 = "1. Yöntem Parametreyle Veri Yakalama";
            ViewBag.Mesaj1 = "Textbox değeri : " + text1;
            ViewBag.Mesaj2 = "Dropdown değeri : " + ddlListe;
            ViewBag.Mesaj3 = "cbOnay değeri : " + cbOnay;

            ViewBag.Baslik2 = "2. Yöntem FormCollection İle Veri Yakalama";
            ViewBag.Mesaj4 = "Textbox değeri : " + formCollection["text1"];
            ViewBag.Mesaj5 = "Dropdown değeri : " + formCollection["ddlListe"];
            ViewBag.Mesaj6 = "cbOnay değeri : " + formCollection["cbOnay"][0];

            ViewBag.Baslik3 = "3. Yöntem Request Form İle Veri Yakalama";
            ViewBag.Mesaj7 = "Textbox değeri : " + Request.Form["text1"];
            ViewBag.Mesaj8 = "Dropdown değeri : " + Request.Form["ddlListe"];
            ViewBag.Mesaj9 = "cbOnay değeri : " + Request.Form["cbOnay"][0];

            return View();
        }
    }
}
