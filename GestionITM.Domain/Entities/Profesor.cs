using System.ComponentModel.DataAnnotations;

namespace GestionITM.Domain.Entities
{
    public class Profesor
    {
        // EF Core reconoce "Id" automáticamente como llave primaria
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; } = string.Empty;

        public string Especialidad { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        public DateTime FechaContratacion { get; set; } = DateTime.Now;
    }
}
