
using SistemaEscolar.Contexts;
using SistemaEscolar.Models;
using Microsoft.AspNetCore.Mvc;

namespace SistemaEscolar.Controllers
{
    public class PresencaController : Controller
    {
        SistemaEscolarContext _context = new SistemaEscolarContext();

        public IActionResult Index()
        {
            var presencas = _context.Presencas.ToList();
            return View(presencas);
        }

        public IActionResult Create() {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Presenca presenca)
        {
            if (ModelState.IsValid)
            {
                _context.Presencas.Add(presenca);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(presenca);
        }

        public IActionResult Edit(int id)
        {
            var presenca = _context.Presencas.Find(id);
            return presenca == null ? NotFound() : View(presenca);
        }

        [HttpPost]
        public  IActionResult Edit(Presenca presenca)
        {
            if (ModelState.IsValid)
            {
                _context.Update(presenca);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(presenca);
        }

        public  IActionResult Delete(int id)
        {
            var presenca = _context.Presencas.Find(id);
            return presenca == null ? NotFound() : View(presenca);
        }

        [HttpPost, ActionName("Delete")]
        public  IActionResult DeleteConfirmed(int id)
        {
            var presenca = _context.Presencas.Find(id);
            if (presenca != null)
            {
                _context.Presencas.Remove(presenca);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
