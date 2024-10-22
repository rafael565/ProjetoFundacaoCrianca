using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoFundacaoCrianca.Models
{
    [Table("Matriculas")]
    public class Matricula
    {
        [Display(Name = "ID: ")]
        public int id { get; set; }

        public Turma turma { get; set; }
        [Display(Name = "Turma: ")]
        public int turmaID { get; set; }

        public Aluno aluno { get; set; }
        [Display(Name = "Aluno: ")]
        public int alunoID { get; set; }

        [Display(Name = "Data da Matricula : ")]
        public DateTime DataMatricula { get; set; }

        [Required(ErrorMessage = "Campo Status da Matricula é obrigatório")]

        [Display(Name = "Status da matricula: ")]
        public int statusMatricula { get; set; }



    }
}
