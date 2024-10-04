using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Afrodite_Sistema.Models
{
    [Table("TipoProfissional")]
    public class TipoProfissional
    {
        [Column("TipoProfissionalId")]
        [Display(Name = "Código do Tipo do Profissional")]
        public int TipoProfissionalId { get; set; }

        [Column("NomeTipoProfissional")]
        [Display(Name = "Nome do Tipo do Profissional")]
        public string NomeTipoProfissional { get; set; } = string.Empty;
    }
}
