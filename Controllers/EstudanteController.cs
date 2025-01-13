using Microsoft.AspNetCore.Mvc;
using IELStudentManager.Data;
using IELStudentManager.Models;

namespace IELStudentManager.Controllers
{
    public class EstudanteController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EstudanteController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var estudantes = _context.Estudantes.ToList();
            return View(estudantes);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Estudante estudante)
        {
            if (ModelState.IsValid)
            {
                _context.Estudantes.Add(estudante);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(estudante);
        }
    }
}
