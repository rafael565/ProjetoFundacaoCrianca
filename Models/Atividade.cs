using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoFundacaoCrianca.Models
{
    [Table("Atividades")]
    public class Atividade
    {
        [Display(Name = "ID: ")]
        public int id { get; set; }

        [Required(ErrorMessage = "Campo Descrição é obrigatório")]
        [StringLength(35)]
        [Display(Name = "Descrição: ")]
        public string descricao { get; set; }

        public Turma turma { get; set; }
        [Display(Name = "Turma: ")]
        public int turmaID { get; set; }

    }
}
