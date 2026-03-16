using GestionITM.Domain.Dtos;

namespace GestionITM.Domain.Interfaces
{
    public interface IProfesorService
    {
        Task<IEnumerable<ProfesorDto>> ObtenerTodosLosProfesoresAsync();
        Task<bool> RegistrarProfesorAsync(ProfesorCreateDto profesorDto);
    }
}
