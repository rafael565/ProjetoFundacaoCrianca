using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoFundacaoCrianca.Models
{
    [Table("Alunos")]
    public class Aluno
    {

        [Display(Name = "ID: ")]
        public int id { get; set; }

        [Required(ErrorMessage = "Campo nome é obrigatório")]
        [StringLength(35)]
        [Display(Name = "Nome: ")]
        public string nome { get; set; }

        [Required(ErrorMessage = "Campo CPF é obrigatório")]
        [StringLength(35)]
        [Display(Name = "Cpf: ")]
        public string cpf { get; set; }

        [Required(ErrorMessage = "Campo Telefone é obrigatório")]
        [StringLength(35)]
        [Display(Name = "Telefone: ")]
        public string telefone { get; set; }



        [Display(Name = "Data de Nascimento: ")]
        public DateTime DatadeNascimento { get; set; }




    }
}
