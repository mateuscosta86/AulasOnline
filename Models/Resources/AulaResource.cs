namespace AulasOnline.Models.Resources
{
    public class AulaResource
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int Duracao { get; set; }
        public MateriaResource Materia { get; set; }
        public DisciplinaResource Disciplina { get; set; }    
        public ProfessorResource Professor { get; set; }    
    }
}