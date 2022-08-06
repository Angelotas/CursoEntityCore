using System.ComponentModel.DataAnnotations;

namespace CursoEntityCore.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<Articulo> Articulos { get; set; }

    }
}
