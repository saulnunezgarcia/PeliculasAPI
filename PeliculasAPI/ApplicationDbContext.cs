using Microsoft.EntityFrameworkCore;
using PeliculasAPI.Entidades;

namespace PeliculasAPI
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Genero> Generos { get; set; } //El generos es el nombre de la tabla 
        public DbSet<Actor> Actores { get; set; } //Se crea la tabla actores despues de definir la entidad
    }
}
