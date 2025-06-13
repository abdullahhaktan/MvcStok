using Microsoft.AspNetCore.Mvc;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class UrunController : Controller
    {
        private readonly MvcDbStokContext _mvcDbStokContext;
        public UrunController(MvcDbStokContext mvcDbStokContext)
        {
            _mvcDbStokContext = mvcDbStokContext;
        }

        public IActionResult Index()
        {
            var uruns = _mvcDbStokContext.Tblurunlers.Where(ktgr => ktgr.URUNDURUM == true).ToList();
            return View(uruns);
        }

        [HttpGet]
        public IActionResult YeniUrun()
        {
            return View();
        }

        [HttpPost]
        public IActionResult YeniUrun(Tblurunler urun)
        {
            urun.URUNDURUM = true;
            _mvcDbStokContext.Tblurunlers.Add(urun);
            _mvcDbStokContext.SaveChanges();
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

            return View(urn);
        }

        [HttpPost]
        public IActionResult UrunGuncelle(Tblurunler urn)
        {
            var prdct = _mvcDbStokContext.Tblurunlers.Find(urn.Urunid);
            prdct.Urunad = urn.Urunad;
            prdct.Stok = urn.Stok;
            prdct.Fİyat = urn.Fİyat;
            prdct.Marka = urn.Marka;
            prdct.Urunkategori = urn.Urunkategori;

            _mvcDbStokContext.Tblurunlers.Update(prdct);
            _mvcDbStokContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
