using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace AulasOnline.Models.Resources
{
    public class SaveMateriaResource
    {
        public int Id { get; set; }        
        public string Nome { get; set; }
        public ICollection<int> Aulas { get; set; }
    
        public SaveMateriaResource()
        {
            Aulas = new Collection<int>();
        }
    }
}