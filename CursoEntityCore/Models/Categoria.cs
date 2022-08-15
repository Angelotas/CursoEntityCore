using System.ComponentModel.DataAnnotations;

namespace CursoEntityCore.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime FechaCreacion { get; set; }
        public bool Activo { get; set; }
        public ICollection<Articulo> Articulos { get; set; }

    }
}
