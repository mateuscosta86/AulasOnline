using AulasOnline.Models;
using Microsoft.EntityFrameworkCore;

namespace AulasOnline.Persistence
{
    public class AulasOnlineDbContext : DbContext
    {

        public DbSet<Aula> Aulas { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Materia> Materias { get; set; }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<Compra> Compras { get; set; }

        public AulasOnlineDbContext(DbContextOptions<AulasOnlineDbContext> options)
        : base(options)
        {            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Compra>().HasKey(c => new { c.AlunoId, c.CursoId });
        }

        

    }
}