using Microsoft.AspNetCore.Mvc;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class MusteriController : Controller
    {

        private readonly MvcDbStokContext _mvcDbStokContext;
        public MusteriController(MvcDbStokContext mvcDbStokContext)
        {
            _mvcDbStokContext = mvcDbStokContext;
        }

        public IActionResult Index()
        {
            var musteris = _mvcDbStokContext.Tblmusterilers.ToList();
            return View(musteris);
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
            return RedirectToAction("Index");
        }

    }
}
