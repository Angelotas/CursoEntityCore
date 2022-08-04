namespace CursoEntityCore.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Articulo> Articulos { get; set; }

    }
}
