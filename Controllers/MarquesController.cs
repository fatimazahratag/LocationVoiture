using Microsoft.AspNetCore.Mvc;
using LocationVoiture.Models;
using LocationVoiture.ViewModels;
using LocationVoiture.Data;

namespace LocationVoiture.Controllers
{
    public class MarquesController : Controller
    {
        private readonly ApplicationDbContext db;

        public MarquesController(ApplicationDbContext context)
        {
            db = context;
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(MarqueAddVM vm)
        {
            if (ModelState.IsValid)
            {
                Marque marque = new Marque { Libelle = vm.Libelle };
                db.Marques.Add(marque);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vm);
        }

        public IActionResult Index()
        {
            List<Marque> marques = db.Marques.ToList();
            return View(marques);
        }

        public IActionResult Edit(int id)
        {
            var marque = db.Marques.Find(id);
            if (marque == null) return NotFound();

            var vm = new MarqueAddVM { Libelle = marque.Libelle };
            ViewBag.Id = id;
            return View(vm);
        }

        [HttpPost]
        public IActionResult Edit(int id, MarqueAddVM vm)
        {
            if (ModelState.IsValid)
            {
                var marque = db.Marques.Find(id);
                if (marque == null) return NotFound();

                marque.Libelle = vm.Libelle;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id = id;
            return View(vm);
        }

        public IActionResult Delete(int id)
        {
            var marque = db.Marques.Find(id);
            if (marque == null) return NotFound();

            db.Marques.Remove(marque);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
