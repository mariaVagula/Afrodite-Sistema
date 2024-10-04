using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Afrodite_Sistema.Models
{
    [Table("PagamentoAssinatura")]
    public class PagamentoAssinatura
    {
        [Column("PagamentoAssinaturaId")]
        [Display(Name = "Código do Pagamento da Assinatura")]
        public int PagamentoAssinaturaId { get; set; }

        [ForeignKey("AssinaturaClubeId")]
        [Display(Name = "Código da Assinatura do Clube")]
        public int AssinaturaClubeId { get; set; }
        public AssinaturaClube? AssinaturaClube { get; set; }

        [ForeignKey("FormaPagamentoId")]
        [Display(Name = "Código da Forma do Pagamento")]
        public int FormaPagamentoId { get; set; }
        public FormaPagamento? FormaPagamento { get; set; }
    }
}
