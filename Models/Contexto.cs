using Microsoft.EntityFrameworkCore;

namespace Afrodite_Sistema.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Clube> Clube { get; set; }
        public DbSet<TipoClube> TipoClube { get; set; }
        public DbSet<AssinaturaClube> AssinaturaClube { get; set; }
        public DbSet<Procedimento> Procedimento { get; set; }
        public DbSet<TipoProcedimento> TipoProcedimento { get; set; }
        public DbSet<Profissional> Profissional { get; set; }
        public DbSet<TipoProfissional> TipoProfissional { get; set; }
        public DbSet<FormaPagamento> FormaPagamento { get; set; }
        public DbSet<PagamentoAgendamento> PagamentoAgendamento { get; set; }
        public DbSet<PagamentoAssinatura> PagamentoAssinatura { get; set; }
        public DbSet<Agendamento> Agendamento { get; set; }
        public DbSet<TipoPlano> TipoPlano { get; set; }

    }
}
