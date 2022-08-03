using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CursoEntityCore.Models
{
    [Table("Article")]
    public class Articulo
    {
        [Key]
        public int Articulo_Id { get; set; }

        [Column("Titulo")]
        [Required(ErrorMessage = "El título del artículo es obligatorio")]
        [MaxLength(50)]
        public string TituloArticulo { get; set; }
        [Required]
        [StringLength(500, ErrorMessage = "No puede tener más de 500 caracteres")]
        public string Descripcion { get; set; }

        [DataType(DataType.Date)]
        public string Fecha { get; set; }
        [Range(0.1, 0.5)]
        [DisplayFormat(ConvertEmptyStringToNull = true, NullDisplayText = "N/A")]
        public double Calificacion { get; set; }
        [NotMapped]
        public bool IsFake { get; set; }
    }
}
