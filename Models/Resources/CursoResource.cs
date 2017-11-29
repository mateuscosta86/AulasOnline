using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace AulasOnline.Models.Resources
{
    public class CursoResource : KeyValuePairResource
    {       
        public DateTime DataCriacao { get; set; }
        public decimal Preco { get; set; }

        public ICollection<AulaKeyValuePairResource> Aulas { get; set; }

        public CursoResource()
        {
            this.Aulas = new Collection<AulaKeyValuePairResource>();
        }
    }
}