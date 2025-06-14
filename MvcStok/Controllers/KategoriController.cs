﻿using Microsoft.AspNetCore.Mvc;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class KategoriController : Controller
    {

        private readonly MvcDbStokContext _mvcDbStokContext;
        public KategoriController(MvcDbStokContext mvcDbStokContext)
        {
            _mvcDbStokContext = mvcDbStokContext;
        }

        public IActionResult Index()
        {
            var degerler = _mvcDbStokContext.Tblkategorilers.Where(ktgr=>ktgr.KATEGORIDURUM==true).ToList();
            return View(degerler);
        }

        [HttpGet]
        public IActionResult YeniKategori()
        {
            return View();
        }

        [HttpPost]
        public IActionResult YeniKategori(Tblkategoriler ktgr)
        {
            if (!ModelState.IsValid)
            {
                return View(ktgr); // Validation başarısızsa formu tekrar göster
            }

            ktgr.KATEGORIDURUM = true;
            _mvcDbStokContext.Tblkategorilers.Add(ktgr);
            _mvcDbStokContext.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult KategoriSil(short id)
        {
            var ktgr = _mvcDbStokContext.Tblkategorilers.Find(id);
            ktgr.KATEGORIDURUM = false;
            _mvcDbStokContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult KategoriGuncelle(short id)
        {
            var ktgr = _mvcDbStokContext.Tblkategorilers.Find(id);

            return View(ktgr);
        }

        [HttpPost]
        public IActionResult KategoriGuncelle(Tblkategoriler ktgr)
        {
            if (!ModelState.IsValid)
            {
                return View(ktgr); // Validation başarısızsa formu tekrar göster
            }

            var ctgr = _mvcDbStokContext.Tblkategorilers.Find(ktgr.KATEGORIID);

            ctgr.KATEGORIAD = ktgr.KATEGORIAD;

            _mvcDbStokContext.Tblkategorilers.Update(ctgr);

            _mvcDbStokContext.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
