namespace AulasOnline.Models.Resources
{
    public class SaveAulaResource
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int Duracao { get; set; }
        public int MateriaId { get; set; }
        public int DisciplinaId { get; set; }
        public int ProfessorId { get; set; }   
    }
}

// TODO: Mapping from Save to Domain