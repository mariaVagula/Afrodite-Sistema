using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Afrodite_Sistema.Migrations
{
    /// <inheritdoc />
    public partial class FotoClube : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FotoClube",
                table: "Clube",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FotoClube",
                table: "Clube");
        }
    }
}
