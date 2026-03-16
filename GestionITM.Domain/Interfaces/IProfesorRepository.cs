using GestionITM.Domain.Entities;

namespace GestionITM.Domain.Interfaces
{
    public interface IProfesorRepository
    {
        // Definimos las operaciones asíncronas (Tasks) para manejar profesores
        Task<IEnumerable<Profesor>> ObtenerTodosAsync(); // Obtener todos los profesores
        Task AgregarAsync(Profesor profesor); // Agregar un nuevo profesor
        Task<bool> ExisteEmailAsync(string email); // Bonus Nivel 5: Validar email único
    }
}
