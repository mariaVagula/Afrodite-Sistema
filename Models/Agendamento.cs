using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Afrodite_Sistema.Models
{
    [Table("Agendamento")]
    public class Agendamento
    {
        [Column("AgendamentoId")]
        [Display(Name = "Código do Agendamento")]
        public int AgendamentoId { get; set; }

        [ForeignKey("ProcedimentoId")]
        [Display(Name = "Código do Procedimento")]
        public int ProcedimentoId { get; set; }
        public Procedimento? Procedimento { get; set; }

        [Column("DataHoraAgendamentoId")]
        [Display(Name = "Data e Hora")]
        public  DateTime DataHoraAgendamentoId { get; set; }

        [ForeignKey("ProfissionalId")]
        [Display(Name = "Código do Profissional")]
        public int ProfissionalId { get; set; }
        public Profissional? Profissional { get; set; }

        [Column("ObservacaoAgendamentoId")]
        [Display(Name = "Observação do Agendamento")]
        public string ObservacaoAgendamentoId { get; set; } = string.Empty;

        [ForeignKey("ClienteId")]
        [Display(Name = "Código do Cliente")]
        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; }
    }
}
