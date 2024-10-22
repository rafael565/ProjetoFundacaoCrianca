using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoFundacaoCrianca.Models
{
    [Table("Professores")]
    public class Professor
    {
        [Display(Name = "ID: ")]
        public int id { get; set; }

        [Required(ErrorMessage = "Campo nome é obrigatório")]
        [StringLength(35)]
        [Display(Name = "Nome: ")]
        public string nome { get; set; }


        [Required(ErrorMessage = "Campo email é obrigatório")]
        [StringLength(50)]
        [Display(Name = "email : ")]
        public string email { get; set; }

        [Required(ErrorMessage = "Campo Telefone é obrigatório")]
        [StringLength(35)]
        [Display(Name = "telefone : ")]
        public string telefone { get; set; }

        [Required(ErrorMessage = "Campo Especialização é obrigatório")]
        [StringLength(50)]
        [Display(Name = "Especialização do Professor : ")]
        public string especializacao { get; set; }









    }
}
