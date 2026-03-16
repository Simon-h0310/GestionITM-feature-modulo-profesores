using GestionITM.Domain.Entities;
using GestionITM.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GestionITM.Infrastructure.Repositories
{
    public class ProfesorRepository : IProfesorRepository
    {
        private readonly ApplicationDbContext _context;

        // Inyectamos el DbContext aquí para acceder a la base de datos
        public ProfesorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Profesor>> ObtenerTodosAsync()
        {
            // Usamos ToListAsync para obtener todos los profesores de la base de datos
            return await _context.Profesores.ToListAsync();
        }

        public async Task AgregarAsync(Profesor profesor)
        {
            // Agregamos el nuevo profesor al DbSet y guardamos los cambios en la base de datos
            await _context.Profesores.AddAsync(profesor);
            await _context.SaveChangesAsync(); // Persiste los cambios en SQL
        }

        // Bonus Nivel 5: Validar que el email sea único antes de insertar
        public async Task<bool> ExisteEmailAsync(string email)
        {
            return await _context.Profesores.AnyAsync(p => p.Email == email);
        }
    }
}
