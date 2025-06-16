using Microsoft.AspNetCore.Mvc;
using MvcStok.Models.Entity;
using X.PagedList;
using X.PagedList.Extensions;

namespace MvcStok.Controllers
{
    public class KategoriController : Controller
    {

        private readonly MvcDbStokContext _mvcDbStokContext;
        public KategoriController(MvcDbStokContext mvcDbStokContext)
        {
            _mvcDbStokContext = mvcDbStokContext;
        }

        public IActionResult Index(string arama, int sayfa = 1)
        {
            var kategoriler = _mvcDbStokContext.Tblkategorilers
                .Where(k => k.KATEGORIDURUM == true);

            if (!string.IsNullOrEmpty(arama))
            {
                kategoriler = kategoriler.Where(k => k.KATEGORIAD.Contains(arama));
            }

            var model = kategoriler
                .OrderBy(k => k.KATEGORIID)
                .ToPagedList(sayfa, 5);

            return View(model);
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

            TempData["SuccessMessage"] = "Kategori Basariyla eklendi";


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

            TempData["SuccessMessage"] = "Kategori Basariyla Guncellendi";

            return RedirectToAction("Index");
        }

    }
}
