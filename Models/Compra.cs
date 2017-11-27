using System.ComponentModel.DataAnnotations.Schema;

namespace AulasOnline.Models
{
    [Table("Compras")]
    public class Compra
    {
        public Aluno Aluno { get; set; }
        public int AlunoId { get; set; }

        public Curso Curso { get; set; }
        public int CursoId { get; set; }
        
    }
}