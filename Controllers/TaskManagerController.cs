using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using prueba_mvc.Data;
using prueba_mvc.Models.Entities;
using System.Formats.Tar;

namespace prueba_mvc.Controllers
{
    public class TaskManagerController : Controller

    {
        private readonly Taskflowcontextcs _context;

        public TaskManagerController(Taskflowcontextcs context)
        {
            _context = context;
        }


        public IActionResult Index()
        {   //aqui va el nombre del db set
            var ListaTareas = _context.tasks.ToList();
            return View(ListaTareas);
        }
        // devuelve la vista vacia
        public IActionResult Crear()
        {
            return View();

        }
        [HttpPost]
        public IActionResult Crear(TaskItem model)
        {
            if (ModelState.IsValid)
            {
                _context.tasks.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(model);


        }
        public IActionResult Editar(int id)
        {
            var Task = _context.tasks.Find(id);
            if (Task == null) return NotFound();
            return View(Task); // devolver la entidad del dbset

        }
      
        public IActionResult Editar(TaskItem model)
        {
            if (ModelState.IsValid)
            {
                _context.tasks.Update(model);// recibe el modelo
                _context.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(model);


        }
        [HttpPost]
        public IActionResult Eliminar(int id)
        {
            var tareas = _context.tasks.Find(id);

            if (tareas != null)
            {
                _context.tasks.Remove(tareas);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");



        }



    }


}
