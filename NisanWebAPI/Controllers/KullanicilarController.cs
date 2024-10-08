﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NisanWebAPI.Models;

namespace NisanWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KullanicilarController : ControllerBase
    {
        private readonly UyeContext _context;

        public KullanicilarController(UyeContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Uye>>> GetAsync()
        {
            return await _context.Uyeler.ToListAsync();
        }

        [HttpGet("{id}")]
        public Uye Get(int id) // id li get geriye 1 tane kayıt döner
        {
            // return _context.Uyeler.Find(id); // Find ile 1 kayıt dönme
            return _context.Uyeler.FirstOrDefault(x => x.Id == id); // FirstOrDefault metodunda lambda expression kullanarak kayıt bulma.
        }

        [HttpPost]
        public Uye Post([FromBody] Uye value)
        {
            _context.Uyeler.Add(value);
            int sonuc = _context.SaveChanges();
            // return sonuc; // geriye int dönmek istersek
            return value;
        }

        //[HttpPut("{id}")]
        [HttpPut]
        public Uye Put([FromBody] Uye value)
        {
            _context.Uyeler.Update(value);
            int sonuc = _context.SaveChanges();
            // return sonuc; // geriye int dönmek istersek
            return value;
        }

        [HttpDelete("{id}")]
        public Uye Delete(int id)
        {
            var kayit = _context.Uyeler.Find(id);
            if (kayit != null)
            {
                _context.Uyeler.Remove(kayit);
            }
            int sonuc = _context.SaveChanges();
            return kayit;
        }
    }
}
