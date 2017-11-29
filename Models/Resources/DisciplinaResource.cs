using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace AulasOnline.Models.Resources
{
    public class DisciplinaResource : KeyValuePairResource
    {        
        public ICollection<AulaKeyValuePairResource> Aulas { get; set; }
    
        public DisciplinaResource()
        {
            Aulas = new Collection<AulaKeyValuePairResource>();
        }
    }
}