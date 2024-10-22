using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoFundacaoCrianca.Models
{
    [Table("PerfisSociosEconomicos")]
    public class PerfilSocioEconomico
    {
        [Display(Name = "ID: ")]
        public int id { get; set; }

        public DadoFamilia dadofamilia { get; set; }
        [Display(Name = "dadofamilia: ")]
        public int dadofamiliaID { get; set; }

        [Required(ErrorMessage = "Campo Renda da Familia é obrigatório")]
        
        [Display(Name = "Renda da Familia : ")]
        public float rendafamilia { get; set; }


        [Required(ErrorMessage = "Campo situação da familia é obrigatório")]
        [StringLength(100)]
        public string situacaofamilia { get; set; }

        [Required(ErrorMessage = "Campo Profissão do pai é obrigatório")]
        [StringLength(35)]
        [Display(Name = "Profissao do Pai: ")]
        public string profissaoPai { get; set; }

        [Required(ErrorMessage = "Campo Profissão da Mãe é obrigatório")]
        [StringLength(35)]
        [Display(Name = "Profissao da Mãe: ")]
        public string profissaoMae { get; set; }





    }
}
