using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace AulasOnline.Models.Resources
{
    public class AlunoResource
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }        
        public string Cpf { get; set; }
        public bool Anual { get; set; }

        public ICollection<CursoResource> Compras { get; set; }

        public AlunoResource()
        {
            this.Compras = new Collection<CursoResource>();
        }
    }
}