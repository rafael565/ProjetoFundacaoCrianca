using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoFundacaoCrianca.Models
{
    [Table("DadosFamilias")]
    public class DadoFamilia
    {
        [Display(Name = "ID: ")]
        public int id { get; set; }

        [Required(ErrorMessage = "Campo nome da mãe é obrigatório")]
        [StringLength(35)]
        [Display(Name = "Nome Mãe: ")]
        public string nomeMae { get; set; }

        [Display(Name = "Data de Nascimento Mãe: ")]
        public DateTime DatadeNascimentoMae { get; set; }

        [Required(ErrorMessage = "Campo Telefone da mae é obrigatório")]
        [StringLength(35)]
        [Display(Name = "telefone da Mãe: ")]
        public string telefoneMae { get; set; }


        [Required(ErrorMessage = "Campo nome do pai é obrigatório")]
        [StringLength(35)]
        [Display(Name = "Nome Pai: ")]
        public string nomePai { get; set; }

        [Display(Name = "Data de Nascimento Pai: ")]
        public DateTime DatadeNascimentoPai { get; set; }

        [Required(ErrorMessage = "Campo Telefone da pai é obrigatório")]
        [StringLength(35)]
        [Display(Name = "telefone do Pai : ")]
        public string telefonePai { get; set; }


        [Required(ErrorMessage = "Campo Historio Familiar é obrigatório")]
        [StringLength(50)]
        [Display(Name = "Historico Familiar : ")]

        public string HistoricoFamiliar { get; set; }

         [Required(ErrorMessage = "Campo Endereço é obrigatório")]
        [StringLength(50)]
        [Display(Name = "Endereço : ")]

        public string endereco { get; set; }

        [Required(ErrorMessage = "Campo cidade é obrigatório")]
        [StringLength(50)]
        [Display(Name = "cidade : ")]
        public string cidade { get; set; }

        [Required(ErrorMessage = "Campo email é obrigatório")]
        [StringLength(50)]
        [Display(Name = "email : ")]
        public string email { get; set; }





    }
}
