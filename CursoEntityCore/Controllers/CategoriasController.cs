using CursoEntityCore.Datos;
using CursoEntityCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            // Seleccionar columnas espefificas
            // var categorias=_contexto.Categoria.Where(n=>n.Nombre =="Test5").Select(n=>n).ToList();
            // List<Categoria>listaCategorias=_contexto.Categoria.ToList();

            // Agrupar
            //contexto.Categoria
            //.GroupBy(c => new { c.Activo })
            //.Select(c => new { c.Key, Count = c.Count() }).ToList();

            // Paginado
            // List<Categoria> listaCategorias = _context..Skip(2).Take(2).ToList();

            // Filtrado por activos y ordenado por fecha
            List<Categoria> listaCategorias = _context.Categoria
                .Where(c => c.Activo == true)
                .OrderBy(c => c.FechaCreacion)
                .ToList();
            return View(listaCategorias);

            // Similar al anterior pero con consultas convencionales
            //var listaCategorias = _context.Categoria.FromSqlRaw("SELECT * FROM Categoria WHERE Activo = 1").ToList();
            //return View(listaCategorias);

            // Consulta con interpolación
            //List<int> ids = new List<int>() { 26, 33 };
            //var listaCategorias = _context.Categoria.FromSqlRaw($"SELECT * FROM Categoria WHERE Id IN ({String.Join(",", ids)})").ToList();
            // const int ID = 26;
            // var listaCategorias = _context.Categoria.FromSqlRaw($"SELECT * FROM Categoria WHERE Id = {ID}").ToList();
            // return View(listaCategorias);
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
        public IActionResult BorrarMultiplesCategorias2()
        {
            List<Categoria> categorias = _context.Categoria.ToList();
            var categoriasToRemove = categorias.TakeLast(2);
            
            _context.Categoria.RemoveRange(categoriasToRemove);
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
        public IActionResult BorrarMultiplesCategorias5()
        {
            List<Categoria> categorias = _context.Categoria.ToList();
            var categoriasToRemove = categorias.TakeLast(5);

            _context.Categoria.RemoveRange(categoriasToRemove);
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
            if (ModelState.IsValid)
            {
                _context.Categoria.Update(categoria);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(categoria);
            //string categoriaName = Request.Form["Name"];
            //int categoriaId = int.Parse(Request.Form["Id"]);

            //if (categoriaId != null && !string.IsNullOrEmpty(categoriaName))
            //{
            //    var categoriaToEdit = _context.Categoria.FirstOrDefault(c => c.Id == categoriaId);
            //    categoriaToEdit.Name = categoriaName;
            //}
            //else
            //{
            //    return View(categoria);
            //}
            //_context.SaveChanges();
            //return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Borrar(int? id)
        {
            var categoriaToRemove = _context.Categoria.FirstOrDefault(a => a.Id == id);
            _context.Categoria.Remove(categoriaToRemove);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
