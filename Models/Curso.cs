using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace AulasOnline.Models
{
    public class Curso
    {
        public int Id { get; set; }
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