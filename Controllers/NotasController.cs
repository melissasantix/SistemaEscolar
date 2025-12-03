
using SistemaEscolar.Contexts;
using SistemaEscolar.Models;
using Microsoft.AspNetCore.Mvc;

namespace SistemaEscolar.Controllers
{
    public class NotasController : Controller
    {
        SistemaEscolarContext _context = new SistemaEscolarContext();

        public IActionResult Index()
        {
            var notas = _context.Nota.ToList();
            return View(notas);
        }

        [HttpPost]
        public IActionResult Create(Nota nota)
        {
            if (ModelState.IsValid)
            {
                _context.Nota.Add(nota);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nota);
        }

        public IActionResult Edit(int id)
        {
            var nota = _context.Nota.Find(id);
            return nota == null ? NotFound() : View(nota);
        }

        [HttpPost]
        public IActionResult Edit(Nota nota)
        {
            if (ModelState.IsValid)
            {
                _context.Update(nota);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nota);
        }

        public IActionResult Delete(int id)
        {
            var nota = _context.Nota.Find(id);
            return nota == null ? NotFound() : View(nota);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var nota = _context.Nota.Find(id);
            if (nota != null)
            {
                _context.Nota.Remove(nota);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
