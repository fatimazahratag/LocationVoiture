using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LocationVoiture.Data;
using LocationVoiture.Models;
using System.Linq;

namespace LocationVoiture.Controllers
{
    public class VoituresController : Controller
    {
        private readonly ApplicationDbContext db;
        public VoituresController(ApplicationDbContext _db) => db = _db;

        public IActionResult Index()
        {
            var voitures = db.Voitures
                             .Include(v => v.Marque)
                             .ToList();
            return View(voitures);
        }

        public IActionResult Add()
        {
            ViewBag.Marques = db.Marques.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Voiture voiture)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Marques = db.Marques.ToList();
                return View(voiture);
            }

            db.Voitures.Add(voiture);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var voiture = db.Voitures
                            .Include(v => v.Marque)
                            .FirstOrDefault(v => v.Id == id);
            if (voiture == null)
                return NotFound();

            return View(voiture);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Voiture voiture)
        {
            ModelState.Remove(nameof(voiture.Marque));

            if (!ModelState.IsValid)
            {
                voiture.Marque = db.Marques.Find(voiture.MarqueId);
                return View(voiture);
            }

            db.Voitures.Update(voiture);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var voiture = db.Voitures.Find(id);
            if (voiture != null)
            {
                db.Voitures.Remove(voiture);
                db.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
