using Microsoft.AspNetCore.Mvc;
using MvcStok.Models.Entity;
using X.PagedList.Extensions;

namespace MvcStok.Controllers
{
    public class MusteriController : Controller
    {

        private readonly MvcDbStokContext _mvcDbStokContext;
        public MusteriController(MvcDbStokContext mvcDbStokContext)
        {
            _mvcDbStokContext = mvcDbStokContext;
        }

        public IActionResult Index(string arama, int sayfa = 1)
        {
            if (!string.IsNullOrEmpty(arama))
            {
                var degerler = _mvcDbStokContext.Tblmusterilers
                .Where(m => m.MUSTERIAD.Contains(arama) || m.MUSTERISOYAD.Contains(arama)) // Filtreleme
                .OrderBy(m => m.MUSTERIID) // Sıralama
                .ToPagedList(sayfa, 5); // Sayfalama

                return View(degerler);
            }
            else
            {
               var degerler = _mvcDbStokContext.Tblmusterilers.OrderBy(m => m.MUSTERIID).ToPagedList(sayfa, 5);
                return View(degerler);
            }

        }

        [HttpGet]
        public IActionResult YeniMusteri()
        {
            return View();
        }

        [HttpPost]
        public IActionResult YeniMusteri(Tblmusteriler mstr)
        {
            if (!ModelState.IsValid)
            {
                return View(mstr); // Validation başarısızsa formu tekrar göster
            }

            _mvcDbStokContext.Tblmusterilers.Add(mstr);
            _mvcDbStokContext.SaveChanges();

            TempData["SuccessMessage"] = "Kategori Basariyla eklendi";

            return RedirectToAction("Index");
        }

        public IActionResult MusteriSil(int id)
        {
            var ktgr = _mvcDbStokContext.Tblmusterilers.Find(id);
            _mvcDbStokContext.Tblmusterilers.Remove(ktgr);
            _mvcDbStokContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult MusteriGuncelle(int id)
        {
            var ktgr = _mvcDbStokContext.Tblmusterilers.Find(id);
            return View(ktgr);
        }

        [HttpPost]
        public IActionResult MusteriGuncelle(Tblmusteriler mstr)
        {
            if (!ModelState.IsValid)
            {
                return View(mstr); // Validation başarısızsa formu tekrar göster
            }

            var cstmr = _mvcDbStokContext.Tblmusterilers.Find(mstr.MUSTERIID);
            cstmr.MUSTERIAD = mstr.MUSTERIAD;
            cstmr.MUSTERISOYAD = mstr.MUSTERISOYAD;
            _mvcDbStokContext.Tblmusterilers.Update(cstmr);
            _mvcDbStokContext.SaveChanges();

            TempData["SuccessMessage"] = "Kategori Basariyla Guncellendi";

            return RedirectToAction("Index");
        }

    }
}
