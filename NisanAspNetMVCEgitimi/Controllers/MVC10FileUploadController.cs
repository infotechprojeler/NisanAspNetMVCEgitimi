using Microsoft.AspNetCore.Mvc;

namespace NisanAspNetMVCEgitimi.Controllers
{
    public class MVC10FileUploadController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(IFormFile? dosya) // Mvc de dosya yükleme IFormFile interface i ile yapılıyor. Burada dosya isminin ekrandaki file upload name i ile aynı olması gerekir yoksa dosya yüklenmez!
        {
            if (dosya is not null)
            {
                var uzanti = Path.GetExtension(dosya.FileName); // yüklenecek dosya uzantısı
                string klasor = Directory.GetCurrentDirectory() + "/wwwroot/Images/"; // dosyayı yükleyeceğimiz klasör
                var klasorVarmi = Directory.Exists(klasor);
                TempData["Message"] = "klasorVarmi : " + klasorVarmi;
                if (klasorVarmi == false) // eğer sunucuda bu konumda klasör yoksa
                {
                    var sonuc = Directory.CreateDirectory(klasor); // ana dizine Images klasörü oluştur
                    TempData["Message"] += " - Klasör Oluşturuldu.. " + sonuc;
                }
                if (uzanti == ".jpg" || uzanti == ".jpeg" || uzanti == ".png" || uzanti == ".gif") // Sadece bu uzantılardaki dosyaları kabul et
                {
                    using var stream = new FileStream(klasor + dosya.FileName, FileMode.Create); // Buradaki using ifadesi stream isimli değişkenin işinin bittikten sonra bellekten atılmasını sağlar
                    dosya.CopyTo(stream); // resmi asenkron olarak yükledik
                    TempData["Resim"] = dosya.FileName;
                }
                else TempData["message"] = "Sadece .jpg, .jpeg, .png, .gif Resimleri Yükleyebilirsiniz! ";
            }
            return View();
        }
        [HttpPost]
        public IActionResult ResimSil(string resimYolu)
        {
            if (System.IO.File.Exists(resimYolu))
            {
                System.IO.File.Delete(resimYolu);
                TempData["message"] = "Resim Silindi!";
                return RedirectToAction("Index");
            }
            return View("Index");
        }
    }
}
