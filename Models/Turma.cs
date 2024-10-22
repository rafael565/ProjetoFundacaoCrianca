using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoFundacaoCrianca.Models
{
    [Table("Turmas")]
    public class Turma
    {
        [Display(Name = "ID: ")]
        public int id { get; set; }

        public Curso curso { get; set; }
        [Display(Name = "Curso: ")]
        public int cursoID { get; set; }

        [Required(ErrorMessage = "Campo nome da turma é obrigatório")]
        [StringLength(35)]
        [Display(Name = "Nome da turma: ")]
        public string nomeTurma{ get; set; }

        [Required(ErrorMessage = "Campo Serie/Ano é obrigatório")]
        
        [Display(Name = "Serie/Ano: ")]
        public int serie { get; set; }

        [Required(ErrorMessage = "Campo maximo aluno é obrigatório")]

        [Display(Name = "Maximo de alunos: ")]
        public int maximoAluno { get; set; }

        [Required(ErrorMessage = "Campo minimo aluno é obrigatório")]

        [Display(Name = "Minimo de alunos: ")]
        public int minimoAluno { get; set; }
    }
}
