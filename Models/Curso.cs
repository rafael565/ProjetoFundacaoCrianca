using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoFundacaoCrianca.Models
{
    public enum Periodo { Manha, Tarde, Noite };
    [Table("Cursos")]
    public class Curso
    {
        [Display(Name = "ID: ")]
        public int id { get; set; }


        [Required(ErrorMessage = "Campo nome é obrigatório")]
        [StringLength(35)]
        [Display(Name = "Nome: ")]
        public string nome { get; set; }


        [Required(ErrorMessage = "Campo descrição é obrigatório")]
        [StringLength(35)]
        public string descricao { get; set; }

        [Display(Name = "Período: ")]
        public Periodo periodo { get; set; }


        [Display(Name = "Carga Horaria: ")]
        [Required(ErrorMessage = "Campo Carga Horaria é obrigatório...")]
        public string CargaHoraria { get; set; }

    }
}
