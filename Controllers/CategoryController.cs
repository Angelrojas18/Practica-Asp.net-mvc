using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using prueba_mvc.Data;
using prueba_mvc.Models.Entities;

namespace prueba_mvc.Controllers
{
    public class CategoryController : Controller
    {

        private readonly Taskflowcontextcs _context;

        public CategoryController(Taskflowcontextcs context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var ListaCategories = _context.categories.ToList();
            return View(ListaCategories);
        }

        [HttpPost]
        public IActionResult Crear(Category model)
        {
            if (ModelState.IsValid)
            {
                _context.categories.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(model);


        }
        [HttpGet]
        public IActionResult Editar(int id)
        {
            var category = _context.categories.Find(id);
            if (category == null) return NotFound();
            return View(category); // devolver la entidad del dbset

        }
        [HttpPost]
        public IActionResult Editar(Category model)
        {
            if (ModelState.IsValid)
            {
                _context.categories.Update(model);// recibe el modelo
                _context.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Eliminar(int id)
        {
            var Category = _context.categories.Find(id);

            if (Category != null)
            {
                _context.categories.Remove(Category);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");



        }
    }
}
