using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CursoEntityCore.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        [EmailAddress(ErrorMessage = "Introduzca un email válido")]
        //[RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "Introduzca un email válido")]
        public string Email { get; set; }

        public int? DetalleUsuarioId { get; set; }
        public DetalleUsuario DetalleUsuario { get; set; }
    }
}
