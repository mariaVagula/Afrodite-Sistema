using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Afrodite_Sistema.Models
{
    [Table("Clube")]
    public class Clube
    {
        [Column("ClubeId")]
        [Display(Name = "Código do Clube")]
        public int ClubeId { get; set; }

        [Column("NomeClube")]
        [Display(Name = "Nome do Clube")]
        public string NomeClube { get; set; } = string.Empty;

        [ForeignKey("TipoClubeId")]
        [Display(Name = "Código do Tipo do Clube")]
        public int TipoClubeId { get; set; }
        public TipoClube? TipoClube { get; set; }

        [ForeignKey("TipoPlanoId")]
        [Display(Name = "Código do Tipo do Plano")]
        public int TipoPlanoId { get; set; }
        public TipoPlano? TipoPlano { get; set; }

        [Column("DetalhesClube")]
        [Display(Name = "Detalhes do Clube")]
        public string DetalhesClube { get; set; } = string.Empty;

        [Column("ValorClube")]
        [Display(Name = "Valor do Clube")]
        public int ValorClube { get; set; }

    }
}
