using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Afrodite_Sistema.Models
{
    [Table("Profissional")]
    public class Profissional
    {
        [Column("ProfissionalId")]
        [Display(Name = "Código do Profissional")]
        public int ProfissionalId { get; set; }

        [Column("NomeProfissional")]
        [Display(Name = "Nome do Profissional")]
        public string NomeProfissional { get; set; } = string.Empty;

        [Column("FotoProfissional")]
        [Display(Name = "Foto do Profissional" ) ]

        public string FotoProfissional { get; set; } = string.Empty;

        [ForeignKey("TipoProfissionalId")]
        [Display(Name = "Código do Tipo Profissional")]
        public int TipoProfissionalId { get; set; }
        public TipoProfissional? TipoProfissional { get; set; }
    }
}
