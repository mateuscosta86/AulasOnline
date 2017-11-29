using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace AulasOnline.Models.Resources
{
    public class CursoResource
    {
        public int Id { get; set; }        
        public string Nome { get; set; }
        public DateTime DataCriacao { get; set; }
        public decimal Preco { get; set; }

        public ICollection<AulaResource> Aulas { get; set; }

        public CursoResource()
        {
            this.Aulas = new Collection<AulaResource>();
        }
    }
}