namespace GestionITM.Domain.Dtos
{
    // DTO para lectura - No incluye FechaContratacion
    public class ProfesorDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Especialidad { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
