using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace AulasOnline.Models
{
    public class Disciplina
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public ICollection<Aula> Aulas { get; set; }
    
        public Disciplina()
        {
            Aulas = new Collection<Aula>();
        }

    }
}