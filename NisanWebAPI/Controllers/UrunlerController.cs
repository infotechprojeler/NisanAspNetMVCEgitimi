using Microsoft.AspNetCore.Mvc;
using NisanWebAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NisanWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrunlerController : ControllerBase
    {
        private readonly UyeContext _context;

        public UrunlerController(UyeContext context)
        {
            _context = context;
        }
        // GET: api/<UrunlerController>
        [HttpGet]
        public IEnumerable<Urun> Get() // bu metot geriye ürün listesi döner
        {
            return _context.Urunler.ToList();
        }

        // GET api/<UrunlerController>/5
        [HttpGet("{id}")]
        public Urun Get(int id) // id li get geriye 1 tane ürün döner
        {
            // return _context.Urunler.Find(id); // Find ile 1 ürün dönme
            return _context.Urunler.FirstOrDefault(x => x.Id == id); // FirstOrDefault metodunda lambda expression kullanarak kayıt bulma.
        }

        // POST api/<UrunlerController>
        [HttpPost]
        public int Post([FromBody] Urun value)
        {
            _context.Urunler.Add(value);
            int sonuc = _context.SaveChanges();
            return sonuc;
        }

        // PUT api/<UrunlerController>/5
        [HttpPut("{id}")]
        public int Put(int id, [FromBody] Urun value)
        {
            _context.Urunler.Update(value);
            int sonuc = _context.SaveChanges();
            return sonuc;
        }

        // DELETE api/<UrunlerController>/5
        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            var kayit = _context.Urunler.Find(id);
            if (kayit != null)
            {
                _context.Remove(kayit);
            }
            int sonuc = _context.SaveChanges();
            return sonuc;
        }
    }
}
