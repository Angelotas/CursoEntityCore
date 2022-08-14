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

        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id == null)
            {
                return View();
            }
            ArticuloCategoriaVM articuloCategorias = new ArticuloCategoriaVM();
            articuloCategorias.ListaCategorias = _context.Categoria.Select(c => new SelectListItem()
            {
                Text = c.Name,
                Value = c.Id.ToString()
            });

            articuloCategorias.Articulo = _context.Articulo.FirstOrDefault(c => c.Articulo_Id == id);
            if (articuloCategorias == null)
            {
                return NotFound();
            }
            return View(articuloCategorias);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(ArticuloCategoriaVM articuloVM)
        {
            if (articuloVM.Articulo.Articulo_Id == 0)
            {
                return View(articuloVM.Articulo);
            }
            else
            {
                _context.Articulo.Update(articuloVM.Articulo);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpGet]
        public IActionResult Borrar(int? id)
        {
            var articuloToRemove = _context.Articulo.FirstOrDefault(a => a.Articulo_Id == id);
            _context.Articulo.Remove(articuloToRemove);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
