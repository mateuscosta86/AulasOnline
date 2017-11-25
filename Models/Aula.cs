using System.ComponentModel.DataAnnotations;

namespace AulasOnline.Models
{
    public class Aula
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Titulo { get; set; }
        public int Duracao { get; set; }

        public Materia Materia { get; set; }

        public int MateriaId { get; set; }
    }
}