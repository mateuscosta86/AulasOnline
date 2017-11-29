using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace AulasOnline.Models.Resources
{
    public class DisciplinaResource
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public ICollection<AulaResource> Aulas { get; set; }
    
        public DisciplinaResource()
        {
            Aulas = new Collection<AulaResource>();
        }
    }
}