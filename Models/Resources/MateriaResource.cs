using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace AulasOnline.Models.Resources
{
    public class MateriaResource
    {
        public int Id { get; set; }
        
        public string Nome { get; set; }

        public ICollection<AulaResource> Aulas { get; set; }
    
        public MateriaResource()
        {
            Aulas = new Collection<AulaResource>();
        }
    }
}