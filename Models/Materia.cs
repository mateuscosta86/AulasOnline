using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace AulasOnline.Models
{
    public class Materia
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Nome { get; set; }

        public ICollection<Aula> Aulas { get; set; }
    
        public Materia()
        {
            Aulas = new Collection<Aula>();
        }
    }
}