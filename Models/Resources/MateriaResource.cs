using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace AulasOnline.Models.Resources
{
    public class MateriaResource : KeyValuePairResource
    {        
        public ICollection<AulaKeyValuePairResource> Aulas { get; set; }
    
        public MateriaResource()
        {
            Aulas = new Collection<AulaKeyValuePairResource>();
        }
    }
}