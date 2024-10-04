using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Afrodite_Sistema.Models
{
    [Table("FormaPagamento")]
    public class FormaPagamento
    {
        [Column("FormaPagamentoId")]
        [Display(Name = "Código da Forma do Pagamento")]
        public int FormaPagamentoId { get; set; }

        [Column("NomeFormaPagamento")]
        [Display(Name = "Nome da Forma do Pagamento")]
        public string NomeFormaPagamento { get; set; } = string.Empty;
    }
}
