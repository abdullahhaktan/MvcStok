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
        public IActionResult YeniMusteri(Tblmusteriler ktgr)
        {
            _mvcDbStokContext.Tblmusterilers.Add(ktgr);
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
            var cstmr = _mvcDbStokContext.Tblmusterilers.Find(mstr.Musteriid);

            cstmr.Musteriad = mstr.Musteriad;

            cstmr.Musterisoyad = mstr.Musterisoyad;

            _mvcDbStokContext.Tblmusterilers.Update(cstmr);

            _mvcDbStokContext.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
