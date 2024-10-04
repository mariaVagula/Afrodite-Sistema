using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Afrodite_Sistema.Models
{
    [Table("TipoPlano")]
    public class TipoPlano
    {
        [Column("TipoPlanoId")]
        [Display(Name = "Código do Tipo Plano")]
        public int TipoPlanoId { get; set; }

        [Column("NomeTipoPlano")]
        [Display(Name = "Nome do Tipo do Plano")]
        public string NomeTipoPlano { get; set; } = string.Empty;
    }
}
