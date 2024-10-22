using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoFundacaoCrianca.Models
{
    [Table("Entidades")]
    public class Entidade
    {
        [Display(Name = "ID: ")]
        public int id { get; set; }

        [Required(ErrorMessage = "Campo nome é obrigatório")]
        [StringLength(35)]
        [Display(Name = "Nome da entidade : ")]
        public string nomeEntidade { get; set; }

        [Required(ErrorMessage = "Campo Endereço é obrigatório")]
        [StringLength(50)]
        [Display(Name = "Endereço : ")]

        public string endereco { get; set; }

        [Required(ErrorMessage = "Campo Status Contrato é obrigatório")]

        [Display(Name = "Status do Contrato: ")]
        public int statusContrato { get; set; }


        [Display(Name = "Data de Inicio: ")]
        public DateTime DatadeInicio { get; set; }

        [Display(Name = "Data de Fim: ")]
        public DateTime DatadoFim { get; set; }


    }
}
