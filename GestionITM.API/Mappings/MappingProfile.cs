using AutoMapper;
using GestionITM.Domain.Dtos;
using GestionITM.Domain.Entities;

namespace GestionITM.API.Mappings
{
    // Configura los mapeos entre entidades y DTOs
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Mapeos de Estudiante
            CreateMap<Estudiante, EstudianteDto>();
            CreateMap<EstudianteCreateDto, Estudiante>();

            // Mapeos de Profesor (sin asignaciones manuales - Nivel 5)
            CreateMap<Profesor, ProfesorDto>();
            CreateMap<ProfesorCreateDto, Profesor>();
        }
    }
}
