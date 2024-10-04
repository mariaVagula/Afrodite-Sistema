using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Afrodite_Sistema.Models
{
    [Table("TipoProcedimento")]
    public class TipoProcedimento
    {
        [Column("TipoProcedimentoId")]
        [Display(Name = "Código do Tipo do Procedimento")]
        public int TipoProcedimentoId { get; set; }

        [Column("NomeTipoProcedimento")]
        [Display(Name = "Nome do Tipo do Procedimento")]
        public string NomeTipoProcedimento { get; set; } = string.Empty;
    }
}
