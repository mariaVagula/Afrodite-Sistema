using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Afrodite_Sistema.Models
{
    [Table("TipoClube")]
    public class TipoClube
    {
        [Column("TipoClubeId")]
        [Display(Name = "Código do Tipo do Clube")]
        public int TipoClubeId { get; set; }

        [Column("NomeTipoClube")]
        [Display(Name = "Nome do Tipo do Clube")]
        public string NomeTipoClube { get; set; } = string.Empty;

    }
}
