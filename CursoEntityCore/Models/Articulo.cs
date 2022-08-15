using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CursoEntityCore.Models
{
    public class Articulo
    {
        public int Articulo_Id { get; set; }

        public string TituloArticulo { get; set; }
        public string Descripcion { get; set; }

        public string Fecha { get; set; }
        public double Calificacion { get; set; }
        public bool IsFake { get; set; }

        public int Categoria_Id { get; set; }
        public Categoria Categoria { get; set; }

        public ICollection<ArticuloEtiqueta> ArticuloEtiqueta { get; set; }
    }
}
