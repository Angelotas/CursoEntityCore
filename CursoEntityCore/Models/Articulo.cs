using System.ComponentModel.DataAnnotations.Schema;

namespace CursoEntityCore.Models
{
    [Table("Article")]
    public class Articulo
    {
        public int ArticuloId { get; set; }
        [Column("Titulo")]
        public string TituloArticulo { get; set; }
        public string Descripcion { get; set; }
        public string Fecha { get; set; }
    }
}
