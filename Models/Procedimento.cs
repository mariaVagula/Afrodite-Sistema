using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Afrodite_Sistema.Models
{
    [Table("Procedimento")]
    public class Procedimento
    {
        [Column("ProcedimentoId")]
        [Display(Name = "Código do Procedimento")]
        public int ProcedimentoId { get; set; }

        [Column("NomeProcedimento")]
        [Display(Name = "Nome do Procedimento")]
        public string NomeProcedimento { get; set; } = string.Empty;

        [Column("ValorProcedimento")]
        [Display(Name = "Valor do Procedimento")]
        public int ValorProcedimento { get; set; } 
    }
}
