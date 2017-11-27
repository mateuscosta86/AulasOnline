using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace AulasOnline.Models
{
    public class Aula
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(255)]
        public string Titulo { get; set; }

        public int Duracao { get; set; }

        public Materia Materia { get; set; }
        public int MateriaId { get; set; }

        public Disciplina Disciplina { get; set; }
        public int DisciplinaId { get; set; }

        public Curso Curso { get; set; }
        public int CursoId { get; set; }

        public Professor Professor { get; set; }
        public int ProfessorId { get; set; }
        
    }
}