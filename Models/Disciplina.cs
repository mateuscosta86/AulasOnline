using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AulasOnline.Models
{
    [Table("Disciplinas")]
    public class Disciplina
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Nome { get; set; }

        public ICollection<Aula> Aulas { get; set; }
    
        public Disciplina()
        {
            Aulas = new Collection<Aula>();
        }

    }
}