using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Afrodite_Sistema.Models
{
    [Table("Cliente")]
    public class Cliente
    {

        [Column("ClienteId")]
        [Display(Name = "Código do Cliente")]
        public int ClienteId { get; set; }

        [Column("NomeCliente")]
        [Display(Name = "Nome do Cliente")]
        public string NomeCliente { get; set; } = string.Empty;

        [Column("DataNascimentoCliente")]
        [Display(Name = "Data de nascimento do cliente")]
        public DateTime DataNascimentoCliente { get; set; }


        [Column("SexoCliente")]
        [Display(Name = "Sexo do cliente")]
        public string SexoCliente { get; set; } = string.Empty;

        [Column("CpfCliente")]
        [Display(Name = "Cpf do Cliente")]
        public int CpfCliente { get; set; }

        [Column("TelCliente")]
        [Display(Name = "Telefone do Cliente")]
        public int TelCliente { get; set; }

        [Column("EmailCliente")]
        [Display(Name = "Email do Cliente")]
        public string EmailCliente { get; set; } = string.Empty;

        [Column("SenhaCliente")]
        [Display(Name = "Senha do Cliente")]
        public string SenhaCliente { get; set; } = string.Empty;


    }
}
