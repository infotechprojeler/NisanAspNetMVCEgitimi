using Microsoft.AspNetCore.Authorization; // güvenlik
using Microsoft.AspNetCore.Mvc;
using NisanAspNetMVCEgitimi.Models;

namespace NisanAspNetMVCEgitimi.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize]
    public class KullanicilarController : Controller
    {
        private readonly UyeContext _context;

        public KullanicilarController(UyeContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var model = _context.Uyeler.ToList();
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(Uye uye)
        {
            // Bir metodun içerisinde asenkron işlemler varsa (aşağıdaki kayıt ekleme işlemi gibi), metodun kendisi (Create metodu) de asenkron yapılır ve bir Task içerisine alınır.
            if (ModelState.IsValid)
            {
                try
                {
                    // senkron ekleme
                    //_context.Uyeler.Add(uye);
                    //var sonuc = _context.SaveChanges();
                    // Asenkron ekleme
                    await _context.Uyeler.AddAsync(uye);
                    var sonuc = await _context.SaveChangesAsync();
                    if (sonuc > 0)
                    {
                        TempData["Mesaj"] = "<div class='alert alert-primary'>Kayıt Eklendi</div>";
                        return RedirectToAction("Index");
                    }
                }
                catch (Exception hata)
                {
                    ModelState.AddModelError("", "Hata Oluştu!" + hata.Message);
                }
            }
            return View(uye);
        }
        
        public async Task<IActionResult> EditAsync(int id)
        {
            // Senkron kayıt arama
            // var model = _context.Uyeler.Find(id);

            // Asenkron kayıt arama
            var model = await _context.Uyeler.FindAsync(id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditAsync(Uye uye)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Uyeler.Update(uye);
                    var sonuc = await _context.SaveChangesAsync();
                    if (sonuc > 0)
                    {
                        TempData["Mesaj"] = "<div class='alert alert-success'>Kayıt Güncellendi</div>";
                        return RedirectToAction("Index");
                    }
                }
                catch (Exception hata)
                {
                    ModelState.AddModelError("", "Hata Oluştu!" + hata.Message);
                }
            }
            return View(uye);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var model = await _context.Uyeler.FindAsync(id);
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id, Uye uye)
        {
            _context.Uyeler.Remove(uye);
            var sonuc = await _context.SaveChangesAsync();
            if (sonuc > 0)
            {
                TempData["Mesaj"] = "<div class='alert alert-danger'>Kayıt Silindi</div>";
                return RedirectToAction("Index");
            }
            return View(uye);
        }
    }
}
