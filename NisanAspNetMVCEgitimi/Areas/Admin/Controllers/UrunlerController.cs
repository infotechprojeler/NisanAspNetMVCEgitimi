using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NisanAspNetMVCEgitimi.Models;
using System.Security.Cryptography;

namespace NisanAspNetMVCEgitimi.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize]
    public class UrunlerController : Controller
    {
        private readonly UyeContext _context;

        public UrunlerController(UyeContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> IndexAsync()
        {
            var model = await _context.Urunler.ToListAsync();
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(Urun urun, IFormFile? Resmi) // form içindeki file inputunun name kısmında Resmi yazdığı için buraya böyle yazdık, yoksa resim dosyasını yakalayamıyoruz!
        {
            if (ModelState.IsValid)
            {
                if (Resmi is not null)
                {
                    string klasor = Directory.GetCurrentDirectory() + "/wwwroot/Images/"; // dosyayı yükleyeceğimiz klasör
                    using var stream = new FileStream(klasor + Resmi.FileName, FileMode.Create);
                    Resmi.CopyTo(stream);
                    urun.Resmi = Resmi.FileName; // eklenecek olan ürünün resim bilgisi yüklenen dosyanın dosya adı olsun.
                }
                await _context.Urunler.AddAsync(urun);
                var sonuc = await _context.SaveChangesAsync();
                if (sonuc > 0)
                {
                    TempData["Mesaj"] = "<div class='alert alert-primary'>Kayıt Eklendi</div>";
                    return RedirectToAction("Index");
                }
            }
            return View(urun);
        }

        public IActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Edit(Urun urun, IFormFile? Resmi)
        {
            return View(urun);
        }
    }
}
