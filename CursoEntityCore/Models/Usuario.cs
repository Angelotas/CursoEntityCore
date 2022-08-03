using System.ComponentModel.DataAnnotations;

namespace CursoEntityCore.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        [EmailAddress(ErrorMessage = "Introduzca un email válido")]
        //[RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "Introduzca un email válido")]
        public string Email { get; set; }
    }
}
