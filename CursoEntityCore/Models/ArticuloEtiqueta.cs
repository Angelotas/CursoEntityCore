using System.ComponentModel.DataAnnotations.Schema;

namespace CursoEntityCore.Models
{
    public class ArticuloEtiqueta
    {
        // Recurrir a fluentApi para definir keys
        public int Articulo_Id { get; set; }
        public int EtiquetaId { get; set; }

        public Articulo Articulo { get; set; }
        public Etiqueta Etiqueta { get; set; }
    }
}
