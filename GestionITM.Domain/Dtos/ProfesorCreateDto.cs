using System.ComponentModel.DataAnnotations;

namespace GestionITM.Domain.Dtos
{
    // DTO para inserción de nuevos profesores
    public class ProfesorCreateDto
    {
        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; } = string.Empty;

        public string Especialidad { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
    }
}
