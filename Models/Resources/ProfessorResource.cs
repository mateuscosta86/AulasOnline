using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace AulasOnline.Models.Resources
{
    public class ProfessorResource : ProfessorKeyValuesResource
    {        
        public ICollection<AulaKeyValuePairResource> Aulas { get; set; }

        public ProfessorResource()
        {
            this.Aulas = new Collection<AulaKeyValuePairResource>();
        }
    }
}