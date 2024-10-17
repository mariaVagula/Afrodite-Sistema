using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Afrodite_Sistema.Migrations
{
    /// <inheritdoc />
    public partial class CamposAgendamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ObservacaoAgendamentoId",
                table: "Agendamento",
                newName: "ObservacaoAgendamento");

            migrationBuilder.RenameColumn(
                name: "DataHoraAgendamentoId",
                table: "Agendamento",
                newName: "DataHoraAgendamento");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ObservacaoAgendamento",
                table: "Agendamento",
                newName: "ObservacaoAgendamentoId");

            migrationBuilder.RenameColumn(
                name: "DataHoraAgendamento",
                table: "Agendamento",
                newName: "DataHoraAgendamentoId");
        }
    }
}
