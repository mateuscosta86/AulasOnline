using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AulasOnline.Models
{
    [Table("Cursos")]
    public class Curso
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Nome { get; set; }
        public DateTime DataCriacao { get; set; }
        public decimal Preco { get; set; }

        public ICollection<Aula> Aulas { get; set; }

        public Curso()
        {
            this.Aulas = new Collection<Aula>();
        }
    }
}