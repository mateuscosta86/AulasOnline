using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace AulasOnline.Models.Resources
{
    public class ProfessorResource
    {
        public int Id { get; set; }        
        public string Nome { get; set; }
        public string Sobrenome { get; set; }

        public ICollection<AulaResource> Aulas { get; set; }

        public ProfessorResource()
        {
            this.Aulas = new Collection<AulaResource>();
        }
    }
}