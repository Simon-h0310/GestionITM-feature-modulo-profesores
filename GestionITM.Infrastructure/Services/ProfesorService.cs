using AutoMapper;
using GestionITM.Domain.Dtos;
using GestionITM.Domain.Entities;
using GestionITM.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace GestionITM.Infrastructure.Services
{
    public class ProfesorService : IProfesorService
    {
        private readonly IProfesorRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<ProfesorService> _logger;

        public ProfesorService(IProfesorRepository repository, IMapper mapper, ILogger<ProfesorService> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<ProfesorDto>> ObtenerTodosLosProfesoresAsync()
        {
            var profesores = await _repository.ObtenerTodosAsync();
            return _mapper.Map<IEnumerable<ProfesorDto>>(profesores);
        }

        public async Task<bool> RegistrarProfesorAsync(ProfesorCreateDto profesorDto)
        {
            // Debug: Verificar qué se está recibiendo
            Console.WriteLine($"[v0] Registrando profesor: {profesorDto.Nombre}, Especialidad: {profesorDto.Especialidad}");

            // RETO DE ROBUSTEZ: Si el nombre es "Error", lanzamos una excepción
            // para probar que el Middleware de Excepciones funciona correctamente
            if (profesorDto.Nombre == "Error")
            {
                throw new Exception("Error de prueba");
            }

            // Regla de Negocio: Validar que la Especialidad no sea vacía
            if (string.IsNullOrWhiteSpace(profesorDto.Especialidad))
            {
                return false; // No se permite registrar sin especialidad
            }

            // Bonus Nivel 5: Validar que el Email sea único en la base de datos
            if (!string.IsNullOrWhiteSpace(profesorDto.Email) && await _repository.ExisteEmailAsync(profesorDto.Email))
            {
                return false; // El email ya existe, no se puede registrar
            }

            // Regla de Negocio: Si la especialidad es "Arquitectura", imprimir log
            Console.WriteLine($"[v0] Comparando especialidad: '{profesorDto.Especialidad}' == 'Arquitectura'");
            if (profesorDto.Especialidad == "Arquitectura")
            {
                Console.WriteLine("[v0] Perfil Senior Detectado");
                _logger.LogWarning("Perfil Senior Detectado");
            }

            // Usamos AutoMapper para convertir el DTO a entidad (sin asignaciones manuales)
            var profesor = _mapper.Map<Profesor>(profesorDto);
            profesor.FechaContratacion = DateTime.UtcNow; // Asignamos la fecha de contratación actual

            await _repository.AgregarAsync(profesor);
            return true; // Profesor registrado exitosamente
        }
    }
}
