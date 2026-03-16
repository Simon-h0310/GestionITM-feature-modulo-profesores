using Microsoft.AspNetCore.Mvc;
using GestionITM.Domain.Interfaces;
using GestionITM.Domain.Dtos;
using Microsoft.AspNetCore.Authorization;

namespace GestionITM.API.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class ProfesorController : ControllerBase
    {
        // Inyección de Dependencias: Solo inyectamos el Servicio, NO el Repositorio
        // Esto cumple con el indicador de Nivel 5: "El controlador es el mesero"
        private readonly IProfesorService _service;

        public ProfesorController(IProfesorService service)
        {
            _service = service;
        }

        // GET: api/profesor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProfesorDto>>> Get()
        {
            // El servicio ya nos devuelve los DTOs mapeados
            var profesoresDto = await _service.ObtenerTodosLosProfesoresAsync();
            return Ok(profesoresDto);
        }

        // POST: api/profesor
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProfesorCreateDto profesorCreateDto)
        {
            // El servicio valida las reglas de negocio y guarda
            var resultado = await _service.RegistrarProfesorAsync(profesorCreateDto);

            if (!resultado)
            {
                return BadRequest("No se pudo registrar. Verifique que la especialidad no esté vacía y que el email no exista ya en el sistema.");
            }

            return Ok(new { message = "Profesor registrado con éxito en el sistema del ITM." });
        }
    }
}
