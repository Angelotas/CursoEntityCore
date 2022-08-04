namespace CursoEntityCore.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Articulo> Articulos { get; set; }

    }
}
