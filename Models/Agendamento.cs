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
        [Display(Name = "Procedimento")]
        public int ProcedimentoId { get; set; }
        public Procedimento? Procedimento { get; set; }

        [Column("DataHoraAgendamento")]
        [Display(Name = "Data e Hora do Agendamento")]
        public  DateTime DataHoraAgendamento { get; set; } 

        [ForeignKey("ProfissionalId")]
        [Display(Name = "Profissional")]
        public int ProfissionalId { get; set; }
        public Profissional? Profissional { get; set; }

        [Column("ObservacaoAgendamento")]
        [Display(Name = "Observação do Agendamento")]
        public string ObservacaoAgendamento { get; set; } = string.Empty;

        [ForeignKey("ClienteId")]
        [Display(Name = "Cliente")]
        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; }
    }
}
