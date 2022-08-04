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
    }
}
