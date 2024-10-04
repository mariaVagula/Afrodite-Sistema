using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Afrodite_Sistema.Models
{
    [Table("PagamentoAgendamento")]
    public class PagamentoAgendamento
    {
        [Column("PagamentoAgendamentoId")]
        [Display(Name = "Código do Pagamento do Agendamento")]
        public int PagamentoAgendamentoId { get; set; }

        [ForeignKey("AgendamentoId")]
        [Display(Name = "Código do Agendamento")]
        public int AgendamentoId { get; set; }
        public Agendamento? Agendamento { get; set; }

        [ForeignKey("FormaPagamentoId")]
        [Display(Name = "Código da Forma do Pagamento")]
        public int FormaPagamentoId { get; set; }
        public FormaPagamento? FormaPagamento { get; set; }
    }
}
