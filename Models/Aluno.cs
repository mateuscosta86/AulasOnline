using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace AulasOnline.Models
{
    public class Aluno
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Nome { get; set; }
        [Required]
        [StringLength(255)]
        public string Sobrenome { get; set; }
        [Required]
        [StringLength(11)]
        public string Cpf { get; set; }
        public bool Anual { get; set; }

        public ICollection<Compra> Compras { get; set; }

        public Aluno()
        {
            this.Compras = new Collection<Compra>();
        }        
    }
}