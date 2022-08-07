using CursoEntityCore.Datos;
using CursoEntityCore.Models;
using CursoEntityCore.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CursoEntityCore.Controllers
{
    public class ArticulosController : Controller
    {
        public readonly ApplicationDbContext _context;
        public ArticulosController(ApplicationDbContext contexto)
        {
            _context = contexto;
        }
        public IActionResult Index()
        {
            List<Articulo> listaArticulos = _context.Articulo.ToList();
            return View(listaArticulos); 
        }

        [HttpGet]
        public IActionResult Crear()
        {
            ArticuloCategoriaVM articuloCategorias = new ArticuloCategoriaVM();
            articuloCategorias.ListaCategorias = _context.Categoria.Select(c => new SelectListItem()
            {
                Text = c.Name,
                Value = c.Id.ToString()
            });
            return View(articuloCategorias);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(Articulo articulo)
        {
            if (ModelState.IsValid)
            {
                _context.Articulo.Add(articulo);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ArticuloCategoriaVM articuloCategorias = new ArticuloCategoriaVM();
            articuloCategorias.ListaCategorias = _context.Categoria.Select(c => new SelectListItem()
            {
                Text = c.Name,
                Value = c.Id.ToString()
            });
            return View(articuloCategorias);
        }
    }
}
