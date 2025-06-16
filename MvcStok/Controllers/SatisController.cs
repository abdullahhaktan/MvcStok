using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class SatisController : Controller
    {
        private readonly MvcDbStokContext _db;
        public SatisController(MvcDbStokContext db)
        {
            _db = db;
        }

        List<SelectListItem> musteriFunk()
        {
            // Aktif kategorileri listele
            List<SelectListItem> mstrList = (from cstmr in _db.Tblmusterilers.ToList()
                                           select new SelectListItem
                                           {
                                               Text = cstmr.MUSTERIAD + " " +cstmr.MUSTERISOYAD, // Kategori adı
                                               Value = cstmr.MUSTERIID.ToString() // Kategori ID'si
                                           }).ToList();
            return mstrList; // Müşteri listesini döndür
        }     
        
        List<SelectListItem> urunFunk()
        {
            // Aktif kategorileri listele
            List<SelectListItem> urnList = (from urn in _db.Tblurunlers.ToList()
                                           select new SelectListItem
                                           {
                                               Text = urn.URUNAD, // Kategori adı
                                               Value = urn.URUNID.ToString() // Kategori ID'si
                                           }).ToList();
            return urnList; // Müşteri listesini döndür
        }


        public IActionResult Index()
        {
            ViewBag.v1 = musteriFunk(); // Müşteri listesini ViewBag'e ata  
            ViewBag.v2 = urunFunk(); // Ürün listesini ViewBag'e ata
            return View();
        }


        [HttpPost]
        public IActionResult YeniSatis(Tblsatislar satis)
        {
            _db.Tblsatislars.Add(satis);

            var urn = _db.Tblurunlers.Find(satis.URUN);

            urn.STOK = (byte?)(urn.STOK - satis.ADET); // Satış sonrası stok güncelleme

            _db.Update(urn);

            _db.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
