using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Afrodite_Sistema.Models
{
    [Table("AssinaturaClube")]
    public class AssinaturaClube
    {
        [Column("AssinaturaClubeId")]
        [Display(Name = "Código da Assinatura do Clube")]
        public int AssinaturaClubeId { get; set; }

        [ForeignKey("ClienteId")]
        [Display(Name = "Código do Cliente")]
        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; }

        [ForeignKey("ClubeId")]
        [Display(Name = "Código do Clube")]
        public int ClubeId { get; set; }
        public Clube? Clube { get; set; }
    }
}
