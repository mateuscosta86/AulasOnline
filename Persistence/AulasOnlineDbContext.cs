using AulasOnline.Models;
using Microsoft.EntityFrameworkCore;

namespace AulasOnline.Persistence
{
    public class AulasOnlineDbContext : DbContext
    {
        public AulasOnlineDbContext(DbContextOptions<AulasOnlineDbContext> options)
        : base(options)
        {            
        }

        public DbSet<Aula> Aulas { get; set; }
        public DbSet<Materia> Materias { get; set; }
    }
}