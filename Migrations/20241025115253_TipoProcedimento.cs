using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Afrodite_Sistema.Migrations
{
    /// <inheritdoc />
    public partial class TipoProcedimento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TipoProcedimentoId",
                table: "Procedimento",
                type: "int",
                nullable: false,
                defaultValue: 2);

            migrationBuilder.CreateIndex(
                name: "IX_Procedimento_TipoProcedimentoId",
                table: "Procedimento",
                column: "TipoProcedimentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Procedimento_TipoProcedimento_TipoProcedimentoId",
                table: "Procedimento",
                column: "TipoProcedimentoId",
                principalTable: "TipoProcedimento",
                principalColumn: "TipoProcedimentoId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Procedimento_TipoProcedimento_TipoProcedimentoId",
                table: "Procedimento");

            migrationBuilder.DropIndex(
                name: "IX_Procedimento_TipoProcedimentoId",
                table: "Procedimento");

            migrationBuilder.DropColumn(
                name: "TipoProcedimentoId",
                table: "Procedimento");
        }
    }
}
