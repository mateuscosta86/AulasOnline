using System.ComponentModel.DataAnnotations;

namespace AulasOnline.Models.Resources
{
    public class SaveAlunoResource
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
    }
}