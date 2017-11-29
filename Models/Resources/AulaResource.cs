namespace AulasOnline.Models.Resources
{
    public class AulaResource
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int Duracao { get; set; }
        public KeyValuePairResource Materia { get; set; }
        public KeyValuePairResource Disciplina { get; set; }    
        public ProfessorKeyValuesResource Professor { get; set; }
        public KeyValuePairResource Curso { get; set; }

    }
}