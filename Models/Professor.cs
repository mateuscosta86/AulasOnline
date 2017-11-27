using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace AulasOnline.Models
{
    public class Professor
    {
        
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Nome { get; set; }
        [Required]
        [StringLength(255)]
        public string Sobrenome { get; set; }

        public ICollection<Aula> Aulas { get; set; }

        public Professor()
        {
            this.Aulas = new Collection<Aula>();
        }
    }
}