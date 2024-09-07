using Microsoft.EntityFrameworkCore;
using NisanAspNetMVCEgitimi.Models;

namespace NisanAspNetMVCEgitimi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews(); // Mvc deki Controller ve Viewlarýn çalýþmasý için gerekli ayar

            builder.Services.AddDbContext<UyeContext>(); // Projede entity framework kullanabilmek için gereki ayar
            // builder.Services.AddDbContext<UyeContext>(option => option.UseInMemoryDatabase("UyeDb")); // Projede gerçek veritabaný yerine cihaz belleðinde çalýþan sanal db kullanmamýzý saðlar.

            var app = builder.Build(); // Yukardaki ayarlarla bir uygulama örneði oluþtur

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment()) // Uygulama çalýþma ortamý IsDevelopment(Geliþtirme ortamý) deðilse
            {
                app.UseExceptionHandler("/Home/Error"); // Oluþan hatalarý yakala ve uygulamayý /Home/Error adresine yönlendir. (Home:Controller, Error:Action)
            }
            app.UseStaticFiles(); // Uygulamada statik dosyalarý, yani css, js, resim dosyalarýný vb çalýþtýrmayý destekle

            app.UseRouting(); // Uygulamada routing yapýsýný kullanarak controller ve action eþleþmelerini destekle

            app.UseAuthorization(); // Uygulamada yetkilendirmeyi aktif et

            app.MapControllerRoute( // Uygulamada varsayýlan Route yapýlandýrmasýný aktif et
                name: "default", // adý default olsun
                pattern: "{controller=Home}/{action=Index}/{id?}"); // Uygulamaya controller ve action belirtilmeden gelinirse varsayýlan olarak Home controller daki Index isimli action ý çalýþtýr. Burada id? parametresi ? ile parametrik olarak ifade edilmiþtir. Yani gelmeyedebilir.

            app.Run(); // Uygulamayý yukardaki tüm ayarlarý kullanarak çalýþtýr.
        }
    }
}
