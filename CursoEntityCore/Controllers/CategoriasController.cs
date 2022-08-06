using CursoEntityCore.Datos;
using CursoEntityCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace CursoEntityCore.Controllers
{
    public class CategoriasController : Controller
    {
        public readonly ApplicationDbContext _context;
        public CategoriasController(ApplicationDbContext contexto)
        {
            _context = contexto;
        }
        public IActionResult Index()
        {
            List<Categoria> listaCategorias = _context.Categoria.ToList();
            return View(listaCategorias);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                _context.Categoria.Add(categoria);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(); 
        }

        [HttpGet]
        public IActionResult CrearMultipleOption2()
        {
            List<Categoria> categorias = new List<Categoria>();
            for (int i = 0; i < 2; i++)
            {
                categorias.Add(new Categoria { Name = Guid.NewGuid().ToString() });
                // _context.Categoria.Add(new Categoria { Name = Guid.NewGuid().ToString() });
            }
            _context.Categoria.AddRange(categorias);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult CrearMultipleOption5()
        {
            List<Categoria> categorias = new List<Categoria>();
            for (int i = 0; i < 5; i++)
            {
                categorias.Add(new Categoria { Name = Guid.NewGuid().ToString() });
                // _context.Categoria.Add(new Categoria { Name = Guid.NewGuid().ToString() });
            }
            _context.Categoria.AddRange(categorias);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult CrearMultiplesCategorias()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CrearMultipleOpcionFormulario()
        {
            string categoriasForm = Request.Form["Name"];
            var listaCategorias = from val in categoriasForm.Split(new[] {","}, StringSplitOptions.RemoveEmptyEntries) select val;

            List<Categoria> categorias = new List<Categoria>();
            foreach (var c in listaCategorias)
            {
                categorias.Add(new Categoria { Name = c });
            }
            _context.Categoria.AddRange(categorias);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id == null)
            {
                return View();
            }
            var categoria = _context.Categoria.FirstOrDefault(c => c.Id == id);
            return View(categoria);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Categoria categoria)
        {
            //if (ModelState.IsValid)
            //{
            //    _context.Categoria.Update(categoria);
            //    _context.SaveChanges();
            //    return RedirectToAction(nameof(Index));
            //}
            //return View(categoria);
            string categoriaName = Request.Form["Name"];
            int categoriaId = int.Parse(Request.Form["Id"]);

            if (categoriaId != null && !string.IsNullOrEmpty(categoriaName))
            {
                var categoriaToEdit = _context.Categoria.FirstOrDefault(c => c.Id == categoriaId);
                categoriaToEdit.Name = categoriaName;
            }
            else
            {
                return View(categoria);
            }
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
