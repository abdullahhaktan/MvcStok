using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcStok.Models.Entity;
using X.PagedList.Extensions;

namespace MvcStok.Controllers
{
    public class UrunController : Controller
    {
        private readonly MvcDbStokContext _mvcDbStokContext;
        public UrunController(MvcDbStokContext mvcDbStokContext)
        {
            _mvcDbStokContext = mvcDbStokContext;
        }

        List<SelectListItem> kategoriFunk()
        {
            // Aktif kategorileri listele
            List<SelectListItem> deger1 = (from ktgr in _mvcDbStokContext.Tblkategorilers.Where(x => x.KATEGORIDURUM == true).ToList()
                                           select new SelectListItem
                                           {
                                               Text = ktgr.KATEGORIAD, // Kategori adı
                                               Value = ktgr.KATEGORIID.ToString() // Kategori ID'si
                                           }).ToList();
            return deger1; // Kategori listesini döndür
        }

        public IActionResult Index(string  arama ,int sayfa = 1)
        {
            if (!string.IsNullOrEmpty(arama))
            {
                var degerler = _mvcDbStokContext.Tblurunlers
                .Include(m=>m.UrunkategoriNavigation)
                .Where(m=> m.URUNDURUM==true)
                .Where(m => m.URUNAD.Contains(arama) || m.MARKA.Contains(arama) || m.STOK.ToString().Contains(arama) || m.FIYAT.ToString().Contains(arama)) // Filtreleme
                .OrderBy(m => m.URUNID) // Sıralama
                .ToPagedList(sayfa, 5); // Sayfalama

                return View(degerler);
            }
            else
            {
                var degerler = _mvcDbStokContext.Tblurunlers.Where(m=>m.URUNDURUM==true).OrderBy(m => m.URUNID).Include(m => m.UrunkategoriNavigation).ToPagedList(sayfa, 5);
                return View(degerler);
            }
        }

        [HttpGet]
        public IActionResult YeniUrun()
        {
            ViewBag.v1 = kategoriFunk();
            return View();
        }

        [HttpPost]
        public IActionResult YeniUrun(Tblurunler urun)
        {
            if (!ModelState.IsValid)
            {
                return View(urun); // Validation başarısızsa formu tekrar göster
            }

            urun.URUNDURUM = true;
            _mvcDbStokContext.Tblurunlers.Add(urun);
            _mvcDbStokContext.SaveChanges();

            TempData["SuccessMessage"] = "Ürün Basariyla eklendi";

            return RedirectToAction("Index");
        }

        public IActionResult UrunSil(int id)
        {
            var ktgr = _mvcDbStokContext.Tblurunlers.Find(id);
            ktgr.URUNDURUM = false;
            _mvcDbStokContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UrunGuncelle(int id)
        {
            var urn = _mvcDbStokContext.Tblurunlers.Find(id);
            ViewBag.v1 = kategoriFunk();
            return View(urn);
        }

        [HttpPost]
        public IActionResult UrunGuncelle(Tblurunler urn)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.v1 = kategoriFunk();
                return View(urn); // Validation başarısızsa formu tekrar göster
            }

            var prdct = _mvcDbStokContext.Tblurunlers.Find(urn.URUNID);
            prdct.URUNAD = urn.URUNAD;
            prdct.STOK = urn.STOK;
            prdct.FIYAT = urn.FIYAT;
            prdct.MARKA = urn.MARKA;
            prdct.URUNKATEGORI = urn.URUNKATEGORI;

            _mvcDbStokContext.Tblurunlers.Update(prdct);
            _mvcDbStokContext.SaveChanges();

            TempData["SuccessMessage"] = "Urun Basariyla eklendi";

            return RedirectToAction("Index");
        }
    }
}
