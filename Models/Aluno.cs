using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoFundacaoCrianca.Models
{
    public enum Genero {Masculino, Feminino}
    public enum Escolaridade {Fundamental, Medio}
    [Table("Alunos")]
    public class Aluno
    {

        [Display(Name = "ID: ")]
        public int id { get; set; }

        public DadoFamilia dadofamilia { get; set; }
        [Display(Name = "Dados da Familia: ")]
        public int dadofamiliaID { get; set; }

        [Required(ErrorMessage = "Campo nome é obrigatório")]
        [StringLength(35)]
        [Display(Name = "Nome: ")]
        public string nome { get; set; }

        [Required(ErrorMessage = "Campo CPF é obrigatório")]
        [StringLength(35)]
        [Display(Name = "Cpf: ")]
        public long cpf { get; set; }


        [Required(ErrorMessage = "Campo Genero é obrigatório")]
        
        [Display(Name = "Genero: ")]
        public Genero genero{ get; set; }

        [Required(ErrorMessage = "Campo Escolaridade é obrigatório")]
        [StringLength(35)]
        [Display(Name = "Escolaridade: ")]
        public Escolaridade escolaridade { get; set; }


        [Display(Name = "Data de Nascimento: ")]
        public DateOnly DatadeNascimento { get; set; }




        [Required(ErrorMessage = "Campo E-mail é obrigatório")]
        [StringLength(35)]
        [Display(Name = "E-mail: ")]
        public string email { get; set; }




    }
}
